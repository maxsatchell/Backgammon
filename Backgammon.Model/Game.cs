using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class Game
    {
        //used for alternating next move
        //if no valid moves available then flips back to the last player
        //returns the colour of which turn it is.
        public Colours Colour { get; private set; }
        public Dice Dice { get; set; }
        public Game(Colours colour,Dice dice)
        {
            Colour = colour;
            Dice = Dice;
        }
        //game has a method called run and where people make move
        //Methods of 
        public void Run(Player player)
        {
            Console.WriteLine("It is " + player.Colour + " turn");
            var roll1 = Dice.Throw();
            var roll2 = Dice.Throw();
            Console.WriteLine("You rolled a " + roll1 + " and a " + roll2);
            //output dice           
            if (Board.ValidMoves(player.Colour, roll1).Count == 0 & Board.ValidMoves(colour, roll2).Count == 0)
            {
                Console.WriteLine("No valid moves available");
                return;
            }
            if (roll1 == roll2)
            {
                Console.WriteLine("You rolled a double! This means that you get 4 throws");
                MoveOneDice(colour, roll1);
                MoveOneDice(colour, roll2);
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
                return;
            }
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

    }
}
