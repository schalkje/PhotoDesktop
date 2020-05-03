namespace Schalken.PhotoDesktop.WFA
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tbBaseFolder = new System.Windows.Forms.TextBox();
            this.tbFolder = new System.Windows.Forms.TextBox();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.lbFolders = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTimerValue = new System.Windows.Forms.NumericUpDown();
            this.rbSeconds = new System.Windows.Forms.RadioButton();
            this.rbMinutes = new System.Windows.Forms.RadioButton();
            this.rbHours = new System.Windows.Forms.RadioButton();
            this.rbStartupOnly = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbOrderRandom = new System.Windows.Forms.RadioButton();
            this.rbOrderSequential = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rbSwitchSameTime = new System.Windows.Forms.RadioButton();
            this.rbSwitchAlternately = new System.Windows.Forms.RadioButton();
            this.cbChangeOnStartup = new System.Windows.Forms.CheckBox();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerValue)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBaseFolder
            // 
            this.tbBaseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseFolder.Location = new System.Drawing.Point(202, 288);
            this.tbBaseFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbBaseFolder.Name = "tbBaseFolder";
            this.tbBaseFolder.Size = new System.Drawing.Size(970, 29);
            this.tbBaseFolder.TabIndex = 7;
            this.tbBaseFolder.Text = "C:\\OneDrive\\Afbeeldingen\\";
            // 
            // tbFolder
            // 
            this.tbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolder.Location = new System.Drawing.Point(202, 250);
            this.tbFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(970, 29);
            this.tbFolder.TabIndex = 6;
            this.tbFolder.Text = "C:\\OneDrive\\Afbeeldingen\\Background Selection";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFolder.Location = new System.Drawing.Point(1181, 250);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(100, 70);
            this.btnAddFolder.TabIndex = 8;
            this.btnAddFolder.Text = "Add";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // lbFolders
            // 
            this.lbFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFolders.FormattingEnabled = true;
            this.lbFolders.ItemHeight = 24;
            this.lbFolders.Location = new System.Drawing.Point(15, 325);
            this.lbFolders.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbFolders.Name = "lbFolders";
            this.lbFolders.Size = new System.Drawing.Size(1268, 316);
            this.lbFolders.TabIndex = 9;
            this.lbFolders.Click += new System.EventHandler(this.lbFolders_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(15, 250);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 70);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Location = new System.Drawing.Point(122, 253);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 292);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Base:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Timer:";
            // 
            // nudTimerValue
            // 
            this.nudTimerValue.Location = new System.Drawing.Point(319, 79);
            this.nudTimerValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nudTimerValue.Name = "nudTimerValue";
            this.nudTimerValue.Size = new System.Drawing.Size(147, 29);
            this.nudTimerValue.TabIndex = 14;
            this.nudTimerValue.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // rbSeconds
            // 
            this.rbSeconds.AutoSize = true;
            this.rbSeconds.Checked = true;
            this.rbSeconds.Location = new System.Drawing.Point(128, 79);
            this.rbSeconds.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSeconds.Name = "rbSeconds";
            this.rbSeconds.Size = new System.Drawing.Size(111, 29);
            this.rbSeconds.TabIndex = 15;
            this.rbSeconds.TabStop = true;
            this.rbSeconds.Text = "seconds";
            this.rbSeconds.UseVisualStyleBackColor = true;
            // 
            // rbMinutes
            // 
            this.rbMinutes.AutoSize = true;
            this.rbMinutes.Location = new System.Drawing.Point(128, 116);
            this.rbMinutes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMinutes.Name = "rbMinutes";
            this.rbMinutes.Size = new System.Drawing.Size(105, 29);
            this.rbMinutes.TabIndex = 16;
            this.rbMinutes.Text = "minutes";
            this.rbMinutes.UseVisualStyleBackColor = true;
            // 
            // rbHours
            // 
            this.rbHours.AutoSize = true;
            this.rbHours.Location = new System.Drawing.Point(128, 154);
            this.rbHours.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbHours.Name = "rbHours";
            this.rbHours.Size = new System.Drawing.Size(86, 29);
            this.rbHours.TabIndex = 17;
            this.rbHours.Text = "hours";
            this.rbHours.UseVisualStyleBackColor = true;
            // 
            // rbStartupOnly
            // 
            this.rbStartupOnly.AutoSize = true;
            this.rbStartupOnly.Location = new System.Drawing.Point(128, 192);
            this.rbStartupOnly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbStartupOnly.Name = "rbStartupOnly";
            this.rbStartupOnly.Size = new System.Drawing.Size(137, 29);
            this.rbStartupOnly.TabIndex = 18;
            this.rbStartupOnly.Text = "startup only";
            this.rbStartupOnly.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(1154, 655);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(128, 41);
            this.btnOk.TabIndex = 19;
            this.btnOk.Text = "Save";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(17, 655);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 38);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rbOrderRandom
            // 
            this.rbOrderRandom.AutoSize = true;
            this.rbOrderRandom.Location = new System.Drawing.Point(658, 82);
            this.rbOrderRandom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbOrderRandom.Name = "rbOrderRandom";
            this.rbOrderRandom.Size = new System.Drawing.Size(110, 29);
            this.rbOrderRandom.TabIndex = 21;
            this.rbOrderRandom.TabStop = true;
            this.rbOrderRandom.Text = "Random";
            this.rbOrderRandom.UseVisualStyleBackColor = true;
            // 
            // rbOrderSequential
            // 
            this.rbOrderSequential.AutoSize = true;
            this.rbOrderSequential.Location = new System.Drawing.Point(658, 120);
            this.rbOrderSequential.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbOrderSequential.Name = "rbOrderSequential";
            this.rbOrderSequential.Size = new System.Drawing.Size(130, 29);
            this.rbOrderSequential.TabIndex = 22;
            this.rbOrderSequential.TabStop = true;
            this.rbOrderSequential.Text = "Sequential";
            this.rbOrderSequential.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 25);
            this.label4.TabIndex = 23;
            this.label4.Text = "Order:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(535, 157);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 25);
            this.label5.TabIndex = 24;
            this.label5.Text = "Multi switch:";
            // 
            // rbSwitchSameTime
            // 
            this.rbSwitchSameTime.AutoSize = true;
            this.rbSwitchSameTime.Location = new System.Drawing.Point(658, 157);
            this.rbSwitchSameTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSwitchSameTime.Name = "rbSwitchSameTime";
            this.rbSwitchSameTime.Size = new System.Drawing.Size(130, 29);
            this.rbSwitchSameTime.TabIndex = 25;
            this.rbSwitchSameTime.TabStop = true;
            this.rbSwitchSameTime.Text = "Same time";
            this.rbSwitchSameTime.UseVisualStyleBackColor = true;
            // 
            // rbSwitchAlternately
            // 
            this.rbSwitchAlternately.AutoSize = true;
            this.rbSwitchAlternately.Location = new System.Drawing.Point(658, 190);
            this.rbSwitchAlternately.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbSwitchAlternately.Name = "rbSwitchAlternately";
            this.rbSwitchAlternately.Size = new System.Drawing.Size(129, 29);
            this.rbSwitchAlternately.TabIndex = 26;
            this.rbSwitchAlternately.TabStop = true;
            this.rbSwitchAlternately.Text = "Alternately";
            this.rbSwitchAlternately.UseVisualStyleBackColor = true;
            // 
            // cbChangeOnStartup
            // 
            this.cbChangeOnStartup.AutoSize = true;
            this.cbChangeOnStartup.Location = new System.Drawing.Point(540, 22);
            this.cbChangeOnStartup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbChangeOnStartup.Name = "cbChangeOnStartup";
            this.cbChangeOnStartup.Size = new System.Drawing.Size(199, 29);
            this.cbChangeOnStartup.TabIndex = 27;
            this.cbChangeOnStartup.Text = "Change on startup";
            this.cbChangeOnStartup.UseVisualStyleBackColor = true;
            // 
            // cbStartWithWindows
            // 
            this.cbStartWithWindows.AutoSize = true;
            this.cbStartWithWindows.Location = new System.Drawing.Point(24, 22);
            this.cbStartWithWindows.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbStartWithWindows.Name = "cbStartWithWindows";
            this.cbStartWithWindows.Size = new System.Drawing.Size(204, 29);
            this.cbStartWithWindows.TabIndex = 28;
            this.cbStartWithWindows.Text = "Start with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            this.cbStartWithWindows.CheckedChanged += new System.EventHandler(this.cbStartWithWindows_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1296, 710);
            this.Controls.Add(this.cbStartWithWindows);
            this.Controls.Add(this.cbChangeOnStartup);
            this.Controls.Add(this.rbSwitchAlternately);
            this.Controls.Add(this.rbSwitchSameTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbOrderSequential);
            this.Controls.Add(this.rbOrderRandom);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.rbStartupOnly);
            this.Controls.Add(this.rbHours);
            this.Controls.Add(this.rbMinutes);
            this.Controls.Add(this.rbSeconds);
            this.Controls.Add(this.nudTimerValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbFolders);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.tbBaseFolder);
            this.Controls.Add(this.tbFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbBaseFolder;
        private System.Windows.Forms.TextBox tbFolder;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.ListBox lbFolders;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTimerValue;
        private System.Windows.Forms.RadioButton rbSeconds;
        private System.Windows.Forms.RadioButton rbMinutes;
        private System.Windows.Forms.RadioButton rbHours;
        private System.Windows.Forms.RadioButton rbStartupOnly;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbOrderRandom;
        private System.Windows.Forms.RadioButton rbOrderSequential;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbSwitchSameTime;
        private System.Windows.Forms.RadioButton rbSwitchAlternately;
        private System.Windows.Forms.CheckBox cbChangeOnStartup;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}