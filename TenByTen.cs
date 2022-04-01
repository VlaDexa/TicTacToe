using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TenByTen : Form
    {
        const int FieldSize = 10;
        const int Combo = 5;
        private uint CurrentTurn = 0;
        private readonly Button[,] Field;
        private GameField GameField = new(FieldSize);
        private ((int, int), (int, int))? PaintCoordinates = null;
        public TenByTen()
        {
            InitializeComponent();
            Field = new Button[FieldSize, FieldSize] {
                {a1, a2, a3, a4, a5, a6, a7, a8, a9, a10},
                {b1, b2, b3, b4, b5, b6, b7, b8, b9, b10},
                {c1, c2, c3, c4, c5, c6, c7, c8, c9, c10},
                {d1, d2, d3, d4, d5, d6, d7, d8, d9, d10},
                {e1, e2, e3, e4, e5, e6, e7, e8, e9, e10},
                {f1, f2, f3, f4, f5, f6, f7, f8, f9, f10},
                {g1, g2, g3, g4, g5, g6, g7, g8, g9, g10},
                {h1, h2, h3, h4, h5, h6, h7, h8, h9, h10},
                {i1, i2, i3, i4, i5, i6, i7, i8, i9, i10},
                {j1, j2, j3, j4, j5, j6, j7, j8, j9, j10}
            };
        }

        private void ProcessButtonClick(object sender, System.EventArgs e)
        {
            if (sender is not Button button) return;
            for (uint x = 0; x < FieldSize; ++x)
                for (uint y = 0; y < FieldSize; ++y)
                    if (button == Field[x, y])
                    {
                        GameField.Place(x, y);
                        break;
                    }
            button.Text = CurrentTurn % 2 == 0 ? "X" : "O";
            button.Enabled = false;
            var (end, coordinates) = GameField.Check(Combo);
            if (end is GameEnd result)
            {
                if (result == GameEnd.Toe)
                {
                    MessageBox.Show("Ничья!");
                }
                else
                {
                    var ((startX, startY), (endX, endY)) = coordinates!.Value;
                    var startLine = (Field[startX, startY].Bounds.Location.X + Field[startX, startY].Width / 2, Field[startX, startY].Bounds.Location.Y + Field[startX, startY].Height / 2);
                    var endLine = (Field[endX, endY].Bounds.Location.X + Field[endX, endY].Width / 2, Field[endX, endY].Bounds.Location.Y + Field[endX, endY].Height / 2);
                    PaintCoordinates = (startLine, endLine);
                    InvokePaint(this, new PaintEventArgs(CreateGraphics(), DisplayRectangle));
                    var winner = result == GameEnd.Tic ? First : Second;
                    winner.Text = (int.Parse(winner.Text) + 1).ToString();
                    MessageBox.Show($"Победили {(result == GameEnd.Tic ? "Крестики" : "Нолики")}");
                }
                Reset();
                return;
            }
            ++CurrentTurn;
        }


        private void Reset()
        {
            for (var x = 0; x < FieldSize; ++x)
                for (var y = 0; y < FieldSize; ++y)
                {
                    Field[x, y].Enabled = true;
                    Field[x, y].Text = "";
                }
            CurrentTurn = 0;
            PaintCoordinates = null;
            GameField.Reset();
            Invalidate();
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Classic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
            if (PaintCoordinates is null) return;
            Pen pen = new(Color.Red, 3);
            var ((startX, startY), (endX, endY)) = PaintCoordinates!.Value;
            var startPoint = new Point(startX, startY);
            var endPoint = new Point(endX, endY);
            e.Graphics.DrawLine(pen, startPoint, endPoint);
            PaintCoordinates = null;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            Second.Text = First.Text = "0";
            Reset();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            FileSaver.ShowDialog();
        }

        private void FileSaver_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var filename = FileSaver.FileName;
            var stringBuild = GameField.PrepareForFile();
            stringBuild.Insert(0, $"{First.Text}\n{Second.Text}\n");
            using StreamWriter outputFile = new(filename);
            outputFile.WriteLine(stringBuild);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            FileLoader.ShowDialog();
        }

        private void FileLoader_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Reset();
            var filename = FileLoader.FileName;
            using StreamReader inputFile = new(filename);
            First.Text = inputFile.ReadLine()!;
            Second.Text = inputFile.ReadLine()!;
            GameField = new GameField(inputFile, Field);
            CurrentTurn = GameField.TurnCount;
        }
    }
}
