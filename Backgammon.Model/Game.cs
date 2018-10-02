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

        public static Bool ()
        {
                
        }
    }
}
