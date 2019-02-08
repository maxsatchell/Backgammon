using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public abstract class RunningGamePlayer : AutomatedPlayer
    {
        public RunningGamePlayer(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer, int movecCount, Tuple<bool, int, int> doubleMove)
        {
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
            throw new NotImplementedException();
        }

        public override void UpdatePlayer()
        {           
        }
    }
}
