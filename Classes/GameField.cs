using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TicTacToe
{
    internal enum GameEnd
    {
        Tic,
        Tac,
        Toe
    }

    internal enum CellState
    {
        None = 0,
        Tic,
        Tac,
    }

    internal class GameField
    {
        CellState[,] Field;
        public uint TurnCount { get; private set; }
        readonly uint Size;

        public GameField(uint size)
        {
            Size = size;
            Field = new CellState[size, size];
            TurnCount = 0;
        }

        public void Place(uint x, uint y)
        {
            Field[x, y] = TurnCount % 2 == 0 ? CellState.Tic : CellState.Tac;
            ++TurnCount;
        }

        public (GameEnd?, ((uint, uint), (uint, uint))?) Check(uint combo)
        {
            if (TurnCount == Size * Size) return (GameEnd.Toe, null);
            --TurnCount;
            for (uint x = 0; x < Size; ++x)
                for (uint y = 0; y < Size; ++y)
                {
                    if (Field[x, y] is CellState.None) continue;
                    var xFit = (x + combo - 1) < Size;
                    var yFit = (y + combo - 1) < Size;
                    var NegYFit = (y - combo + 1) < Size;
                    if (xFit && yFit)
                    {
                        var end = true;
                        var first = Field[x, y];
                        for (var offset = 1; offset < combo; ++offset)
                            if (first != Field[x + offset, y + offset])
                            {
                                end = false;
                                break;
                            }
                        if (end) return (TurnCount % 2 == 0 ? GameEnd.Tic : GameEnd.Tac, ((x, y), (x + combo - 1, y + combo - 1)));
                    }
                    if (xFit)
                    {
                        var end = true;
                        var first = Field[x, y];
                        for (var offset = 1; offset < combo; ++offset)
                            if (first != Field[x + offset, y])
                            {
                                end = false;
                                break;
                            }
                        if (end) return (TurnCount % 2 == 0 ? GameEnd.Tic : GameEnd.Tac, ((x, y), (x + combo - 1, y)));
                    }
                    if (yFit)
                    {
                        var end = true;
                        var first = Field[x, y];
                        for (var offset = 1; offset < combo; ++offset)
                            if (first != Field[x, y + offset])
                            {
                                end = false;
                                break;
                            }
                        if (end) return (TurnCount % 2 == 0 ? GameEnd.Tic : GameEnd.Tac, ((x, y), (x, y + combo - 1)));
                    }
                    if (NegYFit && xFit)
                    {
                        var end = true;
                        var first = Field[x, y];
                        for (var offset = 1; offset < combo; ++offset)
                            if (first != Field[x + offset, y - offset])
                            {
                                end = false;
                                break;
                            }
                        if (end) return (TurnCount % 2 == 0 ? GameEnd.Tic : GameEnd.Tac, ((x, y), (x + combo - 1, y - combo + 1)));

                    }
                }
            ++TurnCount;
            return (null, null);
        }

        public void Reset()
        {
            TurnCount = 0;
            Field = new CellState[Size, Size];
        }

        public StringBuilder PrepareForFile()
        {
            var stringBuild = new StringBuilder((int)(7 + Size * Size));
            stringBuild.Append($"{Size}\n");
            for (var x = 0; x < Size; ++x)
                for (var y = 0; y < Size; ++y)
                    stringBuild.Append((int)Field[x, y]);
            return stringBuild;
        }

        public GameField(StreamReader file, Button[,] buttons, uint size)
        {
            if (uint.Parse(file.ReadLine().Unwrap()) != size) throw new ParseException("Wrong file format");
            Size = size;
            Field = new CellState[Size, Size];
            var x = 0;
            uint y = 0;
            uint turns = 0;
            foreach (var character in file.ReadLine().Unwrap())
            {
                CellState cell = character switch
                {
                    '1' => CellState.Tic,
                    '2' => CellState.Tac,
                    _ => CellState.None,
                };
                if (cell != CellState.None)
                {
                    buttons[x, y].Text = cell == CellState.Tic ? "X" : "O";
                    buttons[x, y].Enabled = false;
                    ++turns;
                }
                Field[x, y] = cell;
                ++y;
                if (y >= Size)
                {
                    y %= Size;
                    ++x;
                }
                TurnCount = turns;
            }
        }
    }


    internal class ParseException : System.Exception
    {
        public ParseException(string? message) : base(message) { }
    }
}
