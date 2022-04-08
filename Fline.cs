using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace TicTacToe
{
    public partial class Fline : UserControl
    {
        public Fline()
        {
            InitializeComponent();
        }

        private void UserControl1_Resize(object sender, EventArgs e)
        {
            var wfactor = 4;

            Point[] pts = {
                new Point(0, 0),
                new Point(wfactor, 0),
                new Point(Width, Height - wfactor),
                new Point(Width, Height) ,
                new Point(Width - wfactor, Height),
                new Point(0, wfactor)
            };

            var types = new byte[]{
                (byte)PathPointType.Start,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line,
                (byte)PathPointType.Line
            };
            var path = new GraphicsPath(pts, types);
            Region = new Region(path);
        }
    }
}
