using System;
using System.Text;
using Backgammon.Model;

namespace Backgammon.ConsoleUI
{
    public class Program
    {
        static Board Board { get; set; }
        static Dice Dice { get; set; }
        static Game Game { get; set; }
        static Player Player1 { get; set; }
        static Player Player2 { get; set; }
        static Player Currentplayer { get; set; }
        

        static void Main(string[] args)
        {
            StartNewGame();
            ChooseColors();

            while (Board.Locations[50].Number < 15 & Board.Locations[51].Number < 15)
            {

               
                Game.Run();
                
                Console.ReadKey();
                Console.Clear();
                BoardOutputter();
            }

            BoardOutputter();
            GameOver();
            Console.ReadKey();

        }
        private static void UpdatePlayer()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Current player is ");
        }


        private static void StartNewGame()
        {
            Console.WriteLine("Welcome to the best backgammon game on the internet");
            Console.WriteLine("The game will start soon");
            
            Board = new Board(Dice);//where you load
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
                Console.Write("For human vs human press H; For human vs bot press HB; For bot vs bot press B :");
                var playerselect = Console.ReadLine();
                if (playerselect.ToUpper() == "H")
                {
                    Console.WriteLine("You have selected human vs human!");
                    Console.Write("Are you a novice player Y/N :");
                    var input = Console.ReadLine();
                    if (input.ToUpper() == "Y")
                    {
                        Console.WriteLine("Enabling hints");
                        player1type = "Novice";
                        player2type = "Novice";
                        Console.WriteLine("You can now customize the players");
                        repeater = true;
                    }
                    else
                    {
                        Console.WriteLine("You can now customize the players");
                        player1type = "Human";
                        player2type = "Human";
                        repeater = true;
                    }
                   
                }
                else if (playerselect.ToUpper() == "B")
                {

                    Console.WriteLine("You have selected bot vs bot");
                    Console.WriteLine("You can now customize the players");
                    Console.WriteLine("What type of bot would you like (b = basic bot, d = defensive bot, ad = advanced defensive bot, adb = advanced defensive bot B, rgs = Running game strategy, bp = Blitz player)");
                    do
                    {
                        Console.Write("Select Player 1s bot type :");
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
                        else if (player1botselection.ToUpper() == "AD")
                        {
                            player1type = "Advanced Defensive Bot";
                            botselectionrepeater1 = true;
                        }
                        else if (player1botselection.ToUpper() == "ADB")
                        {
                            player1type = "Advanced Defensive Bot B";
                            botselectionrepeater1 = true;
                        }
                        else if (player1botselection.ToUpper() == "RGS")
                        {
                            player1type = "Running Game Strategy";
                            botselectionrepeater1 = true;
                        }
                        else if (player1botselection.ToUpper() == "BP")
                        {
                            player1type = "Blitz Player";
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
                        Console.Write("Select Player 2s bot type :");
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
                        else if (player2botselection.ToUpper() == "AD")
                        {
                            player2type = "Advanced Defensive Bot";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "ADB")
                        {
                            player2type = "Advanced Defensive Bot B";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "RGS")
                        {
                            player2type = "Running Game Strategy";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "BP")
                        {
                            player2type = "Blitz Player";
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
                    Console.WriteLine("Are you a novice player Y/N :");
                    var input = Console.ReadLine();
                    if (input.ToUpper() == "Y")
                    {
                        Console.WriteLine("Enabling hints");
                        player1type = "Novice";                      
                        Console.WriteLine("You can now customize the players");
                    }
                    else
                    {
                        player1type = "Human";
                    }
                   
                    Console.WriteLine("Player 1 is human");
                    Console.WriteLine("What type of bot would you like (b = basic bot, d = defensive bot, ad = advanced defensive bot, adb = advanced defensive bot B,rgs = Running game strategy,bp = Blitz player)");
                    do
                    {
                        Console.Write("Select Players bot type :");
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
                        else if (player2botselection.ToUpper() == "AD")
                        {
                            player2type = "Advanced Defensive Bot";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "ADB")
                        {
                            player2type = "Advanced Defensive Bot B";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "RGS")
                        {
                            player2type = "Running Game Strategy";
                            botselectionrepeater2 = true;
                        }
                        else if (player2botselection.ToUpper() == "BP")
                        {
                            player2type = "Blitz Player";
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
                else
                {
                    Console.WriteLine("Invalid selection restarting player selection process");
                    repeater = false;
                }
            } while (repeater == false);

            Console.Write("Name player 1 :");
            player1name = Console.ReadLine();
            Console.Write("Name player 2 :");
            player2name = Console.ReadLine();
            Console.WriteLine("Last step please pick a colour for player 1, player 2 will be the other colour!");

            do
            {
                Console.Write("Select colour (b = black, w = white) :");
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
                Player1 = new HumanPlayer(player1name, player1colour, Board);
            }
            else if (player1type == "Novice")
            {
                Player1 = new NovicePlayer(player1name, player1colour, Board);
            }
            else if (player1type == "Basic Bot")
            {
                Player1 = new AutomatedPlayer1(player1name, player1colour, Board);
            }
            else if (player1type == "Defensive Bot")
            {
                Player1 = new AutomatedPlayer2(player1name, player1colour, Board);
            }
            else if (player1type == "Advanced Defensive Bot")
            {
                Player1 = new AutomatedPlayer3A(player1name, player1colour, Board);
            }
            else if (player1type == "Advanced Defensive Bot B")// ADDD IN IF STATEMENTS FOR IF 
            {
                Player1 = new AutomatedPlayer3B(player1name, player1colour, Board);
            }
            else if (player1type == "Running Game Strategy")
            {
                Player1 = new RunningGamePlayer(player1name, player1colour, Board);
            }
            else
            {
                Player1 = new BlitzPlayer(player1name, player1colour, Board);
            }


            if (player2type == "Human")
            {
                Player2 = new HumanPlayer(player2name, player2colour, Board);
            }
            else if (player2type == "Novice")
            {
                Player2 = new NovicePlayer(player2name, player2colour, Board);
            }
            else if (player2type == "Basic Bot")
            {
                Player2 = new AutomatedPlayer1(player2name, player2colour, Board);
            }
            else if (player2type == "Defensive Bot")
            {
                Player2 = new AutomatedPlayer2(player2name, player2colour, Board);
            }
            else if (player2type == "Advanced Defensive Bot")
            {
                Player2 = new AutomatedPlayer3A(player2name, player2colour, Board);
            }
            else if(player2type == "Advanced Defensive Bot B")
            {
                Player2 = new AutomatedPlayer3B(player2name, player2colour, Board);
            }
            else if (player2type == "Running Game Strategy")
            {
                Player2 = new RunningGamePlayer(player2name, player2colour, Board);
            }
            else
            {
                Player2 = new BlitzPlayer(player2name, player2colour, Board);
            }

            Currentplayer = Player1;


            Game = new Game(Player1, Player2, Currentplayer, Board);

            BoardOutputter();
        }



       
        private static void BoardOutputter()
        {
            StringBuilder topPiece = new StringBuilder();
            topPiece.Append("---------------------------------------");
            StringBuilder LocationIdenTop = new StringBuilder();
            LocationIdenTop.Append("| 23 22 21 20 19 18  17 16 15 14 13 12|");
            StringBuilder line = new StringBuilder();
            int highestPieceCount = HighestvalueTophalf();           
            int topHalfCount = 0;
            Console.WriteLine(topPiece.ToString());
            Console.WriteLine(LocationIdenTop.ToString());
            Console.WriteLine(topPiece.ToString());
            for (int i = 0; i < (highestPieceCount); i++)
            {
                line.Append("|");
                for (int a = 23; a >11; a--)
                {
                    if (a == 17)
                    {
                        line.Append("|");
                    }
                    if (Board.Locations[a].Number - topHalfCount > 0)
                    {
                        var zeroOrOne = Board.Locations[a].Colour;                       
                        if (zeroOrOne == Colours.White)
                        {
                           
                                line.Append(" 0 ");
                            
                        }
                        else if (zeroOrOne == Colours.Black)
                        {
                           
                                line.Append(" 1 ");
                            
                        }
                    }
                    else
                    {
                        line.Append(" . ");
                    }
                }
                line.Append("|");
                Console.WriteLine(line.ToString());
                line.Clear();
                topHalfCount = topHalfCount + 1;
            }
            StringBuilder middlePiece = new StringBuilder();
            middlePiece.Append("---------------------------------------" + "  Pieces that have been taken by the other player; Black pieces =" + Board.Locations[40].Number + " White pieces =" + Board.Locations[41].Number + " B:" + Board.Locations[50].Number + " W:" + Board.Locations[51].Number);
            Console.WriteLine(middlePiece.ToString());
            int bottomHalfCount = highestValueBottomHalf();
            int bottomHighestValue = highestValueBottomHalf();           
            for (int i = 0; i < bottomHighestValue; i++)
            {
                line.Append("|");
                for (int a = 0; a < 12; a++)
                {
                    if (a == 6)
                    {
                        line.Append("|");
                    }
                    if (Board.Locations[a].Number - bottomHalfCount >= 0)
                    {
                        var zeroOrOne = Board.Locations[a].Colour;
                        if (zeroOrOne == Colours.White)
                        {

                            line.Append(" 0 ");

                        }
                        else if (zeroOrOne == Colours.Black)
                        {

                            line.Append(" 1 ");

                        }
                    }
                    else
                    {
                        line.Append(" . ");
                    }
                }
                line.Append("|");
                Console.WriteLine(line.ToString());
                line.Clear();
                bottomHalfCount = bottomHalfCount - 1;
            }
            StringBuilder bottomPiece = new StringBuilder();
            bottomPiece.Append("---------------------------------------");
            StringBuilder LocationIdenBottom = new StringBuilder();
            LocationIdenBottom.Append("| 0  1  2  3  4  5   6  7  8  9  10 11|");
            Console.WriteLine(bottomPiece);
            Console.WriteLine(LocationIdenBottom.ToString());
            Console.WriteLine(bottomPiece);

        }
        private static int HighestvalueTophalf()
        {
            int highestValue = 5;
            for (int i = 23; i > 11 ; i--)
            {
                int valueChecker = 0;
                valueChecker = Board.Locations[i].Number;
                if (valueChecker > highestValue)
                {
                    highestValue = valueChecker;
                }
            }
            return highestValue;
        }
        private static int highestValueBottomHalf()
        {
            int highestValue = 5;
            for (int i = 0; i < 12; i++)
            {
                int valueChecker = 0;
                valueChecker = Board.Locations[i].Number;
                if (valueChecker > highestValue)
                {
                    highestValue = valueChecker;
                }
            }
            return highestValue;

        }


    }

}
