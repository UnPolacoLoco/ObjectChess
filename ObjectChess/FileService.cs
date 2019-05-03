using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ObjectChess
{
    public class FileService
    {
        //this class saves and loads from file

       public static void PrintArray()
        {
            foreach (var figure in Chessboard.chessBoard)
            {
                if (figure is Blank)
                {
                    Console.WriteLine("new Blank()");
                    continue;
                }

                if (figure.Owner.PlayerNumber == 1 && figure is Tower)
                {
                    Console.WriteLine("new Tower() { Owner = player1 }");
                }

                else if (figure.Owner.PlayerNumber == 2 && figure is Tower)
                {
                        Console.WriteLine("new Tower() { Owner = player2 }");
                }

                if (figure.Owner.PlayerNumber == 1 && figure is Pawn)
                {
                    Console.WriteLine("new Pawn() { Owner = player1 }");
                }

                else if (figure.Owner.PlayerNumber == 2 && figure is Pawn)
                {
                    Console.WriteLine("new Pawn() { Owner = player2 }");
                }

                
            }
        }
       public static void SaveToFile()
        {
            using (var writer = new StreamWriter("SaveData.txt"))
            {
                foreach (var figure in Chessboard.chessBoard)
                {
                    //for each type of figure in the array the writer writes a line with codewords
                    //such as "player1", "pawn", "tower" etc.

                    if (figure is Blank)
                    {
                        writer.WriteLine("Blank");
                        continue;
                    }

                    else if (figure.Owner.PlayerNumber == 1 && figure is Tower)
                    {
                        writer.WriteLine("Tower player1");
                    }

                    else if (figure.Owner.PlayerNumber == 2 && figure is Tower)
                    {
                        writer.WriteLine("Tower player2");
                    }

                    else if (figure.Owner.PlayerNumber == 1 && figure is Pawn)
                    {
                        writer.WriteLine("Pawn player1");
                    }

                    else if (figure.Owner.PlayerNumber == 2 && figure is Pawn)
                    {
                        writer.WriteLine("Pawn player2");
                    }


                }
            }
        }
       public static Figure[,] LoadFromFile(Player player1, Player player2)
        {
            string[,] stringArray = new string[Chessboard.Dimension, Chessboard.Dimension];
            Figure[,] arrayToLoad = new Figure[Chessboard.Dimension, Chessboard.Dimension];

            using (var reader = new StreamReader("SaveData.txt"))
            {
                for (int r = 0; r < Chessboard.Dimension; r++)
                {
                    for (int c = 0; c < Chessboard.Dimension; c++)
                    {
                        stringArray[r, c] = reader.ReadLine();
                    }
                }
            }

            for (int r = 0; r < Chessboard.Dimension; r++)
            {
                for (int c = 0; c < Chessboard.Dimension; c++)
                {
                    if (stringArray[r, c].Contains("Blank"))
                        arrayToLoad[r, c] = new Blank();

                    else if (stringArray[r, c].Contains("Tower") && stringArray[r, c].Contains("player1"))
                        arrayToLoad[r, c] = new Tower() { Owner = player1 };

                    else if (stringArray[r, c].Contains("Tower") && stringArray[r, c].Contains("player2"))
                        arrayToLoad[r, c] = new Tower() { Owner = player2 };

                    else if (stringArray[r, c].Contains("Pawn") && stringArray[r, c].Contains("player1"))
                        arrayToLoad[r, c] = new Pawn() { Owner = player1 };

                    else if (stringArray[r, c].Contains("Pawn") && stringArray[r, c].Contains("player2"))
                        arrayToLoad[r, c] = new Pawn() { Owner = player2 };
                }
            }

            return arrayToLoad;
        }
    }
}
