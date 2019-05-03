using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    public class Tower : Figure
    {
        public override string FigureSymbol { get; set; }
        public override Player Owner { get; set; }

        int destinationX;
        int destinationY;
        bool validChoice = false;
        bool validDestinationX = false;
        bool validDestinationY = false;

        public override void Move(Figure figure, int targetX, int targetY)
        {
            Chessboard.ShowChessBoard(targetX, targetY);

            do
            {
                Console.WriteLine("Where would you like to move the Tower?");
                Console.Write("X = "); validDestinationX = int.TryParse(Console.ReadLine(), out destinationX);
                Console.Write("Y = "); validDestinationY = int.TryParse(Console.ReadLine(), out destinationY);

                if (!validDestinationX || !validDestinationY)
                {
                    Console.WriteLine("\nInvalid move. Try again\n");
                    continue;
                }
                validChoice = InputValidator.CheckFigureDestination(figure, targetX, targetY, destinationX, destinationY);

            } while (!validChoice || !validDestinationX || !validDestinationY);




            Chessboard.chessBoard[destinationX, destinationY] = figure; //moves the figure to the destination selected by the user.
            //Console.ReadKey();
        }

        public Tower()
        {
            FigureSymbol = "T";
        }
    }
}
