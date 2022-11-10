using ConnectFourForm;

namespace ConnectFourForm
{
    public partial class Form1 : Form
    {
        char newGame;
        bool winner = false;
        bool player = true;
        bool controlBool;
        int selectedColumn = 1;
        char p1 = 'X';
        char p2 = 'O';
        char currentPlayer;

        string filePath;
        char[] settings;


        Board board = new Board();

        //board.PrintBoard();


        public Form1()
        {
            InitializeComponent();

        }

        private void clickColumn(int column)
        {
            MessageBox.Show("column7");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("column1");
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            winner = false;
            player = true;
            selectedColumn = 1;
            //gets custom characters... later check that these are alphanumeric or special characters, but not new lines or 0 width spaces, etc.
            Console.WriteLine("\nEnter player 1 character (any letter)");
            p1 = Console.ReadKey().KeyChar;
            Console.WriteLine("\nEnter player 2 character (any letter)");
            p2 = Console.ReadKey().KeyChar;
        }

        private void buttonSave_Click(object sender, EventArgs e)
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
            selectedColumn = 1;
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
            MessageBox.Show("column7");
        }

        private void column6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("column6");
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
            MessageBox.Show("column5");
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
            MessageBox.Show("column4");
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
            MessageBox.Show("column3");
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
            MessageBox.Show("column2");
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
            MessageBox.Show("column1");
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

/*
namespace 
while (!winner)
{
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
    Console.WriteLine("Enter column (1-7, 0 to save):");

    selectedColumn = 8;

    controlBool = true;
    while (controlBool)
    {
        try { selectedColumn = Convert.ToInt32(Console.ReadKey().KeyChar.ToString()); } catch { }
        while (!((selectedColumn >= 0) && (selectedColumn <= 7)))
        {
            Console.WriteLine("\nInvalid input, enter number between 0 and 7:");
            try { selectedColumn = Convert.ToInt32(Console.ReadKey().KeyChar.ToString()); } catch { }
        }

        if (selectedColumn != 0)
        {
            if (board.GetBoard()[0, selectedColumn - 1] == ' ')
            {
                board.EnterPiece(selectedColumn - 1, currentPlayer);

                controlBool = false;
            }
            else Console.WriteLine("\nMove not allowed, try again");
        }
        else controlBool = false;
    }

    if (selectedColumn == 0)
    {
        Console.WriteLine("\nEnter file path:");
        filePath = Console.ReadLine();
        board.SaveBoard(filePath, player, p1, p2);
        Console.WriteLine("Game saved\n");
        Thread.Sleep(100);
    }
    else
    {
        board.PrintBoard();
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
}
        }*/