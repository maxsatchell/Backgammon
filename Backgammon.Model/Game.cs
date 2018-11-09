using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{

    public class Game
    {
        //used for Running the game
        //if no valid moves available then flips back to the last player
        //returns the colour of which turn it is.
        public Colours Colour { get; private set; }
        static Board Board { get; set; }
        static Dice Dice { get; set; }

        public Game(Colours colour)
        {
            Colour = colour;
        }
        //game has a method called run and where people make move
        //Methods of 
        public static void Colourswapper(Colours colour)//Make this plaeyr swapper
        {
            if (colour == Colours.White)
            {
                Globals.Gcolour = Colours.Black;
            }
            else
            {
                Globals.Gcolour = Colours.White;
            }
        }
        private void StartNewGame()
        {
            Console.WriteLine("Welcome to the best backgammon game on the internet");
            Console.WriteLine("The game will start soon");
            Board = new Board(Dice);
        }
        private void GameOver()
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
        private void ChooseColors()
        {
            Console.WriteLine("This is the player selection area");
            Console.WriteLine("In this area you can select your colour,name and whether or not you want to play against a bot");
            Console.WriteLine("For human vs human press H; For human vs bot press HB :");
            var playerselect = Console.ReadLine();
            if (playerselect.ToUpper() == "H")
            {
                Console.WriteLine("You have selected human vs human!");                
                var player1type = "Human";
                var player2type = "Human";
            }
            else
            {
                Console.WriteLine("You have selected human vs bot");
                Console.WriteLine("You can now customize the human player");
                var player1type = "Human";
                var player2type = "Bot";
            }
            Console.WriteLine("Name player 1 :");
            var player1name = Console.ReadLine();
            Console.WriteLine("Name player 2 :");
            var player2name = Console.ReadLine();
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
                var player1colour = Colours.Black;
                Console.WriteLine("Player 2 is the colour White");
                var player2colour = Colours.White;
            }
            else
            {
                Console.WriteLine("PLayer 1 has selected White");
                var player1colour = Colours.White;
                Console.WriteLine("Player 2 is the colour Black");
                var player2colour = Colours.Black;
            }

            //player1 = new Player(player1name, player1colour, player1type);
            //player2 = new Player(player2name, player2colour, player2type);



        }
    }
}
