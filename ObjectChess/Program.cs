using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectChess
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

          

            Chessboard chessBoard = new Chessboard(player1, player2);



            Console.WriteLine("Would you like to load your previous game? Y/N");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                var newArray = FileService.LoadFromFile(player1, player2);
                Chessboard.chessBoard = newArray;
            }


            while (true)
            {
                Chessboard.ShowChessBoard();
                Console.WriteLine(player1.Name + "'s move!");
                player1.Move();

                Chessboard.ShowChessBoard();
                Console.WriteLine(player2.Name + "'s move!");
                player2.Move();

                FileService.SaveToFile();

            }

            //Console.ReadKey();

        }
    }
}
