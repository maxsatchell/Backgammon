using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer3 : Player
    {
        public AutomatedPlayer3(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer)
        {
            
            throw new NotImplementedException();
            if (true)
            {

            }
        }

        public override void NoValidMoves()
        {
        }

        public override void RollChange(int roll)
        {
        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer)
        {
            var doubleMoves = Board.DoubleMoves(roll1,roll2,currentplayer);
            var smallerRoll = 0;
            if (roll1 < roll2)
            {
                smallerRoll = roll1;
            }
            else
            {
                smallerRoll = roll2;
            }
            if (doubleMoves.Count > 0)
            {
                
            }
            throw new NotImplementedException();
        }

        public override void UpdatePlayer()
        {
        }
    }
}
