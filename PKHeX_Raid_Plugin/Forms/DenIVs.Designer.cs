using PKHeX_Raid_Plugin;

namespace PKHeX_Raid_Plugin
{
    partial class DenIVs
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
            raidContent = new System.Windows.Forms.DataGridView();
            FrameCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            HPCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AtkCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DefCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SpaCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SpdCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SpeCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            NatureCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            AbilityCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            GenderCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ShinyCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            SeedCell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DetailsBox = new System.Windows.Forms.GroupBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            searchButton = new System.Windows.Forms.Button();
            resetFilter = new System.Windows.Forms.Button();
            applyFilter = new System.Windows.Forms.Button();
            shinyBox = new System.Windows.Forms.ComboBox();
            label23 = new System.Windows.Forms.Label();
            genderBox = new System.Windows.Forms.ComboBox();
            abilityBox = new System.Windows.Forms.ComboBox();
            natureBox = new CheckedComboBox();
            label22 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            label18 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            label16 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            maxSpe = new System.Windows.Forms.NumericUpDown();
            maxSpd = new System.Windows.Forms.NumericUpDown();
            maxSpa = new System.Windows.Forms.NumericUpDown();
            maxDef = new System.Windows.Forms.NumericUpDown();
            maxAtk = new System.Windows.Forms.NumericUpDown();
            maxHP = new System.Windows.Forms.NumericUpDown();
            MinSpe = new System.Windows.Forms.NumericUpDown();
            minSpd = new System.Windows.Forms.NumericUpDown();
            minSpa = new System.Windows.Forms.NumericUpDown();
            minDef = new System.Windows.Forms.NumericUpDown();
            minAtk = new System.Windows.Forms.NumericUpDown();
            minHP = new System.Windows.Forms.NumericUpDown();
            label13 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            endFrame = new System.Windows.Forms.TextBox();
            startFrame = new System.Windows.Forms.TextBox();
            speciesList = new System.Windows.Forms.ComboBox();
            denBox = new System.Windows.Forms.ComboBox();
            seedBox = new System.Windows.Forms.TextBox();
            generateData = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)raidContent).BeginInit();
            DetailsBox.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)maxSpe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxSpd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxSpa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxDef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxAtk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)maxHP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MinSpe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minSpd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minSpa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minDef).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minAtk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minHP).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // raidContent
            // 
            raidContent.AllowUserToAddRows = false;
            raidContent.AllowUserToDeleteRows = false;
            raidContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            raidContent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { FrameCell, HPCell, AtkCell, DefCell, SpaCell, SpdCell, SpeCell, NatureCell, AbilityCell, GenderCell, ShinyCell, SeedCell });
            raidContent.Dock = System.Windows.Forms.DockStyle.Bottom;
            raidContent.Location = new System.Drawing.Point(0, 287);
            raidContent.Margin = new System.Windows.Forms.Padding(2);
            raidContent.Name = "raidContent";
            raidContent.ReadOnly = true;
            raidContent.RowHeadersWidth = 51;
            raidContent.RowTemplate.Height = 24;
            raidContent.Size = new System.Drawing.Size(1104, 462);
            raidContent.TabIndex = 0;
            raidContent.CellMouseClick += RaidContent_SeedCellClick;
            // 
            // FrameCell
            // 
            FrameCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            FrameCell.HeaderText = "Frame Advances";
            FrameCell.MinimumWidth = 6;
            FrameCell.Name = "FrameCell";
            FrameCell.ReadOnly = true;
            FrameCell.Width = 77;
            // 
            // HPCell
            // 
            HPCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            HPCell.HeaderText = "HP";
            HPCell.MinimumWidth = 6;
            HPCell.Name = "HPCell";
            HPCell.ReadOnly = true;
            HPCell.Width = 56;
            // 
            // AtkCell
            // 
            AtkCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            AtkCell.HeaderText = "ATK";
            AtkCell.MinimumWidth = 6;
            AtkCell.Name = "AtkCell";
            AtkCell.ReadOnly = true;
            AtkCell.Width = 64;
            // 
            // DefCell
            // 
            DefCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            DefCell.HeaderText = "DEF";
            DefCell.MinimumWidth = 6;
            DefCell.Name = "DefCell";
            DefCell.ReadOnly = true;
            DefCell.Width = 64;
            // 
            // SpaCell
            // 
            SpaCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            SpaCell.HeaderText = "SPA";
            SpaCell.MinimumWidth = 6;
            SpaCell.Name = "SpaCell";
            SpaCell.ReadOnly = true;
            SpaCell.Width = 64;
            // 
            // SpdCell
            // 
            SpdCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            SpdCell.HeaderText = "SPD";
            SpdCell.MinimumWidth = 6;
            SpdCell.Name = "SpdCell";
            SpdCell.ReadOnly = true;
            SpdCell.Width = 65;
            // 
            // SpeCell
            // 
            SpeCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            SpeCell.HeaderText = "SPE";
            SpeCell.MinimumWidth = 6;
            SpeCell.Name = "SpeCell";
            SpeCell.ReadOnly = true;
            SpeCell.Width = 64;
            // 
            // NatureCell
            // 
            NatureCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            NatureCell.HeaderText = "Nature";
            NatureCell.MinimumWidth = 6;
            NatureCell.Name = "NatureCell";
            NatureCell.ReadOnly = true;
            NatureCell.Width = 80;
            // 
            // AbilityCell
            // 
            AbilityCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            AbilityCell.HeaderText = "Ability";
            AbilityCell.MinimumWidth = 6;
            AbilityCell.Name = "AbilityCell";
            AbilityCell.ReadOnly = true;
            AbilityCell.Width = 74;
            // 
            // GenderCell
            // 
            GenderCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            GenderCell.HeaderText = "Gender";
            GenderCell.MinimumWidth = 6;
            GenderCell.Name = "GenderCell";
            GenderCell.ReadOnly = true;
            GenderCell.Width = 85;
            // 
            // ShinyCell
            // 
            ShinyCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            ShinyCell.HeaderText = "Shiny";
            ShinyCell.MinimumWidth = 6;
            ShinyCell.Name = "ShinyCell";
            ShinyCell.ReadOnly = true;
            ShinyCell.Width = 72;
            // 
            // SeedCell
            // 
            SeedCell.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            SeedCell.HeaderText = "Seed";
            SeedCell.MaxInputLength = 16;
            SeedCell.MinimumWidth = 6;
            SeedCell.Name = "SeedCell";
            SeedCell.ReadOnly = true;
            SeedCell.Width = 140;
            // 
            // DetailsBox
            // 
            DetailsBox.AutoSize = true;
            DetailsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            DetailsBox.Controls.Add(groupBox2);
            DetailsBox.Controls.Add(groupBox1);
            DetailsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            DetailsBox.Location = new System.Drawing.Point(0, 0);
            DetailsBox.Margin = new System.Windows.Forms.Padding(2);
            DetailsBox.Name = "DetailsBox";
            DetailsBox.Padding = new System.Windows.Forms.Padding(2);
            DetailsBox.Size = new System.Drawing.Size(1104, 287);
            DetailsBox.TabIndex = 1;
            DetailsBox.TabStop = false;
            DetailsBox.Text = "Details";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(searchButton);
            groupBox2.Controls.Add(resetFilter);
            groupBox2.Controls.Add(applyFilter);
            groupBox2.Controls.Add(shinyBox);
            groupBox2.Controls.Add(label23);
            groupBox2.Controls.Add(genderBox);
            groupBox2.Controls.Add(abilityBox);
            groupBox2.Controls.Add(natureBox);
            groupBox2.Controls.Add(label22);
            groupBox2.Controls.Add(label21);
            groupBox2.Controls.Add(label20);
            groupBox2.Controls.Add(label19);
            groupBox2.Controls.Add(label18);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(label16);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(maxSpe);
            groupBox2.Controls.Add(maxSpd);
            groupBox2.Controls.Add(maxSpa);
            groupBox2.Controls.Add(maxDef);
            groupBox2.Controls.Add(maxAtk);
            groupBox2.Controls.Add(maxHP);
            groupBox2.Controls.Add(MinSpe);
            groupBox2.Controls.Add(minSpd);
            groupBox2.Controls.Add(minSpa);
            groupBox2.Controls.Add(minDef);
            groupBox2.Controls.Add(minAtk);
            groupBox2.Controls.Add(minHP);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Location = new System.Drawing.Point(345, 20);
            groupBox2.Margin = new System.Windows.Forms.Padding(2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(2);
            groupBox2.Size = new System.Drawing.Size(715, 217);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filters";
            // 
            // searchButton
            // 
            searchButton.Location = new System.Drawing.Point(509, 170);
            searchButton.Margin = new System.Windows.Forms.Padding(2);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(106, 28);
            searchButton.TabIndex = 35;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += SearchButton_Click;
            // 
            // resetFilter
            // 
            resetFilter.Location = new System.Drawing.Point(369, 170);
            resetFilter.Margin = new System.Windows.Forms.Padding(2);
            resetFilter.Name = "resetFilter";
            resetFilter.Size = new System.Drawing.Size(106, 28);
            resetFilter.TabIndex = 34;
            resetFilter.Text = "Reset Filter";
            resetFilter.UseVisualStyleBackColor = true;
            resetFilter.Click += ResetFilter_Click;
            // 
            // applyFilter
            // 
            applyFilter.Location = new System.Drawing.Point(229, 170);
            applyFilter.Margin = new System.Windows.Forms.Padding(2);
            applyFilter.Name = "applyFilter";
            applyFilter.Size = new System.Drawing.Size(106, 28);
            applyFilter.TabIndex = 33;
            applyFilter.Text = "Apply Filter";
            applyFilter.UseVisualStyleBackColor = true;
            applyFilter.Click += ApplyFilter_Click;
            // 
            // shinyBox
            // 
            shinyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            shinyBox.FormattingEnabled = true;
            shinyBox.Items.AddRange(new object[] { "Any", "Yes (Any Type)", "No", "Star", "Square" });
            shinyBox.Location = new System.Drawing.Point(509, 132);
            shinyBox.Margin = new System.Windows.Forms.Padding(2);
            shinyBox.Name = "shinyBox";
            shinyBox.Size = new System.Drawing.Size(134, 23);
            shinyBox.TabIndex = 32;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new System.Drawing.Point(229, 132);
            label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new System.Drawing.Size(36, 15);
            label23.TabIndex = 31;
            label23.Text = "Shiny";
            // 
            // genderBox
            // 
            genderBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            genderBox.FormattingEnabled = true;
            genderBox.Location = new System.Drawing.Point(509, 103);
            genderBox.Margin = new System.Windows.Forms.Padding(2);
            genderBox.Name = "genderBox";
            genderBox.Size = new System.Drawing.Size(134, 23);
            genderBox.TabIndex = 30;
            // 
            // abilityBox
            // 
            abilityBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            abilityBox.DropDownWidth = 135;
            abilityBox.FormattingEnabled = true;
            abilityBox.Location = new System.Drawing.Point(509, 75);
            abilityBox.Margin = new System.Windows.Forms.Padding(2);
            abilityBox.Name = "abilityBox";
            abilityBox.Size = new System.Drawing.Size(134, 23);
            abilityBox.TabIndex = 29;
            // 
            // natureBox
            // 
            natureBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            natureBox.DropDownHeight = 1;
            natureBox.FormattingEnabled = true;
            natureBox.IntegralHeight = false;
            natureBox.Location = new System.Drawing.Point(509, 47);
            natureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            natureBox.Name = "natureBox";
            natureBox.Size = new System.Drawing.Size(134, 24);
            natureBox.TabIndex = 28;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new System.Drawing.Point(229, 103);
            label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label22.Name = "label22";
            label22.Size = new System.Drawing.Size(45, 15);
            label22.TabIndex = 27;
            label22.Text = "Gender";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new System.Drawing.Point(229, 75);
            label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new System.Drawing.Size(41, 15);
            label21.TabIndex = 26;
            label21.Text = "Ability";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new System.Drawing.Point(229, 47);
            label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new System.Drawing.Size(43, 15);
            label20.TabIndex = 25;
            label20.Text = "Nature";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(117, 168);
            label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(15, 15);
            label19.TabIndex = 24;
            label19.Text = "~";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(117, 145);
            label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(15, 15);
            label18.TabIndex = 23;
            label18.Text = "~";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(117, 122);
            label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(15, 15);
            label17.TabIndex = 22;
            label17.Text = "~";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(117, 98);
            label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(15, 15);
            label16.TabIndex = 21;
            label16.Text = "~";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(117, 75);
            label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(15, 15);
            label15.TabIndex = 20;
            label15.Text = "~";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(117, 52);
            label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(15, 15);
            label14.TabIndex = 12;
            label14.Text = "~";
            // 
            // maxSpe
            // 
            maxSpe.Location = new System.Drawing.Point(133, 164);
            maxSpe.Margin = new System.Windows.Forms.Padding(2);
            maxSpe.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            maxSpe.Name = "maxSpe";
            maxSpe.Size = new System.Drawing.Size(37, 23);
            maxSpe.TabIndex = 19;
            maxSpe.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // maxSpd
            // 
            maxSpd.Location = new System.Drawing.Point(133, 141);
            maxSpd.Margin = new System.Windows.Forms.Padding(2);
            maxSpd.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            maxSpd.Name = "maxSpd";
            maxSpd.Size = new System.Drawing.Size(37, 23);
            maxSpd.TabIndex = 18;
            maxSpd.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // maxSpa
            // 
            maxSpa.Location = new System.Drawing.Point(133, 118);
            maxSpa.Margin = new System.Windows.Forms.Padding(2);
            maxSpa.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            maxSpa.Name = "maxSpa";
            maxSpa.Size = new System.Drawing.Size(37, 23);
            maxSpa.TabIndex = 17;
            maxSpa.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // maxDef
            // 
            maxDef.Location = new System.Drawing.Point(133, 93);
            maxDef.Margin = new System.Windows.Forms.Padding(2);
            maxDef.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            maxDef.Name = "maxDef";
            maxDef.Size = new System.Drawing.Size(37, 23);
            maxDef.TabIndex = 16;
            maxDef.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // maxAtk
            // 
            maxAtk.Location = new System.Drawing.Point(133, 70);
            maxAtk.Margin = new System.Windows.Forms.Padding(2);
            maxAtk.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            maxAtk.Name = "maxAtk";
            maxAtk.Size = new System.Drawing.Size(37, 23);
            maxAtk.TabIndex = 15;
            maxAtk.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // maxHP
            // 
            maxHP.Location = new System.Drawing.Point(133, 47);
            maxHP.Margin = new System.Windows.Forms.Padding(2);
            maxHP.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            maxHP.Name = "maxHP";
            maxHP.Size = new System.Drawing.Size(37, 23);
            maxHP.TabIndex = 14;
            maxHP.Value = new decimal(new int[] { 31, 0, 0, 0 });
            // 
            // MinSpe
            // 
            MinSpe.Location = new System.Drawing.Point(75, 164);
            MinSpe.Margin = new System.Windows.Forms.Padding(2);
            MinSpe.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            MinSpe.Name = "MinSpe";
            MinSpe.Size = new System.Drawing.Size(37, 23);
            MinSpe.TabIndex = 13;
            // 
            // minSpd
            // 
            minSpd.Location = new System.Drawing.Point(75, 141);
            minSpd.Margin = new System.Windows.Forms.Padding(2);
            minSpd.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            minSpd.Name = "minSpd";
            minSpd.Size = new System.Drawing.Size(37, 23);
            minSpd.TabIndex = 12;
            // 
            // minSpa
            // 
            minSpa.Location = new System.Drawing.Point(75, 118);
            minSpa.Margin = new System.Windows.Forms.Padding(2);
            minSpa.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            minSpa.Name = "minSpa";
            minSpa.Size = new System.Drawing.Size(37, 23);
            minSpa.TabIndex = 11;
            // 
            // minDef
            // 
            minDef.Location = new System.Drawing.Point(75, 93);
            minDef.Margin = new System.Windows.Forms.Padding(2);
            minDef.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            minDef.Name = "minDef";
            minDef.Size = new System.Drawing.Size(37, 23);
            minDef.TabIndex = 10;
            // 
            // minAtk
            // 
            minAtk.Location = new System.Drawing.Point(75, 70);
            minAtk.Margin = new System.Windows.Forms.Padding(2);
            minAtk.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            minAtk.Name = "minAtk";
            minAtk.Size = new System.Drawing.Size(37, 23);
            minAtk.TabIndex = 9;
            // 
            // minHP
            // 
            minHP.Location = new System.Drawing.Point(75, 47);
            minHP.Margin = new System.Windows.Forms.Padding(2);
            minHP.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            minHP.Name = "minHP";
            minHP.Size = new System.Drawing.Size(37, 23);
            minHP.TabIndex = 8;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(23, 168);
            label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(26, 15);
            label13.TabIndex = 7;
            label13.Text = "SPE";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(23, 145);
            label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(28, 15);
            label12.TabIndex = 6;
            label12.Text = "SPD";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(23, 122);
            label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(27, 15);
            label11.TabIndex = 5;
            label11.Text = "SPA";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(23, 98);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(27, 15);
            label10.TabIndex = 4;
            label10.Text = "DEF";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(23, 75);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(27, 15);
            label9.TabIndex = 3;
            label9.Text = "ATK";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(23, 52);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(23, 15);
            label8.TabIndex = 2;
            label8.Text = "HP";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(132, 24);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(43, 15);
            label7.TabIndex = 1;
            label7.Text = "Max IV";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(72, 24);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 15);
            label6.TabIndex = 0;
            label6.Text = "Min IV";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(endFrame);
            groupBox1.Controls.Add(startFrame);
            groupBox1.Controls.Add(speciesList);
            groupBox1.Controls.Add(denBox);
            groupBox1.Controls.Add(seedBox);
            groupBox1.Controls.Add(generateData);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new System.Drawing.Point(5, 20);
            groupBox1.Margin = new System.Windows.Forms.Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2);
            groupBox1.Size = new System.Drawing.Size(327, 217);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Raid Details";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(212, 136);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(15, 15);
            label5.TabIndex = 11;
            label5.Text = "~";
            // 
            // endFrame
            // 
            endFrame.Location = new System.Drawing.Point(231, 132);
            endFrame.Margin = new System.Windows.Forms.Padding(2);
            endFrame.Name = "endFrame";
            endFrame.Size = new System.Drawing.Size(70, 23);
            endFrame.TabIndex = 10;
            endFrame.Text = "1000";
            endFrame.KeyPress += IsNumberPressed;
            // 
            // startFrame
            // 
            startFrame.Location = new System.Drawing.Point(138, 132);
            startFrame.Margin = new System.Windows.Forms.Padding(2);
            startFrame.Name = "startFrame";
            startFrame.Size = new System.Drawing.Size(70, 23);
            startFrame.TabIndex = 9;
            startFrame.Text = "0";
            startFrame.KeyPress += IsNumberPressed;
            // 
            // speciesList
            // 
            speciesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            speciesList.FormattingEnabled = true;
            speciesList.Location = new System.Drawing.Point(138, 98);
            speciesList.Margin = new System.Windows.Forms.Padding(2);
            speciesList.Name = "speciesList";
            speciesList.Size = new System.Drawing.Size(164, 23);
            speciesList.TabIndex = 8;
            speciesList.SelectedIndexChanged += SpeciesList_SelectedIndexChanged;
            // 
            // denBox
            // 
            denBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            denBox.FormattingEnabled = true;
            denBox.Items.AddRange(new object[] { "1 [b]: Rolling Fields 1", "2 [b]: Rolling Fields 2", "3 [b]: Rolling Fields 3", "4 [b]: Rolling Fields 4", "5 [b]: Rolling Fields 5", "6 [b]: Rolling Fields 6", "7 [b]: Rolling Fields 7", "8 [b]: Rolling Fields 8", "9 [b]: Rolling Fields 9", "10 [b]: Dappled Grove 1", "11 [b]: Dappled Grove 2", "12 [b]: Dappled Grove 3", "13 [b]: Dappled Grove 4", "14 [b]: Dappled Grove 5", "15 [b]: Watchtower Ruins 1", "16 [b]: Watchtower Ruins 2", "17 [b]: Watchtower Ruins 3", "18 [b]: East Lake Axewell 1", "19 [b]: East Lake Axewell 2", "20 [b]: East Lake Axewell 3", "21 [b]: East Lake Axewell 4", "22 [b]: West Lake Axewell 1", "23 [b]: West Lake Axewell 2", "24 [b]: West Lake Axewell 3", "25 [b]: West Lake Axewell 4", "26 [b]: West Lake Axewell 5", "27 [b]: West Lake Axewell 6", "28 [b]: Axew’s Eye 1", "29 [b]: South Lake Miloch 1", "30 [b]: South Lake Miloch 2", "31 [b]: South Lake Miloch 3", "32 [b]: South Lake Miloch 4", "33 [b]: South Lake Miloch 5", "34 [b]: Giant’s Seat 1", "35 [b]: Giant’s Seat 2", "36 [b]: Giant’s Seat 3", "37 [b]: Giant’s Seat 4", "38 [b]: Giant’s Seat 5", "39 [b]: North Lake Miloch 1", "40 [b]: North Lake Miloch 2", "41 [b]: North Lake Miloch 3", "42 [b]: North Lake Miloch 4", "43 [b]: North Lake Miloch 5", "44 [b]: East Lake Axewell 5", "45 [b]: North Lake Miloch 6", "46 [b]: Motostoke Riverbank 1", "47 [b]: Motostoke Riverbank 2", "48 [b]: Motostoke Riverbank 3", "49 [b]: Motostoke Riverbank 4", "50 [b]: Bridge Field 1", "51 [b]: Bridge Field 2", "52 [b]: Bridge Field 3", "53 [b]: Bridge Field 4", "54 [b]: Bridge Field 5", "55 [b]: Bridge Field 6", "56 [b]: Bridge Field 7", "57 [b]: Bridge Field 8", "58 [b]: Bridge Field 9", "59 [b]: Stony Wilderness 1", "60 [b]: Stony Wilderness 2", "61 [b]: Stony Wilderness 3", "62 [b]: Stony Wilderness 4", "63 [b]: Stony Wilderness 5", "64 [b]: Stony Wilderness 6", "65 [b]: Stony Wilderness 7", "66 [b]: Stony Wilderness 8", "67 [b]: Stony Wilderness 9", "68 [b]: Stony Wilderness 10", "69 [b]: Stony Wilderness 11", "70 [b]: Stony Wilderness 12", "71 [b]: Dusty Bowl 1", "72 [b]: Dusty Bowl 2", "73 [b]: Dusty Bowl 3", "74 [b]: Dusty Bowl 4", "75 [b]: Dusty Bowl 5", "76 [b]: Dusty Bowl 6", "77 [b]: Dusty Bowl 7", "78 [b]: Dusty Bowl 8", "79 [b]: Giant’s Mirror 1", "80 [b]: Dusty Bowl 9", "81 [b]: Giant’s Mirror 2", "82 [b]: Giant’s Mirror 3", "83 [b]: Giant’s Mirror 4", "84 [b]: Giant’s Mirror 5", "85 [b]: Hammerlocke Hills 1", "86 [b]: Hammerlocke Hills 2", "87 [b]: Hammerlocke Hills 3", "88 [b]: Hammerlocke Hills 4", "89 [b]: Hammerlocke Hills 5", "90 [b]: Hammerlocke Hills 6", "91 [b]: Hammerlocke Hills 7", "92 [b]: Giant’s Cap 1", "93 [b]: Giant’s Cap 2", "94 [b]: Giant’s Cap 3", "95 [b]: Giant’s Cap 4", "96 [b]: Giant’s Cap 5", "97 [b]: Lake of Outrage 1", "98 [b]: Lake of Outrage 2", "99 [b]: Lake of Outrage 3", "100 [b]: Lake of Outrage 4", "1 [IoA]: Fields of Honor 1", "2 [IoA]: Fields of Honor 2", "3 [IoA]: Fields of Honor 3", "4 [IoA]: Fields of Honor 4", "5 [IoA]: Fields of Honor 5", "6 [IoA]: Fields of Honor 6", "7 [IoA]: Fields of Honor 7", "8 [IoA]: Fields of Honor 8", "9 [IoA]: Fields of Honor 9", "10 [IoA]: Fields of Honor 10", "11 [IoA]: Soothing Wetlands 1", "12 [IoA]: Soothing Wetlands 2", "13 [IoA]: Soothing Wetlands 3", "14 [IoA]: Soothing Wetlands 4", "15 [IoA]: Soothing Wetlands 5", "16 [IoA]: Soothing Wetlands 6", "17 [IoA]: Soothing Wetlands 7", "18 [IoA]: Soothing Wetlands 8", "19 [IoA]: Soothing Wetlands 9", "20 [IoA]: Forest of Focus 1", "21 [IoA]: Forest of Focus 2", "22 [IoA]: Forest of Focus 3", "23 [IoA]: Forest of Focus 4", "24 [IoA]: Forest of Focus 5", "25 [IoA]: Forest of Focus 6", "26 [IoA]: Challenge Beach 1", "27 [IoA]: Challenge Beach 2", "28 [IoA]: Challenge Beach 3", "29 [IoA]: Challenge Beach 4", "30 [IoA]: Challenge Beach 5", "31 [IoA]: Challenge Beach 6", "32 [IoA]: Challenge Beach 7", "33 [IoA]: Challenge Beach 8", "34 [IoA]: Brawlers’ Cave 1", "35 [IoA]: Challenge Road 1", "36 [IoA]: Challenge Road 2", "37 [IoA]: Challenge Road 3", "38 [IoA]: Challenge Road 4", "39 [IoA]: Courageous Cavern 1", "40 [IoA]: Courageous Cavern 2", "41 [IoA]: Courageous Cavern 3", "42 [IoA]: Courageous Cavern 4", "43 [IoA]: Courageous Cavern 5", "44 [IoA]: Courageous Cavern 6", "45 [IoA]: Loop Lagoon 1", "46 [IoA]: Loop Lagoon 2", "47 [IoA]: Loop Lagoon 3", "48 [IoA]: Loop Lagoon 4", "49 [IoA]: Training Lowlands 1", "50 [IoA]: Training Lowlands 2", "51 [IoA]: Training Lowlands 3", "52 [IoA]: Training Lowlands 4", "53 [IoA]: Training Lowlands 5", "54 [IoA]: Training Lowlands 6", "55 [IoA]: Training Lowlands 7", "56 [IoA]: Potbottom Desert 1", "57 [IoA]: Potbottom Desert 2", "58 [IoA]: Potbottom Desert 3", "59 [IoA]: Workout Sea 1", "60 [IoA]: Workout Sea 2", "61 [IoA]: Workout Sea 3", "62 [IoA]: Workout Sea 4", "63 [IoA]: Workout Sea 5", "64 [IoA]: Workout Sea 6", "65 [IoA]: Workout Sea 7", "66 [IoA]: Stepping-Stone Sea 1", "67 [IoA]: Stepping-Stone Sea 2", "68 [IoA]: Stepping-Stone Sea 3", "69 [IoA]: Stepping-Stone Sea 4", "70 [IoA]: Stepping-Stone Sea 5", "71 [IoA]: Stepping-Stone Sea 6", "72 [IoA]: Stepping-Stone Sea 7", "73 [IoA]: Stepping-Stone Sea 8", "74 [IoA]: Stepping-Stone Sea 9", "75 [IoA]: Insular Sea 1", "76 [IoA]: Insular Sea 2", "77 [IoA]: Insular Sea 3", "78 [IoA]: Insular Sea 4", "79 [IoA]: Insular Sea 5", "80 [IoA]: Honeycalm Sea 1", "81 [IoA]: Honeycalm Sea 2", "82 [IoA]: Honeycalm Sea 3", "83 [IoA]: Honeycalm Sea 4", "84 [IoA]: Honeycalm Sea 5", "85 [IoA]: Honeycalm Island 1", "86 [IoA]: Honeycalm Island 2", "87 [IoA]: Honeycalm Island 3", "88 [IoA]: Honeycalm Island 4", "89 [IoA]: Honeycalm Island 5", "90 [IoA]: Honeycalm Island 6", "1 [CT]: Slippery Slope 1", "2 [CT]: Slippery Slope 2", "3 [CT]: Slippery Slope 3", "4 [CT]: Slippery Slope 4", "5 [CT]: Slippery Slope 5", "6 [CT]: Slippery Slope 6", "7 [CT]: Frostpoint Field 1", "8 [CT]: Frostpoint Field 2", "9 [CT]: Frostpoint Field 3", "10 [CT]: Frostpoint Field 4", "11 [CT]: Frostpoint Field 5", "12 [CT]: Giant’s Bed 1", "13 [CT]: Giant’s Bed 10", "14 [CT]: Giant’s Bed 11", "15 [CT]: Giant’s Bed 12", "16 [CT]: Giant’s Bed 13", "17 [CT]: Giant’s Bed 14", "18 [CT]: Giant’s Bed 15", "19 [CT]: Giant’s Bed 16", "20 [CT]: Giant’s Bed 17", "21 [CT]: Giant’s Bed 18", "22 [CT]: Giant’s Bed 19", "23 [CT]: Giant’s Bed 2", "24 [CT]: Giant’s Bed 20", "25 [CT]: Giant’s Bed 21", "26 [CT]: Giant’s Bed 3", "27 [CT]: Giant’s Bed 4", "28 [CT]: Giant’s Bed 5", "29 [CT]: Giant’s Bed 6", "30 [CT]: Giant’s Bed 7", "31 [CT]: Giant’s Bed 8", "32 [CT]: Giant’s Bed 9", "33 [CT]: Old Cemetery 1", "34 [CT]: Old Cemetery 2", "35 [CT]: Snowslide Slope 1", "36 [CT]: Snowslide Slope 2", "37 [CT]: Snowslide Slope 3", "38 [CT]: Snowslide Slope 4", "39 [CT]: Snowslide Slope 5", "40 [CT]: Snowslide Slope 6", "41 [CT]: Snowslide Slope 7", "42 [CT]: Snowslide Slope 8", "43 [CT]: Snowslide Slope 9", "44 [CT]: Path to the Peak 1", "45 [CT]: Path to the Peak 2", "46 [CT]: Path to the Peak 3", "47 [CT]: Crown Shrine 1", "48 [CT]: Giant’s Foot 1", "49 [CT]: Giant’s Foot 2", "50 [CT]: Giant’s Foot 3", "51 [CT]: Giant’s Foot 4", "52 [CT]: Giant’s Foot 5", "53 [CT]: Frigid Sea 1", "54 [CT]: Frigid Sea 10", "55 [CT]: Frigid Sea 11", "56 [CT]: Frigid Sea 12", "57 [CT]: Frigid Sea 13", "58 [CT]: Frigid Sea 14", "59 [CT]: Frigid Sea 2", "60 [CT]: Frigid Sea 3", "61 [CT]: Frigid Sea 4", "62 [CT]: Frigid Sea 5", "63 [CT]: Frigid Sea 6", "64 [CT]: Frigid Sea 7", "65 [CT]: Frigid Sea 8", "66 [CT]: Frigid Sea 9", "67 [CT]: Three-Point Pass 1", "68 [CT]: Three-Point Pass 2", "69 [CT]: Ballimere Lake 1", "70 [CT]: Ballimere Lake 10", "71 [CT]: Ballimere Lake 11", "72 [CT]: Ballimere Lake 12", "73 [CT]: Ballimere Lake 13", "74 [CT]: Ballimere Lake 14", "75 [CT]: Ballimere Lake 15", "76 [CT]: Ballimere Lake 16", "77 [CT]: Ballimere Lake 17", "78 [CT]: Ballimere Lake 2", "79 [CT]: Ballimere Lake 3", "80 [CT]: Ballimere Lake 4", "81 [CT]: Ballimere Lake 5", "82 [CT]: Ballimere Lake 6", "83 [CT]: Ballimere Lake 7", "84 [CT]: Ballimere Lake 8", "85 [CT]: Ballimere Lake 9", "86 [CT]: Dyna Tree Hill 1" });
            denBox.Location = new System.Drawing.Point(138, 66);
            denBox.Margin = new System.Windows.Forms.Padding(2);
            denBox.Name = "denBox";
            denBox.Size = new System.Drawing.Size(164, 23);
            denBox.TabIndex = 7;
            denBox.SelectedIndexChanged += DenBox_SelectedIndexChanged;
            // 
            // seedBox
            // 
            seedBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            seedBox.Location = new System.Drawing.Point(138, 32);
            seedBox.Margin = new System.Windows.Forms.Padding(2);
            seedBox.MaxLength = 16;
            seedBox.Name = "seedBox";
            seedBox.Size = new System.Drawing.Size(164, 20);
            seedBox.TabIndex = 6;
            seedBox.KeyPress += SeedBox_KeyPress;
            // 
            // generateData
            // 
            generateData.Location = new System.Drawing.Point(16, 170);
            generateData.Margin = new System.Windows.Forms.Padding(2);
            generateData.Name = "generateData";
            generateData.Size = new System.Drawing.Size(285, 28);
            generateData.TabIndex = 5;
            generateData.Text = "Show";
            generateData.UseVisualStyleBackColor = true;
            generateData.Click += GenerateData_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(16, 132);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(45, 15);
            label4.TabIndex = 3;
            label4.Text = "Frames";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(16, 98);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(46, 15);
            label3.TabIndex = 2;
            label3.Text = "Species";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 66);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "Den";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(16, 32);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(32, 15);
            label1.TabIndex = 0;
            label1.Text = "Seed";
            // 
            // DenIVs
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1104, 749);
            Controls.Add(DetailsBox);
            Controls.Add(raidContent);
            Margin = new System.Windows.Forms.Padding(2);
            Name = "DenIVs";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Den Search";
            Load += DenIVs_Load;
            ((System.ComponentModel.ISupportInitialize)raidContent).EndInit();
            DetailsBox.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)maxSpe).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxSpd).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxSpa).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxDef).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxAtk).EndInit();
            ((System.ComponentModel.ISupportInitialize)maxHP).EndInit();
            ((System.ComponentModel.ISupportInitialize)MinSpe).EndInit();
            ((System.ComponentModel.ISupportInitialize)minSpd).EndInit();
            ((System.ComponentModel.ISupportInitialize)minSpa).EndInit();
            ((System.ComponentModel.ISupportInitialize)minDef).EndInit();
            ((System.ComponentModel.ISupportInitialize)minAtk).EndInit();
            ((System.ComponentModel.ISupportInitialize)minHP).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView raidContent;
        private System.Windows.Forms.GroupBox DetailsBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generateData;
        private System.Windows.Forms.TextBox seedBox;
        private System.Windows.Forms.ComboBox speciesList;
        private System.Windows.Forms.ComboBox denBox;
        private System.Windows.Forms.TextBox endFrame;
        private System.Windows.Forms.TextBox startFrame;
        private System.Windows.Forms.NumericUpDown MinSpe;
        private System.Windows.Forms.NumericUpDown minSpd;
        private System.Windows.Forms.NumericUpDown minSpa;
        private System.Windows.Forms.NumericUpDown minDef;
        private System.Windows.Forms.NumericUpDown minAtk;
        private System.Windows.Forms.NumericUpDown minHP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown maxSpe;
        private System.Windows.Forms.NumericUpDown maxSpd;
        private System.Windows.Forms.NumericUpDown maxSpa;
        private System.Windows.Forms.NumericUpDown maxDef;
        private System.Windows.Forms.NumericUpDown maxAtk;
        private System.Windows.Forms.NumericUpDown maxHP;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox genderBox;
        private System.Windows.Forms.ComboBox abilityBox;
        private CheckedComboBox natureBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox shinyBox;
        private System.Windows.Forms.Button resetFilter;
        private System.Windows.Forms.Button applyFilter;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn FrameCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn HPCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn AtkCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpaCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpdCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpeCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn NatureCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn AbilityCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn GenderCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShinyCell;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeedCell;
    }
}