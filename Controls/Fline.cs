using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Fline : UserControl
    {
        public bool Inverted = false;
        public int LineWidth = 4;
        public Fline()
        {
            InitializeComponent();
        }

        private void Fline_Resize(object sender, EventArgs e)
        {
            Point[] pts;
            if (Inverted)
                pts = new Point[6]{
                    new Point(Width, 0),
                    new Point(Width, LineWidth),
                    new Point(LineWidth, Height),
                    new Point(0, Height),
                    new Point(0, Height-LineWidth),
                    new Point(Width-LineWidth, 0),
                };
            else
                pts = new Point[6]{
                    new Point(0, 0),
                    new Point(LineWidth, 0),
                    new Point(Width, Height - LineWidth),
                    new Point(Width, Height) ,
                    new Point(Width - LineWidth, Height),
                    new Point(0, LineWidth)
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
