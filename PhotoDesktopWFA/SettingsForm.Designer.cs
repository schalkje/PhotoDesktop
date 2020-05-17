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
            this.nudTimerValue = new System.Windows.Forms.NumericUpDown();
            this.rbSeconds = new System.Windows.Forms.RadioButton();
            this.rbMinutes = new System.Windows.Forms.RadioButton();
            this.rbHours = new System.Windows.Forms.RadioButton();
            this.rbStartupOnly = new System.Windows.Forms.RadioButton();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rbOrderRandom = new System.Windows.Forms.RadioButton();
            this.rbOrderSequential = new System.Windows.Forms.RadioButton();
            this.rbSwitchSameTime = new System.Windows.Forms.RadioButton();
            this.rbSwitchAlternately = new System.Windows.Forms.RadioButton();
            this.cbChangeOnStartup = new System.Windows.Forms.CheckBox();
            this.cbStartWithWindows = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cbLogonImage = new System.Windows.Forms.CheckBox();
            this.gbOrder = new System.Windows.Forms.GroupBox();
            this.gbMultiSwitch = new System.Windows.Forms.GroupBox();
            this.rbSwitchRotate = new System.Windows.Forms.RadioButton();
            this.gbTimer = new System.Windows.Forms.GroupBox();
            this.gbLogonImage = new System.Windows.Forms.GroupBox();
            this.btnOpenExplorerOnLogonImageLocation = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lbDebug = new System.Windows.Forms.ListBox();
            this.btnTest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerValue)).BeginInit();
            this.gbOrder.SuspendLayout();
            this.gbMultiSwitch.SuspendLayout();
            this.gbTimer.SuspendLayout();
            this.gbLogonImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBaseFolder
            // 
            this.tbBaseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBaseFolder.Location = new System.Drawing.Point(202, 288);
            this.tbBaseFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tbBaseFolder.Name = "tbBaseFolder";
            this.tbBaseFolder.Size = new System.Drawing.Size(970, 20);
            this.tbBaseFolder.TabIndex = 7;
            this.tbBaseFolder.Text = "C:\\OneDrive\\Afbeeldingen\\";
            // 
            // tbFolder
            // 
            this.tbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFolder.Location = new System.Drawing.Point(202, 250);
            this.tbFolder.Margin = new System.Windows.Forms.Padding(4);
            this.tbFolder.Name = "tbFolder";
            this.tbFolder.Size = new System.Drawing.Size(970, 20);
            this.tbFolder.TabIndex = 6;
            this.tbFolder.Text = "C:\\OneDrive\\Afbeeldingen\\Background Selection";
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFolder.Location = new System.Drawing.Point(1181, 250);
            this.btnAddFolder.Margin = new System.Windows.Forms.Padding(4);
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
            this.lbFolders.Location = new System.Drawing.Point(15, 325);
            this.lbFolders.Margin = new System.Windows.Forms.Padding(4);
            this.lbFolders.Name = "lbFolders";
            this.lbFolders.Size = new System.Drawing.Size(1268, 316);
            this.lbFolders.TabIndex = 9;
            this.lbFolders.Click += new System.EventHandler(this.lbFolders_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(15, 250);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
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
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 292);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Base:";
            // 
            // nudTimerValue
            // 
            this.nudTimerValue.Location = new System.Drawing.Point(144, 16);
            this.nudTimerValue.Margin = new System.Windows.Forms.Padding(4);
            this.nudTimerValue.Name = "nudTimerValue";
            this.nudTimerValue.Size = new System.Drawing.Size(100, 20);
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
            this.rbSeconds.Location = new System.Drawing.Point(7, 19);
            this.rbSeconds.Margin = new System.Windows.Forms.Padding(4);
            this.rbSeconds.Name = "rbSeconds";
            this.rbSeconds.Size = new System.Drawing.Size(65, 17);
            this.rbSeconds.TabIndex = 15;
            this.rbSeconds.Text = "seconds";
            this.rbSeconds.UseVisualStyleBackColor = true;
            // 
            // rbMinutes
            // 
            this.rbMinutes.AutoSize = true;
            this.rbMinutes.Checked = true;
            this.rbMinutes.Location = new System.Drawing.Point(7, 44);
            this.rbMinutes.Margin = new System.Windows.Forms.Padding(4);
            this.rbMinutes.Name = "rbMinutes";
            this.rbMinutes.Size = new System.Drawing.Size(61, 17);
            this.rbMinutes.TabIndex = 16;
            this.rbMinutes.TabStop = true;
            this.rbMinutes.Text = "minutes";
            this.rbMinutes.UseVisualStyleBackColor = true;
            // 
            // rbHours
            // 
            this.rbHours.AutoSize = true;
            this.rbHours.Location = new System.Drawing.Point(7, 69);
            this.rbHours.Margin = new System.Windows.Forms.Padding(4);
            this.rbHours.Name = "rbHours";
            this.rbHours.Size = new System.Drawing.Size(51, 17);
            this.rbHours.TabIndex = 17;
            this.rbHours.Text = "hours";
            this.rbHours.UseVisualStyleBackColor = true;
            // 
            // rbStartupOnly
            // 
            this.rbStartupOnly.AutoSize = true;
            this.rbStartupOnly.Location = new System.Drawing.Point(7, 114);
            this.rbStartupOnly.Margin = new System.Windows.Forms.Padding(4);
            this.rbStartupOnly.Name = "rbStartupOnly";
            this.rbStartupOnly.Size = new System.Drawing.Size(79, 17);
            this.rbStartupOnly.TabIndex = 18;
            this.rbStartupOnly.Text = "startup only";
            this.rbStartupOnly.UseVisualStyleBackColor = true;
            this.rbStartupOnly.CheckedChanged += new System.EventHandler(this.rbStartupOnly_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(1154, 655);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 38);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // rbOrderRandom
            // 
            this.rbOrderRandom.AutoSize = true;
            this.rbOrderRandom.Checked = true;
            this.rbOrderRandom.Location = new System.Drawing.Point(7, 21);
            this.rbOrderRandom.Margin = new System.Windows.Forms.Padding(4);
            this.rbOrderRandom.Name = "rbOrderRandom";
            this.rbOrderRandom.Size = new System.Drawing.Size(65, 17);
            this.rbOrderRandom.TabIndex = 21;
            this.rbOrderRandom.TabStop = true;
            this.rbOrderRandom.Text = "Random";
            this.rbOrderRandom.UseVisualStyleBackColor = true;
            // 
            // rbOrderSequential
            // 
            this.rbOrderSequential.AutoSize = true;
            this.rbOrderSequential.Location = new System.Drawing.Point(7, 46);
            this.rbOrderSequential.Margin = new System.Windows.Forms.Padding(4);
            this.rbOrderSequential.Name = "rbOrderSequential";
            this.rbOrderSequential.Size = new System.Drawing.Size(75, 17);
            this.rbOrderSequential.TabIndex = 22;
            this.rbOrderSequential.Text = "Sequential";
            this.rbOrderSequential.UseVisualStyleBackColor = true;
            // 
            // rbSwitchSameTime
            // 
            this.rbSwitchSameTime.AutoSize = true;
            this.rbSwitchSameTime.Checked = true;
            this.rbSwitchSameTime.Location = new System.Drawing.Point(7, 23);
            this.rbSwitchSameTime.Margin = new System.Windows.Forms.Padding(4);
            this.rbSwitchSameTime.Name = "rbSwitchSameTime";
            this.rbSwitchSameTime.Size = new System.Drawing.Size(74, 17);
            this.rbSwitchSameTime.TabIndex = 25;
            this.rbSwitchSameTime.TabStop = true;
            this.rbSwitchSameTime.Text = "Same time";
            this.rbSwitchSameTime.UseVisualStyleBackColor = true;
            // 
            // rbSwitchAlternately
            // 
            this.rbSwitchAlternately.AutoSize = true;
            this.rbSwitchAlternately.Location = new System.Drawing.Point(7, 48);
            this.rbSwitchAlternately.Margin = new System.Windows.Forms.Padding(4);
            this.rbSwitchAlternately.Name = "rbSwitchAlternately";
            this.rbSwitchAlternately.Size = new System.Drawing.Size(74, 17);
            this.rbSwitchAlternately.TabIndex = 26;
            this.rbSwitchAlternately.Text = "Alternately";
            this.rbSwitchAlternately.UseVisualStyleBackColor = true;
            // 
            // cbChangeOnStartup
            // 
            this.cbChangeOnStartup.AutoSize = true;
            this.cbChangeOnStartup.Location = new System.Drawing.Point(540, 22);
            this.cbChangeOnStartup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbChangeOnStartup.Name = "cbChangeOnStartup";
            this.cbChangeOnStartup.Size = new System.Drawing.Size(113, 17);
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
            this.cbStartWithWindows.Size = new System.Drawing.Size(117, 17);
            this.cbStartWithWindows.TabIndex = 28;
            this.cbStartWithWindows.Text = "Start with Windows";
            this.cbStartWithWindows.UseVisualStyleBackColor = true;
            this.cbStartWithWindows.CheckedChanged += new System.EventHandler(this.cbStartWithWindows_CheckedChanged);
            // 
            // cbLogonImage
            // 
            this.cbLogonImage.AutoSize = true;
            this.cbLogonImage.Location = new System.Drawing.Point(8, 22);
            this.cbLogonImage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbLogonImage.Name = "cbLogonImage";
            this.cbLogonImage.Size = new System.Drawing.Size(117, 17);
            this.cbLogonImage.TabIndex = 29;
            this.cbLogonImage.Text = "Create logon image";
            this.cbLogonImage.UseVisualStyleBackColor = true;
            // 
            // gbOrder
            // 
            this.gbOrder.Controls.Add(this.rbOrderRandom);
            this.gbOrder.Controls.Add(this.rbOrderSequential);
            this.gbOrder.Location = new System.Drawing.Point(291, 60);
            this.gbOrder.Name = "gbOrder";
            this.gbOrder.Size = new System.Drawing.Size(200, 73);
            this.gbOrder.TabIndex = 30;
            this.gbOrder.TabStop = false;
            this.gbOrder.Text = "Order";
            // 
            // gbMultiSwitch
            // 
            this.gbMultiSwitch.Controls.Add(this.rbSwitchRotate);
            this.gbMultiSwitch.Controls.Add(this.rbSwitchAlternately);
            this.gbMultiSwitch.Controls.Add(this.rbSwitchSameTime);
            this.gbMultiSwitch.Location = new System.Drawing.Point(291, 139);
            this.gbMultiSwitch.Name = "gbMultiSwitch";
            this.gbMultiSwitch.Size = new System.Drawing.Size(200, 104);
            this.gbMultiSwitch.TabIndex = 31;
            this.gbMultiSwitch.TabStop = false;
            this.gbMultiSwitch.Text = "Multi switch";
            // 
            // rbSwitchRotate
            // 
            this.rbSwitchRotate.AutoSize = true;
            this.rbSwitchRotate.Location = new System.Drawing.Point(8, 73);
            this.rbSwitchRotate.Margin = new System.Windows.Forms.Padding(4);
            this.rbSwitchRotate.Name = "rbSwitchRotate";
            this.rbSwitchRotate.Size = new System.Drawing.Size(57, 17);
            this.rbSwitchRotate.TabIndex = 27;
            this.rbSwitchRotate.Text = "Rotate";
            this.rbSwitchRotate.UseVisualStyleBackColor = true;
            // 
            // gbTimer
            // 
            this.gbTimer.Controls.Add(this.rbSeconds);
            this.gbTimer.Controls.Add(this.rbMinutes);
            this.gbTimer.Controls.Add(this.rbHours);
            this.gbTimer.Controls.Add(this.rbStartupOnly);
            this.gbTimer.Controls.Add(this.nudTimerValue);
            this.gbTimer.Location = new System.Drawing.Point(24, 60);
            this.gbTimer.Name = "gbTimer";
            this.gbTimer.Size = new System.Drawing.Size(261, 154);
            this.gbTimer.TabIndex = 32;
            this.gbTimer.TabStop = false;
            this.gbTimer.Text = "Timer";
            // 
            // gbLogonImage
            // 
            this.gbLogonImage.Controls.Add(this.btnOpenExplorerOnLogonImageLocation);
            this.gbLogonImage.Controls.Add(this.cbLogonImage);
            this.gbLogonImage.Location = new System.Drawing.Point(497, 60);
            this.gbLogonImage.Name = "gbLogonImage";
            this.gbLogonImage.Size = new System.Drawing.Size(200, 154);
            this.gbLogonImage.TabIndex = 33;
            this.gbLogonImage.TabStop = false;
            this.gbLogonImage.Text = "Logon image";
            // 
            // btnOpenExplorerOnLogonImageLocation
            // 
            this.btnOpenExplorerOnLogonImageLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenExplorerOnLogonImageLocation.Location = new System.Drawing.Point(8, 106);
            this.btnOpenExplorerOnLogonImageLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenExplorerOnLogonImageLocation.Name = "btnOpenExplorerOnLogonImageLocation";
            this.btnOpenExplorerOnLogonImageLocation.Size = new System.Drawing.Size(185, 38);
            this.btnOpenExplorerOnLogonImageLocation.TabIndex = 34;
            this.btnOpenExplorerOnLogonImageLocation.Text = "Open Explorer";
            this.btnOpenExplorerOnLogonImageLocation.UseVisualStyleBackColor = true;
            this.btnOpenExplorerOnLogonImageLocation.Click += new System.EventHandler(this.btnOpenExplorerOnLogonImageLocation_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Location = new System.Drawing.Point(951, 13);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(185, 38);
            this.btnNext.TabIndex = 35;
            this.btnNext.Text = "-->";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrevious.Location = new System.Drawing.Point(758, 13);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(185, 38);
            this.btnPrevious.TabIndex = 36;
            this.btnPrevious.Text = "<--";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lbDebug
            // 
            this.lbDebug.FormattingEnabled = true;
            this.lbDebug.Location = new System.Drawing.Point(758, 76);
            this.lbDebug.Name = "lbDebug";
            this.lbDebug.Size = new System.Drawing.Size(378, 134);
            this.lbDebug.TabIndex = 37;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(1144, 13);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(137, 38);
            this.btnTest.TabIndex = 38;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1296, 710);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.lbDebug);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.gbLogonImage);
            this.Controls.Add(this.gbTimer);
            this.Controls.Add(this.gbMultiSwitch);
            this.Controls.Add(this.gbOrder);
            this.Controls.Add(this.cbStartWithWindows);
            this.Controls.Add(this.cbChangeOnStartup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbFolders);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.tbBaseFolder);
            this.Controls.Add(this.tbFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Settings_FormClosing);
            this.Shown += new System.EventHandler(this.Settings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudTimerValue)).EndInit();
            this.gbOrder.ResumeLayout(false);
            this.gbOrder.PerformLayout();
            this.gbMultiSwitch.ResumeLayout(false);
            this.gbMultiSwitch.PerformLayout();
            this.gbTimer.ResumeLayout(false);
            this.gbTimer.PerformLayout();
            this.gbLogonImage.ResumeLayout(false);
            this.gbLogonImage.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown nudTimerValue;
        private System.Windows.Forms.RadioButton rbSeconds;
        private System.Windows.Forms.RadioButton rbMinutes;
        private System.Windows.Forms.RadioButton rbHours;
        private System.Windows.Forms.RadioButton rbStartupOnly;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.RadioButton rbOrderRandom;
        private System.Windows.Forms.RadioButton rbOrderSequential;
        private System.Windows.Forms.RadioButton rbSwitchSameTime;
        private System.Windows.Forms.RadioButton rbSwitchAlternately;
        private System.Windows.Forms.CheckBox cbChangeOnStartup;
        private System.Windows.Forms.CheckBox cbStartWithWindows;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox cbLogonImage;
        private System.Windows.Forms.GroupBox gbOrder;
        private System.Windows.Forms.GroupBox gbMultiSwitch;
        private System.Windows.Forms.GroupBox gbTimer;
        private System.Windows.Forms.GroupBox gbLogonImage;
        private System.Windows.Forms.Button btnOpenExplorerOnLogonImageLocation;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.ListBox lbDebug;
        private System.Windows.Forms.RadioButton rbSwitchRotate;
        private System.Windows.Forms.Button btnTest;
    }
}