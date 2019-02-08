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

        public override int ChoosePiece(int roll,Player currentplayer,int movecount,Tuple<bool,int,int> results)
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
            Console.Write("Press D to roll the Dice, Or press S to save the game :");
            var input = Console.ReadLine();
            if (input.ToUpper() == "S") 
            {
                
            }

            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("You rolled a " + roll1 + " and a " + roll2);
        }


        public override int RollSelector(int roll1, int roll2, Player currentplayer,int movecount)
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
            topPiece.Append("--------------");
            StringBuilder line = new StringBuilder();
            int highestPieceCount = HighestvalueTophalf();
            int topHalfCount = 0;
            Console.WriteLine(topPiece.ToString());
            for (int i = 0; i < (highestPieceCount); i++)
            {
                line.Append("|");
                for (int a = 23; a > 11; a--)
                {
                    if (Board.Locations[a].Number - topHalfCount > 0)
                    {
                        var zeroOrOne = Board.Locations[a].Colour;
                        if (zeroOrOne == Colours.White)
                        {

                            line.Append("0");

                        }
                        else if (zeroOrOne == Colours.Black)
                        {

                            line.Append("1");

                        }
                    }
                    else
                    {
                        line.Append(".");
                    }
                }
                line.Append("|");
                Console.WriteLine(line.ToString());
                line.Clear();
                topHalfCount = topHalfCount + 1;
            }
            StringBuilder middlePiece = new StringBuilder();
            middlePiece.Append("--------------" + "          Pieces that have been taken by the other player; Black pieces =" + Board.Locations[40].Number + " White pieces =" + Board.Locations[41].Number + " B:" + Board.Locations[50].Number + " W:" + Board.Locations[51].Number);
            Console.WriteLine(middlePiece.ToString());
            int bottomHalfCount = highestValueBottomHalf();
            int bottomHighestValue = highestValueBottomHalf();
            for (int i = 0; i < bottomHighestValue; i++)
            {
                line.Append("|");
                for (int a = 0; a < 12; a++)
                {
                    if (Board.Locations[a].Number - bottomHalfCount >= 0)
                    {
                        var zeroOrOne = Board.Locations[a].Colour;
                        if (zeroOrOne == Colours.White)
                        {

                            line.Append("0");

                        }
                        else if (zeroOrOne == Colours.Black)
                        {

                            line.Append("1");

                        }
                    }
                    else
                    {
                        line.Append(".");
                    }
                }
                line.Append("|");
                Console.WriteLine(line.ToString());
                line.Clear();
                bottomHalfCount = bottomHalfCount - 1;
            }
            StringBuilder bottomPiece = new StringBuilder();
            bottomPiece.Append("--------------");
            Console.WriteLine(bottomPiece);

        }
        
           
        
        public int HighestvalueTophalf()
        {
            int highestValue = 0;
            for (int i = 23; i > 11; i--)
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
        public int highestValueBottomHalf()
        {
            int highestValue = 0;
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




