namespace Schalken.PhotoDesktop.WFA
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
            this.star1 = new System.Windows.Forms.Label();
            this.btnPrev = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Label();
            this.star2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.star3 = new System.Windows.Forms.Label();
            this.star4 = new System.Windows.Forms.Label();
            this.star5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            // 
            // star1
            // 
            this.star1.BackColor = System.Drawing.Color.DarkRed;
            this.star1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star1.ImageIndex = 13;
            this.star1.ImageList = this.imageList;
            this.star1.Location = new System.Drawing.Point(0, 0);
            this.star1.Name = "star1";
            this.star1.Size = new System.Drawing.Size(40, 40);
            this.star1.TabIndex = 11;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.DarkRed;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Image = global::Schalken.PhotoDesktop.WFA.Properties.Resources.PD_Prev_t;
            this.btnPrev.Location = new System.Drawing.Point(278, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 40);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.Visible = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DarkRed;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = global::Schalken.PhotoDesktop.WFA.Properties.Resources.pd_next_t1;
            this.btnNext.Location = new System.Drawing.Point(360, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 40);
            this.btnNext.TabIndex = 12;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // star2
            // 
            this.star2.BackColor = System.Drawing.Color.DarkRed;
            this.star2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star2.ImageIndex = 11;
            this.star2.ImageList = this.imageList;
            this.star2.Location = new System.Drawing.Point(40, 0);
            this.star2.Name = "star2";
            this.star2.Size = new System.Drawing.Size(40, 40);
            this.star2.TabIndex = 15;
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
            // star3
            // 
            this.star3.BackColor = System.Drawing.Color.DarkRed;
            this.star3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star3.ImageIndex = 11;
            this.star3.ImageList = this.imageList;
            this.star3.Location = new System.Drawing.Point(80, 0);
            this.star3.Name = "star3";
            this.star3.Size = new System.Drawing.Size(40, 40);
            this.star3.TabIndex = 17;
            // 
            // star4
            // 
            this.star4.BackColor = System.Drawing.Color.DarkRed;
            this.star4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star4.ImageIndex = 11;
            this.star4.ImageList = this.imageList;
            this.star4.Location = new System.Drawing.Point(120, 0);
            this.star4.Name = "star4";
            this.star4.Size = new System.Drawing.Size(40, 40);
            this.star4.TabIndex = 18;
            // 
            // star5
            // 
            this.star5.BackColor = System.Drawing.Color.DarkRed;
            this.star5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star5.ImageIndex = 11;
            this.star5.ImageList = this.imageList;
            this.star5.Location = new System.Drawing.Point(160, 0);
            this.star5.Name = "star5";
            this.star5.Size = new System.Drawing.Size(40, 40);
            this.star5.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkRed;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.ImageIndex = 4;
            this.label1.ImageList = this.imageList;
            this.label1.Location = new System.Drawing.Point(210, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 40);
            this.label1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkRed;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.ImageIndex = 9;
            this.label2.ImageList = this.imageList;
            this.label2.Location = new System.Drawing.Point(319, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 40);
            this.label2.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(400, 40);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.star5);
            this.Controls.Add(this.star4);
            this.Controls.Add(this.star3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.star2);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.star1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimizeBox = false;
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
        private System.Windows.Forms.Label star1;
        private System.Windows.Forms.Label btnNext;
        private System.Windows.Forms.Label btnPrev;
        private System.Windows.Forms.Label star2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label star3;
        private System.Windows.Forms.Label star4;
        private System.Windows.Forms.Label star5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

