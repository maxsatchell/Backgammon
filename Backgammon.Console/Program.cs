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
            var WEndGame = Board.WEndGameChecker();
            var BEndGame = Board.BEndGameChecker();
            do
            {
                WEndGame = Board.WEndGameChecker();
                BEndGame = Board.BEndGameChecker();
                Move(Globals.Gcolour);
                Console.ReadKey();
            } while (WEndGame ==false | BEndGame == false);

            
            if (WEndGame == true & BEndGame !=true)
            {
                //When colour is black do normal moves still check that board is in the end state as there could have been a white piece taken
                //WEndGameMove();
            }

            
               
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
                    Console.WriteLine("|---------------|" + "          Pieces that have been taken by the other player; Black pieces =" + Board.Locations[24].Number + " White pieces =" + Board.Locations[25].Number);
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
        public static void Move(Colours colour)
        {
            //interation with the user only
            //Must know which colour it is to roll dice.
            Console.WriteLine("It is " + colour + " turn");
            Console.Write("Press D to roll the Dice :");
            Console.ReadKey();
            Console.WriteLine();
            var roll1 = Dice.Throw();
            var roll2 = Dice.Throw();
            Console.WriteLine("You rolled a "+roll1+" and a "+roll2);
            //output dice
            Console.WriteLine("Select the dice that you would like to use first roll number 1 or 2 :");
            var dicePicker = Console.ReadLine();
            if (dicePicker == "1")
            {
                MoveOneDice(colour, roll1);
                MoveOneDice(colour, roll2);
            }
            else
            {
                MoveOneDice(colour, roll2);
                MoveOneDice(colour, roll1);
            }          
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
                Console.WriteLine("If piece has been taken you will come in on the dice you chose to use first");
                Console.WriteLine("Select a piece from the Board to move. E.G. press 1 to move the pieces in location 1 :");        
                int pieceNumber = Convert.ToInt32(Console.ReadLine());
                Board.executeMove(Globals.Gcolour, pieceNumber, roll);//select piece you would like to move
            BoardOutputter();

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
                    Console.WriteLine("|---------------|" + "          Pieces that have been taken by the other player; Black pieces =" + Board.Locations[24].Number + " White pieces =" + Board.Locations[25].Number);
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
