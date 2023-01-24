using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void LoadHvsH(object sender, EventArgs e)
        {
            this.Hide();
            Human_Human gameHH  = new Human_Human();
            gameHH.Show();
        }



        private void LoadHvsP(object sender, EventArgs e)
        {
            this.Hide();
            Human_PC gameHP = new Human_PC();
            gameHP.Show();
        }
    }
}
