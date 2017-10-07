using Simia.Entities;
using Simia.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Simia
{
    public partial class MainForm : Form
    {
        #region Constants

        // TODO - make this in a resource file mayhaps?
        private static readonly Dictionary<string, string> CITY_NAMES = new Dictionary<string, string>()
        {
            { "ARI", "Arizona" },
            { "ATL", "Atlanta" },
            { "BAL", "Baltimore" },
            { "BUF", "Buffalo" },
            { "CAR", "Carolina" },
            { "CHI", "Chicago" },
            { "CIN", "Cincinnati" },
            { "CLE", "Cleveland" },
            { "DAL", "Dallas" },
            { "DEN", "Denver" },
            { "DET", "Detroit" },
            { "GB", "Green Bay" },
            { "HOU", "Houston" },
            { "IND", "Indianapolis" },
            { "JAX", "Jacksonville" },
            { "KC", "Kansas City" },
            { "LA", "Los Angeles" },
            { "LAC", "Los Angeles" },
            { "MIA", "Miami" },
            { "MIN", "Minnesota" },
            { "NE", "New England" },
            { "NO", "New Orleans" },
            { "NYG", "New York" },
            { "NYJ", "New York" },
            { "OAK", "Oakland" },
            { "PHI", "Philadelphia" },
            { "PIT", "Pittsburgh" },
            { "SD", "San Diego" },
            { "SEA", "Seattle" },
            { "SF", "San Francisco" },
            { "STL", "St. Louis" },
            { "TB", "Tampa Bay" },
            { "TEN", "Tennessee" },
            { "WAS", "Washington" }
        };

        #endregion Constants

        #region Fields

        private Season _currentSeason = null;
        private string _filename = null;

        #endregion Fields

        #region Properties

        private string FileName
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                UpdateTitle();
            }
        }

        private Season CurrentSeason
        {
            get
            {
                return _currentSeason;
            }
            set
            {
                _currentSeason = value;
                if (value != null)
                {
                    cbWeek.SelectedItem = "1";
                }
                else
                {
                    cbWeek.SelectedText = null;
                }

                IsDirty = false;
                UpdateSeasonBindings();
            }
        }

        private Week _week = null;
        private Week CurrentWeek
        {
            get
            {
                return _week;
            }
            set
            {
                _week = value;
                dgvWeek.DataSource = _week?.Games;

                // remove the event handler cuz all it does is set _week.NumTeasers and MarkDirty(), which is not appropriate in this case
                numericUpDownTeasers.ValueChanged -= UpdateTeaser;
                numericUpDownTeasers.Value = (_week != null ? _week.NumTeasers : 0);
                numericUpDownTeasers.ValueChanged += UpdateTeaser;
            }
        }

        private bool _isDirty;
        private bool IsDirty
        {
            get
            {
                return _isDirty;
            }
            set
            {
                _isDirty = value;
                UpdateTitle();
            }
        }

        #endregion Properties

        #region Constructors

        public MainForm(string filename = null)
        {
            InitializeComponent();

            // initialize these to null, it could cause the form to bind twice but...meh
            FileName = null;
            CurrentSeason = null;

            try
            {
                if (filename != null)
                {
                    var openedSeason = LoadFile(filename);
                    if (openedSeason != null)
                    {
                        FileName = filename;
                        CurrentSeason = openedSeason;
                    }
                }
                else if (!string.IsNullOrEmpty(Properties.Settings.Default.FileName))
                {
                    var openedSeason = LoadFile(Properties.Settings.Default.FileName);
                    if (openedSeason != null)
                    {
                        FileName = Properties.Settings.Default.FileName;
                        CurrentSeason = openedSeason;
                    }
                }
            }
            catch (Exception)
            {
                // just in case one of the property settings worked but another threw an exception, ensure that they're null
                FileName = null;
                CurrentSeason = null;
            }
        }

        #endregion Constructors

        #region Async Functions

        private async void CloseWithPrompt(object sender, EventArgs e)
        {
            Disable();

            try
            {
                if (await SaveWithPromptAsync())
                {
                    FileName = null;
                    CurrentSeason = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async void CloseWithPrompt(object sender, FormClosingEventArgs e)
        {
            Disable();

            try
            {
                if (!(await SaveWithPromptAsync()))
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async void CreateNewSeasonWithPrompt(object sender, EventArgs e)
        {
            Disable();
            try
            {
                if (await SaveWithPromptAsync())
                {
                    using (var ys = new YearSelector() { Year = DateTime.Now.Year })
                    {
                        switch (ys.ShowDialog(this))
                        {
                            case DialogResult.OK:
                                CurrentSeason = await GetScheduleFromNflAsync(ys.Year);
                                FileName = null;
                                IsDirty = true;
                                break;
                            case DialogResult.Cancel:
                                return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async Task<Season> GetScheduleFromNflAsync(int year)
        {
            Season season = new Season() { Year = year };
            season.Players.ListChanged += MarkDirty;
            season.Weeks = new Week[17];

            using (var webClient = new WebClient())
            {
                for (int i = 0; i < 17; i++)
                {
                    season.Weeks[i] = new Week();
                    season.Weeks[i].Games.ListChanged += MarkDirty;

                    var url = string.Format("http://www.nfl.com/ajax/scorestrip?season={0}&seasonType=REG&week={1}", season.Year, i + 1);
                    var data = await webClient.DownloadStringTaskAsync(url);

                    var xml = new XmlDocument();
                    xml.LoadXml(data);

                    foreach (XmlNode gameElement in xml.GetElementsByTagName("g"))
                    {
                        string gameId = gameElement.Attributes["eid"].Value;

                        int gameYear = int.Parse(gameId.Substring(0, 4));
                        int gameMonth = int.Parse(gameId.Substring(4, 2));
                        int gameDay = int.Parse(gameId.Substring(6, 2));

                        TimeSpan gameTime = TimeSpan.Parse(gameElement.Attributes["t"].Value);

                        string homeTeamName = gameElement.Attributes["hnn"].Value;
                        homeTeamName = homeTeamName.Substring(0, 1).ToUpper() + homeTeamName.Substring(1);
                        string homeTeamCity = gameElement.Attributes["h"].Value;
                        if (CITY_NAMES.ContainsKey(homeTeamCity))
                        {
                            homeTeamCity = CITY_NAMES[homeTeamCity];
                        }
                        string visitorTeamName = gameElement.Attributes["vnn"].Value;
                        visitorTeamName = visitorTeamName.Substring(0, 1).ToUpper() + visitorTeamName.Substring(1);
                        string visitorTeamCity = gameElement.Attributes["v"].Value;
                        if (CITY_NAMES.ContainsKey(visitorTeamCity))
                        {
                            visitorTeamCity = CITY_NAMES[visitorTeamCity];
                        }

                        var game = new Game()
                        {
                            Id = uint.Parse(gameId),
                            GameTime = new DateTime(gameYear, gameMonth, gameDay).AddHours(12) + gameTime,
                            HomeTeam = (homeTeamCity + " " + homeTeamName).ToUpper(),
                            AwayTeam = (visitorTeamCity + " " + visitorTeamName),
                            IsGameDone = ("F".Equals(gameElement.Attributes["q"].Value, StringComparison.OrdinalIgnoreCase)
                                        || "FO".Equals(gameElement.Attributes["q"].Value, StringComparison.OrdinalIgnoreCase))
                        };

                        game.Favourite = game.HomeTeam;

                        season.Weeks[i].Games.Add(game);
                    }
                }
            }

            return season;
        }

        private static async Task<Dictionary<uint, Tuple<int, int, bool>>> GetScoresFromNflAsync(int year, int week)
        {
            var result = new Dictionary<uint, Tuple<int, int, bool>>();
            using (var webClient = new WebClient())
            {
                var url = string.Format("http://www.nfl.com/ajax/scorestrip?season={0}&seasonType=REG&week={1}", year, week);
                var data = await webClient.DownloadStringTaskAsync(url);
                var xml = new XmlDocument();
                xml.LoadXml(data);

                foreach (XmlNode gameElement in xml.GetElementsByTagName("g"))
                {
                    uint gameId = uint.Parse(gameElement.Attributes["eid"].Value);
                    var strHomeScore = gameElement.Attributes["hs"].Value;
                    var strAwayScore = gameElement.Attributes["vs"].Value;
                    var isGameDone = "F".Equals(gameElement.Attributes["q"].Value, StringComparison.OrdinalIgnoreCase)
                                    || "FO".Equals(gameElement.Attributes["q"].Value, StringComparison.OrdinalIgnoreCase);

                    if (!int.TryParse(strHomeScore, out var homeScore))
                    {
                        homeScore = 0;
                    }

                    if (!int.TryParse(strAwayScore, out var awayScore))
                    {
                        awayScore = 0;
                    }

                    result[gameId] = new Tuple<int, int, bool>(homeScore, awayScore, isGameDone);
                }
            }

            return result;
        }

        private async Task<Season> LoadFileAsync(string fileName)
        {
            var result = await Task<Season>.Run(() =>
            {
                return LoadFile(fileName);
            });

            return result;
        }

        private async void OpenSeason(object sender, EventArgs e)
        {
            Disable();

            try
            {
                if (await SaveWithPromptAsync())
                {
                    switch (openFileDialog1.ShowDialog(this))
                    {
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            var filename = openFileDialog1.FileName;
                            var openedSeason = await LoadFileAsync(filename);
                            if (openedSeason != null)
                            {
                                FileName = filename;
                                CurrentSeason = openedSeason;
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async void Save(object sender, EventArgs e)
        {
            Disable();

            try
            {
                await SaveAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async void SaveAs(object sender, EventArgs e)
        {
            Disable();

            try
            {
                await SaveAsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private async Task<bool> SaveAsAsync()
        {
            if (CurrentSeason != null)
            {
                switch (saveFileDialog1.ShowDialog(this))
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        FileName = saveFileDialog1.FileName;
                        return await SaveFileAsync();
                    case DialogResult.Cancel:
                        return false;

                }
            }

            return true;
        }

        private async Task<bool> SaveAsync()
        {
            if (CurrentSeason != null)
            {
                if (FileName != null)
                {
                    return await SaveFileAsync();
                }
                else
                {
                    return await SaveAsAsync();
                }
            }

            return true;
        }

        private async Task<bool> SaveFileAsync()
        {
            await Task.Run(() =>
            {
                return SaveFile();
            });

            return true;
        }

        private async Task<bool> SaveWithPromptAsync()
        {
            if (CurrentSeason != null
                && IsDirty)
            {
                switch (MessageBox.Show(this, "Save changes?", string.Empty, MessageBoxButtons.YesNoCancel))
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.Yes:
                        return await SaveAsync();
                }
            }

            return true;
        }

        private async void Sync(object sender, EventArgs e)
        {
            Disable();

            try
            {
                // get a clean version of the schedule, in case it has changed
                var updatedSeason = await GetScheduleFromNflAsync(CurrentSeason.Year);

                // create a comparer to use with linq later that uses Id as comparer
                var gameComparer = new LambdaEqualityComparer<Game>((x, y) => { return x.Id.Equals(y.Id); }, (x) => { return x.Id.GetHashCode(); });

                for (int i = 0; i < updatedSeason.Weeks.Length && i < CurrentSeason.Weeks.Length; i++)
                {
                    // update kickoff times
                    foreach (var updatedGame in updatedSeason.Weeks[i].Games.Intersect(CurrentSeason.Weeks[i].Games, gameComparer))
                    {
                        var gameToUpdate = CurrentSeason.Weeks[i].Games.Single((x) => { return x.Id == updatedGame.Id; });
                        gameToUpdate.GameTime = updatedGame.GameTime;
                    }

                    // add new games
                    foreach (var gameToAdd in updatedSeason.Weeks[i].Games.Except(CurrentSeason.Weeks[i].Games, gameComparer))
                    {
                        CurrentSeason.Weeks[i].Games.Add(gameToAdd);
                    }

                    // remove rescheduled or abandoned games
                    foreach (var gameToRemove in CurrentSeason.Weeks[i].Games.Except(updatedSeason.Weeks[i].Games, gameComparer).ToList())
                    {
                        CurrentSeason.Weeks[i].Games.Remove(gameToRemove);
                    }
                }

                // update all the scores for the games
                for (int i = 0; i < CurrentSeason.Weeks.Length; i++)
                {
                    var result = await GetScoresFromNflAsync(CurrentSeason.Year, i + 1);

                    foreach (var game in CurrentSeason.Weeks[i].Games)
                    {
                        if (result.TryGetValue(game.Id, out var score))
                        {
                            game.HomeScore = score.Item1;
                            game.AwayScore = score.Item2;
                            game.IsGameDone = score.Item3;
                        }
                    }

                    CurrentSeason.Weeks[i].Games.ResetBindings();
                }

                // update the scores
                UpdateScores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        #endregion Async Functions

        #region Sync Functions

        private void Disable()
        {
            Enable(false);
            EndEdit();
        }

        private void EditPicks(object sender, EventArgs e)
        {
            var selectedPlayer = cbPlayer.SelectedItem as User;
            if (selectedPlayer == null)
            {
                MessageBox.Show(this, "No selected player.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!CurrentWeek.Picks.TryGetValue(selectedPlayer, out var selectedPlayersPicks))
            {
                CurrentWeek.Picks[selectedPlayer] = selectedPlayersPicks = new Dictionary<Game, Pick>();
            }

            UserPicksForm userPicksForm = new UserPicksForm(selectedPlayersPicks, CurrentWeek.Games, CurrentWeek.NumTeasers, selectedPlayer.DisplayName);
            switch (userPicksForm.ShowDialog(this))
            {
                case DialogResult.OK:
                    selectedPlayersPicks.Clear();
                    foreach (var game in userPicksForm.Picks.Keys)
                    {
                        selectedPlayersPicks.Add(game, new Pick() { Team = userPicksForm.Picks[game].Team, Teaser = userPicksForm.Picks[game].Teaser });
                    }
                    UpdateScores();
                    MarkDirty();
                    break;
                case DialogResult.Cancel:
                    break;
            }

        }

        private void Enable(bool enabled = true)
        {
            foreach (Control control in Controls)
            {
                control.Enabled = enabled;
            }
            UseWaitCursor = !enabled;
        }

        private void EndEdit()
        {
            if (InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() => EndEdit()));
            }
            else
            {
                if (dataGridView1 != null
                    && !dataGridView1.IsDisposed)
                {
                    dataGridView1.EndEdit();
                }

                if (dgvWeek != null
                    && !dgvWeek.IsDisposed)
                {
                    dgvWeek.EndEdit();
                }
            }
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeFavouriteColumn(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvWeek.Rows)
            {
                var game = row.DataBoundItem as Game;

                switch (row.Cells["Favourite"])
                {
                    case DataGridViewComboBoxCell cell:
                        cell.Items.Clear();
                        cell.Items.Add(game.HomeTeam);
                        cell.Items.Add(game.AwayTeam);
                        break;
                }

                if (game.IsGameDone)
                {
                    decimal scoreDifference = game.GetScoreDifference();

                    if (scoreDifference > 0)
                    {
                        if (row.Cells["HomeTeam"] != null)
                        {
                            row.Cells["HomeTeam"].Style.BackColor = System.Drawing.Color.LightGreen;
                            row.Cells["HomeScore"].Style.BackColor = System.Drawing.Color.LightGreen;
                            row.Cells["AwayTeam"].Style.BackColor = System.Drawing.Color.LightPink;
                            row.Cells["AwayScore"].Style.BackColor = System.Drawing.Color.LightPink;
                        }
                    }
                    else if (scoreDifference < 0)
                    {
                        if (row.Cells["AwayTeam"] != null)
                        {
                            row.Cells["AwayTeam"].Style.BackColor = System.Drawing.Color.LightGreen;
                            row.Cells["AwayScore"].Style.BackColor = System.Drawing.Color.LightGreen;
                            row.Cells["HomeTeam"].Style.BackColor = System.Drawing.Color.LightPink;
                            row.Cells["HomeScore"].Style.BackColor = System.Drawing.Color.LightPink;
                        }
                    }
                }
            }
        }

        private Season LoadFile(string fileName)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                var loadedSeason = (Season)formatter.Deserialize(fileStream);
                loadedSeason.Players.ListChanged += MarkDirty;
                foreach (var week in loadedSeason.Weeks)
                {
                    week.Games.ListChanged += MarkDirty;
                }
                IsDirty = false;
                return loadedSeason;
            }
        }

        private void MarkDirty()
        {
            IsDirty = true;
        }

        private void MarkDirty(object sender, ListChangedEventArgs e)
        {
            MarkDirty();
        }

        private void ResetChangedItem(object sender, DataGridViewCellEventArgs e)
        {
            // if data source is a BindingList, then mark that item in the binding list as having changed,
            // then update the scoreboard
            switch (((DataGridView)sender).DataSource)
            {
                case BindingList<User> users:
                    users.ResetItem(e.RowIndex);
                    break;
                case BindingList<Game> games:
                    games.ResetItem(e.RowIndex);
                    break;
            }
            UpdateScores();
        }

        private bool SaveFile()
        {
            using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, CurrentSeason);
                IsDirty = false;
                return true;
            }
        }

        private void SaveSettings(object sender, FormClosedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.FileName = FileName;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetCurrentWeek(object sender, EventArgs e)
        {
            SetCurrentWeek(cbWeek.SelectedItem.ToString());
        }

        public void SetCurrentWeek(string selectedWeek)
        {
            if (int.TryParse(selectedWeek, out int intValue)
                    && intValue >= 1
                    && CurrentSeason != null
                    && CurrentSeason.Weeks != null
                    && CurrentSeason.Weeks.Length >= intValue)
            {
                CurrentWeek = CurrentSeason.Weeks[intValue - 1];
            }
        }

        private void SkipReadonlyDataGridViewCell(object sender, DataGridViewCellEventArgs e)
        {
            switch (sender)
            {
                case DataGridView dgv:
                    if (dgv.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
                    {
                        SendKeys.Send("{tab}");
                    }
                    break;
            }
        }

        private void UpdateSeasonBindings()
        {
            if (CurrentSeason != null)
            {
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
                closeToolStripMenuItem.Enabled = true;
                syncToolStripMenuItem.Enabled = true;
                pnlSeason.Visible = true;
                pnlSplashScreen.Visible = false;

                if (FileName == null)
                {
                    saveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                    openFileDialog1.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                }
                else
                {
                    saveFileDialog1.FileName = Path.GetFileName(FileName);
                    openFileDialog1.FileName = Path.GetFileName(FileName);
                }

                dataGridView1.DataSource = CurrentSeason.Players;

                cbWeek.SelectedItem = "1";
                SetCurrentWeek("1"); // in case current value didn't change, explicity set CurrentWeek to update dgvWeek
                IsDirty = false; // setting current week will cause games dgv to endedit causing IsDirty to be set to true, causing IsDirty to be true when opening a file for instance

                cbPlayer.DataSource = CurrentSeason.Players;
                if (CurrentSeason.Players.Count > 0)
                {
                    cbPlayer.SelectedIndex = 0;
                }
                UpdateScores();
            }
            else
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
                closeToolStripMenuItem.Enabled = false;
                syncToolStripMenuItem.Enabled = false;
                pnlSeason.Visible = false;
                pnlSplashScreen.Visible = true;
            }
        }

        private static Random _random = new Random();
        private void UpdateScores()
        {
            CurrentSeason.UpdateScores();

            var allPlayerScores = new SortableBindingList<PlayerScoresViewModel>();
            foreach (var player in CurrentSeason.Players)
            {
                var playerScores = new PlayerScoresViewModel() { Name = player.DisplayName, TotalScore = 0 };
                for (int i = 0; i < 17; i++)
                {
                    var score = CurrentSeason.Weeks[i].Scores[player];
                    playerScores.TotalScore += score;
                    playerScores.Place = _random.Next(16) + 1;
                    switch (i)
                    {
                        case 0: { playerScores.Week1Score = score; break; }
                        case 1: { playerScores.Week2Score = score; break; }
                        case 2: { playerScores.Week3Score = score; break; }
                        case 3: { playerScores.Week4Score = score; break; }
                        case 4: { playerScores.Week5Score = score; break; }
                        case 5: { playerScores.Week6Score = score; break; }
                        case 6: { playerScores.Week7Score = score; break; }
                        case 7: { playerScores.Week8Score = score; break; }
                        case 8: { playerScores.Week9Score = score; break; }
                        case 9: { playerScores.Week10Score = score; break; }
                        case 10: { playerScores.Week11Score = score; break; }
                        case 11: { playerScores.Week12Score = score; break; }
                        case 12: { playerScores.Week13Score = score; break; }
                        case 13: { playerScores.Week14Score = score; break; }
                        case 14: { playerScores.Week15Score = score; break; }
                        case 15: { playerScores.Week16Score = score; break; }
                        case 16: { playerScores.Week17Score = score; break; }
                    }
                }

                allPlayerScores.Add(playerScores);
            }

            dgvScores.DataSource = allPlayerScores;
        }

        private async void UpdateScores(object sender, EventArgs e)
        {
            Disable();

            try
            {
                var result = await GetScoresFromNflAsync(CurrentSeason.Year, cbWeek.SelectedIndex + 1);

                foreach (var game in CurrentWeek.Games)
                {
                    if (result.TryGetValue(game.Id, out var score))
                    {
                        game.HomeScore = score.Item1;
                        game.AwayScore = score.Item2;
                        game.IsGameDone = score.Item3;
                    }
                }
                CurrentWeek.Games.ResetBindings();

                await Task.Run(() => CurrentWeek.UpdateScores(CurrentSeason.Players)); // hop outta the msg loop in case this takes a while
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Enable();
            }
        }

        private void UpdateTitle()
        {
            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action(UpdateTitle));
                }
                catch
                {
                    // sometimes there's a race condition and the form is disposing at the exact same time the title is updating
                    // so....fuck it and eat it
                }
            }
            else
            {
                var title = "Simia";

                if (_currentSeason != null)
                {
                    title += " - ";

                    if (!string.IsNullOrWhiteSpace(_filename))
                    {
                        title += Path.GetFileName(_filename);
                    }

                    if (IsDirty)
                    {
                        title += "*";
                    }
                }

                this.Text = title;
            }
        }

        private void UpdateTeaser(object sender, EventArgs e)
        {
            CurrentWeek.NumTeasers = (int)numericUpDownTeasers.Value;
            MarkDirty();
            UpdateScores();
        }

        #endregion Sync Functions

        #region Subclasses

        private class LambdaEqualityComparer<T> : IEqualityComparer<T>
        {
            public LambdaEqualityComparer(Func<T, T, bool> equals, Func<T, int> getHashCode)
            {
                this.equals = equals;
                this.getHashCode = getHashCode;
            }

            readonly Func<T, T, bool> equals;
            public bool Equals(T x, T y)
            {
                return equals(x, y);
            }

            readonly Func<T, int> getHashCode;
            public int GetHashCode(T obj)
            {
                return getHashCode(obj);
            }
        }

        #endregion
    }
}
