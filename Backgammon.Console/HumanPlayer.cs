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
        static Board Board { get; set; }
        static Dice Dice { get; set; }
        public HumanPlayer(string name, Colours colour) : base(name, colour)
        {
        }

        public override int ChoosePiece(int roll,Player currentplayer)
        {
            var validSelection = false;
            int locationidentifier = 0;
            var availableLocationsToTakeFrom = Board.ValidPieceLocations(currentplayer.Colour);
            do
            {
                Console.WriteLine("If your piece has been taken you piece will come in on the dice you chose press 0 to continue in this case");

                Console.WriteLine("Select a piece from the Board to move. E.G. press 1 to move the pieces in location 1 :");
                var piecelocation = Console.ReadLine();
                locationidentifier = Convert.ToInt32(piecelocation);
                if (availableLocationsToTakeFrom.Contains(locationidentifier))
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
                Console.WriteLine("To select the dice you would like to use first press the number that it is : ");
                var dicePicker = Console.ReadLine();
                var diceCheckone = Convert.ToString(roll1);
                var diceChecktwo = Convert.ToString(roll2);
                if (dicePicker == diceCheckone)
                {
                    Console.WriteLine("You have selected the dice " + diceCheckone + " your next roll will be with the other dice");
                    return roll1;
                }
                else if (dicePicker == diceChecktwo)
                {
                    Console.WriteLine("You have selected the dice " + diceChecktwo + " your next roll will be with the other dice");
                    return roll2;
                }
                else
                {
                    Console.WriteLine("Invalid input please restart the process");
                }
            } while (true);
             
        }
    }



}
