using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    public class InputValidator
    {
        //this class has methods to check user input, output errors and allow to use while loops on bools to re-do user selection.


        public static bool CheckTargetSelection(Player player, int targetX, int targetY)
        {
            if (Chessboard.chessBoard[targetX, targetY] is Blank) //if selection is blank, throw error and pass turn.
            {
                Console.WriteLine("Can't select empty spot!");
                Console.Beep();
                Console.ReadKey();
                return false;
            }

            else if (Chessboard.chessBoard[targetX, targetY].Owner.Name != player.Name) //if the currently selected Users figure does not match the "owner" name string, throw an error
            {
                Console.WriteLine("Can't move your opponents figures. Try again!");
                Console.Beep();
                Console.ReadKey();
                return false;
            }

            

            return true;

        }

        public static bool CheckFigureDestination(Figure figure, int targetX, int targetY, int destinationX, int destinationY)
        {
            if (Chessboard.chessBoard[destinationX,destinationY].Owner == Chessboard.chessBoard[targetX, targetY].Owner) //if the currently selected Users figure does not match the "owner" name string, throw an error
            {
                Console.WriteLine("Can't move onto your own figures. Try again!");
                Console.Beep();
                Console.ReadKey();
                return false;
            }

            switch (figure.FigureSymbol)
            {
                //Pawn
                case "P":

                    //if player 1, check current [,] and allow only a move by [+1,]
                    if (Chessboard.chessBoard[targetX, targetY].Owner.PlayerNumber == 1 && destinationX > targetX + 1)
                    {
                        Console.WriteLine("\nCan't move the pawn so far! Try again!");
                        Console.Beep();
                        Console.ReadKey();
                        return false;

                    }

                    //if player 2, check current [,] and allow only a move by [-1,]
                    else if (Chessboard.chessBoard[targetX, targetY].Owner.PlayerNumber == 2 && destinationX < targetX - 1)
                    {
                        Console.WriteLine("\nCan't move the pawn so far! Try again!");
                        Console.Beep();
                        Console.ReadKey();
                        return false;
                    }
                    

                    return true;

                //Tower
                case "T":
                    
                        if (targetX != destinationX && targetY == destinationY) //valid moe if tower is move along the Y axis (Y remains the same, X is changed)
                            return true;
                        else if (targetY != destinationY && targetX == destinationX)//valid moe if tower is move along the X axis (X remains the same, Y is changed)
                            return true;

                        else
                        {
                            Console.WriteLine("\nCan't move the tower this way! Try again!");
                            Console.Beep();
                            Console.ReadKey();
                            return false;
                        }
                    

                default:
                    Console.WriteLine("Error! Try again!");
                    Console.Beep();
                    return false;

            }
        }
    }
}
