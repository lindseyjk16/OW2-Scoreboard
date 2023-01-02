namespace OW2ScoreboardController
{
	partial class MainForm
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ScoreGroupBox = new System.Windows.Forms.GroupBox();
            this.DrawsLabel = new System.Windows.Forms.Label();
            this.DrawsUpDown = new System.Windows.Forms.NumericUpDown();
            this.LosesUpDown = new System.Windows.Forms.NumericUpDown();
            this.LosesLabel = new System.Windows.Forms.Label();
            this.WinsUpDown = new System.Windows.Forms.NumericUpDown();
            this.WinsLabel = new System.Windows.Forms.Label();
            this.RankGroupBox = new System.Windows.Forms.GroupBox();
            this.SupportRankDropdown = new GroupedComboBox();
            this.TankRankDropdown = new GroupedComboBox();
            this.DamageRankDropdown = new GroupedComboBox();
            this.SupportInPlacementCheckbox = new System.Windows.Forms.CheckBox();
            this.DamageInPlacementCheckbox = new System.Windows.Forms.CheckBox();
            this.SupportRankEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.DamageRankEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.TankRankEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.TankInPlacementCheckbox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DrawButton = new System.Windows.Forms.Button();
            this.LoseButton = new System.Windows.Forms.Button();
            this.WinButton = new System.Windows.Forms.Button();
            this.SaveTimer = new System.Windows.Forms.Timer(this.components);
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_AlwayOnTop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_StopUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_ClearScore = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SwitchMode = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SwitchMode_RoleQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_SwitchMode_OpenQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Language_Automatic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Language_Japanese = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Language_English = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItem_Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItem_Version = new System.Windows.Forms.ToolStripMenuItem();
            this.ScoreGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LosesUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinsUpDown)).BeginInit();
            this.RankGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ScoreGroupBox
            // 
            this.ScoreGroupBox.Controls.Add(this.DrawsLabel);
            this.ScoreGroupBox.Controls.Add(this.DrawsUpDown);
            this.ScoreGroupBox.Controls.Add(this.LosesUpDown);
            this.ScoreGroupBox.Controls.Add(this.LosesLabel);
            this.ScoreGroupBox.Controls.Add(this.WinsUpDown);
            this.ScoreGroupBox.Controls.Add(this.WinsLabel);
            this.ScoreGroupBox.Location = new System.Drawing.Point(17, 34);
            this.ScoreGroupBox.Margin = new System.Windows.Forms.Padding(8);
            this.ScoreGroupBox.Name = "ScoreGroupBox";
            this.ScoreGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.ScoreGroupBox.Size = new System.Drawing.Size(144, 152);
            this.ScoreGroupBox.TabIndex = 0;
            this.ScoreGroupBox.TabStop = false;
            this.ScoreGroupBox.Text = "Today\'s Score";
            // 
            // DrawsLabel
            // 
            this.DrawsLabel.AutoSize = true;
            this.DrawsLabel.Location = new System.Drawing.Point(16, 112);
            this.DrawsLabel.Margin = new System.Windows.Forms.Padding(8);
            this.DrawsLabel.Name = "DrawsLabel";
            this.DrawsLabel.Size = new System.Drawing.Size(42, 15);
            this.DrawsLabel.TabIndex = 7;
            this.DrawsLabel.Text = "Draws";
            // 
            // DrawsUpDown
            // 
            this.DrawsUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DrawsUpDown.Location = new System.Drawing.Point(76, 110);
            this.DrawsUpDown.Margin = new System.Windows.Forms.Padding(8);
            this.DrawsUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.DrawsUpDown.Name = "DrawsUpDown";
            this.DrawsUpDown.Size = new System.Drawing.Size(52, 21);
            this.DrawsUpDown.TabIndex = 6;
            this.DrawsUpDown.ValueChanged += new System.EventHandler(this.DrawsUpDown_ValueChanged);
            this.DrawsUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DrawsUpDown_KeyUp);
            // 
            // LosesUpDown
            // 
            this.LosesUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LosesUpDown.Location = new System.Drawing.Point(76, 71);
            this.LosesUpDown.Margin = new System.Windows.Forms.Padding(8);
            this.LosesUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.LosesUpDown.Name = "LosesUpDown";
            this.LosesUpDown.Size = new System.Drawing.Size(52, 21);
            this.LosesUpDown.TabIndex = 5;
            this.LosesUpDown.ValueChanged += new System.EventHandler(this.LosesUpDown_ValueChanged);
            this.LosesUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LosesUpDown_KeyUp);
            // 
            // LosesLabel
            // 
            this.LosesLabel.AutoSize = true;
            this.LosesLabel.Location = new System.Drawing.Point(16, 73);
            this.LosesLabel.Margin = new System.Windows.Forms.Padding(8);
            this.LosesLabel.Name = "LosesLabel";
            this.LosesLabel.Size = new System.Drawing.Size(46, 15);
            this.LosesLabel.TabIndex = 0;
            this.LosesLabel.Text = "Losses";
            // 
            // WinsUpDown
            // 
            this.WinsUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WinsUpDown.Location = new System.Drawing.Point(76, 32);
            this.WinsUpDown.Margin = new System.Windows.Forms.Padding(8);
            this.WinsUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.WinsUpDown.Name = "WinsUpDown";
            this.WinsUpDown.Size = new System.Drawing.Size(52, 21);
            this.WinsUpDown.TabIndex = 4;
            this.WinsUpDown.ValueChanged += new System.EventHandler(this.WinsUpDown_ValueChanged);
            this.WinsUpDown.KeyUp += new System.Windows.Forms.KeyEventHandler(this.WinsUpDown_KeyUp);
            // 
            // WinsLabel
            // 
            this.WinsLabel.AutoSize = true;
            this.WinsLabel.Location = new System.Drawing.Point(25, 34);
            this.WinsLabel.Margin = new System.Windows.Forms.Padding(8);
            this.WinsLabel.Name = "WinsLabel";
            this.WinsLabel.Size = new System.Drawing.Size(34, 15);
            this.WinsLabel.TabIndex = 1;
            this.WinsLabel.Text = "Wins";
            // 
            // RankGroupBox
            // 
            this.RankGroupBox.Controls.Add(this.SupportRankDropdown);
            this.RankGroupBox.Controls.Add(this.TankRankDropdown);
            this.RankGroupBox.Controls.Add(this.DamageRankDropdown);
            this.RankGroupBox.Controls.Add(this.SupportInPlacementCheckbox);
            this.RankGroupBox.Controls.Add(this.DamageInPlacementCheckbox);
            this.RankGroupBox.Controls.Add(this.SupportRankEnabledCheckBox);
            this.RankGroupBox.Controls.Add(this.DamageRankEnabledCheckBox);
            this.RankGroupBox.Controls.Add(this.TankRankEnabledCheckBox);
            this.RankGroupBox.Controls.Add(this.TankInPlacementCheckbox);
            this.RankGroupBox.Location = new System.Drawing.Point(17, 202);
            this.RankGroupBox.Margin = new System.Windows.Forms.Padding(8);
            this.RankGroupBox.Name = "RankGroupBox";
            this.RankGroupBox.Padding = new System.Windows.Forms.Padding(8);
            this.RankGroupBox.Size = new System.Drawing.Size(334, 149);
            this.RankGroupBox.TabIndex = 1;
            this.RankGroupBox.TabStop = false;
            this.RankGroupBox.Text = "Rank";
            // 
            // SupportRankDropdown
            // 
            this.SupportRankDropdown.DataSource = null;
            this.SupportRankDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SupportRankDropdown.FormattingEnabled = true;
            this.SupportRankDropdown.Location = new System.Drawing.Point(95, 109);
            this.SupportRankDropdown.Name = "SupportRankDropdown";
            this.SupportRankDropdown.Size = new System.Drawing.Size(111, 22);
            this.SupportRankDropdown.TabIndex = 16;
            this.SupportRankDropdown.SelectedIndexChanged += new System.EventHandler(this.SupportRankDropdown_SelectedIndexChanged);
            // 
            // TankRankDropdown
            // 
            this.TankRankDropdown.DataSource = null;
            this.TankRankDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TankRankDropdown.FormattingEnabled = true;
            this.TankRankDropdown.Location = new System.Drawing.Point(95, 31);
            this.TankRankDropdown.Name = "TankRankDropdown";
            this.TankRankDropdown.Size = new System.Drawing.Size(111, 22);
            this.TankRankDropdown.TabIndex = 14;
            this.TankRankDropdown.SelectedIndexChanged += new System.EventHandler(this.TankRankDropdown_SelectedIndexChanged);
            // 
            // DamageRankDropdown
            // 
            this.DamageRankDropdown.DataSource = null;
            this.DamageRankDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DamageRankDropdown.FormattingEnabled = true;
            this.DamageRankDropdown.Location = new System.Drawing.Point(95, 72);
            this.DamageRankDropdown.Name = "DamageRankDropdown";
            this.DamageRankDropdown.Size = new System.Drawing.Size(111, 22);
            this.DamageRankDropdown.TabIndex = 15;
            this.DamageRankDropdown.SelectedIndexChanged += new System.EventHandler(this.DamageRankDropdown_SelectedIndexChanged);
            // 
            // SupportInPlacementCheckbox
            // 
            this.SupportInPlacementCheckbox.AutoSize = true;
            this.SupportInPlacementCheckbox.Location = new System.Drawing.Point(220, 111);
            this.SupportInPlacementCheckbox.Name = "SupportInPlacementCheckbox";
            this.SupportInPlacementCheckbox.Size = new System.Drawing.Size(98, 19);
            this.SupportInPlacementCheckbox.TabIndex = 12;
            this.SupportInPlacementCheckbox.Text = "In Placement";
            this.SupportInPlacementCheckbox.UseVisualStyleBackColor = true;
            this.SupportInPlacementCheckbox.CheckedChanged += new System.EventHandler(this.SupportInPlacementCheckbox_CheckedChanged);
            // 
            // DamageInPlacementCheckbox
            // 
            this.DamageInPlacementCheckbox.AutoSize = true;
            this.DamageInPlacementCheckbox.Location = new System.Drawing.Point(220, 72);
            this.DamageInPlacementCheckbox.Name = "DamageInPlacementCheckbox";
            this.DamageInPlacementCheckbox.Size = new System.Drawing.Size(98, 19);
            this.DamageInPlacementCheckbox.TabIndex = 11;
            this.DamageInPlacementCheckbox.Text = "In Placement";
            this.DamageInPlacementCheckbox.UseVisualStyleBackColor = true;
            this.DamageInPlacementCheckbox.CheckedChanged += new System.EventHandler(this.DamageInPlacementCheckbox_CheckedChanged);
            // 
            // SupportRankEnabledCheckBox
            // 
            this.SupportRankEnabledCheckBox.AutoSize = true;
            this.SupportRankEnabledCheckBox.Checked = true;
            this.SupportRankEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SupportRankEnabledCheckBox.Location = new System.Drawing.Point(11, 111);
            this.SupportRankEnabledCheckBox.Name = "SupportRankEnabledCheckBox";
            this.SupportRankEnabledCheckBox.Size = new System.Drawing.Size(69, 19);
            this.SupportRankEnabledCheckBox.TabIndex = 10;
            this.SupportRankEnabledCheckBox.Text = "Support";
            this.SupportRankEnabledCheckBox.UseVisualStyleBackColor = true;
            this.SupportRankEnabledCheckBox.CheckedChanged += new System.EventHandler(this.StartingRateSupportCheckBox_CheckedChanged);
            // 
            // DamageRankEnabledCheckBox
            // 
            this.DamageRankEnabledCheckBox.AutoSize = true;
            this.DamageRankEnabledCheckBox.Checked = true;
            this.DamageRankEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DamageRankEnabledCheckBox.Location = new System.Drawing.Point(11, 72);
            this.DamageRankEnabledCheckBox.Name = "DamageRankEnabledCheckBox";
            this.DamageRankEnabledCheckBox.Size = new System.Drawing.Size(74, 19);
            this.DamageRankEnabledCheckBox.TabIndex = 9;
            this.DamageRankEnabledCheckBox.Text = "Damage";
            this.DamageRankEnabledCheckBox.UseVisualStyleBackColor = true;
            this.DamageRankEnabledCheckBox.CheckedChanged += new System.EventHandler(this.StartingRateDamageCheckBox_CheckedChanged);
            // 
            // TankRankEnabledCheckBox
            // 
            this.TankRankEnabledCheckBox.AutoSize = true;
            this.TankRankEnabledCheckBox.Checked = true;
            this.TankRankEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TankRankEnabledCheckBox.Location = new System.Drawing.Point(11, 33);
            this.TankRankEnabledCheckBox.Name = "TankRankEnabledCheckBox";
            this.TankRankEnabledCheckBox.Size = new System.Drawing.Size(53, 19);
            this.TankRankEnabledCheckBox.TabIndex = 7;
            this.TankRankEnabledCheckBox.Text = "Tank";
            this.TankRankEnabledCheckBox.UseVisualStyleBackColor = true;
            this.TankRankEnabledCheckBox.CheckedChanged += new System.EventHandler(this.StartingRateTankCheckBox_CheckedChanged);
            // 
            // TankInPlacementCheckbox
            // 
            this.TankInPlacementCheckbox.AutoSize = true;
            this.TankInPlacementCheckbox.Location = new System.Drawing.Point(220, 33);
            this.TankInPlacementCheckbox.Name = "TankInPlacementCheckbox";
            this.TankInPlacementCheckbox.Size = new System.Drawing.Size(98, 19);
            this.TankInPlacementCheckbox.TabIndex = 1;
            this.TankInPlacementCheckbox.Text = "In Placement";
            this.TankInPlacementCheckbox.UseVisualStyleBackColor = true;
            this.TankInPlacementCheckbox.CheckedChanged += new System.EventHandler(this.InPlacementCheckbox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DrawButton);
            this.groupBox1.Controls.Add(this.LoseButton);
            this.groupBox1.Controls.Add(this.WinButton);
            this.groupBox1.Location = new System.Drawing.Point(177, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 8, 8, 83);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(174, 152);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick Actions";
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(16, 110);
            this.DrawButton.Margin = new System.Windows.Forms.Padding(8);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(142, 23);
            this.DrawButton.TabIndex = 2;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // LoseButton
            // 
            this.LoseButton.Location = new System.Drawing.Point(16, 71);
            this.LoseButton.Margin = new System.Windows.Forms.Padding(8);
            this.LoseButton.Name = "LoseButton";
            this.LoseButton.Size = new System.Drawing.Size(142, 23);
            this.LoseButton.TabIndex = 1;
            this.LoseButton.Text = "Lose";
            this.LoseButton.UseVisualStyleBackColor = true;
            this.LoseButton.Click += new System.EventHandler(this.LoseButton_Click);
            // 
            // WinButton
            // 
            this.WinButton.Location = new System.Drawing.Point(16, 32);
            this.WinButton.Margin = new System.Windows.Forms.Padding(8);
            this.WinButton.Name = "WinButton";
            this.WinButton.Size = new System.Drawing.Size(142, 23);
            this.WinButton.TabIndex = 0;
            this.WinButton.Text = "Win";
            this.WinButton.UseVisualStyleBackColor = true;
            this.WinButton.Click += new System.EventHandler(this.WinButton_Click);
            // 
            // SaveTimer
            // 
            this.SaveTimer.Interval = 1000;
            this.SaveTimer.Tick += new System.EventHandler(this.SaveTimer_Tick);
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.OptionMenu,
            this.HelpMenu});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MenuBar.Size = new System.Drawing.Size(368, 24);
            this.MenuBar.TabIndex = 4;
            this.MenuBar.Text = "MenuBar";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Exit});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(54, 20);
            this.FileMenu.Text = "File (&F)";
            // 
            // MenuItem_Exit
            // 
            this.MenuItem_Exit.Name = "MenuItem_Exit";
            this.MenuItem_Exit.Size = new System.Drawing.Size(115, 22);
            this.MenuItem_Exit.Text = "Quit (&X)";
            this.MenuItem_Exit.Click += new System.EventHandler(this.MenuItem_Exit_Click);
            // 
            // OptionMenu
            // 
            this.OptionMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_AlwayOnTop,
            this.MenuItem_StopUpdate,
            this.MenuItem_ClearScore,
            this.MenuItem_SwitchMode,
            this.toolStripSeparator1,
            this.MenuItem_Language,
            this.toolStripSeparator3,
            this.MenuItem_Settings});
            this.OptionMenu.Name = "OptionMenu";
            this.OptionMenu.Size = new System.Drawing.Size(81, 20);
            this.OptionMenu.Text = "Options (&O)";
            // 
            // MenuItem_AlwayOnTop
            // 
            this.MenuItem_AlwayOnTop.CheckOnClick = true;
            this.MenuItem_AlwayOnTop.Name = "MenuItem_AlwayOnTop";
            this.MenuItem_AlwayOnTop.Size = new System.Drawing.Size(165, 22);
            this.MenuItem_AlwayOnTop.Text = "Always On Top";
            this.MenuItem_AlwayOnTop.Click += new System.EventHandler(this.MenuItem_AlwayOnTop_Click);
            // 
            // MenuItem_StopUpdate
            // 
            this.MenuItem_StopUpdate.CheckOnClick = true;
            this.MenuItem_StopUpdate.Name = "MenuItem_StopUpdate";
            this.MenuItem_StopUpdate.Size = new System.Drawing.Size(165, 22);
            this.MenuItem_StopUpdate.Text = "Suspend Updates";
            this.MenuItem_StopUpdate.Click += new System.EventHandler(this.MenuItem_StopUpdate_Click);
            // 
            // MenuItem_ClearScore
            // 
            this.MenuItem_ClearScore.Name = "MenuItem_ClearScore";
            this.MenuItem_ClearScore.Size = new System.Drawing.Size(165, 22);
            this.MenuItem_ClearScore.Text = "Clear Score";
            this.MenuItem_ClearScore.Click += new System.EventHandler(this.MenuItem_ClearScore_Click);
            // 
            // MenuItem_SwitchMode
            // 
            this.MenuItem_SwitchMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_SwitchMode_RoleQueue,
            this.MenuItem_SwitchMode_OpenQueue});
            this.MenuItem_SwitchMode.Name = "MenuItem_SwitchMode";
            this.MenuItem_SwitchMode.Size = new System.Drawing.Size(165, 22);
            this.MenuItem_SwitchMode.Text = "Switch Mode";
            // 
            // MenuItem_SwitchMode_RoleQueue
            // 
            this.MenuItem_SwitchMode_RoleQueue.Checked = true;
            this.MenuItem_SwitchMode_RoleQueue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItem_SwitchMode_RoleQueue.Name = "MenuItem_SwitchMode_RoleQueue";
            this.MenuItem_SwitchMode_RoleQueue.Size = new System.Drawing.Size(139, 22);
            this.MenuItem_SwitchMode_RoleQueue.Text = "ロールキュー";
            this.MenuItem_SwitchMode_RoleQueue.Click += new System.EventHandler(this.MenuItem_SwitchRoleQueueMode_Click);
            // 
            // MenuItem_SwitchMode_OpenQueue
            // 
            this.MenuItem_SwitchMode_OpenQueue.Name = "MenuItem_SwitchMode_OpenQueue";
            this.MenuItem_SwitchMode_OpenQueue.Size = new System.Drawing.Size(139, 22);
            this.MenuItem_SwitchMode_OpenQueue.Text = "オープンキュー";
            this.MenuItem_SwitchMode_OpenQueue.Click += new System.EventHandler(this.MenuItem_SwitchOpenQueueMode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // MenuItem_Language
            // 
            this.MenuItem_Language.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Language_Automatic,
            this.toolStripSeparator4,
            this.MenuItem_Language_Japanese,
            this.MenuItem_Language_English});
            this.MenuItem_Language.Name = "MenuItem_Language";
            this.MenuItem_Language.Size = new System.Drawing.Size(165, 22);
            this.MenuItem_Language.Text = "Language (&L)";
            // 
            // MenuItem_Language_Automatic
            // 
            this.MenuItem_Language_Automatic.Checked = true;
            this.MenuItem_Language_Automatic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuItem_Language_Automatic.Name = "MenuItem_Language_Automatic";
            this.MenuItem_Language_Automatic.Size = new System.Drawing.Size(130, 22);
            this.MenuItem_Language_Automatic.Text = "Automatic";
            this.MenuItem_Language_Automatic.Click += new System.EventHandler(this.MenuItem_Language_Automatic_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(127, 6);
            // 
            // MenuItem_Language_Japanese
            // 
            this.MenuItem_Language_Japanese.Enabled = false;
            this.MenuItem_Language_Japanese.Name = "MenuItem_Language_Japanese";
            this.MenuItem_Language_Japanese.Size = new System.Drawing.Size(130, 22);
            this.MenuItem_Language_Japanese.Text = "日本語";
            this.MenuItem_Language_Japanese.Click += new System.EventHandler(this.MenuItem_Language_Japanese_Click);
            // 
            // MenuItem_Language_English
            // 
            this.MenuItem_Language_English.Name = "MenuItem_Language_English";
            this.MenuItem_Language_English.Size = new System.Drawing.Size(130, 22);
            this.MenuItem_Language_English.Text = "English";
            this.MenuItem_Language_English.Click += new System.EventHandler(this.MenuItem_Language_English_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // MenuItem_Settings
            // 
            this.MenuItem_Settings.Name = "MenuItem_Settings";
            this.MenuItem_Settings.Size = new System.Drawing.Size(165, 22);
            this.MenuItem_Settings.Text = "Settings (&C)...";
            this.MenuItem_Settings.Click += new System.EventHandler(this.MenuItem_Settings_Click);
            // 
            // HelpMenu
            // 
            this.HelpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem_Manual,
            this.toolStripSeparator2,
            this.MenuItem_Version});
            this.HelpMenu.Name = "HelpMenu";
            this.HelpMenu.Size = new System.Drawing.Size(64, 20);
            this.HelpMenu.Text = "Help (&H)";
            // 
            // MenuItem_Manual
            // 
            this.MenuItem_Manual.Name = "MenuItem_Manual";
            this.MenuItem_Manual.Size = new System.Drawing.Size(145, 22);
            this.MenuItem_Manual.Text = "Help";
            this.MenuItem_Manual.Click += new System.EventHandler(this.MenuItem_Manual_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(142, 6);
            // 
            // MenuItem_Version
            // 
            this.MenuItem_Version.Name = "MenuItem_Version";
            this.MenuItem_Version.Size = new System.Drawing.Size(145, 22);
            this.MenuItem_Version.Text = "Version Info...";
            this.MenuItem_Version.Click += new System.EventHandler(this.MenuItem_Version_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(368, 368);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.RankGroupBox);
            this.Controls.Add(this.ScoreGroupBox);
            this.Controls.Add(this.MenuBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuBar;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "OW2 Scoreboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ScoreGroupBox.ResumeLayout(false);
            this.ScoreGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LosesUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WinsUpDown)).EndInit();
            this.RankGroupBox.ResumeLayout(false);
            this.RankGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox ScoreGroupBox;
		private System.Windows.Forms.GroupBox RankGroupBox;
		private System.Windows.Forms.Label LosesLabel;
		private System.Windows.Forms.Label WinsLabel;
		private System.Windows.Forms.NumericUpDown WinsUpDown;
		private System.Windows.Forms.NumericUpDown LosesUpDown;
		private System.Windows.Forms.Label DrawsLabel;
		private System.Windows.Forms.NumericUpDown DrawsUpDown;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button WinButton;
		private System.Windows.Forms.Button DrawButton;
		private System.Windows.Forms.Button LoseButton;
		private System.Windows.Forms.Timer SaveTimer;
		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem FileMenu;
		private System.Windows.Forms.ToolStripMenuItem OptionMenu;
		private System.Windows.Forms.ToolStripMenuItem HelpMenu;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Exit;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Version;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_StopUpdate;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Settings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Manual;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_AlwayOnTop;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Language;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Language_Automatic;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Language_Japanese;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_Language_English;
		private System.Windows.Forms.CheckBox TankInPlacementCheckbox;
		private System.Windows.Forms.CheckBox SupportInPlacementCheckbox;
		private System.Windows.Forms.CheckBox DamageInPlacementCheckbox;
		private System.Windows.Forms.CheckBox SupportRankEnabledCheckBox;
		private System.Windows.Forms.CheckBox DamageRankEnabledCheckBox;
		private System.Windows.Forms.CheckBox TankRankEnabledCheckBox;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_ClearScore;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_SwitchMode;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_SwitchMode_RoleQueue;
		private System.Windows.Forms.ToolStripMenuItem MenuItem_SwitchMode_OpenQueue;
        private GroupedComboBox SupportRankDropdown;
        private GroupedComboBox TankRankDropdown;
        private GroupedComboBox DamageRankDropdown;
    }
}

