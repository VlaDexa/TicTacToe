using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Classic : TicTacToeField
    {
        const int FieldSize = 3;
        const int Combo = 3;
        readonly Button[,] Field;

        protected override uint AbstractCombo => Combo;

        protected override uint AbstractFieldSize => FieldSize;

        protected override Button[,] AbstractField => Field;

        protected override Label AbstractFirst => First;

        protected override Label AbstractSecond => Second;

        protected override OpenFileDialog AbstractFileLoader => FileLoader;

        protected override SaveFileDialog AbstractFileSaver => FileSaver;

        public Classic()
        {
            InitializeComponent();
            Field = new Button[FieldSize, FieldSize] { { a1, a2, a3 }, { b1, b2, b3 }, { c1, c2, c3 } };
        }
    }
}
