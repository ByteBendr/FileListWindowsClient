namespace FileListClient
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            tabControl = new TabControl();
            searchTab = new TabPage();
            downloadBtn = new Button();
            torrentsListView = new ListView();
            nameColumn = new ColumnHeader();
            sizeColumn = new ColumnHeader();
            seedersColumn = new ColumnHeader();
            leechersColumn = new ColumnHeader();
            categoryColumn = new ColumnHeader();
            searchBtn = new Button();
            searchBox = new TextBox();
            searchTypeCombo = new ComboBox();
            categoryCombo = new ComboBox();
            filterGroupBox = new GroupBox();
            doubleupCheck = new CheckBox();
            freeleechCheck = new CheckBox();
            internalCheck = new CheckBox();
            moderatedCheck = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            latestTab = new TabPage();
            downloadLatestBtn = new Button();
            latestListView = new ListView();
            nameColLatest = new ColumnHeader();
            sizeColLatest = new ColumnHeader();
            seedersColLatest = new ColumnHeader();
            leechersColLatest = new ColumnHeader();
            categoryColLatest = new ColumnHeader();
            refreshLatestBtn = new Button();
            limitLabel = new Label();
            limitNumeric = new NumericUpDown();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            apiStatusLabel = new ToolStripStatusLabel();
            menuStrip.SuspendLayout();
            tabControl.SuspendLayout();
            searchTab.SuspendLayout();
            filterGroupBox.SuspendLayout();
            latestTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)limitNumeric).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(7, 2, 0, 2);
            menuStrip.Size = new Size(1167, 24);
            menuStrip.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(116, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(searchTab);
            tabControl.Controls.Add(latestTab);
            tabControl.Location = new Point(14, 31);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1139, 600);
            tabControl.TabIndex = 1;
            // 
            // searchTab
            // 
            searchTab.Controls.Add(downloadBtn);
            searchTab.Controls.Add(torrentsListView);
            searchTab.Controls.Add(searchBtn);
            searchTab.Controls.Add(searchBox);
            searchTab.Controls.Add(searchTypeCombo);
            searchTab.Controls.Add(categoryCombo);
            searchTab.Controls.Add(filterGroupBox);
            searchTab.Controls.Add(label1);
            searchTab.Controls.Add(label2);
            searchTab.Location = new Point(4, 24);
            searchTab.Margin = new Padding(4, 3, 4, 3);
            searchTab.Name = "searchTab";
            searchTab.Padding = new Padding(4, 3, 4, 3);
            searchTab.Size = new Size(1131, 572);
            searchTab.TabIndex = 0;
            searchTab.Text = "Search Torrents";
            searchTab.UseVisualStyleBackColor = true;
            // 
            // downloadBtn
            // 
            downloadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            downloadBtn.Enabled = false;
            downloadBtn.Location = new Point(986, 537);
            downloadBtn.Margin = new Padding(4, 3, 4, 3);
            downloadBtn.Name = "downloadBtn";
            downloadBtn.Size = new Size(136, 27);
            downloadBtn.TabIndex = 8;
            downloadBtn.Text = "Download Selected";
            downloadBtn.UseVisualStyleBackColor = true;
            downloadBtn.Click += downloadBtn_Click;
            // 
            // torrentsListView
            // 
            torrentsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            torrentsListView.Columns.AddRange(new ColumnHeader[] { nameColumn, sizeColumn, seedersColumn, leechersColumn, categoryColumn });
            torrentsListView.FullRowSelect = true;
            torrentsListView.GridLines = true;
            torrentsListView.Location = new Point(7, 173);
            torrentsListView.Margin = new Padding(4, 3, 4, 3);
            torrentsListView.Name = "torrentsListView";
            torrentsListView.Size = new Size(1115, 356);
            torrentsListView.TabIndex = 7;
            torrentsListView.UseCompatibleStateImageBehavior = false;
            torrentsListView.View = View.Details;
            torrentsListView.SelectedIndexChanged += torrentsListView_SelectedIndexChanged;
            // 
            // nameColumn
            // 
            nameColumn.Text = "Name";
            nameColumn.Width = 500;
            // 
            // sizeColumn
            // 
            sizeColumn.Text = "Size";
            sizeColumn.Width = 100;
            // 
            // seedersColumn
            // 
            seedersColumn.Text = "Seeders";
            seedersColumn.Width = 80;
            // 
            // leechersColumn
            // 
            leechersColumn.Text = "Leechers";
            leechersColumn.Width = 80;
            // 
            // categoryColumn
            // 
            categoryColumn.Text = "Category";
            categoryColumn.Width = 150;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(1035, 12);
            searchBtn.Margin = new Padding(4, 3, 4, 3);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(88, 27);
            searchBtn.TabIndex = 6;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(397, 14);
            searchBox.Margin = new Padding(4, 3, 4, 3);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(630, 23);
            searchBox.TabIndex = 5;
            // 
            // searchTypeCombo
            // 
            searchTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            searchTypeCombo.FormattingEnabled = true;
            searchTypeCombo.Items.AddRange(new object[] { "Name", "IMDB" });
            searchTypeCombo.Location = new Point(105, 14);
            searchTypeCombo.Margin = new Padding(4, 3, 4, 3);
            searchTypeCombo.Name = "searchTypeCombo";
            searchTypeCombo.Size = new Size(233, 23);
            searchTypeCombo.TabIndex = 4;
            // 
            // categoryCombo
            // 
            categoryCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryCombo.FormattingEnabled = true;
            categoryCombo.Location = new Point(105, 45);
            categoryCombo.Margin = new Padding(4, 3, 4, 3);
            categoryCombo.Name = "categoryCombo";
            categoryCombo.Size = new Size(233, 23);
            categoryCombo.TabIndex = 3;
            // 
            // filterGroupBox
            // 
            filterGroupBox.Controls.Add(doubleupCheck);
            filterGroupBox.Controls.Add(freeleechCheck);
            filterGroupBox.Controls.Add(internalCheck);
            filterGroupBox.Controls.Add(moderatedCheck);
            filterGroupBox.Location = new Point(7, 76);
            filterGroupBox.Margin = new Padding(4, 3, 4, 3);
            filterGroupBox.Name = "filterGroupBox";
            filterGroupBox.Padding = new Padding(4, 3, 4, 3);
            filterGroupBox.Size = new Size(1115, 90);
            filterGroupBox.TabIndex = 2;
            filterGroupBox.TabStop = false;
            filterGroupBox.Text = "Filters";
            // 
            // doubleupCheck
            // 
            doubleupCheck.AutoSize = true;
            doubleupCheck.Location = new Point(210, 53);
            doubleupCheck.Margin = new Padding(4, 3, 4, 3);
            doubleupCheck.Name = "doubleupCheck";
            doubleupCheck.Size = new Size(82, 19);
            doubleupCheck.TabIndex = 3;
            doubleupCheck.Text = "Double Up";
            doubleupCheck.UseVisualStyleBackColor = true;
            // 
            // freeleechCheck
            // 
            freeleechCheck.AutoSize = true;
            freeleechCheck.Location = new Point(210, 27);
            freeleechCheck.Margin = new Padding(4, 3, 4, 3);
            freeleechCheck.Name = "freeleechCheck";
            freeleechCheck.Size = new Size(76, 19);
            freeleechCheck.TabIndex = 2;
            freeleechCheck.Text = "Freeleech";
            freeleechCheck.UseVisualStyleBackColor = true;
            // 
            // internalCheck
            // 
            internalCheck.AutoSize = true;
            internalCheck.Location = new Point(18, 53);
            internalCheck.Margin = new Padding(4, 3, 4, 3);
            internalCheck.Name = "internalCheck";
            internalCheck.Size = new Size(66, 19);
            internalCheck.TabIndex = 1;
            internalCheck.Text = "Internal";
            internalCheck.UseVisualStyleBackColor = true;
            // 
            // moderatedCheck
            // 
            moderatedCheck.AutoSize = true;
            moderatedCheck.Location = new Point(18, 27);
            moderatedCheck.Margin = new Padding(4, 3, 4, 3);
            moderatedCheck.Name = "moderatedCheck";
            moderatedCheck.Size = new Size(84, 19);
            moderatedCheck.TabIndex = 0;
            moderatedCheck.Text = "Moderated";
            moderatedCheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 1;
            label1.Text = "Search Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 48);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 0;
            label2.Text = "Category:";
            // 
            // latestTab
            // 
            latestTab.Controls.Add(downloadLatestBtn);
            latestTab.Controls.Add(latestListView);
            latestTab.Controls.Add(refreshLatestBtn);
            latestTab.Controls.Add(limitLabel);
            latestTab.Controls.Add(limitNumeric);
            latestTab.Location = new Point(4, 24);
            latestTab.Margin = new Padding(4, 3, 4, 3);
            latestTab.Name = "latestTab";
            latestTab.Padding = new Padding(4, 3, 4, 3);
            latestTab.Size = new Size(1131, 572);
            latestTab.TabIndex = 1;
            latestTab.Text = "Latest Torrents";
            latestTab.UseVisualStyleBackColor = true;
            // 
            // downloadLatestBtn
            // 
            downloadLatestBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            downloadLatestBtn.Enabled = false;
            downloadLatestBtn.Location = new Point(986, 537);
            downloadLatestBtn.Margin = new Padding(4, 3, 4, 3);
            downloadLatestBtn.Name = "downloadLatestBtn";
            downloadLatestBtn.Size = new Size(136, 27);
            downloadLatestBtn.TabIndex = 4;
            downloadLatestBtn.Text = "Download Selected";
            downloadLatestBtn.UseVisualStyleBackColor = true;
            downloadLatestBtn.Click += downloadLatestBtn_Click;
            // 
            // latestListView
            // 
            latestListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            latestListView.Columns.AddRange(new ColumnHeader[] { nameColLatest, sizeColLatest, seedersColLatest, leechersColLatest, categoryColLatest });
            latestListView.FullRowSelect = true;
            latestListView.GridLines = true;
            latestListView.Location = new Point(7, 46);
            latestListView.Margin = new Padding(4, 3, 4, 3);
            latestListView.Name = "latestListView";
            latestListView.Size = new Size(1115, 483);
            latestListView.TabIndex = 3;
            latestListView.UseCompatibleStateImageBehavior = false;
            latestListView.View = View.Details;
            latestListView.SelectedIndexChanged += latestListView_SelectedIndexChanged;
            // 
            // nameColLatest
            // 
            nameColLatest.Text = "Name";
            nameColLatest.Width = 500;
            // 
            // sizeColLatest
            // 
            sizeColLatest.Text = "Size";
            sizeColLatest.Width = 100;
            // 
            // seedersColLatest
            // 
            seedersColLatest.Text = "Seeders";
            seedersColLatest.Width = 80;
            // 
            // leechersColLatest
            // 
            leechersColLatest.Text = "Leechers";
            leechersColLatest.Width = 80;
            // 
            // categoryColLatest
            // 
            categoryColLatest.Text = "Category";
            categoryColLatest.Width = 150;
            // 
            // refreshLatestBtn
            // 
            refreshLatestBtn.Location = new Point(1035, 12);
            refreshLatestBtn.Margin = new Padding(4, 3, 4, 3);
            refreshLatestBtn.Name = "refreshLatestBtn";
            refreshLatestBtn.Size = new Size(88, 27);
            refreshLatestBtn.TabIndex = 2;
            refreshLatestBtn.Text = "Refresh";
            refreshLatestBtn.UseVisualStyleBackColor = true;
            refreshLatestBtn.Click += refreshLatestBtn_Click;
            // 
            // limitLabel
            // 
            limitLabel.AutoSize = true;
            limitLabel.Location = new Point(7, 17);
            limitLabel.Margin = new Padding(4, 0, 4, 0);
            limitLabel.Name = "limitLabel";
            limitLabel.Size = new Size(152, 15);
            limitLabel.TabIndex = 1;
            limitLabel.Text = "Number of torrents (1-100):";
            // 
            // limitNumeric
            // 
            limitNumeric.Location = new Point(163, 14);
            limitNumeric.Margin = new Padding(4, 3, 4, 3);
            limitNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            limitNumeric.Name = "limitNumeric";
            limitNumeric.Size = new Size(140, 23);
            limitNumeric.TabIndex = 0;
            limitNumeric.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLabel, apiStatusLabel });
            statusStrip.Location = new Point(0, 638);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.Size = new Size(1167, 22);
            statusStrip.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(39, 17);
            statusLabel.Text = "Ready";
            // 
            // apiStatusLabel
            // 
            apiStatusLabel.Name = "apiStatusLabel";
            apiStatusLabel.Size = new Size(1111, 17);
            apiStatusLabel.Spring = true;
            apiStatusLabel.Text = "API Status: Connected";
            apiStatusLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 660);
            Controls.Add(statusStrip);
            Controls.Add(tabControl);
            Controls.Add(menuStrip);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(931, 686);
            Name = "Form1";
            Text = "FileList Windows Client (win-x64) [build 07012026]";
            Load += Form1_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            tabControl.ResumeLayout(false);
            searchTab.ResumeLayout(false);
            searchTab.PerformLayout();
            filterGroupBox.ResumeLayout(false);
            filterGroupBox.PerformLayout();
            latestTab.ResumeLayout(false);
            latestTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)limitNumeric).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.TabPage latestTab;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel apiStatusLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox filterGroupBox;
        private System.Windows.Forms.CheckBox moderatedCheck;
        private System.Windows.Forms.CheckBox internalCheck;
        private System.Windows.Forms.CheckBox freeleechCheck;
        private System.Windows.Forms.CheckBox doubleupCheck;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.ComboBox searchTypeCombo;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ListView torrentsListView;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader sizeColumn;
        private System.Windows.Forms.ColumnHeader seedersColumn;
        private System.Windows.Forms.ColumnHeader leechersColumn;
        private System.Windows.Forms.ColumnHeader categoryColumn;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.NumericUpDown limitNumeric;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.Button refreshLatestBtn;
        private System.Windows.Forms.ListView latestListView;
        private System.Windows.Forms.ColumnHeader nameColLatest;
        private System.Windows.Forms.ColumnHeader sizeColLatest;
        private System.Windows.Forms.ColumnHeader seedersColLatest;
        private System.Windows.Forms.ColumnHeader leechersColLatest;
        private System.Windows.Forms.ColumnHeader categoryColLatest;
        private System.Windows.Forms.Button downloadLatestBtn;
    }
}