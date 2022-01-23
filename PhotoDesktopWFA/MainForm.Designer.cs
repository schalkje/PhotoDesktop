﻿namespace Schalken.PhotoDesktop.WFA
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.photoTimer = new System.Windows.Forms.Timer(this.components);
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageList_16x16 = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.star1 = new WindowsFormsControlLibrary.ImageButton();
            this.star2 = new WindowsFormsControlLibrary.ImageButton();
            this.star3 = new WindowsFormsControlLibrary.ImageButton();
            this.imageList_20x20 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Click for application";
            this.notifyIcon.BalloonTipTitle = "PhotoDesktop";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "PhotoDesktop";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNext,
            this.menuPrevious,
            this.menuOpenFile,
            this.menuOpenFolder,
            this.toolStripSeparator1,
            this.toolStripMenuItem1,
            this.menuSettings,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 170);
            this.contextMenuStrip1.Text = "Menu";
            // 
            // menuNext
            // 
            this.menuNext.Name = "menuNext";
            this.menuNext.Size = new System.Drawing.Size(139, 22);
            this.menuNext.Text = "Next";
            this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
            // 
            // menuPrevious
            // 
            this.menuPrevious.Name = "menuPrevious";
            this.menuPrevious.Size = new System.Drawing.Size(139, 22);
            this.menuPrevious.Text = "Previous";
            // 
            // menuOpenFile
            // 
            this.menuOpenFile.Name = "menuOpenFile";
            this.menuOpenFile.Size = new System.Drawing.Size(139, 22);
            this.menuOpenFile.Text = "Open File";
            // 
            // menuOpenFolder
            // 
            this.menuOpenFolder.Name = "menuOpenFolder";
            this.menuOpenFolder.Size = new System.Drawing.Size(139, 22);
            this.menuOpenFolder.Text = "Open Folder";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.toolStripMenuItem1.Text = "Show";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(139, 22);
            this.menuSettings.Text = "Settings";
            this.menuSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // photoTimer
            // 
            this.photoTimer.Enabled = true;
            this.photoTimer.Interval = 1000;
            this.photoTimer.Tick += new System.EventHandler(this.photoTimer_Tick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Maroon;
            this.imageList.Images.SetKeyName(0, "PD_Prev.png");
            this.imageList.Images.SetKeyName(1, "PD_Prev_active.png");
            this.imageList.Images.SetKeyName(2, "pd_next.png");
            this.imageList.Images.SetKeyName(3, "pd_next_active.png");
            this.imageList.Images.SetKeyName(4, "pd_dislike.png");
            this.imageList.Images.SetKeyName(5, "pd_dislike_active.png");
            this.imageList.Images.SetKeyName(6, "pd_disliked.png");
            this.imageList.Images.SetKeyName(7, "pd_hide.png");
            this.imageList.Images.SetKeyName(8, "pd_hide_active.png");
            this.imageList.Images.SetKeyName(9, "pd_settings.png");
            this.imageList.Images.SetKeyName(10, "pd_settings_active.png");
            this.imageList.Images.SetKeyName(11, "pd_star.png");
            this.imageList.Images.SetKeyName(12, "pd_star_active.png");
            this.imageList.Images.SetKeyName(13, "pd_starred.png");
            this.imageList.Images.SetKeyName(14, "pd_starred_16x16.png");
            // 
            // imageList_16x16
            // 
            this.imageList_16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_16x16.ImageStream")));
            this.imageList_16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_16x16.Images.SetKeyName(0, "pd_star_t_16x16.png");
            this.imageList_16x16.Images.SetKeyName(1, "pd_starred_16x16.png");
            this.imageList_16x16.Images.SetKeyName(2, "pd_dislike_16x16 .png");
            this.imageList_16x16.Images.SetKeyName(3, "pd_settings_16x16.png");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkRed;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.ImageIndex = 11;
            this.label4.ImageList = this.imageList;
            this.label4.Location = new System.Drawing.Point(166, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 16;
            // 
            // star1
            // 
            this.star1.CanbeSelected = false;
            this.star1.FixedSize = true;
            this.star1.ImageKeyActive = null;
            this.star1.ImageKeyDefault = null;
            this.star1.ImageKeySelected = null;
            this.star1.IsSelected = false;
            this.star1.Location = new System.Drawing.Point(0, 0);
            this.star1.Name = "star1";
            this.star1.Size = new System.Drawing.Size(50, 50);
            this.star1.TabIndex = 26;
            // 
            // star2
            // 
            this.star2.CanbeSelected = false;
            this.star2.FixedSize = true;
            this.star2.ImageKeyActive = null;
            this.star2.ImageKeyDefault = null;
            this.star2.ImageKeySelected = null;
            this.star2.IsSelected = false;
            this.star2.Location = new System.Drawing.Point(0, 0);
            this.star2.Name = "star2";
            this.star2.Size = new System.Drawing.Size(50, 50);
            this.star2.TabIndex = 25;
            // 
            // star3
            // 
            this.star3.CanbeSelected = false;
            this.star3.FixedSize = true;
            this.star3.ImageKeyActive = null;
            this.star3.ImageKeyDefault = null;
            this.star3.ImageKeySelected = null;
            this.star3.IsSelected = false;
            this.star3.Location = new System.Drawing.Point(0, 0);
            this.star3.Name = "star3";
            this.star3.Size = new System.Drawing.Size(50, 50);
            this.star3.TabIndex = 24;
            // 
            // imageList_20x20
            // 
            this.imageList_20x20.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_20x20.ImageStream")));
            this.imageList_20x20.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_20x20.Images.SetKeyName(0, "pd_dislike_20x20.png");
            this.imageList_20x20.Images.SetKeyName(1, "pd_settings_20x20.png");
            this.imageList_20x20.Images.SetKeyName(2, "pd_next_20x20.png");
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.ControlBox = false;
            this.Controls.Add(this.star3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.star2);
            this.Controls.Add(this.star1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 100);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 100);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Photo Desktop";
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuNext;
        private System.Windows.Forms.ToolStripMenuItem menuPrevious;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem menuOpenFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.Timer photoTimer;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label4;
        private WindowsFormsControlLibrary.ImageButton star1;
        private WindowsFormsControlLibrary.ImageButton star2;
        private WindowsFormsControlLibrary.ImageButton star3;
        private System.Windows.Forms.ImageList imageList_16x16;
        private System.Windows.Forms.ImageList imageList_20x20;
    }
}

