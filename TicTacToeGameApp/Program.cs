namespace TicTacToeGameApp
{
    internal class Program
    {

        static int player = 1;
        static int flag = 0;
        static string[,] board=new string[3, 3] { 
            { "-","-","-"},
            { "-","-","-"},
            { "-","-","-"},
        };
     
        static void Main(string[] args)
        {
            
          
            ShowInstruction();
            Console.WriteLine("\nPlayer 1:X and Player 2:O\n\n");
            do
            {
                if (player % 2 ==0)
                    Console.WriteLine("Player 2 Chance\n");
             
                else
                    Console.WriteLine("Player 1 Chance\n");
               
                PrintBoard();
                int choice=Convert.ToInt16(Console.ReadLine())-1;
             

                if (board[choice/3,choice%3] =="-")
                {
                    if(player%2==0)
                    {
                        board[choice / 3, (choice % 3)] = "O";
                    }
                    else
                    {
                        board[choice / 3, (choice % 3) ] = "X";
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine($"Sorry the cell {choice+1} is already marked with {board[choice / 3, choice % 3]}" );
                    Console.WriteLine("\n");
                }
                flag = CheckWin();
                
            }while(flag!=1 && flag!=-1);
            PrintBoard();
            PrintWinner();
            Console.ReadLine();
        }
        private static void PrintWinner()
        {
            if (flag == 1)
            {
                Console.WriteLine($"Player {(player % 2) + 1} has won");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
        private static void ShowInstruction()
        {
            Console.WriteLine("\t\tTic-Tac-Toe\n\n");
            Console.WriteLine("Choose a cell numbered from 1 to 9 as below " +
                "and play\n\n");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  1  |  2  |  3 ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  4  |  5  |  6");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  7  |  8  |  9");
            Console.WriteLine("     |     |      ");
        }

        

        private static void PrintBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[0,0], board[0,1], board[0,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[1,0], board[1,1], board[1,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", board[2,0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");
        }
        private static int CheckWin()
        {
            //Check for rows

            bool row = RowCheck();
            //Check for colomns
            bool colomn = ColomnCheck();
            //Check for diagonals
            bool diagonal = CheckDiagonal();
            if(row || colomn||diagonal)
            {
                return 1;
            }
            //Check for draw
            else if (board[0,0]!="-"&& board[0, 1] != "-" && board[0, 2] != "-" 
                && board[1, 0] != "-" && board[1,1]!="-" && board[1, 2] != "-" && board[2, 0] != "-" && board[2, 1] != "-" && board[2,2]!="-")
            {
                return -1;
            }
            else
            {
                return 0;
            }
            
        }
        private static bool RowCheck()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] &&
                    board[i, 1] == board[i, 2] &&
                    board[i, 0] != "-")
                    return true;
            }
            return false;   
        }
        private static bool ColomnCheck()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == board[1, i] &&
                    board[1, i] == board[2, i] &&
                    board[0, i] != "-")
                    return true;
            }
            return false;
        }
        private static bool CheckDiagonal()
        {
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[2, 2] != "-")
            {
                return true;
            }
            else if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != "-")
            {
                return true;

            }
            else { return false; }
        }
    }
}