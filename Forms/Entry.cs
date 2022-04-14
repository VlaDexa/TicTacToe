using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void ClassicShower_Click(object sender, EventArgs e)
        {
            new Classic().Show();
        }

        private void ComplexShower_Click(object sender, EventArgs e)
        {
            new TenByTen().Show();
        }
    }
}
