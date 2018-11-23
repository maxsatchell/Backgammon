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
        static Game Game { get; set; }
        static Player Player1 { get; set; }
        static Player Player2 { get; set; }
        static Player Currentplayer { get; set; }

        static void Main(string[] args)
        {
            StartNewGame();
            ChooseColors();

            while (Board.Locations[50].Number < 15 & Board.Locations[51].Number < 15)//End game condition here that can be looked at 
            {
                BoardOutputter();
                Game.Run();
            }

            BoardOutputter();
            GameOver();
            Console.ReadKey();

        }
        private static void UpdatePlayer()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Current player is " );
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
            var selection = false;
            var player1colourselect = "";
            var repeater = false;
            var player1botselection = "";
            var player2botselection = "";
            var botselectionrepeater1 = false;
            var botselectionrepeater2 = false;



            Console.WriteLine("This is the player selection area");
            Console.WriteLine("In this area you can select your colour,name and whether or not you want to play against a bot");
            do
            {
                Console.WriteLine("For human vs human press H; For human vs bot press HB; For bot vs bot press B :");
                var playerselect = Console.ReadLine();
                if (playerselect.ToUpper() == "H")
                {
                    Console.WriteLine("You have selected human vs human!");
                    Console.WriteLine("You can now customize the players");
                    player1type = "Human";
                    player2type = "Human";
                    repeater = true;
                }
                else if (playerselect.ToUpper() == "B")
                {
                    
                    Console.WriteLine("You have selected bot vs bot");
                    Console.WriteLine("You can now customize the players");
                    Console.WriteLine("What type of bot would you like (b = basic bot, d = defensive bot)");
                    do
                    {
                        Console.WriteLine("Select Player 1s bot type :");
                        player1botselection = Console.ReadLine();
                        if (player1botselection.ToUpper() == "B")
                        {
                            player1type = "Basic Bot";
                            botselectionrepeater1 = true;
                        }
                        else if (player1botselection.ToUpper() == "D")
                        {
                            player1type = "Defensive Bot";
                            botselectionrepeater1 = true;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input restarting bot selection process");
                            botselectionrepeater1 = false;
                        }
                    } while (botselectionrepeater1 == false);


                    do
                    {
                        Console.WriteLine("Select Player 2s bot type :");
                        player2botselection = Console.ReadLine();
                        if (player2botselection.ToUpper() == "B")
                        {
                            player2type = "Basic Bot";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "D")
                        {
                            player2type = "Defensive Bot";
                            botselectionrepeater2 = true;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input restarting bot selection process");
                            botselectionrepeater2 = false;
                        }
                    } while (botselectionrepeater2 == false);

                    repeater = true;
                }
                else if (playerselect.ToUpper() == "HB")
                {
                    Console.WriteLine("You have selected human vs bot");
                    Console.WriteLine("You can now customize the players");
                    player1type = "Human";
                    Console.WriteLine("Player 1 is human");
                    Console.WriteLine("What type of bot would you like (b = basic bot, d = defensive bot)");
                    do
                    {
                        Console.WriteLine("Select Players bot type :");
                        player1botselection = Console.ReadLine();
                        if (player1botselection.ToUpper() == "B")
                        {
                            player1type = "Basic Bot";
                            botselectionrepeater1 = true;
                        }
                        else if (player1botselection.ToUpper() == "D")
                        {
                            player1type = "Defensive Bot";
                            botselectionrepeater1 = true;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect input restarting bot selection process");
                            botselectionrepeater1 = false;
                        }
                    } while (botselectionrepeater1 == false);
                    repeater = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection restarting player selection process");
                    repeater = false;
                }
            } while (repeater == false);
            
            Console.WriteLine("Name player 1 :");
            player1name = Console.ReadLine();
            Console.WriteLine("Name player 2 :");
            player2name = Console.ReadLine();
            Console.WriteLine("Last step please pick a colour for player 1 player 2 will be the other colour");
     
            do
            {
                Console.WriteLine("Select colour (b = black, w = white) :");
                player1colourselect = Console.ReadLine();
                if (player1colourselect == "b")
                {
                    selection = true;
                }
                else if (player1colourselect == "w")
                {
                    selection = true;
                }
                else
                {
                    selection = false;
                }
            } while (selection == false);


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
                Player1 = new HumanPlayer(player1name, player1colour,Board);
            }
            else if (player1type == "Basic Bot")
            {
                Player1 = new AutomatedPlayer1(player1name, player1colour, Board);
            }
            else
            {
                Player1 = new AutomatedPlayer2(player1name, player1colour, Board);
            }
            if (player2type == "Human")
            {
                 Player2 = new HumanPlayer(player2name, player2colour,Board);
            }
            else if(player2type == "Basic Bot")
            {
                 Player2 = new AutomatedPlayer1(player2name, player2colour,Board);
            }
            else
            {
                Player2 = new AutomatedPlayer2(player2name, player2colour, Board);
            }
            Currentplayer = Player1;

            Game = new Game(Player1, Player2, Currentplayer,Board);
         
            
            
                    
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
