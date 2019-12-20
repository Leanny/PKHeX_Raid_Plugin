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
    partial class SeedFinder
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinSpe = new System.Windows.Forms.NumericUpDown();
            this.minSpd = new System.Windows.Forms.NumericUpDown();
            this.minSpa = new System.Windows.Forms.NumericUpDown();
            this.minDef = new System.Windows.Forms.NumericUpDown();
            this.minAtk = new System.Windows.Forms.NumericUpDown();
            this.minHP = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.seedSlow = new System.Windows.Forms.Button();
            this.seedFast = new System.Windows.Forms.Button();
            this.PIDBox = new System.Windows.Forms.TextBox();
            this.ECBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SeedResult = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.MinSpe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSpd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSpa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAtk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHP)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "EC";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "PID";
            // 
            // MinSpe
            // 
            this.MinSpe.Location = new System.Drawing.Point(87, 199);
            this.MinSpe.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.MinSpe.Name = "MinSpe";
            this.MinSpe.Size = new System.Drawing.Size(97, 22);
            this.MinSpe.TabIndex = 26;
            this.MinSpe.Enter += new System.EventHandler(this.minHP_Enter);
            // 
            // minSpd
            // 
            this.minSpd.Location = new System.Drawing.Point(87, 174);
            this.minSpd.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.minSpd.Name = "minSpd";
            this.minSpd.Size = new System.Drawing.Size(97, 22);
            this.minSpd.TabIndex = 25;
            this.minSpd.Enter += new System.EventHandler(this.minHP_Enter);
            // 
            // minSpa
            // 
            this.minSpa.Location = new System.Drawing.Point(87, 149);
            this.minSpa.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.minSpa.Name = "minSpa";
            this.minSpa.Size = new System.Drawing.Size(97, 22);
            this.minSpa.TabIndex = 24;
            this.minSpa.Enter += new System.EventHandler(this.minHP_Enter);
            // 
            // minDef
            // 
            this.minDef.Location = new System.Drawing.Point(87, 124);
            this.minDef.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.minDef.Name = "minDef";
            this.minDef.Size = new System.Drawing.Size(97, 22);
            this.minDef.TabIndex = 23;
            this.minDef.Enter += new System.EventHandler(this.minHP_Enter);
            // 
            // minAtk
            // 
            this.minAtk.Location = new System.Drawing.Point(87, 99);
            this.minAtk.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.minAtk.Name = "minAtk";
            this.minAtk.Size = new System.Drawing.Size(97, 22);
            this.minAtk.TabIndex = 22;
            this.minAtk.Enter += new System.EventHandler(this.minHP_Enter);
            // 
            // minHP
            // 
            this.minHP.Location = new System.Drawing.Point(87, 74);
            this.minHP.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.minHP.Name = "minHP";
            this.minHP.Size = new System.Drawing.Size(97, 22);
            this.minHP.TabIndex = 21;
            this.minHP.Enter += new System.EventHandler(this.minHP_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 17);
            this.label13.TabIndex = 20;
            this.label13.Text = "SPE";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 179);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "SPD";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 17);
            this.label11.TabIndex = 18;
            this.label11.Text = "SPA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "DEF";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "ATK";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "HP";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.seedSlow);
            this.groupBox1.Controls.Add(this.seedFast);
            this.groupBox1.Controls.Add(this.PIDBox);
            this.groupBox1.Controls.Add(this.ECBox);
            this.groupBox1.Controls.Add(this.minDef);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.MinSpe);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.minSpd);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.minSpa);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.minAtk);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.minHP);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 306);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PKMN Information";
            // 
            // seedSlow
            // 
            this.seedSlow.Location = new System.Drawing.Point(17, 266);
            this.seedSlow.Name = "seedSlow";
            this.seedSlow.Size = new System.Drawing.Size(167, 23);
            this.seedSlow.TabIndex = 30;
            this.seedSlow.Text = "Calculate Seed (Slow)";
            this.seedSlow.UseVisualStyleBackColor = true;
            this.seedSlow.Click += new System.EventHandler(this.seedSlow_Click);
            // 
            // seedFast
            // 
            this.seedFast.Location = new System.Drawing.Point(17, 234);
            this.seedFast.Name = "seedFast";
            this.seedFast.Size = new System.Drawing.Size(167, 23);
            this.seedFast.TabIndex = 29;
            this.seedFast.Text = "Calculate Seed (Fast)";
            this.seedFast.UseVisualStyleBackColor = true;
            this.seedFast.Click += new System.EventHandler(this.seedFast_Click);
            // 
            // PIDBox
            // 
            this.PIDBox.Location = new System.Drawing.Point(87, 49);
            this.PIDBox.MaxLength = 8;
            this.PIDBox.Name = "PIDBox";
            this.PIDBox.Size = new System.Drawing.Size(97, 22);
            this.PIDBox.TabIndex = 1;
            this.PIDBox.Enter += new System.EventHandler(this.ECBox_Enter);
            this.PIDBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.seedBox_KeyPress);
            // 
            // ECBox
            // 
            this.ECBox.Location = new System.Drawing.Point(87, 24);
            this.ECBox.MaxLength = 8;
            this.ECBox.Name = "ECBox";
            this.ECBox.Size = new System.Drawing.Size(97, 22);
            this.ECBox.TabIndex = 0;
            this.ECBox.Enter += new System.EventHandler(this.ECBox_Enter);
            this.ECBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.seedBox_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SeedResult);
            this.groupBox2.Location = new System.Drawing.Point(12, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 76);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculated Seed";
            // 
            // SeedResult
            // 
            this.SeedResult.Location = new System.Drawing.Point(17, 33);
            this.SeedResult.Name = "SeedResult";
            this.SeedResult.Size = new System.Drawing.Size(167, 22);
            this.SeedResult.TabIndex = 0;
            // 
            // SeedFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 408);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(240, 455);
            this.MinimumSize = new System.Drawing.Size(240, 455);
            this.Name = "SeedFinder";
            this.ShowIcon = false;
            this.Text = "SeedFinder";
            ((System.ComponentModel.ISupportInitialize)(this.MinSpe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSpd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minSpa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minAtk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minHP)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox PIDBox;
        private System.Windows.Forms.TextBox ECBox;
        private System.Windows.Forms.Button seedSlow;
        private System.Windows.Forms.Button seedFast;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox SeedResult;
    }
}