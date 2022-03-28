using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace TicTacToe
{
    public partial class Classic : Form
    {
        const int FieldSize = 3;
        const int Combo = 3;
        private uint CurrentTurn = 0;
        private readonly Button[,] Field;
        private GameField GameField = new(FieldSize);
        private ((int, int), (int, int))? PaintCoordinates = null;

        public Classic()
        {
            InitializeComponent();
            Field = new Button[FieldSize, FieldSize] { { a1, a2, a3 }, { b1, b2, b3 }, { c1, c2, c3 } };
        }

        private void ProcessButtonClick(object sender, EventArgs e)
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
                } else
                {
                    var ((startX, startY), (endX, endY)) = coordinates!.Value;
                    var startLine = (Field[startX, startY].Bounds.Location.X + Field[startX, startY].Width / 2, Field[startX, startY].Bounds.Location.Y + Field[startX, startY].Height / 2);
                    var endLine = (Field[endX, endY].Bounds.Location.X + Field[endX, endY].Width / 2, Field[endX, endY].Bounds.Location.Y + Field[endX, endY].Height / 2);
                    PaintCoordinates = (startLine, endLine);
                    InvokePaint(this, new PaintEventArgs(CreateGraphics(), DisplayRectangle));
                    var winner = result == GameEnd.Tic ? First : Second;
                    winner.Text = (int.Parse(winner.Text)+1).ToString();
                    MessageBox.Show($"Победили {(result == GameEnd.Tic ? "Крестики": "Нолики")}");
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
