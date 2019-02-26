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
            //use the pre made exposed method to calclate the expoosed pieces and create the colourflipper method to get the oppenents colour
            throw new NotImplementedException();
        }

        public override void NoValidMoves()
        {
            throw new NotImplementedException();
        }

        public override void RollChange(int roll)
        {
            throw new NotImplementedException();
        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer, int moveCount)
        {
            throw new NotImplementedException();
        }

        public override void UpdatePlayer()
        {
            throw new NotImplementedException();
        }
    }
}
