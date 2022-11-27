using ConnectFourForm;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace ConnectFourForm
{
    public partial class Form1 : Form
    {
        bool winner = false;
        bool player = true;
        char p1 = '1';
        char p2 = '2';
        char currentPlayer;

        string filePath;
        char[] settings;

        int boardX;
        int boardY;
        int pieceHeight = 64;
        int pieceWidth = 64;
        int marginHeight = 4;
        int marginWidth = 4;
        int pieceBorder = 2;


        Graphics g;

        SolidBrush brush0;
        SolidBrush brush1;
        SolidBrush brush2;
        SolidBrush currentBrush;


        Board board = new();


        public Form1()
        {
            InitializeComponent();
            if (player)
            {
                label1.Text = "Player 1's turn (Red)";
                currentPlayer = p1;
            }
            else
            {
                label1.Text = "Player 2's turn (Yellow)";
                currentPlayer = p2;
            }

            g = panel1.CreateGraphics();
            g.SmoothingMode = SmoothingMode.HighQuality;

            brush0 = new(Color.FromArgb(0, 0, 0));
            brush1 = new(Color.FromArgb(255, 0, 0));
            brush2 = new(Color.FromArgb(255, 223, 0));

            boardX = panel1.Location.X;
            boardY = panel1.Location.Y;

            PrintBoard();
        }

        public void PrintBoard()
        {
            int rectX;
            int rectY;
            char[,] boardChars = board.GetBoard();

            g.Clear(panel1.BackColor);
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (boardChars[i, j] == p1 || boardChars[i, j] == p2) {
                        rectX = (((j) * pieceWidth) + ((j + 1) * marginWidth));
                        rectY = (((i) * pieceHeight) + ((i + 1) * marginHeight));

                        if (boardChars[i, j] == p1) currentBrush = brush1; else currentBrush = brush2;
                        g.FillEllipse(brush0, new Rectangle(rectX, rectY, pieceWidth, pieceHeight));
                        g.FillEllipse(currentBrush, new Rectangle(rectX + pieceBorder, rectY + pieceBorder, pieceWidth - (pieceBorder * 2), pieceHeight - (pieceBorder * 2)));
                    }
                }
            }
        }

        private void clickColumn(int column)
        {
            if (!winner)
            {
                if (board.GetBoard()[0, column - 1] == ' ')
                {
                    board.EnterPiece(column - 1, currentPlayer);

                    switch (board.CheckWin(currentPlayer))
                    {
                        case 0:
                            label1.Text = "The board is full, game has tied.";
                            winner = true;
                            break;

                        case 1:
                            if (player) label1.Text = "Player 1 (Red) has won!";
                            else label1.Text = "Player 2 (Yellow) has won!";

                            winner = true;
                            break;

                        default:
                            break;
                    }

                    if (!winner) player = !player;
                }

                if (!winner)
                {
                    if (player)
                    {
                        label1.Text = "Player 1's turn (Red)";
                        currentPlayer = p1;
                    }
                    else
                    {
                        label1.Text = "Player 2's turn (Yellow)";
                        currentPlayer = p2;
                    }
                }

                PrintBoard();
            }
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
            currentPlayer = p1;

            board.ResetBoard();
            label1.Text = "Player 1's turn (Red)";
            PrintBoard();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            filePath = Console.ReadLine();
            board.SaveBoard(filePath, player, p1, p2);
        }

        private void panel1_MouseUp(object sender, EventArgs e)
        {
            int x = this.PointToClient(Cursor.Position).X;
            int y = this.PointToClient(Cursor.Position).Y;
            int selectedColumn = (Convert.ToInt32(Math.Floor((Convert.ToDouble(x) - (boardX + (marginWidth / 2))) / (pieceWidth + marginWidth))) + 1);
            if (1 <= selectedColumn && selectedColumn <= 7)
            {
                clickColumn(selectedColumn);
            }
        }
    }
}
