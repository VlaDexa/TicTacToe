using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TicTacToe
{
    public abstract class TicTacToeField : Form
    {
        private uint CurrentTurn = 0;
        private GameField? GameField;
        private readonly FileStream HistoryFile = File.Create("history.txt");
        
        protected abstract uint AbstractCombo { get; }
        protected abstract uint AbstractFieldSize { get; }
        protected abstract Button[,] AbstractField { get; }
        protected abstract Label AbstractFirst { get; }
        protected abstract Label AbstractSecond { get; }
        protected abstract OpenFileDialog AbstractFileLoader { get; }
        protected abstract SaveFileDialog AbstractFileSaver { get; }


        protected void ProcessButtonClick(object sender, EventArgs e)
        {
            GameField ??= new GameField(AbstractFieldSize);
            if (sender is Button button) { }  else return;
            for (uint x = 0; x < AbstractFieldSize; ++x)
                for (uint y = 0; y < AbstractFieldSize; ++y)
                    if (button == AbstractField[x, y])
                    {
                        GameField.Place(x, y);
                        goto outloop;
                    }
                outloop:
            button.Text = CurrentTurn % 2 == 0 ? "X" : "O";
            button.Enabled = false;
            AppendHistory();
            var (end, coordinates) = GameField.Check(AbstractCombo);
            if (end is GameEnd result)
            {
                if (result == GameEnd.Toe)
                {
                    MessageBox.Show("Ничья!");
                }
                else
                {
                    var ((startX, startY), (endX, endY)) = coordinates!.Value;
                    var startLine = (AbstractField[startX, startY].Bounds.Location.X + AbstractField[startX, startY].Width / 2, AbstractField[startX, startY].Bounds.Location.Y + AbstractField[startX, startY].Height / 2);
                    var endLine = (AbstractField[endX, endY].Bounds.Location.X + AbstractField[endX, endY].Width / 2, AbstractField[endX, endY].Bounds.Location.Y + AbstractField[endX, endY].Height / 2);
                    var (startXNew, startYNew) = startLine;
                    var (endXNew, endYNew) = endLine;
                    var fline = new Fline();
                    if (startXNew > endXNew && startYNew < endYNew)
                    {
                        fline.Inverted = true;
                        (startXNew, endXNew) = (endXNew, startXNew);
                    }
                    fline.Location = new Point(startXNew, startYNew);
                    fline.Height = endYNew - startYNew + 4;
                    fline.Width = endXNew - startXNew + 4;
                    Controls.Add(fline);
                    fline.BringToFront();
                    var winner = result == GameEnd.Tic ? AbstractFirst : AbstractSecond;
                    winner.Text = (uint.Parse(winner.Text) + 1).ToString();
                    MessageBox.Show($"Победили {(result == GameEnd.Tic ? "Крестики" : "Нолики")}");
                }
                Reset();
                return;
            }
            ++CurrentTurn;
        }

        private void AppendHistory()
        {
            var sw = new StreamWriter(HistoryFile);
            var text = GameField!.PrepareForFile();
            text.Remove(0, 4);
            text = text.Replace('1', 'X').Replace('2', 'O');
            text.Insert(0, $"{CurrentTurn+1}: ");
            text.AppendLine();
            sw.WriteLine(text);
            sw.Flush();
        }

        private void Reset()
        {
            for (var x = 0; x < AbstractFieldSize; ++x)
                for (var y = 0; y < AbstractFieldSize; ++y)
                {
                    AbstractField[x, y].Enabled = true;
                    AbstractField[x, y].Text = "";
                }
            for (var i = 0; i < Controls.Count; ++i)
                if (Controls[i] is Fline)
                {
                    Controls.RemoveAt(i);
                    break;
                }
            CurrentTurn = 0;
            if (GameField != null) GameField.Reset();
        }

        protected void NewGame_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            AbstractSecond.Text = AbstractFirst.Text = "0";
            Reset();
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            AbstractFileSaver.ShowDialog();
        }

        protected void FileSaver_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (GameField is null) { e.Cancel = true; MessageBox.Show("Игра ещё не начата"); return; }
            var filename = AbstractFileSaver.FileName;
            var stringBuild = GameField.PrepareForFile();
            stringBuild.Insert(0, $"{AbstractFirst.Text}\n{AbstractSecond.Text}\n");
            using StreamWriter outputFile = new StreamWriter(filename);
            outputFile.WriteLine(stringBuild);
        }

        protected void Load_Click(object sender, EventArgs e)
        {
            AbstractFileLoader.ShowDialog();
        }

        protected void FileLoader_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Reset();
                var filename = AbstractFileLoader.FileName;
                using (StreamReader inputFile = new StreamReader(filename))
                {
                    AbstractFirst.Text = inputFile.ReadLine().Unwrap();
                    AbstractSecond.Text = inputFile.ReadLine().Unwrap();
                    GameField = new GameField(inputFile, AbstractField, AbstractFieldSize);
                    CurrentTurn = GameField.TurnCount;
                };
                return;
            }
            catch (ParseException)
            {
                MessageBox.Show("Сохранение сделано в поле другого размера");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Неверный формат файла");
            }
            catch (IOException)
            {
                MessageBox.Show("Ошибка при чтении файла");
            }
            AbstractSecond.Text = AbstractFirst.Text = "0";
            Reset();
            e.Cancel = true;
        }
    }

    internal static partial class Extensions
    {
        public static T Unwrap<T>(this T? value) where T: class
        {
            if (value is null) throw new NullReferenceException(nameof(value));
            return value;
        }
    }
}
