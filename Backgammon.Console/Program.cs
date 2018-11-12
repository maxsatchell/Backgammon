using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon.Model;
using Fixtures;

namespace Backgammon.ConsoleUI
{
    public class Program
    {
        static Board Board{ get; set; }
        static Dice Dice { get; set; }
        static void Main(string[] args)
        {
            StartNewGame();
            ChooseColors();
            while (true)//End game condition here that can be looked at 
            {

            }
            

        }
        private void UpdatePlayer()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Current player is " + Currentplayer.Colour);
        }


        private static void StartNewGame()
        {
            Console.WriteLine("Welcome to the best backgammon game on the internet");
            Console.WriteLine("The game will start soon");
            Board = new Board(Dice);
        }


        private static void GameOver()
        {
            Console.WriteLine("  ");
            Console.WriteLine("  ");
            if (Board.Locations[50].Number == 15)
            {
                Console.WriteLine("Congratulations Black has won the game!!!");
            }
            else
            {
                Console.WriteLine("Congratulations White has won the game!!!");
            }
            Console.WriteLine(" ");
            Console.WriteLine("G A M E  O V E R!");

        }


        private static void ChooseColors()
        {
            var player1type = "";
            var player2type = "";
            var player1colour = Colours.Empty;
            var player2colour = Colours.Empty;
            var player1name = "";
            var player2name = "";


            Console.WriteLine("This is the player selection area");
            Console.WriteLine("In this area you can select your colour,name and whether or not you want to play against a bot");
            Console.WriteLine("For human vs human press H; For human vs bot press HB :");
            var playerselect = Console.ReadLine();
            if (playerselect.ToUpper() == "H")
            {
                Console.WriteLine("You have selected human vs human!");
                player1type = "Human";
                player2type = "Human";
            }
            else
            {
                Console.WriteLine("You have selected human vs bot");
                Console.WriteLine("You can now customize the human player");
                player1type = "Human";
                player2type = "Bot";
            }
            Console.WriteLine("Name player 1 :");
            player1name = Console.ReadLine();
            Console.WriteLine("Name player 2 :");
            player2name = Console.ReadLine();
            Console.WriteLine("Last step please pick a colour for player 1 player 2 will be the other colour");
            var player1colourselect = "";
            do
            {
                Console.WriteLine("Select colour (b = black, w = white) :");
                player1colourselect = Console.ReadLine();
            } while (player1colourselect != "b" | player1colourselect != "w");
            if (player1colourselect == "b")
            {
                Console.WriteLine("PLayer 1 has selected Black");
                player1colour = Colours.Black;
                Console.WriteLine("Player 2 is the colour White");
                player2colour = Colours.White;
            }
            else
            {
                Console.WriteLine("PLayer 1 has selected White");
                player1colour = Colours.White;
                Console.WriteLine("Player 2 is the colour Black");
                player2colour = Colours.Black;
            }
            if (player1type == "Human")
            {
                Player Player1 = new HumanPlayer(player1name, player1colour);
            }
            else
            {
                Player Player1 = new AutomatedPlayer1(player1name, player1colour);
            }
            if (player2type == "Human")
            {
                Player Player2 = new HumanPlayer(player2name, player2colour);
            }
            else
            {
                Player Player2 = new AutomatedPlayer1(player2name, player2colour);
            }
           
                    
        }



        private static void BoardOutputter()
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
                    Console.WriteLine("|---------------|" + "          Pieces that have been taken by the other player; Black pieces =" + Board.Locations[40].Number + " White pieces =" + Board.Locations[41].Number + " B:" + Board.Locations[50].Number + " W:" + Board.Locations[51].Number);
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
