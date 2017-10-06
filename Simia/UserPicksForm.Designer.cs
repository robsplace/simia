namespace Simia
{
    partial class UserPicksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPicksForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Favourite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PickFavourite = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Spread = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PickUnderdog = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Underdog = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pick = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teaser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Game = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(479, 427);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Favourite,
            this.PickFavourite,
            this.Spread,
            this.PickUnderdog,
            this.Underdog,
            this.Pick,
            this.Teaser,
            this.Game});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(473, 391);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SkipReadonlyColumn);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.UpdatePickAndTeaser);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.SetFavouriteAndUnderdog);
            // 
            // Favourite
            // 
            this.Favourite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Favourite.DataPropertyName = "Favourite";
            this.Favourite.HeaderText = "Favourite";
            this.Favourite.Name = "Favourite";
            this.Favourite.ReadOnly = true;
            this.Favourite.Width = 76;
            // 
            // PickFavourite
            // 
            this.PickFavourite.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PickFavourite.HeaderText = "Pick";
            this.PickFavourite.Name = "PickFavourite";
            this.PickFavourite.Width = 34;
            // 
            // Spread
            // 
            this.Spread.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Spread.DataPropertyName = "Spread";
            this.Spread.HeaderText = "Odds";
            this.Spread.Name = "Spread";
            this.Spread.ReadOnly = true;
            // 
            // PickUnderdog
            // 
            this.PickUnderdog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PickUnderdog.HeaderText = "Pick";
            this.PickUnderdog.Name = "PickUnderdog";
            this.PickUnderdog.Width = 34;
            // 
            // Underdog
            // 
            this.Underdog.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Underdog.DataPropertyName = "Underdog";
            this.Underdog.HeaderText = "Underdog";
            this.Underdog.Name = "Underdog";
            this.Underdog.ReadOnly = true;
            this.Underdog.Width = 79;
            // 
            // Pick
            // 
            this.Pick.DataPropertyName = "Pick";
            this.Pick.HeaderText = "Pick";
            this.Pick.Name = "Pick";
            this.Pick.Visible = false;
            // 
            // Teaser
            // 
            this.Teaser.DataPropertyName = "Teaser";
            this.Teaser.HeaderText = "Teaser";
            this.Teaser.Name = "Teaser";
            this.Teaser.Visible = false;
            // 
            // Game
            // 
            this.Game.DataPropertyName = "Game";
            this.Game.HeaderText = "Game";
            this.Game.Name = "Game";
            this.Game.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(3, 400);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(233, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(242, 400);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(234, 24);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.Save);
            // 
            // UserPicksForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(479, 427);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 150);
            this.Name = "UserPicksForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Picks";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn Favourite;
        private System.Windows.Forms.DataGridViewComboBoxColumn PickFavourite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spread;
        private System.Windows.Forms.DataGridViewComboBoxColumn PickUnderdog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Underdog;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pick;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teaser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Game;
    }
}