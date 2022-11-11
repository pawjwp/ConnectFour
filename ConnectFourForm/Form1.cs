using ConnectFourForm;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace ConnectFourForm
{
    public partial class Form1 : Form
    {
        bool winner = false;
        bool player = true;
        char p1 = 'X';
        char p2 = 'O';
        char currentPlayer;

        string filePath;
        char[] settings;


        Board board = new();


        public Form1()
        {
            InitializeComponent();
            if (player)
            {
                Console.WriteLine("Player 1's turn (" + p1 + ")");
                currentPlayer = p1;
            }
            else
            {
                Console.WriteLine("Player 2's turn (" + p2 + ")");
                currentPlayer = p2;
            }

            PrintBoard();
        }

        public void PrintBoard()
        {
            char[,] boardChars = new char[6, 7];
            boardChars = board.GetBoard();

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    stringBuilder.Append(boardChars[i, j]);
                }
                stringBuilder.Append("\n");
            }


            MessageBox.Show(stringBuilder.ToString());
        }

        private void clickColumn(int column)
        {
            if (board.GetBoard()[0, column - 1] == ' ')
            {
                board.EnterPiece(column - 1, currentPlayer);
            }


            PrintBoard();



            if (player)
            {
                Console.WriteLine("Player 1's turn (" + p1 + ")");
                currentPlayer = p1;
            }
            else
            {
                Console.WriteLine("Player 2's turn (" + p2 + ")");
                currentPlayer = p2;
            }


            switch (board.CheckWin(currentPlayer))
            {
                case 0:
                    Console.WriteLine("The board is full, game has tied.");
                    winner = true;
                    break;

                case 1:
                    if (player) Console.WriteLine("Player 1 (" + p1 + ") has won!");
                    else Console.WriteLine("Player 2 (" + p2 + ") has won!");

                    winner = true;
                    break;

                default:
                    break;
            }

            player = !player;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            Console.WriteLine("\nEnter file path:");
            filePath = Console.ReadLine();

            while (!File.Exists(filePath))
            {
                Console.WriteLine("Invalid input\nEnter valid file path:");
                filePath = Console.ReadLine();
            }

            settings = board.LoadBoard(filePath);

            if (settings[0] == '1') player = true; else player = false;
            p1 = settings[1];
            p2 = settings[2];

            winner = false;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            winner = false;
            player = true;
            p1 = 'X';
            p2 = 'O';

            board.ResetBoard();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            filePath = Console.ReadLine();
            board.SaveBoard(filePath, player, p1, p2);
        }
        private void column7_MouseEnter(object sender, EventArgs e)
        {
            column7.BackColor = Color.White;
        }
        private void column7_MouseLeave(object sender, EventArgs e)
        {
            column7.BackColor = Color.White;
        }

        private void column7_Click(object sender, EventArgs e)
        {
            clickColumn(7);
        }

        private void column6_Click(object sender, EventArgs e)
        {
            clickColumn(6);
        }

        private void column6_MouseEnter(object sender, EventArgs e)
        {
            column6.BackColor = Color.White;
        }
        private void column6_MouseLeave(object sender, EventArgs e)
        {
            column6.BackColor = Color.White;
        }

        private void column5_Click(object sender, EventArgs e)
        {
            clickColumn(5);
        }

        private void column5_MouseEnter(object sender, EventArgs e)
        {
            column5.BackColor = Color.White;
        }
        private void column5_MouseLeave(object sender, EventArgs e)
        {
            column5.BackColor = Color.White;
        }
        private void column4_Click(object sender, EventArgs e)
        {
            clickColumn(4);
        }

        private void column4_MouseEnter(object sender, EventArgs e)
        {
            column4.BackColor = Color.White;
        }
        private void column4_MouseLeave(object sender, EventArgs e)
        {
            column4.BackColor = Color.White;
        }

        private void column3_Click(object sender, EventArgs e)
        {
            clickColumn(3);
        }

        private void column3_MouseEnter(object sender, EventArgs e)
        {
            column3.BackColor = Color.White;
        }
        private void column3_MouseLeave(object sender, EventArgs e)
        {
            column3.BackColor = Color.White;
        }

        private void column2_Click(object sender, EventArgs e)
        {
            clickColumn(2);
        }

        private void column2_MouseEnter(object sender, EventArgs e)
        {
            column2.BackColor = Color.White;
        }
        private void column2_MouseLeave(object sender, EventArgs e)
        {
            column2.BackColor = Color.White;
        }


        private void column1_Click(object sender, EventArgs e)
        {
            clickColumn(1);
        }

        private void column1_MouseEnter(object sender, EventArgs e)
        {
            column1.BackColor = Color.White;
        }
        private void column1_MouseLeave(object sender, EventArgs e)
        {
            column1.BackColor = Color.White;
        }
    }
}
