using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Human_PC : Form
    {
        private int[,] board = new int[3, 3];
        private int AI_PLAYER = 1;
        private int HUMAN_PLAYER = -1;
        private Button[,] buttons = new Button[3, 3];
        private Label statusLabel;

        public Human_PC()
        {
            // Initialize the board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = 0;
                }
            }

            // Create buttons for the board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(75, 75);
                    buttons[i, j].Location = new Point(i * 75, j * 75);
                    buttons[i, j].Click += new EventHandler(button_Click);
                    this.Controls.Add(buttons[i, j]);
                }
            }

            // Create a label to display the status of the game
            statusLabel = new Label();
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(250, 0);
            this.Controls.Add(statusLabel);
        }

        private void button_Click(object sender, EventArgs e)
        {
            // Get the button that was clicked
            Button button = (Button)sender;

            // Get the row and column of the button
            int row = (button.Location.Y / 75);
            int col = (button.Location.X / 75);

            // Make the move
            board[row, col] = HUMAN_PLAYER;

            // Update the button text
            button.Text = "O";

            // Check for a winner
            int winner = checkForWinner();
            if (winner != 0)
            {
                statusLabel.Text = "The winner is player " + winner;
                return;
            }

            // Check for a tie
            if (!board.Cast<int>().Any(x => x == 0))
            {
                statusLabel.Text = "The game is a tie!";
                return;
            }

            // Get the AI player's move
            Tuple<int, int> move = getAIMove();
            board[move.Item1, move.Item2] = AI_PLAYER;

            // Update the button text
            buttons[move.Item1, move.Item2].Text = "X";

            // Check for a winner
            winner = checkForWinner();
            if (winner != 0)
            {
                statusLabel.Text = "The winner is player " + winner;
                return;
            }

            // Check for a tie
            if (!board.Cast<int>().Any(x => x == 0))
            {
                statusLabel.Text = "The game is a tie!";
                return;
            }
        }

        public Tuple<int, int> getAIMove()
        {
            int bestVal = int.MinValue;
            Tuple<int, int> bestMove = new Tuple<int, int>(-1, -1);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        // Make the move
                        board[i, j] = AI_PLAYER;

                        // Get the score for this move
                        int moveVal = minimax(0, HUMAN_PLAYER);
                        board[i, j] = 0;

                        // Update the best move if necessary
                        if (moveVal > bestVal)
                        {
                            bestVal = moveVal;
                            bestMove = new Tuple<int, int>(i, j);
                        }
                    }
                }
            }

            return bestMove;
        }

        // Function to evaluate the score of the current board state
        public int evaluate()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    if (board[i, 0] == AI_PLAYER)
                        return 10;
                    else if (board[i, 0] == HUMAN_PLAYER)
                        return -10;
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    if (board[0, i] == AI_PLAYER)
                        return 10;
                    else if (board[0, i] == HUMAN_PLAYER)
                        return -10;
                }
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                if (board[0, 0] == AI_PLAYER)
                    return 10;
                else if (board[0, 0] == HUMAN_PLAYER)
                    return -10;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                if (board[0, 2] == AI_PLAYER)
                    return 10;
                else if (board[0, 2] == HUMAN_PLAYER)
                    return -10;
            }

            // Otherwise, return 0
            return 0;
        }

        public int minimax(int depth, int player)
        {
            int score = evaluate();

            // If AI wins, return score
            if (score == 10)
                return score;

            // If human wins, return -score
            if (score == -10)
                return score;

            // If there are no more moves and no winner, it's a tie
            if (!board.Cast<int>().Any(x => x == 0))
                return 0;

            // Initialize best value for AI and human
            int best;
            if (player == AI_PLAYER)
                best = int.MinValue;
            else
                best = int.MaxValue;

            // Generate all possible next moves
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == 0)
                    {
                        // Make the move
                        board[i, j] = player;
                        // Recursively call minimax for the other player
                        int value = minimax(depth + 1, player * -1);

                        // Undo the move
                        board[i, j] = 0;

                        // Update best value
                        if (player == AI_PLAYER)
                        {
                            best = Math.Max(best, value);
                        }
                        else
                        {
                            best = Math.Min(best, value);
                        }
                    }
                }
            }

            return best;
        }

        public int checkForWinner()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return board[i, 0];
                }
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return board[0, i];
                }
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return board[0, 0];
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return board[0, 2];
            }

            // Otherwise, return 0
            return 0;
        }
    }
}

