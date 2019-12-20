/*
 MIT License

Copyright (c) 2019 Leanny

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
namespace PKHeX_Raid_Plugin
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.natureLbl = new System.Windows.Forms.Label();
            this.abilityLbl = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.shinyframes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EventBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.StarLbl = new System.Windows.Forms.Label();
            this.rareBox = new System.Windows.Forms.CheckBox();
            this.activeBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_SPE_IV1 = new System.Windows.Forms.TextBox();
            this.TB_DEF_IV1 = new System.Windows.Forms.TextBox();
            this.TB_SPD_IV1 = new System.Windows.Forms.TextBox();
            this.TB_ATK_IV1 = new System.Windows.Forms.TextBox();
            this.TB_SPA_IV1 = new System.Windows.Forms.TextBox();
            this.TB_HP_IV1 = new System.Windows.Forms.TextBox();
            this.denSeed = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.denBox = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DenMap = new System.Windows.Forms.PictureBox();
            this.PB_PK1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DenMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PK1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.locationLabel);
            this.groupBox1.Controls.Add(this.natureLbl);
            this.groupBox1.Controls.Add(this.abilityLbl);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.shinyframes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EventBox);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.StarLbl);
            this.groupBox1.Controls.Add(this.PB_PK1);
            this.groupBox1.Controls.Add(this.rareBox);
            this.groupBox1.Controls.Add(this.activeBox);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.denSeed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.denBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 533);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Den List";
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(10, 75);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(0, 17);
            this.locationLabel.TabIndex = 18;
            // 
            // natureLbl
            // 
            this.natureLbl.AutoSize = true;
            this.natureLbl.Location = new System.Drawing.Point(150, 260);
            this.natureLbl.Name = "natureLbl";
            this.natureLbl.Size = new System.Drawing.Size(0, 17);
            this.natureLbl.TabIndex = 17;
            // 
            // abilityLbl
            // 
            this.abilityLbl.AutoSize = true;
            this.abilityLbl.Location = new System.Drawing.Point(150, 290);
            this.abilityLbl.Name = "abilityLbl";
            this.abilityLbl.Size = new System.Drawing.Size(0, 17);
            this.abilityLbl.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 290);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 13;
            this.label11.Text = "Ability";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 260);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 17);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nature";
            // 
            // shinyframes
            // 
            this.shinyframes.AutoSize = true;
            this.shinyframes.Location = new System.Drawing.Point(150, 230);
            this.shinyframes.Name = "shinyframes";
            this.shinyframes.Size = new System.Drawing.Size(0, 17);
            this.shinyframes.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Shiny in frames:";
            // 
            // EventBox
            // 
            this.EventBox.AutoSize = true;
            this.EventBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EventBox.Location = new System.Drawing.Point(6, 200);
            this.EventBox.Name = "EventBox";
            this.EventBox.Size = new System.Drawing.Size(98, 21);
            this.EventBox.TabIndex = 9;
            this.EventBox.Text = "Event Pool";
            this.EventBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(245, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Raid Calculator";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StarLbl
            // 
            this.StarLbl.AutoSize = true;
            this.StarLbl.Location = new System.Drawing.Point(153, 208);
            this.StarLbl.Name = "StarLbl";
            this.StarLbl.Size = new System.Drawing.Size(0, 17);
            this.StarLbl.TabIndex = 7;
            // 
            // rareBox
            // 
            this.rareBox.AutoSize = true;
            this.rareBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rareBox.Location = new System.Drawing.Point(6, 170);
            this.rareBox.Name = "rareBox";
            this.rareBox.Size = new System.Drawing.Size(93, 21);
            this.rareBox.TabIndex = 5;
            this.rareBox.Text = "Rare Pool";
            this.rareBox.UseVisualStyleBackColor = true;
            // 
            // activeBox
            // 
            this.activeBox.AutoSize = true;
            this.activeBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.activeBox.Location = new System.Drawing.Point(6, 140);
            this.activeBox.Name = "activeBox";
            this.activeBox.Size = new System.Drawing.Size(98, 21);
            this.activeBox.TabIndex = 4;
            this.activeBox.Text = "Den Active";
            this.activeBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TB_SPE_IV1);
            this.groupBox2.Controls.Add(this.TB_DEF_IV1);
            this.groupBox2.Controls.Add(this.TB_SPD_IV1);
            this.groupBox2.Controls.Add(this.TB_ATK_IV1);
            this.groupBox2.Controls.Add(this.TB_SPA_IV1);
            this.groupBox2.Controls.Add(this.TB_HP_IV1);
            this.groupBox2.Location = new System.Drawing.Point(10, 319);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(245, 141);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IVs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Spe:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 74);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "SpD:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "SpA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Def:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Atk:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "HP:";
            // 
            // TB_SPE_IV1
            // 
            this.TB_SPE_IV1.Location = new System.Drawing.Point(191, 103);
            this.TB_SPE_IV1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_SPE_IV1.Name = "TB_SPE_IV1";
            this.TB_SPE_IV1.ReadOnly = true;
            this.TB_SPE_IV1.Size = new System.Drawing.Size(25, 22);
            this.TB_SPE_IV1.TabIndex = 15;
            // 
            // TB_DEF_IV1
            // 
            this.TB_DEF_IV1.Location = new System.Drawing.Point(51, 103);
            this.TB_DEF_IV1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_DEF_IV1.Name = "TB_DEF_IV1";
            this.TB_DEF_IV1.ReadOnly = true;
            this.TB_DEF_IV1.Size = new System.Drawing.Size(25, 22);
            this.TB_DEF_IV1.TabIndex = 9;
            // 
            // TB_SPD_IV1
            // 
            this.TB_SPD_IV1.Location = new System.Drawing.Point(191, 71);
            this.TB_SPD_IV1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_SPD_IV1.Name = "TB_SPD_IV1";
            this.TB_SPD_IV1.ReadOnly = true;
            this.TB_SPD_IV1.Size = new System.Drawing.Size(25, 22);
            this.TB_SPD_IV1.TabIndex = 13;
            // 
            // TB_ATK_IV1
            // 
            this.TB_ATK_IV1.Location = new System.Drawing.Point(51, 71);
            this.TB_ATK_IV1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_ATK_IV1.Name = "TB_ATK_IV1";
            this.TB_ATK_IV1.ReadOnly = true;
            this.TB_ATK_IV1.Size = new System.Drawing.Size(25, 22);
            this.TB_ATK_IV1.TabIndex = 6;
            // 
            // TB_SPA_IV1
            // 
            this.TB_SPA_IV1.Location = new System.Drawing.Point(191, 39);
            this.TB_SPA_IV1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_SPA_IV1.Name = "TB_SPA_IV1";
            this.TB_SPA_IV1.ReadOnly = true;
            this.TB_SPA_IV1.Size = new System.Drawing.Size(25, 22);
            this.TB_SPA_IV1.TabIndex = 11;
            // 
            // TB_HP_IV1
            // 
            this.TB_HP_IV1.Location = new System.Drawing.Point(51, 39);
            this.TB_HP_IV1.Margin = new System.Windows.Forms.Padding(4);
            this.TB_HP_IV1.Name = "TB_HP_IV1";
            this.TB_HP_IV1.ReadOnly = true;
            this.TB_HP_IV1.Size = new System.Drawing.Size(25, 22);
            this.TB_HP_IV1.TabIndex = 1;
            // 
            // denSeed
            // 
            this.denSeed.AutoSize = true;
            this.denSeed.Location = new System.Drawing.Point(88, 113);
            this.denSeed.Name = "denSeed";
            this.denSeed.Size = new System.Drawing.Size(0, 17);
            this.denSeed.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Den Seed:";
            // 
            // denBox
            // 
            this.denBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.denBox.FormattingEnabled = true;
            this.denBox.Items.AddRange(new object[] {
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
            this.denBox.Location = new System.Drawing.Point(6, 35);
            this.denBox.Name = "denBox";
            this.denBox.Size = new System.Drawing.Size(263, 24);
            this.denBox.TabIndex = 0;
            this.denBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DenMap);
            this.groupBox3.Location = new System.Drawing.Point(293, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 533);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Den Map";
            // 
            // DenMap
            // 
            this.DenMap.BackgroundImage = global::PKHeX_Raid_Plugin.Properties.Resources.map;
            this.DenMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DenMap.Location = new System.Drawing.Point(6, 21);
            this.DenMap.Name = "DenMap";
            this.DenMap.Size = new System.Drawing.Size(223, 506);
            this.DenMap.TabIndex = 0;
            this.DenMap.TabStop = false;
            // 
            // PB_PK1
            // 
            this.PB_PK1.BackColor = System.Drawing.Color.Transparent;
            this.PB_PK1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PB_PK1.Location = new System.Drawing.Point(150, 135);
            this.PB_PK1.Margin = new System.Windows.Forms.Padding(4);
            this.PB_PK1.Name = "PB_PK1";
            this.PB_PK1.Size = new System.Drawing.Size(91, 69);
            this.PB_PK1.TabIndex = 6;
            this.PB_PK1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 553);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Raid List";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DenMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PK1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox denBox;
        private System.Windows.Forms.Label denSeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PB_PK1;
        private System.Windows.Forms.CheckBox rareBox;
        private System.Windows.Forms.CheckBox activeBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TB_SPE_IV1;
        private System.Windows.Forms.TextBox TB_DEF_IV1;
        private System.Windows.Forms.TextBox TB_SPD_IV1;
        private System.Windows.Forms.TextBox TB_ATK_IV1;
        private System.Windows.Forms.TextBox TB_SPA_IV1;
        private System.Windows.Forms.TextBox TB_HP_IV1;
        private System.Windows.Forms.Label StarLbl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox EventBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label shinyframes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label natureLbl;
        private System.Windows.Forms.Label abilityLbl;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox DenMap;
    }
}