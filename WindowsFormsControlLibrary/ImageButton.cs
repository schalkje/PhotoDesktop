using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Drawing.Design;

namespace WindowsFormsControlLibrary
{
    public partial class ImageButton : Label
    {
        #region hide properties
        // hide unnecessary properties

        //[Obsolete("Don't use this", true)]
        //private new string ImageKey
        //{
        //    get { return base.ImageKey; }
        //    set { base.ImageKey = value; }
        //}


        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = "";
            }
        }

        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }

            set
            {
                base.AutoSize = false;
            }
        }
        #endregion

        public new ImageList ImageList
        {
            get
            {
                return base.ImageList;
            }
            set
            {
                base.ImageList = value;

                // on first setup initialize image indexes
                if (imageKeyActive == null &&
                    imageKeyDefault == null &&
                    imageKeySelected == null &&
                    ImageList.Images.Count > 0)
                {
                    ImageKeyDefault = ImageList.Images.Keys[Math.Min(0, ImageList.Images.Count - 1)];
                    ImageKeyActive = ImageList.Images.Keys[Math.Min(1, ImageList.Images.Count - 1)];
                }
            }
        }

        bool fixedSize = true;
        public Boolean FixedSize
        {
            get
            {
                return fixedSize;
            }
            set
            {
                fixedSize = value;
            }
        }

        string imageKeyDefault;

        [
            Category("ImageButton"),
            TypeConverterAttribute(typeof(ImageKeyConverter)),
            Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor)),
            DefaultValue(""),
            RefreshProperties(RefreshProperties.Repaint),
            Description("Gets or sets the image that is displayed by default."),
            RelatedImageList("ImageList")
        ]
        public string ImageKeyDefault
        {
            get
            {
                return imageKeyDefault;
            }
            set
            {
                if (base.ImageKey != value)
                    base.ImageKey = value;
                imageKeyDefault = value;
            }
        }

        string imageKeyActive;
        [
            Category("ImageButton"),
            Description("Gets or sets the image that is displayed when the mouse if hoovering the button."),
            Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor)),
            DefaultValue(""),
            RefreshProperties(RefreshProperties.Repaint),
            TypeConverterAttribute(typeof(ImageKeyConverter)),
            RelatedImageList("ImageList")
        ]
        public string ImageKeyActive
        {
            get
            {
                return imageKeyActive;
            }
            set
            {
                imageKeyActive = value;
            }
        }

        string imageKeySelected;
        [
            Category("ImageButton"),
            Description("Gets or sets the image that is displayed when the option is selected."),
            Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor)),
            Localizable(true),
            DefaultValue(""),
            RefreshProperties(RefreshProperties.Repaint),
            TypeConverterAttribute(typeof(ImageKeyConverter)),
            RelatedImageList("ImageList")
        ]
        public string ImageKeySelected
        {
            get
            {
                return imageKeySelected;
            }
            set
            {
                imageKeySelected = value;
            }
        }

        bool isSelected = false;
        [
            Category("ImageButton"),
            Description("Boolean to check if the option is selected."),
            Localizable(true),
            DefaultValue("False")
        ]
        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;

                DrawCurrent();
            }
        }

        private void DrawCurrent()
        {
            if (isSelected)
                base.ImageKey = imageKeySelected;
            else
                base.ImageKey = imageKeyDefault;
        }

        bool canbeSelected = false;
        [
            Category("ImageButton"),
            Description("This button is a tri-state button."),
            Localizable(true),
            DefaultValue("False")
        ]
        public bool CanbeSelected
        {
            get { return canbeSelected; }
            set { canbeSelected = value; }
        }

        public ImageButton()
        {

            InitializeComponent();




            Width = 50;
            Height = 50;
            Text = "";
            AutoSize = false;

            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
            this.BackColor = Color.Black;

            MouseEnter += ImageButton_MouseEnter;
            MouseLeave += ImageButton_MouseLeave;
            Click += ImageButton_Click;
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            if (canbeSelected)
                IsSelected = !IsSelected;
        }

        private void ImageButton_MouseLeave(object sender, EventArgs e)
        {
            DrawCurrent();
        }

        private void ImageButton_MouseEnter(object sender, EventArgs e)
        {
            base.ImageKey = ImageKeyActive;
        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    // empty function, so no background
        //    if (this.DesignMode)
        //    {
        //        e.Graphics.FillRectangle(Brushes.Black, e.ClipRectangle);

        //        Pen border = new Pen(Color.White);
        //        border.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

        //        e.Graphics.DrawRectangle(border, 0,0,e.ClipRectangle.Width-1, e.ClipRectangle.Height-1);
        //    }
        //    base.OnPaintBackground(e);

        //}

    }
}
