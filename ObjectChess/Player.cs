using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    public class Player
    {
        public string Name { get; set; }

        public static int staticPlayerNumber = 1;
        public int PlayerNumber { get; set; }

        bool validChoice = false;
        bool validInputX = false;
        bool validInputY = false;

        public Player(string name)
        {
            Name = name;
            PlayerNumber = staticPlayerNumber;
            staticPlayerNumber++;
        }

        public void Move()
        {
            
            Figure userSelection;
           
                int targetX;
                int targetY;

            do
            {
                Console.WriteLine("\n{0}: which figure would you like to move?",this.Name);
                Console.Write("X = "); validInputX = int.TryParse(Console.ReadLine(), out targetX);
                Console.Write("Y = "); validInputY = int.TryParse(Console.ReadLine(), out targetY);

                validChoice = InputValidator.CheckTargetSelection(this, targetX, targetY);

            } while (!validInputX || !validInputY ||!validChoice);
              
            
            userSelection = Chessboard.chessBoard[targetX, targetY];
            userSelection.Move(userSelection, targetX, targetY);
            Chessboard.chessBoard[targetX, targetY] = new Blank();


        }
    }
}
