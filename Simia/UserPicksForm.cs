using Simia.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Simia
{
    public partial class UserPicksForm : Form
    {
        public Dictionary<Game, Pick> Picks { get; private set; } = null;

        BindingList<UserPickVM> UserPicks { get; set; } = new BindingList<UserPickVM>();
        int NumTeasers { get; set; } = 0;

        private class UserPickVM
        {
            public string Favourite { get; set; }
            public string Underdog { get; set; }
            public decimal Spread { get; set; }
            public string Pick { get; set; }
            public int Teaser { get; set; }
            public Game Game { get; set; }
        }

        public UserPicksForm(Dictionary<Game, Pick> picks, IList<Game> games, int numTeasers, string userName = "")
        {
            InitializeComponent();

            if (!string.IsNullOrWhiteSpace(userName))
            {
                Text += " - " + userName;
            }

            NumTeasers = numTeasers;
            Picks = picks.ToDictionary(entry => entry.Key, entry => entry.Value.Clone() as Pick);

            foreach (var game in games)
            {
                if (!Picks.ContainsKey(game))
                {
                    Picks.Add(game, new Pick());
                }
            }

            foreach (var game in Picks.Keys.OrderBy(g => g.Id))
            {
                var upvm = new UserPickVM()
                {
                    Favourite = game.Favourite,
                    Game = game,
                    Pick = Picks[game].Team,
                    Spread = game.Spread,
                    Teaser = Picks[game].Teaser
                };

                if (upvm.Favourite.Equals(game.HomeTeam, StringComparison.InvariantCultureIgnoreCase)) // prolly overkill but meh
                {
                    upvm.Underdog = game.AwayTeam;
                }
                else
                {
                    upvm.Underdog = game.HomeTeam;
                }

                UserPicks.Add(upvm);
            }

            dataGridView1.DataSource = UserPicks;
        }

        private void Save(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();

            // validate teasers
            var teaserCounts = new int[NumTeasers];
            teaserCounts.Initialize();
            foreach (var userPick in UserPicks)
            {
                if (userPick.Teaser > 0
                    && userPick.Teaser <= NumTeasers)
                {
                    teaserCounts[userPick.Teaser - 1]++;
                }
            }
            for (var i = 0; i < NumTeasers; i++)
            {
                var teaserCount = teaserCounts[i];
                if (teaserCount != 0 && teaserCount != 3)
                {
                    MessageBox.Show(this, string.Format("Teaser {0} has invalid number of picks ({1})", i + 1, teaserCount), "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (var userPick in UserPicks)
            {
                if (string.IsNullOrWhiteSpace(userPick.Pick))
                {
                    Picks.Remove(userPick.Game);
                }
                else
                {
                    if (!Picks.TryGetValue(userPick.Game, out var pick))
                    {
                        Picks[userPick.Game] = pick = new Pick();
                    }

                    pick.Team = userPick.Pick;
                    pick.Teaser = userPick.Teaser;
                }
            }

            DialogResult = DialogResult.OK;
        }

        private void SetFavouriteAndUnderdog(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var pickFavouriteCell = row.Cells["PickFavourite"] as DataGridViewComboBoxCell;
                var pickUnderdogCell = row.Cells["PickUnderdog"] as DataGridViewComboBoxCell;

                InitializePickColumn(pickFavouriteCell);
                InitializePickColumn(pickUnderdogCell);

                var pickVM = (UserPickVM)row.DataBoundItem;

                if (!string.IsNullOrEmpty(pickVM.Pick))
                {
                    if (pickVM.Pick.Equals(pickVM.Favourite, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (pickVM.Teaser > 0 && pickVM.Teaser <= NumTeasers)
                        {
                            pickFavouriteCell.Value = "T" + pickVM.Teaser;
                        }
                        else
                        {
                            pickFavouriteCell.Value = "X";
                        }
                    }
                    else if (pickVM.Pick.Equals(pickVM.Underdog, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (pickVM.Teaser > 0 && pickVM.Teaser <= NumTeasers)
                        {
                            pickUnderdogCell.Value = "T" + pickVM.Teaser;
                        }
                        else
                        {
                            pickUnderdogCell.Value = "X";
                        }
                    }
                }
            }
        }

        private void InitializePickColumn(DataGridViewComboBoxCell cell)
        {
            if (cell != null)
            {
                cell.Items.Clear();
                cell.Items.Add(string.Empty);
                cell.Items.Add("X");
                for (int i = 0; i < NumTeasers; i++)
                {
                    cell.Items.Add("T" + (i + 1));
                }
            }
        }

        private void SkipReadonlyColumn(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void UpdatePickAndTeaser(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }

            var column = dataGridView1.Columns[e.ColumnIndex];
            var row = dataGridView1.Rows[e.RowIndex];
            var selectedValue = row.Cells[e.ColumnIndex].Value;
            var favourite = row.Cells["Favourite"].Value as string;
            var underdog = row.Cells["Underdog"].Value as string;
            var game = row.Cells["Game"].Value as Game;
            var currentTeam = Picks[game].Team as string ?? string.Empty;
            var selectedItem = row.DataBoundItem as UserPickVM;

            if (column.Name.Equals("PickFavourite", StringComparison.InvariantCultureIgnoreCase))
            {
                var selectedValueStr = selectedValue as string;

                if (!string.IsNullOrEmpty(selectedValueStr))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["PickUnderdog"].Value = "";

                    selectedItem.Pick = favourite;
                    if (selectedValueStr.StartsWith("T", StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedItem.Teaser = int.Parse(selectedValueStr.Substring(1));
                    }
                    else
                    {
                        selectedItem.Teaser = 0;
                    }
                }
                else if (currentTeam.Equals(favourite, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedItem.Pick = string.Empty;
                    selectedItem.Teaser = 0;
                }
            }
            else if (column.Name.Equals("PickUnderdog"))
            {
                var selectedValueStr = selectedValue as string;

                if (!string.IsNullOrEmpty(selectedValueStr))
                {
                    dataGridView1.Rows[e.RowIndex].Cells["PickFavourite"].Value = "";

                    selectedItem.Pick = underdog;
                    if (selectedValueStr.StartsWith("T", StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedItem.Teaser = int.Parse(selectedValueStr.Substring(1));
                    }
                    else
                    {
                        selectedItem.Teaser = 0;
                    }
                }
                else if (currentTeam.Equals(underdog, StringComparison.InvariantCultureIgnoreCase))
                {
                    selectedItem.Pick = string.Empty;
                    selectedItem.Teaser = 0;
                }
            }
        }
    }
}
