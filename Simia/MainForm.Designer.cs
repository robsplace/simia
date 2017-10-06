namespace Simia
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlSplashScreen = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlSeason = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpSummary = new System.Windows.Forms.TabPage();
            this.dgvScores = new System.Windows.Forms.DataGridView();
            this.Place = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Week17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPlayers = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Paid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tbWeeks = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvWeek = new System.Windows.Forms.DataGridView();
            this.GameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GameTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomeScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AwayScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Favourite = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Spread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsGameDone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownTeasers = new System.Windows.Forms.NumericUpDown();
            this.btnEditPicks = new System.Windows.Forms.Button();
            this.cbPlayer = new System.Windows.Forms.ComboBox();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.lblWeek = new System.Windows.Forms.Label();
            this.cbWeek = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.pnlSplashScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlSeason.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).BeginInit();
            this.tbPlayers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tbWeeks.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeek)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTeasers)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.syncToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.CreateNewSeasonWithPrompt);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenSeason);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.Save);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Enabled = false;
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAs);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseWithPrompt);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Exit);
            // 
            // syncToolStripMenuItem
            // 
            this.syncToolStripMenuItem.Name = "syncToolStripMenuItem";
            this.syncToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.syncToolStripMenuItem.Text = "Sync";
            this.syncToolStripMenuItem.Click += new System.EventHandler(this.Sync);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "league";
            this.saveFileDialog1.Filter = "Simia League files|*.simialeague|All files|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.Title = "Save As...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "league";
            this.openFileDialog1.Filter = "Simia League files|*.simialeague|All files|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // pnlSplashScreen
            // 
            this.pnlSplashScreen.Controls.Add(this.pictureBox1);
            this.pnlSplashScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSplashScreen.Location = new System.Drawing.Point(0, 24);
            this.pnlSplashScreen.Name = "pnlSplashScreen";
            this.pnlSplashScreen.Size = new System.Drawing.Size(784, 523);
            this.pnlSplashScreen.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 523);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlSeason
            // 
            this.pnlSeason.BackColor = System.Drawing.SystemColors.Control;
            this.pnlSeason.Controls.Add(this.tabControl1);
            this.pnlSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSeason.Location = new System.Drawing.Point(0, 24);
            this.pnlSeason.Name = "pnlSeason";
            this.pnlSeason.Size = new System.Drawing.Size(784, 523);
            this.pnlSeason.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpSummary);
            this.tabControl1.Controls.Add(this.tbPlayers);
            this.tabControl1.Controls.Add(this.tbWeeks);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tpSummary
            // 
            this.tpSummary.Controls.Add(this.dgvScores);
            this.tpSummary.Location = new System.Drawing.Point(4, 22);
            this.tpSummary.Name = "tpSummary";
            this.tpSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tpSummary.Size = new System.Drawing.Size(776, 497);
            this.tpSummary.TabIndex = 0;
            this.tpSummary.Text = "Summary";
            this.tpSummary.UseVisualStyleBackColor = true;
            // 
            // dgvScores
            // 
            this.dgvScores.AllowUserToAddRows = false;
            this.dgvScores.AllowUserToDeleteRows = false;
            this.dgvScores.AllowUserToOrderColumns = true;
            this.dgvScores.AllowUserToResizeColumns = false;
            this.dgvScores.AllowUserToResizeRows = false;
            this.dgvScores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScores.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Place,
            this.PlayerName,
            this.Week1,
            this.Week2,
            this.Week3,
            this.Week4,
            this.Week5,
            this.Week6,
            this.Week7,
            this.Week8,
            this.Week9,
            this.Week10,
            this.Week11,
            this.Week12,
            this.Week13,
            this.Week14,
            this.Week15,
            this.Week16,
            this.Week17,
            this.Total});
            this.dgvScores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScores.Location = new System.Drawing.Point(3, 3);
            this.dgvScores.Name = "dgvScores";
            this.dgvScores.ReadOnly = true;
            this.dgvScores.RowHeadersVisible = false;
            this.dgvScores.Size = new System.Drawing.Size(770, 491);
            this.dgvScores.TabIndex = 0;
            // 
            // Place
            // 
            this.Place.DataPropertyName = "Place";
            this.Place.HeaderText = "Place";
            this.Place.Name = "Place";
            this.Place.ReadOnly = true;
            this.Place.Width = 59;
            // 
            // PlayerName
            // 
            this.PlayerName.DataPropertyName = "Name";
            this.PlayerName.HeaderText = "Name";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            this.PlayerName.Width = 60;
            // 
            // Week1
            // 
            this.Week1.DataPropertyName = "Week1Score";
            this.Week1.HeaderText = "1";
            this.Week1.Name = "Week1";
            this.Week1.ReadOnly = true;
            this.Week1.Width = 38;
            // 
            // Week2
            // 
            this.Week2.DataPropertyName = "Week2Score";
            this.Week2.HeaderText = "2";
            this.Week2.Name = "Week2";
            this.Week2.ReadOnly = true;
            this.Week2.Width = 38;
            // 
            // Week3
            // 
            this.Week3.DataPropertyName = "Week3Score";
            this.Week3.HeaderText = "3";
            this.Week3.Name = "Week3";
            this.Week3.ReadOnly = true;
            this.Week3.Width = 38;
            // 
            // Week4
            // 
            this.Week4.DataPropertyName = "Week4Score";
            this.Week4.HeaderText = "4";
            this.Week4.Name = "Week4";
            this.Week4.ReadOnly = true;
            this.Week4.Width = 38;
            // 
            // Week5
            // 
            this.Week5.DataPropertyName = "Week5Score";
            this.Week5.HeaderText = "5";
            this.Week5.Name = "Week5";
            this.Week5.ReadOnly = true;
            this.Week5.Width = 38;
            // 
            // Week6
            // 
            this.Week6.DataPropertyName = "Week6Score";
            this.Week6.HeaderText = "6";
            this.Week6.Name = "Week6";
            this.Week6.ReadOnly = true;
            this.Week6.Width = 38;
            // 
            // Week7
            // 
            this.Week7.DataPropertyName = "Week7Score";
            this.Week7.HeaderText = "7";
            this.Week7.Name = "Week7";
            this.Week7.ReadOnly = true;
            this.Week7.Width = 38;
            // 
            // Week8
            // 
            this.Week8.DataPropertyName = "Week8Score";
            this.Week8.HeaderText = "8";
            this.Week8.Name = "Week8";
            this.Week8.ReadOnly = true;
            this.Week8.Width = 38;
            // 
            // Week9
            // 
            this.Week9.DataPropertyName = "Week9Score";
            this.Week9.HeaderText = "9";
            this.Week9.Name = "Week9";
            this.Week9.ReadOnly = true;
            this.Week9.Width = 38;
            // 
            // Week10
            // 
            this.Week10.DataPropertyName = "Week10Score";
            this.Week10.HeaderText = "10";
            this.Week10.Name = "Week10";
            this.Week10.ReadOnly = true;
            this.Week10.Width = 44;
            // 
            // Week11
            // 
            this.Week11.DataPropertyName = "Week11Score";
            this.Week11.HeaderText = "11";
            this.Week11.Name = "Week11";
            this.Week11.ReadOnly = true;
            this.Week11.Width = 44;
            // 
            // Week12
            // 
            this.Week12.DataPropertyName = "Week12Score";
            this.Week12.HeaderText = "12";
            this.Week12.Name = "Week12";
            this.Week12.ReadOnly = true;
            this.Week12.Width = 44;
            // 
            // Week13
            // 
            this.Week13.DataPropertyName = "Week13Score";
            this.Week13.HeaderText = "13";
            this.Week13.Name = "Week13";
            this.Week13.ReadOnly = true;
            this.Week13.Width = 44;
            // 
            // Week14
            // 
            this.Week14.DataPropertyName = "Week14Score";
            this.Week14.HeaderText = "14";
            this.Week14.Name = "Week14";
            this.Week14.ReadOnly = true;
            this.Week14.Width = 44;
            // 
            // Week15
            // 
            this.Week15.DataPropertyName = "Week15Score";
            this.Week15.HeaderText = "15";
            this.Week15.Name = "Week15";
            this.Week15.ReadOnly = true;
            this.Week15.Width = 44;
            // 
            // Week16
            // 
            this.Week16.DataPropertyName = "Week16Score";
            this.Week16.HeaderText = "16";
            this.Week16.Name = "Week16";
            this.Week16.ReadOnly = true;
            this.Week16.Width = 44;
            // 
            // Week17
            // 
            this.Week17.DataPropertyName = "Week17Score";
            this.Week17.HeaderText = "17";
            this.Week17.Name = "Week17";
            this.Week17.ReadOnly = true;
            this.Week17.Width = 44;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "TotalScore";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 56;
            // 
            // tbPlayers
            // 
            this.tbPlayers.Controls.Add(this.dataGridView1);
            this.tbPlayers.Location = new System.Drawing.Point(4, 22);
            this.tbPlayers.Name = "tbPlayers";
            this.tbPlayers.Padding = new System.Windows.Forms.Padding(3);
            this.tbPlayers.Size = new System.Drawing.Size(776, 497);
            this.tbPlayers.TabIndex = 1;
            this.tbPlayers.Text = "Players";
            this.tbPlayers.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DisplayName,
            this.Email,
            this.Paid});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(770, 491);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResetChangedItem);
            // 
            // DisplayName
            // 
            this.DisplayName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Paid
            // 
            this.Paid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Paid.DataPropertyName = "Paid";
            this.Paid.HeaderText = "Paid";
            this.Paid.Name = "Paid";
            // 
            // tbWeeks
            // 
            this.tbWeeks.Controls.Add(this.tableLayoutPanel1);
            this.tbWeeks.Location = new System.Drawing.Point(4, 22);
            this.tbWeeks.Name = "tbWeeks";
            this.tbWeeks.Padding = new System.Windows.Forms.Padding(3);
            this.tbWeeks.Size = new System.Drawing.Size(776, 497);
            this.tbWeeks.TabIndex = 2;
            this.tbWeeks.Text = "Weeks";
            this.tbWeeks.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvWeek, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(770, 491);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvWeek
            // 
            this.dgvWeek.AllowUserToAddRows = false;
            this.dgvWeek.AllowUserToDeleteRows = false;
            this.dgvWeek.AllowUserToOrderColumns = true;
            this.dgvWeek.AllowUserToResizeRows = false;
            this.dgvWeek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GameId,
            this.GameTime,
            this.HomeTeam,
            this.HomeScore,
            this.AwayTeam,
            this.AwayScore,
            this.Favourite,
            this.Spread,
            this.IsGameDone});
            this.dgvWeek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWeek.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvWeek.Location = new System.Drawing.Point(3, 38);
            this.dgvWeek.MultiSelect = false;
            this.dgvWeek.Name = "dgvWeek";
            this.dgvWeek.RowHeadersVisible = false;
            this.dgvWeek.Size = new System.Drawing.Size(764, 450);
            this.dgvWeek.TabIndex = 1;
            this.dgvWeek.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResetChangedItem);
            this.dgvWeek.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SkipReadonlyDataGridViewCell);
            this.dgvWeek.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.InitializeFavouriteColumn);
            // 
            // GameId
            // 
            this.GameId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GameId.DataPropertyName = "Id";
            this.GameId.HeaderText = "Id";
            this.GameId.Name = "GameId";
            this.GameId.Visible = false;
            // 
            // GameTime
            // 
            this.GameTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.GameTime.DataPropertyName = "GameTime";
            this.GameTime.HeaderText = "Kickoff";
            this.GameTime.Name = "GameTime";
            this.GameTime.ReadOnly = true;
            this.GameTime.Width = 65;
            // 
            // HomeTeam
            // 
            this.HomeTeam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HomeTeam.DataPropertyName = "HomeTeam";
            this.HomeTeam.HeaderText = "Home Team";
            this.HomeTeam.Name = "HomeTeam";
            this.HomeTeam.ReadOnly = true;
            this.HomeTeam.Width = 90;
            // 
            // HomeScore
            // 
            this.HomeScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HomeScore.DataPropertyName = "HomeScore";
            this.HomeScore.HeaderText = "Score";
            this.HomeScore.Name = "HomeScore";
            this.HomeScore.ReadOnly = true;
            this.HomeScore.Width = 60;
            // 
            // AwayTeam
            // 
            this.AwayTeam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AwayTeam.DataPropertyName = "AwayTeam";
            this.AwayTeam.HeaderText = "Away Team";
            this.AwayTeam.Name = "AwayTeam";
            this.AwayTeam.ReadOnly = true;
            this.AwayTeam.Width = 88;
            // 
            // AwayScore
            // 
            this.AwayScore.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AwayScore.DataPropertyName = "AwayScore";
            this.AwayScore.HeaderText = "Score";
            this.AwayScore.Name = "AwayScore";
            this.AwayScore.ReadOnly = true;
            this.AwayScore.Width = 60;
            // 
            // Favourite
            // 
            this.Favourite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Favourite.DataPropertyName = "Favourite";
            this.Favourite.HeaderText = "Favourite";
            this.Favourite.Name = "Favourite";
            // 
            // Spread
            // 
            this.Spread.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Spread.DataPropertyName = "Spread";
            this.Spread.HeaderText = "Spread";
            this.Spread.Name = "Spread";
            this.Spread.Width = 50;
            // 
            // IsGameDone
            // 
            this.IsGameDone.DataPropertyName = "IsGameDone";
            this.IsGameDone.HeaderText = "IsGameDone";
            this.IsGameDone.Name = "IsGameDone";
            this.IsGameDone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsGameDone.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numericUpDownTeasers);
            this.panel1.Controls.Add(this.btnEditPicks);
            this.panel1.Controls.Add(this.cbPlayer);
            this.panel1.Controls.Add(this.lblPlayer);
            this.panel1.Controls.Add(this.lblWeek);
            this.panel1.Controls.Add(this.cbWeek);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 29);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(199, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Number of Teasers:";
            // 
            // numericUpDownTeasers
            // 
            this.numericUpDownTeasers.Location = new System.Drawing.Point(305, 4);
            this.numericUpDownTeasers.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownTeasers.Name = "numericUpDownTeasers";
            this.numericUpDownTeasers.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownTeasers.TabIndex = 6;
            this.numericUpDownTeasers.ValueChanged += new System.EventHandler(this.UpdateTeaser);
            // 
            // btnEditPicks
            // 
            this.btnEditPicks.Location = new System.Drawing.Point(637, 3);
            this.btnEditPicks.Name = "btnEditPicks";
            this.btnEditPicks.Size = new System.Drawing.Size(121, 23);
            this.btnEditPicks.TabIndex = 5;
            this.btnEditPicks.Text = "Edit Picks";
            this.btnEditPicks.UseVisualStyleBackColor = true;
            this.btnEditPicks.Click += new System.EventHandler(this.EditPicks);
            // 
            // cbPlayer
            // 
            this.cbPlayer.DisplayMember = "DisplayName";
            this.cbPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayer.FormattingEnabled = true;
            this.cbPlayer.Location = new System.Drawing.Point(500, 3);
            this.cbPlayer.Name = "cbPlayer";
            this.cbPlayer.Size = new System.Drawing.Size(131, 21);
            this.cbPlayer.TabIndex = 4;
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Location = new System.Drawing.Point(454, 7);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(39, 13);
            this.lblPlayer.TabIndex = 3;
            this.lblPlayer.Text = "Player:";
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Location = new System.Drawing.Point(3, 6);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(39, 13);
            this.lblWeek.TabIndex = 2;
            this.lblWeek.Text = "Week:";
            // 
            // cbWeek
            // 
            this.cbWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWeek.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.cbWeek.Location = new System.Drawing.Point(48, 3);
            this.cbWeek.Name = "cbWeek";
            this.cbWeek.Size = new System.Drawing.Size(121, 21);
            this.cbWeek.TabIndex = 0;
            this.cbWeek.SelectedValueChanged += new System.EventHandler(this.SetCurrentWeek);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 547);
            this.Controls.Add(this.pnlSeason);
            this.Controls.Add(this.pnlSplashScreen);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "MainForm";
            this.Text = "Simia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseWithPrompt);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SaveSettings);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlSplashScreen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlSeason.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScores)).EndInit();
            this.tbPlayers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tbWeeks.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeek)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTeasers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlSplashScreen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlSeason;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpSummary;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.TabPage tbPlayers;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tbWeeks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbWeek;
        private System.Windows.Forms.DataGridView dgvWeek;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWeek;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Paid;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.ComboBox cbPlayer;
        private System.Windows.Forms.Button btnEditPicks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownTeasers;
        private System.Windows.Forms.ToolStripMenuItem syncToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvScores;
        private System.Windows.Forms.DataGridViewTextBoxColumn Place;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Week17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn GameTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomeScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn AwayScore;
        private System.Windows.Forms.DataGridViewComboBoxColumn Favourite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spread;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsGameDone;
    }
}

