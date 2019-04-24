using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon.Model;

namespace Backgammon.Testsimualtions
{
    public class SimulationsProgram
    {
        static Board Board { get; set; }
        static Dice Dice { get; set; }
        static Game Game { get; set; }
        static Player Player1 { get; set; }
        static Player Player2 { get; set; }
        static Player Currentplayer { get; set; }

        static void Main(string[] args)
        {
            var repeater = true;
            do
            {
                var winsForBlack = 0;
                var winsForWhite = 0;
                Board = new Board(Dice);
                ChooseBots();
                Console.Write("How many games would you like to play :");
                var input = Console.ReadLine();
                int number = Convert.ToInt32(input);
                for (int i = 0; i < number; i++)
                {

                    while (Board.Locations[50].Number < 15 & Board.Locations[51].Number < 15)//End game condition here that can be looked at 
                    {
                        Game.Run();
                    }

                    if (Board.Locations[50].Number == 15)
                    {
                        winsForBlack = winsForBlack + 1;
                    }
                    else
                    {
                        winsForWhite = winsForWhite + 1;
                    }

                    //add the results of the matches to a DB
                    Board = new Board(Dice);
                    RefreshBots();

                }

                Console.WriteLine("White won :" + winsForWhite + " times");
                Console.WriteLine("Black won :" + winsForBlack + " times");
                Console.Write("Would you like to repeat this process (y = yes, n = no) :");
                var input2 = Console.ReadLine();
                if (input2 == "y")
                {
                    repeater = true;
                }
                else
                {
                    repeater = false; 
                }
                Console.ReadKey();
            } while (repeater == true);
           
        }
        private static void RefreshBots()
        {
            if (Player1.Name == "AutomatedPlayer1")
            {
                Player1 = new AutomatedPlayer1("AutomatedPlayer1", Colours.White, Board);
            }
            else if (Player1.Name == "AutomatedPlayer2")
            {
                Player1 = new AutomatedPlayer2("AutomatedPlayer2", Colours.White, Board);
            }
            else if (Player1.Name == "AutomatedPlayer3A")
            {
                Player1 = new AutomatedPlayer3A("AutomatedPlayer3A", Colours.White, Board);
            }
            else if (Player1.Name == "AutomatedPlayer3B")
            {
                Player1 = new AutomatedPlayer3B("AutomatedPlayer3B", Colours.White, Board);
            }
            else
            {
                Player1 = new RunningGamePlayer("RunningGamePlayer", Colours.White, Board);
            }




            if (Player2.Name == "AutomatedPlayer1")
            {
                Player2 = new AutomatedPlayer1("AutomatedPlayer1", Colours.Black, Board);
            }
            else if (Player2.Name == "AutomatedPlayer2")
            {
                Player2 = new AutomatedPlayer2("AutomatedPlayer2", Colours.Black, Board);
            }
            else if (Player2.Name == "AutomatedPlayer3A")
            {
                Player2 = new AutomatedPlayer3A("AutomatedPlayer3A", Colours.Black, Board);
            }          
            else if (Player2.Name == "AutomatedPlayer3B")
            {
                Player2 = new AutomatedPlayer3B("AutomatedPlayer3B", Colours.Black, Board);
            }
            else
            {
                Player2 = new RunningGamePlayer("RunningGamePlayer", Colours.Black, Board);
                
            }

            Currentplayer = Player1;
            Game = new Game(Player1, Player2, Currentplayer, Board);
        }
        private static void ChooseBots()
        {
            var player1type = "";
            var player2type = "";
            var player1botselection = "";
            var player2botselection = "";
            var botselectionrepeater1 = false;
            var botselectionrepeater2 = false;


            Console.WriteLine("Please select the bots that you will want to test aganist each other");
            Console.WriteLine("What type of bot would you like (b = basic bot, d = defensive bot, ad = advanced defensive bot, adb = advanced defensive bot B)");
          
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


            if (player1type == "Basic Bot")
            {
                Player1 = new AutomatedPlayer1("AutomatedPlayer1", Colours.White, Board);
            }
            else if (player1type == "Defensive Bot")
            {
                Player1 = new AutomatedPlayer2("AutomatedPlayer2", Colours.White, Board);
            }
            else if (player1type == "Advanced Defensive Bot")
            {
                Player1 = new AutomatedPlayer3A("AutomatedPlayer3A", Colours.White, Board);
            }
            else if (player1type == "Advanced Defensive Bot B")
            {
                Player1 = new AutomatedPlayer3B("AutomatedPlayer3B", Colours.White, Board);
            }
            else if (player1type == "Running Game Strategy")
            {
                Player1 = new RunningGamePlayer("Running Game Strategy", Colours.White, Board);
            }
            else
            {
                Player1 = new BlitzPlayer("Blitz Player", Colours.White, Board);
            }




            if (player2type == "Basic Bot")
            {
                Player2 = new AutomatedPlayer1("AutomatedPlayer1", Colours.Black, Board);
            }
            else if (player2type == "Defensive Bot")
            {
                Player2 = new AutomatedPlayer2("AutomatedPlayer2", Colours.Black, Board);
            }
            else if (player2type == "Advanced Defensive Bot")
            {
                Player2 = new AutomatedPlayer3A("AutomatedPlayer3A", Colours.Black, Board);
            }
            else if(player2type == "Advanced Defensive Bot B")
            {
                Player2 = new AutomatedPlayer3B("AutomatedPlayer3B", Colours.Black, Board);
            }
            else if (player2type == "Running Game Strategy")
            {
                Player2 = new RunningGamePlayer("Running Game Strategy", Colours.Black, Board);
            }
            else
            {
                Player2 = new BlitzPlayer("Blitz Player", Colours.Black, Board);
            }

            Currentplayer = Player1;
            Game = new Game(Player1, Player2, Currentplayer, Board);

        }


        
            
        
    }
}
