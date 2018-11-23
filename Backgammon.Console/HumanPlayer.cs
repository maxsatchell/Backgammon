using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon.Model;

namespace Backgammon.ConsoleUI
{

    public class HumanPlayer : Player
    {
        static Dice Dice { get; set; }
        public HumanPlayer(string name, Colours colour,Board board) : base(name, colour,board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll,Player currentplayer)
        {
            var checker = Board.ValidMoves(currentplayer.Colour, roll);
            var validSelection = false;
            int locationidentifier = 0;
            do
            {
                Console.WriteLine("If your piece has been taken your piece will come in on the dice you chose in this case select the location corresponding to this dice roll");

                Console.WriteLine("Select a piece from the Board to move. E.G. press 1 to move the pieces in location 1 :");
                var piecelocation = Console.ReadLine();
                locationidentifier = Convert.ToInt32(piecelocation);
                if (checker.Contains(locationidentifier))
                {
                    validSelection = true;
                }
                else
                {
                    Console.WriteLine("Invalid selection please restart");
                }
            } while (validSelection == false);
            return locationidentifier;
           
        }

        
        public static void OutputDice(int roll1,int roll2)
        {
            Console.Write("Press D to roll the Dice :");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("You rolled a " + roll1 + " and a " + roll2);
        }


        public override int RollSelector(int roll1, int roll2, Player currentplayer)
        {
            OutputDice(roll1, roll2);
            if (roll1 == roll2)
            {
                Console.WriteLine("You rolled a double! This means that you get 4 throws");
                return roll1;
            }
            do
            {
                Console.WriteLine("Select the dice that you would like to use first.");
                if (Board.ValidMoves(currentplayer.Colour, roll1).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll2).Count < 0)
                {
                    Console.WriteLine("You have not got any available moves with " + roll1);
                    Console.WriteLine("Please select the dice " + roll2 + " to begin with");
                }
                else if (Board.ValidMoves(currentplayer.Colour, roll2).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll1).Count < 0)
                {
                    Console.WriteLine("You have not got any available moves with " + roll2);
                    Console.WriteLine("Please select the dice " + roll1 + " to begin with");
                }
                Console.WriteLine("To select the dice you would like to use first press the number that it is : ");
                var dicePicker = Console.ReadLine();
                var diceCheckone = Convert.ToString(roll1);
                var diceChecktwo = Convert.ToString(roll2);
                if (dicePicker == diceCheckone)
                {
                    Console.WriteLine("You have selected the dice " + diceCheckone + " your next roll will be with " + diceChecktwo);
                    return roll1;
                }
                else if (dicePicker == diceChecktwo)
                {
                    Console.WriteLine("You have selected the dice " + diceChecktwo + " your next roll will be with "+ diceCheckone);
                    return roll2;
                }
                else
                {
                    Console.WriteLine("Invalid input please restart the process");
                }
            } while (true);
             
        }

        public override void UpdatePlayer()
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

        public override void RollChange(int roll)
        {
            Console.WriteLine("There are no available moves on the dice you have selected!");
            Console.WriteLine("But there are availble moves with the other roll "+roll);
            Console.WriteLine(roll + " is the dice you have now selected");
        }

        public override void NoValidMoves()
        {
            Console.WriteLine("There are no valid moves available switching turn");
        }
    }
}




