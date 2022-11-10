using System.Text;

namespace ConnectFourForm
{
    internal class Board
    {
        private char[,] board = new char[6, 7]
        {
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' }
        };

        public char[,] GetBoard()
        {
            return board;
        }

        public void PrintBoard()
        {
            Console.WriteLine("\n╓─ ─┬─ ─┬─ ─┬─ ─┬─ ─┬─ ─┬─ ─╖");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Console.Write("║ ");
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j]);
                    if (j < board.GetLength(1) - 1) Console.Write(" │ ");
                }
                Console.Write(" ║");
                Console.WriteLine();
            }
            Console.WriteLine("╙───┴───┴───┴───┴───┴───┴───╜");
        }

        public void EnterPiece(int column, char piece)
        {
            for (int i = board.GetLength(0) - 1; i >= 0; i--)
            {
                if (board[i, column] == ' ')
                {
                    board[i, column] = piece;
                    break;
                }
            }
        }

        public int CheckWin(char p1)
        {
            int fullCount = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //horizontal win check
                    try
                    {
                        if ((board[i, j] == p1) && (board[i, j + 1] == p1) && (board[i, j + 2] == p1) && (board[i, j + 3] == p1))
                        {
                            return 1;
                        }
                    }
                    catch { }

                    //vertical win check
                    try
                    {
                        if ((board[i, j] == p1) && (board[i + 1, j] == p1) && (board[i + 2, j] == p1) && (board[i + 3, j] == p1))
                        {
                            return 1;
                        }
                    }
                    catch { }

                    //diagonal up win check
                    try
                    {
                        if ((board[i, j] == p1) && (board[i + 1, j + 1] == p1) && (board[i + 2, j + 2] == p1) && (board[i + 3, j + 3] == p1))
                        {
                            return 1;
                        }
                    }
                    catch { }

                    //diagonal down win check
                    try
                    {
                        if ((board[i, j] == p1) && (board[i + 1, j - 1] == p1) && (board[i + 2, j - 2] == p1) && (board[i + 3, j - 3] == p1))
                        {
                            return 1;
                        }
                    }
                    catch { }

                    if (board[i, j] != ' ') fullCount++;
                }
            }

            if (fullCount >= (board.GetLength(0) * board.GetLength(1))) return 0;
            else return -1;
        }

        public int GetLength(int which)
        {
            try
            {
                return board.GetLength(which);
            }
            catch
            {
                return -1;
            }
        }

        /*public void SetBoard(char[,] newBoard)
        {
            board = newBoard;
        }

        public void SetPlace(char set, int row, int col)
        {
            try
            {
                board[row,col] = set;
            }
            catch { } //throw error here later
        }

        public void ResetBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //later check if the entered characters are valid
                    board[i, j] = ' ';
                }
            }
        }*/

        public char[] LoadBoard(string filePath)
        {
            //char[] settings = new char[3];
            string[] saveFile = File.ReadAllLines(filePath);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    //later check if the entered characters are valid
                    board[i, j] = saveFile[i + 1][j];
                }
            }

            return saveFile[0].ToCharArray();
        }

        public void SaveBoard(string filePath, bool turn, char p1, char p2)
        {
            string[] saveFile = new string[7];

            //set settings string
            StringBuilder settings = new("", 3);
            if (turn) settings.Append('1'); else settings.Append('0');
            settings.Append(p1);
            settings.Append(p2);
            saveFile[0] = settings.ToString();

            for (int i = 0; i < 6; i++)
            {
                StringBuilder rowBuilding = new("", 7);
                for (int j = 0; j < 7; j++)
                {
                    rowBuilding.Append(board[i, j]);
                }
                saveFile[i + 1] = rowBuilding.ToString();
            }

            File.WriteAllLines(filePath, saveFile);
        }
    }
}
