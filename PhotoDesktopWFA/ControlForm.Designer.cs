﻿namespace Schalken.PhotoDesktop.WFA
{
    partial class ControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.imageList_16x16 = new System.Windows.Forms.ImageList(this.components);
            this.btnPrev = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.star1 = new WindowsFormsControlLibrary.ImageButton();
            this.star2 = new WindowsFormsControlLibrary.ImageButton();
            this.star3 = new WindowsFormsControlLibrary.ImageButton();
            this.star4 = new WindowsFormsControlLibrary.ImageButton();
            this.star5 = new WindowsFormsControlLibrary.ImageButton();
            this.btnDislike = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Label();
            this.imageList_20x20 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
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
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.DarkRed;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Image = global::Schalken.PhotoDesktop.WFA.Properties.Resources.PD_Prev_t;
            this.btnPrev.Location = new System.Drawing.Point(330, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(20, 20);
            this.btnPrev.TabIndex = 14;
            this.btnPrev.Visible = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.DarkRed;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(368, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(20, 20);
            this.btnNext.TabIndex = 12;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
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
            this.star1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.star1.CanbeSelected = true;
            this.star1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star1.FixedSize = true;
            this.star1.ImageKey = "pd_star_t_16x16.png";
            this.star1.ImageKeyActive = "pd_starred_16x16.png";
            this.star1.ImageKeyDefault = "pd_star_t_16x16.png";
            this.star1.ImageKeySelected = "pd_starred_16x16.png";
            this.star1.ImageList = this.imageList_16x16;
            this.star1.IsSelected = false;
            this.star1.Location = new System.Drawing.Point(0, 4);
            this.star1.Name = "star1";
            this.star1.Size = new System.Drawing.Size(16, 16);
            this.star1.TabIndex = 11;
            this.star1.Visible = false;
            this.star1.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // star2
            // 
            this.star2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.star2.CanbeSelected = true;
            this.star2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star2.FixedSize = true;
            this.star2.ImageKey = "pd_star_t_16x16.png";
            this.star2.ImageKeyActive = "pd_starred_16x16.png";
            this.star2.ImageKeyDefault = "pd_star_t_16x16.png";
            this.star2.ImageKeySelected = "pd_starred_16x16.png";
            this.star2.ImageList = this.imageList_16x16;
            this.star2.IsSelected = false;
            this.star2.Location = new System.Drawing.Point(16, 4);
            this.star2.Name = "star2";
            this.star2.Size = new System.Drawing.Size(16, 16);
            this.star2.TabIndex = 15;
            this.star2.Visible = false;
            this.star2.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // star3
            // 
            this.star3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.star3.CanbeSelected = false;
            this.star3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star3.FixedSize = true;
            this.star3.ImageKey = "pd_star_t_16x16.png";
            this.star3.ImageKeyActive = "pd_starred_16x16.png";
            this.star3.ImageKeyDefault = "pd_star_t_16x16.png";
            this.star3.ImageKeySelected = "pd_starred_16x16.png";
            this.star3.ImageList = this.imageList_16x16;
            this.star3.IsSelected = false;
            this.star3.Location = new System.Drawing.Point(32, 4);
            this.star3.Name = "star3";
            this.star3.Size = new System.Drawing.Size(16, 16);
            this.star3.TabIndex = 17;
            this.star3.Visible = false;
            this.star3.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // star4
            // 
            this.star4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.star4.CanbeSelected = false;
            this.star4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star4.FixedSize = true;
            this.star4.ImageKey = "pd_star_t_16x16.png";
            this.star4.ImageKeyActive = "pd_starred_16x16.png";
            this.star4.ImageKeyDefault = "pd_star_t_16x16.png";
            this.star4.ImageKeySelected = "pd_starred_16x16.png";
            this.star4.ImageList = this.imageList_16x16;
            this.star4.IsSelected = false;
            this.star4.Location = new System.Drawing.Point(48, 4);
            this.star4.Name = "star4";
            this.star4.Size = new System.Drawing.Size(16, 16);
            this.star4.TabIndex = 18;
            this.star4.Visible = false;
            this.star4.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // star5
            // 
            this.star5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.star5.CanbeSelected = false;
            this.star5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.star5.FixedSize = true;
            this.star5.ImageKey = "pd_star_t_16x16.png";
            this.star5.ImageKeyActive = "pd_dislike_16x16 .png";
            this.star5.ImageKeyDefault = "pd_star_t_16x16.png";
            this.star5.ImageKeySelected = "pd_starred_16x16.png";
            this.star5.ImageList = this.imageList_16x16;
            this.star5.IsSelected = false;
            this.star5.Location = new System.Drawing.Point(64, 4);
            this.star5.Name = "star5";
            this.star5.Size = new System.Drawing.Size(16, 16);
            this.star5.TabIndex = 19;
            this.star5.Visible = false;
            this.star5.Click += new System.EventHandler(this.btnStar_Click);
            // 
            // btnDislike
            // 
            this.btnDislike.BackColor = System.Drawing.Color.DarkRed;
            this.btnDislike.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDislike.ImageKey = "pd_dislike_16x16 .png";
            this.btnDislike.ImageList = this.imageList_16x16;
            this.btnDislike.Location = new System.Drawing.Point(132, 74);
            this.btnDislike.Name = "btnDislike";
            this.btnDislike.Size = new System.Drawing.Size(12, 12);
            this.btnDislike.TabIndex = 20;
            this.btnDislike.Visible = false;
            this.btnDislike.Click += new System.EventHandler(this.btnDislike_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.DarkRed;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.ImageIndex = 3;
            this.btnSettings.ImageList = this.imageList_16x16;
            this.btnSettings.Location = new System.Drawing.Point(353, 8);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(12, 12);
            this.btnSettings.TabIndex = 21;
            this.btnSettings.Visible = false;
            this.btnSettings.Click += new System.EventHandler(this.menuSettings_Click);
            // 
            // imageList_20x20
            // 
            this.imageList_20x20.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_20x20.ImageStream")));
            this.imageList_20x20.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_20x20.Images.SetKeyName(0, "pd_dislike_20x20.png");
            this.imageList_20x20.Images.SetKeyName(1, "pd_settings_20x20.png");
            this.imageList_20x20.Images.SetKeyName(2, "pd_next_20x20.png");
            // 
            // ControlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(400, 100);
            this.ControlBox = false;
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnDislike);
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
            this.MaximumSize = new System.Drawing.Size(400, 100);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 100);
            this.Name = "ControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Photo Desktop";
            this.Click += new System.EventHandler(this.ControlForm_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlForm_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label btnNext;
        private System.Windows.Forms.Label btnPrev;
        private System.Windows.Forms.Label label4;
        private WindowsFormsControlLibrary.ImageButton star1;
        private WindowsFormsControlLibrary.ImageButton star2;
        private WindowsFormsControlLibrary.ImageButton star3;
        private WindowsFormsControlLibrary.ImageButton star4;
        private WindowsFormsControlLibrary.ImageButton star5;
        private System.Windows.Forms.Label btnDislike;
        private System.Windows.Forms.Label btnSettings;
        private System.Windows.Forms.ImageList imageList_16x16;
        private System.Windows.Forms.ImageList imageList_20x20;
    }
}
