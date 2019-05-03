using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    class Chessboard
    {
        public static int Dimension { get; private set; }
        public static Figure[,] chessBoard;

        static string horizontalLine = "+---";
        static string verticalLine = " |";

        Blank blank = new Blank();
        Player player1;
        Player player2;

        //Figure userSelection\
        //int targetX
        //int targetY



        public Chessboard(Player player1, Player player2) //instantiate a chessboard with 2 players. Players are created at runtime.
        {
            Dimension = 8;
            chessBoard = new Figure[Dimension, Dimension];
            this.player1 = player1;
            this.player2 = player2;
            InitializeChessBoard();
        }

        //public void MakeAMove()
        //{
        //    //select the figure to move.
        //    Console.WriteLine("Which figure would you like to move?");
        //    Console.Write("X = "); targetX = Convert.ToInt32(Console.ReadLine());
        //    Console.Write("Y = "); targetY = Convert.ToInt32(Console.ReadLine());

        //    if (chessBoard[targetX, targetY] is Blank)
        //    {
        //        Console.WriteLine("Can't move an empty spot!");
        //        Console.ReadKey();
        //        return;
        //    }


        //    //based on the type of the figure, polymorhpism choses the correct object to call "Move" on.
        //    userSelection = chessBoard[targetX, targetY];
        //    userSelection.Move(userSelection);
        //    chessBoard[targetX, targetY] = blank;

        //}

        private void InitializeChessBoard()
        {
            Console.Title = "Object Chess";

            for (int r = 0; r < Dimension; r++)
            {
                for (int c = 0; c < Dimension; c++)
                {
                    if (r == 1)
                        chessBoard[r, c] = new Pawn() { Owner = player1 };
                    else if (r == Dimension - 2)
                        chessBoard[r, c] = new Pawn() { Owner = player2 };

                    else if (r == 0)
                        chessBoard[r, c] = new Tower() { Owner = player1 };
                    else if (r == Dimension - 1)
                        chessBoard[r, c] = new Tower() { Owner = player2 };

                    else
                        chessBoard[r, c] = blank;
                }

            }
        }

        public static void ShowChessBoard()
        {
            
            Console.Clear();

            #region Setup headers and top line
            Console.WriteLine("               Player 1");
            Console.Write("    0   1   2   3   4   5   6   7 \n"+ "  ");

            for (int i = 0; i < Dimension; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine("+");

            #endregion

            #region Display the figures in a grid

            int columnCounter = 0;
            int rowCounter = 0;
            bool rowDisplay = true; //determines if to print row number

                foreach (var figure in chessBoard)
                {
                    if (rowDisplay == true) //adds row number if the rowDisplay is set back to true (it's set to true at the end of each line)
                    {
                        Console.Write(rowCounter + verticalLine);
                        rowDisplay = false;
                    }


                    Console.Write(" " + figure.FigureSymbol + verticalLine); //polymorphically prints each figures symbol
                    columnCounter++;

                    if (columnCounter == Dimension) //if the colum amount hits the dimension limit, write a line 
                    {
                        rowCounter++;
                        Console.WriteLine();


                      Console.Write("  ");
                      for (int i = 0; i < Dimension; i++) //after each data row, draw a cosmetic row of lines
                       {
                            Console.Write(horizontalLine);
                       }

                        Console.WriteLine("+");
                        columnCounter = 0; //jumps to a new line and resents columns back to 0
                        rowDisplay = true;
                    }
                }

            Console.WriteLine("               Player 2\n");
            #endregion
        }
        public static void ShowChessBoard(int targetX, int targetY) // method to display the selected figure on the board
        {
          
            Console.Clear();
            #region Setup headers and top line
            Console.WriteLine("               Player 1");
            Console.Write("    0   1   2   3   4   5   6   7 \n" + "  ");

            for (int i = 0; i < Dimension; i++)
            {
                Console.Write(horizontalLine);
            }
            Console.WriteLine("+");

            #endregion

            #region Display the figures in a grid

            int columnCounter = 0;
            int rowCounter = 0;
            bool rowDisplay = true; //determines if to print row number

            foreach (var figure in chessBoard)
            {
                if (rowDisplay == true) //adds row number if the rowDisplay is set back to true (it's set to true at the end of each line)
                {
                    Console.Write(rowCounter + verticalLine);
                    rowDisplay = false;
                }


                if (Chessboard.chessBoard[targetX, targetY] == figure) //if the selected figure is hit, re-print the board with a new color on the selected pawn.
                {
                    if (chessBoard[targetX, targetY].Owner.PlayerNumber == 1)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    
                    Console.Write(" " + figure.FigureSymbol);
                    columnCounter++;
                    Console.ResetColor();
                    Console.Write(" |");
                }
                else
                {
                    
                    Console.Write(" " + figure.FigureSymbol + " |"); //polymorphically prints each figures symbol
                    columnCounter++;
                }

                if (columnCounter == Dimension) //if the colum amount hits the dimension limit, write a line 
                {
                    rowCounter++;
                    Console.WriteLine();


                    Console.Write("  ");
                    for (int i = 0; i < Dimension; i++) //after each data row, draw a cosmetic row of lines
                    {
                        Console.Write(horizontalLine);
                    }

                    Console.WriteLine("+");
                    columnCounter = 0; //jumps to a new line and resents columns back to 0
                    rowDisplay = true;
                }
            }

            Console.WriteLine("               Player 2\n");
            #endregion
        }
    }
}
