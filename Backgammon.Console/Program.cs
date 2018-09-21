using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon.Model;

namespace Backgammon.ConsoleUI
{
    public class Program
    {
        static Board Board{ get; set; }
        static Dice Dice { get; set; }
        static void Main(string[] args)
        {
            Dice = new Dice();
            Console.WriteLine("Welcome to the best backgammon game on the internet");
            Console.WriteLine("The game will start soon");
            Console.Write("Please pick a colour White or Black :");
            var ColourPicker = Console.ReadLine();
            Console.WriteLine("The Board is now initializing good luck :)");
            BoardRender();
            Console.WriteLine("White to move first ");
            do
            {
                Move(Globals.Gcolour);
                Console.ReadKey();
            } while (true);
            
               
        }
        public static void BoardRender()
        {
            Board = new Board(Dice);
            StringBuilder topPiece = new StringBuilder();
            StringBuilder bottomPiece = new StringBuilder();
            topPiece.Append("-----------------");
            Console.WriteLine(topPiece.ToString());
            int count = 23;
            int dots = 7;
            
            for (int i = 0; i < 12; i++)
            {
                if (i==6)
                {
                    Console.WriteLine("|---------------|");
                }
                StringBuilder piece = new StringBuilder();
                piece.Append("|");
                var zeroOrOne = Board.Locations[i].Colour;
                var zeroOrOneC = Board.Locations[count].Colour;
                if (zeroOrOne == Colours.White)
                {
                    for (int a = 0; a < Board.Locations[i].Number; a++)
                    {
                        piece.Append("0");
                    }
                }
                else if (zeroOrOne == Colours.Black)
                {
                    for (int a = 0; a < Board.Locations[i].Number; a++)
                    {
                        piece.Append("1");
                    }
                }
                for (int c = 0; c < dots - Board.Locations[i].Number; c++)
                {
                    piece.Append(".");
                }
                piece.Append("|");
                for (int c = 0; c < dots - Board.Locations[count].Number; c++)
                {
                    piece.Append(".");
                }
                if (zeroOrOneC == Colours.White)
                {
                    for (int a = 0; a < Board.Locations[count].Number; a++)
                    {
                        piece.Append("0");
                    }
                }
                else if (zeroOrOneC == Colours.Black)
                {
                    for (int a = 0; a < Board.Locations[count].Number; a++)
                    {
                        piece.Append("1");
                    }
                }
                piece.Append("|");
                count = count - 1;
                Console.WriteLine(piece.ToString());
            }
            bottomPiece.Append("-----------------");
            Console.WriteLine(bottomPiece.ToString());

            Console.WriteLine("                                            ");

        }
        public static void Move(Colours colour)
        {
            //interation with the user only
            //Must know which colour it is to roll dice
            Console.WriteLine("It is " + colour + " turn");
            Console.Write("Press D to roll the Dice :");
            Console.ReadKey();
            Console.WriteLine();
            var roll1 = Dice.Throw();
            var roll2 = Dice.Throw();
            Console.WriteLine("You rolled a "+roll1+" and a "+roll2);
            //output dice

            MoveOneDice(colour, roll1);
            MoveOneDice(colour, roll2);
            if (colour == Colours.White)
            {
                Globals.Gcolour = Colours.Black;
            }
            else
            {
                Globals.Gcolour = Colours.White;
            }
    
        }

        private static void MoveOneDice(Colours colour, int roll)
        {
            var oldBoard = Board.Locations;
                do
                {
                Console.WriteLine("Select a piece from the Board to move. E.G. press 1 to move the pieces in location 1 :");
                int pieceNumber = Convert.ToInt32(Console.ReadLine());
                Board.executeMove(Globals.Gcolour, pieceNumber, roll);
               
            } while (oldBoard != Board.Locations);
            BoardOutputter();

            //select piece you would like to move

        }
        public static void BoardOutputter()
        {

            StringBuilder topPiece = new StringBuilder();
            StringBuilder bottomPiece = new StringBuilder();
            topPiece.Append("-----------------");
            Console.WriteLine(topPiece.ToString());
            int count = 23;
            int dots = 7;
            for (int i = 0; i < 12; i++)
            {
                if (i == 6)
                {
                    Console.WriteLine("|---------------|");
                }
                StringBuilder piece = new StringBuilder();
                piece.Append("|");
                var zeroOrOne = Board.Locations[i].Colour;
                var zeroOrOneC = Board.Locations[count].Colour;
                if (zeroOrOne == Colours.White)
                {
                    for (int a = 0; a < Board.Locations[i].Number; a++)
                    {
                        piece.Append("0");
                    }
                }
                else if (zeroOrOne == Colours.Black)
                {
                    for (int a = 0; a < Board.Locations[i].Number; a++)
                    {
                        piece.Append("1");
                    }
                }
                for (int c = 0; c < dots - Board.Locations[i].Number; c++)
                {
                    piece.Append(".");
                }
                piece.Append("|");
                for (int c = 0; c < dots - Board.Locations[count].Number; c++)
                {
                    piece.Append(".");
                }
                if (zeroOrOneC == Colours.White)
                {
                    for (int a = 0; a < Board.Locations[count].Number; a++)
                    {
                        piece.Append("0");
                    }
                }
                else if (zeroOrOneC == Colours.Black)
                {
                    for (int a = 0; a < Board.Locations[count].Number; a++)
                    {
                        piece.Append("1");
                    }
                }
                piece.Append("|");
                count = count - 1;
                Console.WriteLine(piece.ToString());
            }
            bottomPiece.Append("-----------------");
            Console.WriteLine(bottomPiece.ToString());
        }
        
        
    }
}
