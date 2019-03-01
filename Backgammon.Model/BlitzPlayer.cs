using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class BlitzPlayer : AutomatedPlayer
    {
        public BlitzPlayer(string name, Colours colour, Board board) : base(name, colour, board)
        {
        }

        public override int ChoosePiece(int roll, Player currentplayer, int movecCount, Tuple<bool, int, int> doubleMove)
        {

            //normal play
            //use the pre made exposed method to calclate the expoosed pieces and create the colourflipper method to get the oppenents colour

            //Take oppenents exposed pieces whenever possible
         
            if (Board.ExposedPieces(ColourFlipper(currentplayer)).Count > 0)
            {

            }

            //To begin to build the backboard but with many condidtions on when to move etc

            //highest valid moves when these are not in play.

            //End game play

            //Take safe moves off look at what is left behind, but that should only be the case if you still have a piece taken from an enemy player as otherwise
            //you should just play to take off as much as possible

            throw new NotImplementedException();
        }

        public override void NoValidMoves()
        {
        }

        public override void RollChange(int roll)
        {
        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer, int moveCount)
        {
            var doubleMoves = Board.DoubleMoves(roll1, roll2, currentplayer);
            var smallerRoll = 0;
            var largerRoll = 0;
            if (roll1 < roll2)
            {
                smallerRoll = roll1;
                largerRoll = roll2;
            }
            else
            {
                smallerRoll = roll2;
                largerRoll = roll1;
            }
            if (doubleMoves.Count > 0)
            {
                if (moveCount == 1)
                {
                    return smallerRoll;
                }
                else
                {
                    return largerRoll;
                }
            }
            if (Board.ValidMoves(currentplayer.Colour, roll1).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll2).Count > 0)
            {
                return roll2;
            }
            if (Board.ValidMoves(currentplayer.Colour, roll2).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll1).Count > 0)
            {
                return roll1;
            }
            if (roll1 > roll2)
            {
                return roll1;
            }
            else
            {
                return roll2;
            }
        }

        public override void UpdatePlayer()
        {
        }
    }
}
