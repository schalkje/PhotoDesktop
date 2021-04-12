using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsControlLibrary
{
    public partial class TransparentForm : Form
    {
        public TransparentForm() : base()
        {
            //InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.BackColor = Color.Transparent;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.DesignMode)
                e.Graphics.FillRectangle(Brushes.Green, e.ClipRectangle);

            // empty function, so no background
            //base.OnPaintBackground(e);
        }
    }
}
