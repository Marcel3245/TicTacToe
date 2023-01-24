using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Human_Human : Form
    {
        List<Button> buttons;
        int playerOWinCount = 0;
        int playerXWinCount = 0;
        bool runda = false;             //First player = O, Second player = X

        public Human_Human()
        {
            InitializeComponent();
            RestartGame();
        }

        private void BackMenuHH(object sender, EventArgs e)
        {
            this.Close();
            Menu MenuWindow = new Menu();
            MenuWindow.Show();
        }

        private void PLayerClickButton(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                (sender as Button).Text = runda ? "X" : "O";            //Circel first
                if (runda == true)
                {
                    (sender as Button).Enabled = false;
                    (sender as Button).BackColor = Color.DarkSalmon;
                    CheckGame();
                }
                if (runda == false)
                {
                    (sender as Button).Enabled = false;
                    (sender as Button).BackColor = Color.Cyan;
                    CheckGame();
                }
                runda = !runda;
            }
        }

        private void CheckGame()
        {
            if (a1.Text == "X" && a2.Text == "X" && a3.Text == "X"
                || b1.Text == "X" && b2.Text == "X" && b3.Text == "X"
                    || c1.Text == "X" && c2.Text == "X" && c3.Text == "X"
                        || a1.Text == "X" && b1.Text == "X" && c1.Text == "X"
                            || a2.Text == "X" && b2.Text == "X" && c2.Text == "X"
                                || a3.Text == "X" && b3.Text == "X" && c3.Text == "X"
                                    || a1.Text == "X" && b2.Text == "X" && c3.Text == "X"
                                        || a3.Text == "X" && b2.Text == "X" && c1.Text == "X")
            {
                MessageBox.Show("Player X wins");
                playerXWinCount++;
                ScoreX.Text = "Wins: " + playerXWinCount;
                RestartGame();
            }

            else if (a1.Text == "O" && a2.Text == "O" && a3.Text == "O"
                        || b1.Text == "O" && b2.Text == "O" && b3.Text == "O"
                            || c1.Text == "O" && c2.Text == "O" && c3.Text == "O"
                                || a1.Text == "O" && b1.Text == "O" && c1.Text == "O"
                                    || a2.Text == "O" && b2.Text == "O" && c2.Text == "O"
                                        || a3.Text == "O" && b3.Text == "O" && c3.Text == "O"
                                            || a1.Text == "O" && b2.Text == "O" && c3.Text == "O"
                                                || a3.Text == "O" && b2.Text == "O" && c1.Text == "O")
            {
                MessageBox.Show("Player O wins");
                playerOWinCount++;
                ScoreO.Text = "Wins: " + playerOWinCount;
                RestartGame();
            }

            else if (a1.Enabled == false && a2.Enabled == false && a3.Enabled == false
                        && b1.Enabled == false && b2.Enabled == false && b3.Enabled == false
                            && c1.Enabled == false && c2.Enabled == false && c3.Enabled == false)
            {
                MessageBox.Show("Draw");
                RestartGame();
            }
        }

        private void RestartGame()
        {
            buttons = new List<Button> { a1, a2, a3, b1, b2, b3, c1, c2, c3 };

            foreach (Button x in buttons)
            {
                x.Enabled = true;
                x.Text = " ";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}
