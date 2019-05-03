using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    public class Pawn : Figure
    {
        public override string FigureSymbol { get; set; }

        int destinationX;
        bool validChoice = false;
        bool validDestinationX = false;

        public override Player Owner { get; set; }

        public Pawn()
        {
            FigureSymbol = "P";
        }

        public override void Move(Figure figure, int targetX, int targetY)
        {
            //gets the figure to move from Player.Move()
            Chessboard.ShowChessBoard(targetX, targetY); //displays the current selection

            do
            {
                Console.WriteLine("Where would you like to move the pawn?");
                Console.Write("X = "); validDestinationX = int.TryParse(Console.ReadLine(), out destinationX);
                Console.Write("Y = {0}", targetY);

                if (!validDestinationX)
                {
                    Console.WriteLine("\nInvalid X. Try again\n");
                    continue;
                }
                validChoice = InputValidator.CheckFigureDestination(figure, targetX, targetY, destinationX, 0);
                
            } while (!validChoice || !validDestinationX);
           
            

            
            Chessboard.chessBoard[destinationX, targetY] = figure; //moves the figure to the destination selected by the user.
            //Console.ReadKey();
        }
    }

       
}

