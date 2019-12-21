namespace PKHeX_Raid_Plugin
{
    partial class RaidList
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
            this.GB_Left = new System.Windows.Forms.GroupBox();
            this.L_Stars = new System.Windows.Forms.Label();
            this.L_Location = new System.Windows.Forms.Label();
            this.L_Ability = new System.Windows.Forms.Label();
            this.L_Nature = new System.Windows.Forms.Label();
            this.L_ShinyInFrames = new System.Windows.Forms.Label();
            this.CHK_Event = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PB_PK1 = new System.Windows.Forms.PictureBox();
            this.CHK_Rare = new System.Windows.Forms.CheckBox();
            this.CHK_Active = new System.Windows.Forms.CheckBox();
            this.L_Spe = new System.Windows.Forms.Label();
            this.L_SpD = new System.Windows.Forms.Label();
            this.L_SpA = new System.Windows.Forms.Label();
            this.L_Def = new System.Windows.Forms.Label();
            this.L_Atk = new System.Windows.Forms.Label();
            this.L_HP = new System.Windows.Forms.Label();
            this.TB_SPE_IV1 = new System.Windows.Forms.TextBox();
            this.TB_DEF_IV1 = new System.Windows.Forms.TextBox();
            this.TB_SPD_IV1 = new System.Windows.Forms.TextBox();
            this.TB_ATK_IV1 = new System.Windows.Forms.TextBox();
            this.TB_SPA_IV1 = new System.Windows.Forms.TextBox();
            this.TB_HP_IV1 = new System.Windows.Forms.TextBox();
            this.L_DenSeed = new System.Windows.Forms.Label();
            this.CB_Den = new System.Windows.Forms.ComboBox();
            this.GB_Right = new System.Windows.Forms.GroupBox();
            this.DenMap = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.L_Shiny = new System.Windows.Forms.Label();
            this.GB_Left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PK1)).BeginInit();
            this.GB_Right.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenMap)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_Left
            // 
            this.GB_Left.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GB_Left.Controls.Add(this.L_Shiny);
            this.GB_Left.Controls.Add(this.label1);
            this.GB_Left.Controls.Add(this.L_Spe);
            this.GB_Left.Controls.Add(this.L_Stars);
            this.GB_Left.Controls.Add(this.L_SpD);
            this.GB_Left.Controls.Add(this.L_Location);
            this.GB_Left.Controls.Add(this.L_SpA);
            this.GB_Left.Controls.Add(this.L_Ability);
            this.GB_Left.Controls.Add(this.TB_SPE_IV1);
            this.GB_Left.Controls.Add(this.L_Def);
            this.GB_Left.Controls.Add(this.TB_SPD_IV1);
            this.GB_Left.Controls.Add(this.L_Nature);
            this.GB_Left.Controls.Add(this.TB_SPA_IV1);
            this.GB_Left.Controls.Add(this.L_Atk);
            this.GB_Left.Controls.Add(this.L_ShinyInFrames);
            this.GB_Left.Controls.Add(this.L_HP);
            this.GB_Left.Controls.Add(this.CHK_Event);
            this.GB_Left.Controls.Add(this.button1);
            this.GB_Left.Controls.Add(this.TB_DEF_IV1);
            this.GB_Left.Controls.Add(this.PB_PK1);
            this.GB_Left.Controls.Add(this.CHK_Rare);
            this.GB_Left.Controls.Add(this.TB_ATK_IV1);
            this.GB_Left.Controls.Add(this.CHK_Active);
            this.GB_Left.Controls.Add(this.TB_HP_IV1);
            this.GB_Left.Controls.Add(this.L_DenSeed);
            this.GB_Left.Controls.Add(this.CB_Den);
            this.GB_Left.Location = new System.Drawing.Point(9, 10);
            this.GB_Left.Margin = new System.Windows.Forms.Padding(2);
            this.GB_Left.Name = "GB_Left";
            this.GB_Left.Padding = new System.Windows.Forms.Padding(2);
            this.GB_Left.Size = new System.Drawing.Size(206, 419);
            this.GB_Left.TabIndex = 0;
            this.GB_Left.TabStop = false;
            this.GB_Left.Text = "Den List";
            // 
            // L_Stars
            // 
            this.L_Stars.Location = new System.Drawing.Point(112, 193);
            this.L_Stars.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Stars.Name = "L_Stars";
            this.L_Stars.Size = new System.Drawing.Size(70, 21);
            this.L_Stars.TabIndex = 19;
            this.L_Stars.Text = "*****";
            this.L_Stars.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // L_Location
            // 
            this.L_Location.AutoSize = true;
            this.L_Location.Location = new System.Drawing.Point(53, 53);
            this.L_Location.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Location.Name = "L_Location";
            this.L_Location.Size = new System.Drawing.Size(54, 13);
            this.L_Location.TabIndex = 18;
            this.L_Location.Text = "$Location";
            // 
            // L_Ability
            // 
            this.L_Ability.AutoSize = true;
            this.L_Ability.Location = new System.Drawing.Point(94, 257);
            this.L_Ability.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Ability.Name = "L_Ability";
            this.L_Ability.Size = new System.Drawing.Size(37, 13);
            this.L_Ability.TabIndex = 13;
            this.L_Ability.Text = "Ability:";
            // 
            // L_Nature
            // 
            this.L_Nature.AutoSize = true;
            this.L_Nature.Location = new System.Drawing.Point(94, 236);
            this.L_Nature.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Nature.Name = "L_Nature";
            this.L_Nature.Size = new System.Drawing.Size(42, 13);
            this.L_Nature.TabIndex = 12;
            this.L_Nature.Text = "Nature:";
            // 
            // L_ShinyInFrames
            // 
            this.L_ShinyInFrames.AutoSize = true;
            this.L_ShinyInFrames.Location = new System.Drawing.Point(8, 103);
            this.L_ShinyInFrames.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_ShinyInFrames.Name = "L_ShinyInFrames";
            this.L_ShinyInFrames.Size = new System.Drawing.Size(81, 13);
            this.L_ShinyInFrames.TabIndex = 10;
            this.L_ShinyInFrames.Text = "Shiny in frames:";
            // 
            // CHK_Event
            // 
            this.CHK_Event.AutoCheck = false;
            this.CHK_Event.AutoSize = true;
            this.CHK_Event.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_Event.Location = new System.Drawing.Point(12, 174);
            this.CHK_Event.Margin = new System.Windows.Forms.Padding(2);
            this.CHK_Event.Name = "CHK_Event";
            this.CHK_Event.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CHK_Event.Size = new System.Drawing.Size(78, 17);
            this.CHK_Event.TabIndex = 9;
            this.CHK_Event.Text = "Event Pool";
            this.CHK_Event.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 387);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "Raid Calculator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ShowDenIVs);
            // 
            // PB_PK1
            // 
            this.PB_PK1.BackColor = System.Drawing.Color.Transparent;
            this.PB_PK1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PB_PK1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_PK1.Location = new System.Drawing.Point(112, 134);
            this.PB_PK1.Name = "PB_PK1";
            this.PB_PK1.Size = new System.Drawing.Size(70, 58);
            this.PB_PK1.TabIndex = 6;
            this.PB_PK1.TabStop = false;
            // 
            // CHK_Rare
            // 
            this.CHK_Rare.AutoCheck = false;
            this.CHK_Rare.AutoSize = true;
            this.CHK_Rare.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_Rare.Location = new System.Drawing.Point(12, 155);
            this.CHK_Rare.Margin = new System.Windows.Forms.Padding(2);
            this.CHK_Rare.Name = "CHK_Rare";
            this.CHK_Rare.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CHK_Rare.Size = new System.Drawing.Size(73, 17);
            this.CHK_Rare.TabIndex = 5;
            this.CHK_Rare.Text = "Rare Pool";
            this.CHK_Rare.UseVisualStyleBackColor = true;
            // 
            // CHK_Active
            // 
            this.CHK_Active.AutoCheck = false;
            this.CHK_Active.AutoSize = true;
            this.CHK_Active.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CHK_Active.Location = new System.Drawing.Point(12, 135);
            this.CHK_Active.Margin = new System.Windows.Forms.Padding(2);
            this.CHK_Active.Name = "CHK_Active";
            this.CHK_Active.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CHK_Active.Size = new System.Drawing.Size(79, 17);
            this.CHK_Active.TabIndex = 4;
            this.CHK_Active.Text = "Den Active";
            this.CHK_Active.UseVisualStyleBackColor = true;
            // 
            // L_Spe
            // 
            this.L_Spe.Location = new System.Drawing.Point(5, 338);
            this.L_Spe.Name = "L_Spe";
            this.L_Spe.Size = new System.Drawing.Size(50, 20);
            this.L_Spe.TabIndex = 22;
            this.L_Spe.Text = "Spe:";
            this.L_Spe.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_SpD
            // 
            this.L_SpD.Location = new System.Drawing.Point(5, 317);
            this.L_SpD.Name = "L_SpD";
            this.L_SpD.Size = new System.Drawing.Size(50, 20);
            this.L_SpD.TabIndex = 21;
            this.L_SpD.Text = "SpD:";
            this.L_SpD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_SpA
            // 
            this.L_SpA.Location = new System.Drawing.Point(5, 296);
            this.L_SpA.Name = "L_SpA";
            this.L_SpA.Size = new System.Drawing.Size(50, 20);
            this.L_SpA.TabIndex = 20;
            this.L_SpA.Text = "SpA:";
            this.L_SpA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Def
            // 
            this.L_Def.Location = new System.Drawing.Point(5, 275);
            this.L_Def.Name = "L_Def";
            this.L_Def.Size = new System.Drawing.Size(50, 20);
            this.L_Def.TabIndex = 19;
            this.L_Def.Text = "Def:";
            this.L_Def.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Atk
            // 
            this.L_Atk.Location = new System.Drawing.Point(5, 254);
            this.L_Atk.Name = "L_Atk";
            this.L_Atk.Size = new System.Drawing.Size(50, 20);
            this.L_Atk.TabIndex = 18;
            this.L_Atk.Text = "Atk:";
            this.L_Atk.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_HP
            // 
            this.L_HP.Location = new System.Drawing.Point(5, 233);
            this.L_HP.Name = "L_HP";
            this.L_HP.Size = new System.Drawing.Size(50, 20);
            this.L_HP.TabIndex = 17;
            this.L_HP.Text = "HP:";
            this.L_HP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TB_SPE_IV1
            // 
            this.TB_SPE_IV1.Location = new System.Drawing.Point(56, 338);
            this.TB_SPE_IV1.Name = "TB_SPE_IV1";
            this.TB_SPE_IV1.ReadOnly = true;
            this.TB_SPE_IV1.Size = new System.Drawing.Size(20, 20);
            this.TB_SPE_IV1.TabIndex = 15;
            // 
            // TB_DEF_IV1
            // 
            this.TB_DEF_IV1.Location = new System.Drawing.Point(56, 275);
            this.TB_DEF_IV1.Name = "TB_DEF_IV1";
            this.TB_DEF_IV1.ReadOnly = true;
            this.TB_DEF_IV1.Size = new System.Drawing.Size(20, 20);
            this.TB_DEF_IV1.TabIndex = 9;
            // 
            // TB_SPD_IV1
            // 
            this.TB_SPD_IV1.Location = new System.Drawing.Point(56, 317);
            this.TB_SPD_IV1.Name = "TB_SPD_IV1";
            this.TB_SPD_IV1.ReadOnly = true;
            this.TB_SPD_IV1.Size = new System.Drawing.Size(20, 20);
            this.TB_SPD_IV1.TabIndex = 13;
            // 
            // TB_ATK_IV1
            // 
            this.TB_ATK_IV1.Location = new System.Drawing.Point(56, 254);
            this.TB_ATK_IV1.Name = "TB_ATK_IV1";
            this.TB_ATK_IV1.ReadOnly = true;
            this.TB_ATK_IV1.Size = new System.Drawing.Size(20, 20);
            this.TB_ATK_IV1.TabIndex = 6;
            // 
            // TB_SPA_IV1
            // 
            this.TB_SPA_IV1.Location = new System.Drawing.Point(56, 296);
            this.TB_SPA_IV1.Name = "TB_SPA_IV1";
            this.TB_SPA_IV1.ReadOnly = true;
            this.TB_SPA_IV1.Size = new System.Drawing.Size(20, 20);
            this.TB_SPA_IV1.TabIndex = 11;
            // 
            // TB_HP_IV1
            // 
            this.TB_HP_IV1.Location = new System.Drawing.Point(56, 233);
            this.TB_HP_IV1.Name = "TB_HP_IV1";
            this.TB_HP_IV1.ReadOnly = true;
            this.TB_HP_IV1.Size = new System.Drawing.Size(20, 20);
            this.TB_HP_IV1.TabIndex = 1;
            // 
            // L_DenSeed
            // 
            this.L_DenSeed.AutoSize = true;
            this.L_DenSeed.Location = new System.Drawing.Point(53, 70);
            this.L_DenSeed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_DenSeed.Name = "L_DenSeed";
            this.L_DenSeed.Size = new System.Drawing.Size(38, 13);
            this.L_DenSeed.TabIndex = 1;
            this.L_DenSeed.Text = "$Seed";
            // 
            // CB_Den
            // 
            this.CB_Den.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Den.FormattingEnabled = true;
            this.CB_Den.Items.AddRange(new object[] {
            "Den 1",
            "Den 2",
            "Den 3",
            "Den 4",
            "Den 5",
            "Den 6",
            "Den 7",
            "Den 8",
            "Den 9",
            "Den 10",
            "Den 11",
            "Den 12",
            "Den 13",
            "Den 14",
            "Den 15",
            "Den 16",
            "Den 17",
            "Den 18",
            "Den 19",
            "Den 20",
            "Den 21",
            "Den 22",
            "Den 23",
            "Den 24",
            "Den 25",
            "Den 26",
            "Den 27",
            "Den 28",
            "Den 29",
            "Den 30",
            "Den 31",
            "Den 32",
            "Den 33",
            "Den 34",
            "Den 35",
            "Den 36",
            "Den 37",
            "Den 38",
            "Den 39",
            "Den 40",
            "Den 41",
            "Den 42",
            "Den 43",
            "Den 44",
            "Den 45",
            "Den 46",
            "Den 47",
            "Den 48",
            "Den 49",
            "Den 50",
            "Den 51",
            "Den 52",
            "Den 53",
            "Den 54",
            "Den 55",
            "Den 56",
            "Den 57",
            "Den 58",
            "Den 59",
            "Den 60",
            "Den 61",
            "Den 62",
            "Den 63",
            "Den 64",
            "Den 65",
            "Den 66",
            "Den 67",
            "Den 68",
            "Den 69",
            "Den 70",
            "Den 71",
            "Den 72",
            "Den 73",
            "Den 74",
            "Den 75",
            "Den 76",
            "Den 77",
            "Den 78",
            "Den 79",
            "Den 80",
            "Den 81",
            "Den 82",
            "Den 83",
            "Den 84",
            "Den 85",
            "Den 86",
            "Den 87",
            "Den 88",
            "Den 89",
            "Den 90",
            "Den 91",
            "Den 92",
            "Den 93",
            "Den 94",
            "Den 95",
            "Den 96",
            "Den 97",
            "Den 98",
            "Den 99"});
            this.CB_Den.Location = new System.Drawing.Point(56, 28);
            this.CB_Den.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Den.Name = "CB_Den";
            this.CB_Den.Size = new System.Drawing.Size(124, 21);
            this.CB_Den.TabIndex = 0;
            this.CB_Den.SelectedIndexChanged += new System.EventHandler(this.ChangeDenIndex);
            // 
            // GB_Right
            // 
            this.GB_Right.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GB_Right.Controls.Add(this.DenMap);
            this.GB_Right.Location = new System.Drawing.Point(220, 10);
            this.GB_Right.Margin = new System.Windows.Forms.Padding(2);
            this.GB_Right.Name = "GB_Right";
            this.GB_Right.Padding = new System.Windows.Forms.Padding(2);
            this.GB_Right.Size = new System.Drawing.Size(176, 419);
            this.GB_Right.TabIndex = 1;
            this.GB_Right.TabStop = false;
            this.GB_Right.Text = "Den Map";
            // 
            // DenMap
            // 
            this.DenMap.BackgroundImage = global::PKHeX_Raid_Plugin.Properties.Resources.map;
            this.DenMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DenMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DenMap.Location = new System.Drawing.Point(2, 15);
            this.DenMap.Margin = new System.Windows.Forms.Padding(2);
            this.DenMap.Name = "DenMap";
            this.DenMap.Size = new System.Drawing.Size(172, 402);
            this.DenMap.TabIndex = 0;
            this.DenMap.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Den:";
            // 
            // L_Shiny
            // 
            this.L_Shiny.AutoSize = true;
            this.L_Shiny.Location = new System.Drawing.Point(94, 279);
            this.L_Shiny.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.L_Shiny.Name = "L_Shiny";
            this.L_Shiny.Size = new System.Drawing.Size(36, 13);
            this.L_Shiny.TabIndex = 24;
            this.L_Shiny.Text = "Shiny!";
            // 
            // RaidList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 440);
            this.Controls.Add(this.GB_Right);
            this.Controls.Add(this.GB_Left);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RaidList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Raid List";
            this.GB_Left.ResumeLayout(false);
            this.GB_Left.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PK1)).EndInit();
            this.GB_Right.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DenMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Left;
        private System.Windows.Forms.ComboBox CB_Den;
        private System.Windows.Forms.Label L_DenSeed;
        private System.Windows.Forms.PictureBox PB_PK1;
        private System.Windows.Forms.CheckBox CHK_Rare;
        private System.Windows.Forms.CheckBox CHK_Active;
        private System.Windows.Forms.Label L_Spe;
        private System.Windows.Forms.Label L_SpD;
        private System.Windows.Forms.Label L_SpA;
        private System.Windows.Forms.Label L_Def;
        private System.Windows.Forms.Label L_Atk;
        private System.Windows.Forms.Label L_HP;
        private System.Windows.Forms.TextBox TB_SPE_IV1;
        private System.Windows.Forms.TextBox TB_DEF_IV1;
        private System.Windows.Forms.TextBox TB_SPD_IV1;
        private System.Windows.Forms.TextBox TB_ATK_IV1;
        private System.Windows.Forms.TextBox TB_SPA_IV1;
        private System.Windows.Forms.TextBox TB_HP_IV1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox CHK_Event;
        private System.Windows.Forms.Label L_Ability;
        private System.Windows.Forms.Label L_Nature;
        private System.Windows.Forms.Label L_ShinyInFrames;
        private System.Windows.Forms.Label L_Location;
        private System.Windows.Forms.GroupBox GB_Right;
        private System.Windows.Forms.PictureBox DenMap;
        private System.Windows.Forms.Label L_Stars;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_Shiny;
    }
}