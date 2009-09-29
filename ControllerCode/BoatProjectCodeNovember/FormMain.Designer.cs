namespace BoatProjectCodeNovember
{
    partial class FormMain
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBarRudder = new System.Windows.Forms.TrackBar();
            this.maskedTextBoxInitialRudderDelay = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBoxConsecutiveRudderDelay = new System.Windows.Forms.MaskedTextBox();
            this.buttonSheetOut = new System.Windows.Forms.Button();
            this.buttonSheetIn = new System.Windows.Forms.Button();
            this.buttonTrimIn = new System.Windows.Forms.Button();
            this.buttonTrimOut = new System.Windows.Forms.Button();
            this.buttonTopsailDouse = new System.Windows.Forms.Button();
            this.buttonTopsailHoist = new System.Windows.Forms.Button();
            this.buttonHeadsailDouse = new System.Windows.Forms.Button();
            this.buttonHeadsailHoist = new System.Windows.Forms.Button();
            this.comboBoxCOMPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonKeelStarboard = new System.Windows.Forms.Button();
            this.buttonKeelPort = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRudder)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sheet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Jib Trim";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Topsail Hoist";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(302, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Headsail Hoist";
            // 
            // trackBarRudder
            // 
            this.trackBarRudder.LargeChange = 1;
            this.trackBarRudder.Location = new System.Drawing.Point(7, 98);
            this.trackBarRudder.Maximum = 4700;
            this.trackBarRudder.Minimum = 900;
            this.trackBarRudder.Name = "trackBarRudder";
            this.trackBarRudder.Size = new System.Drawing.Size(197, 45);
            this.trackBarRudder.TabIndex = 5;
            this.trackBarRudder.TickFrequency = 200;
            this.trackBarRudder.Value = 2700;
            this.trackBarRudder.ValueChanged += new System.EventHandler(this.trackBarRudder_ValueChanged);
            // 
            // maskedTextBoxInitialRudderDelay
            // 
            this.maskedTextBoxInitialRudderDelay.Location = new System.Drawing.Point(44, 161);
            this.maskedTextBoxInitialRudderDelay.Name = "maskedTextBoxInitialRudderDelay";
            this.maskedTextBoxInitialRudderDelay.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxInitialRudderDelay.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "InitialRudderDelay";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(203, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "ConsecutiveRudderDelay";
            // 
            // maskedTextBoxConsecutiveRudderDelay
            // 
            this.maskedTextBoxConsecutiveRudderDelay.Location = new System.Drawing.Point(203, 161);
            this.maskedTextBoxConsecutiveRudderDelay.Name = "maskedTextBoxConsecutiveRudderDelay";
            this.maskedTextBoxConsecutiveRudderDelay.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxConsecutiveRudderDelay.TabIndex = 8;
            // 
            // buttonSheetOut
            // 
            this.buttonSheetOut.Location = new System.Drawing.Point(21, 29);
            this.buttonSheetOut.Name = "buttonSheetOut";
            this.buttonSheetOut.Size = new System.Drawing.Size(26, 23);
            this.buttonSheetOut.TabIndex = 10;
            this.buttonSheetOut.Text = "^";
            this.buttonSheetOut.UseVisualStyleBackColor = true;
            // 
            // buttonSheetIn
            // 
            this.buttonSheetIn.Location = new System.Drawing.Point(21, 58);
            this.buttonSheetIn.Name = "buttonSheetIn";
            this.buttonSheetIn.Size = new System.Drawing.Size(26, 23);
            this.buttonSheetIn.TabIndex = 11;
            this.buttonSheetIn.Text = "V";
            this.buttonSheetIn.UseVisualStyleBackColor = true;
            // 
            // buttonTrimIn
            // 
            this.buttonTrimIn.Location = new System.Drawing.Point(86, 58);
            this.buttonTrimIn.Name = "buttonTrimIn";
            this.buttonTrimIn.Size = new System.Drawing.Size(26, 23);
            this.buttonTrimIn.TabIndex = 13;
            this.buttonTrimIn.Text = "A";
            this.buttonTrimIn.UseVisualStyleBackColor = true;
            this.buttonTrimIn.Click += new System.EventHandler(this.buttonTrimIn_Click);
            // 
            // buttonTrimOut
            // 
            this.buttonTrimOut.Location = new System.Drawing.Point(86, 29);
            this.buttonTrimOut.Name = "buttonTrimOut";
            this.buttonTrimOut.Size = new System.Drawing.Size(26, 23);
            this.buttonTrimOut.TabIndex = 12;
            this.buttonTrimOut.Text = "Q";
            this.buttonTrimOut.UseVisualStyleBackColor = true;
            // 
            // buttonTopsailDouse
            // 
            this.buttonTopsailDouse.Location = new System.Drawing.Point(252, 58);
            this.buttonTopsailDouse.Name = "buttonTopsailDouse";
            this.buttonTopsailDouse.Size = new System.Drawing.Size(26, 23);
            this.buttonTopsailDouse.TabIndex = 17;
            this.buttonTopsailDouse.Text = "D";
            this.buttonTopsailDouse.UseVisualStyleBackColor = true;
            // 
            // buttonTopsailHoist
            // 
            this.buttonTopsailHoist.Location = new System.Drawing.Point(252, 29);
            this.buttonTopsailHoist.Name = "buttonTopsailHoist";
            this.buttonTopsailHoist.Size = new System.Drawing.Size(26, 23);
            this.buttonTopsailHoist.TabIndex = 16;
            this.buttonTopsailHoist.Text = "E";
            this.buttonTopsailHoist.UseVisualStyleBackColor = true;
            // 
            // buttonHeadsailDouse
            // 
            this.buttonHeadsailDouse.Location = new System.Drawing.Point(326, 58);
            this.buttonHeadsailDouse.Name = "buttonHeadsailDouse";
            this.buttonHeadsailDouse.Size = new System.Drawing.Size(26, 23);
            this.buttonHeadsailDouse.TabIndex = 19;
            this.buttonHeadsailDouse.Text = "F";
            this.buttonHeadsailDouse.UseVisualStyleBackColor = true;
            // 
            // buttonHeadsailHoist
            // 
            this.buttonHeadsailHoist.Location = new System.Drawing.Point(326, 29);
            this.buttonHeadsailHoist.Name = "buttonHeadsailHoist";
            this.buttonHeadsailHoist.Size = new System.Drawing.Size(26, 23);
            this.buttonHeadsailHoist.TabIndex = 18;
            this.buttonHeadsailHoist.Text = "R";
            this.buttonHeadsailHoist.UseVisualStyleBackColor = true;
            // 
            // comboBoxCOMPort
            // 
            this.comboBoxCOMPort.FormattingEnabled = true;
            this.comboBoxCOMPort.Location = new System.Drawing.Point(396, 74);
            this.comboBoxCOMPort.Name = "comboBoxCOMPort";
            this.comboBoxCOMPort.Size = new System.Drawing.Size(75, 21);
            this.comboBoxCOMPort.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(137, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Top Sail Trim";
            // 
            // buttonKeelStarboard
            // 
            this.buttonKeelStarboard.Location = new System.Drawing.Point(153, 58);
            this.buttonKeelStarboard.Name = "buttonKeelStarboard";
            this.buttonKeelStarboard.Size = new System.Drawing.Size(26, 23);
            this.buttonKeelStarboard.TabIndex = 14;
            this.buttonKeelStarboard.Text = "S";
            this.buttonKeelStarboard.UseVisualStyleBackColor = true;
            // 
            // buttonKeelPort
            // 
            this.buttonKeelPort.Location = new System.Drawing.Point(153, 29);
            this.buttonKeelPort.Name = "buttonKeelPort";
            this.buttonKeelPort.Size = new System.Drawing.Size(26, 23);
            this.buttonKeelPort.TabIndex = 15;
            this.buttonKeelPort.Text = "W";
            this.buttonKeelPort.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "COM Port:";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(398, 101);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(73, 23);
            this.buttonConnect.TabIndex = 22;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 193);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxCOMPort);
            this.Controls.Add(this.buttonHeadsailDouse);
            this.Controls.Add(this.buttonHeadsailHoist);
            this.Controls.Add(this.buttonTopsailDouse);
            this.Controls.Add(this.buttonTopsailHoist);
            this.Controls.Add(this.buttonKeelPort);
            this.Controls.Add(this.buttonKeelStarboard);
            this.Controls.Add(this.buttonTrimIn);
            this.Controls.Add(this.buttonTrimOut);
            this.Controls.Add(this.buttonSheetIn);
            this.Controls.Add(this.buttonSheetOut);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBoxConsecutiveRudderDelay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxInitialRudderDelay);
            this.Controls.Add(this.trackBarRudder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.Text = "Boat Control";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRudder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBarRudder;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxInitialRudderDelay;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxConsecutiveRudderDelay;
        private System.Windows.Forms.Button buttonSheetOut;
        private System.Windows.Forms.Button buttonSheetIn;
        private System.Windows.Forms.Button buttonTrimIn;
        private System.Windows.Forms.Button buttonTrimOut;
        private System.Windows.Forms.Button buttonTopsailDouse;
        private System.Windows.Forms.Button buttonTopsailHoist;
        private System.Windows.Forms.Button buttonHeadsailDouse;
        private System.Windows.Forms.Button buttonHeadsailHoist;
        private System.Windows.Forms.ComboBox comboBoxCOMPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonKeelStarboard;
        private System.Windows.Forms.Button buttonKeelPort;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

