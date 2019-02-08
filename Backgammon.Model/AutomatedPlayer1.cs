using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer1 : AutomatedPlayer
    {
        private Random rnd = new Random();
        public AutomatedPlayer1(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll,Player currentplayer,int moveCount, Tuple<bool,int, int> doubleMove)
        {
           return SelectionOfRandomVM(roll, currentplayer);

        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer,int moveCount)
        {
            if (Board.ValidMoves(currentplayer.Colour, roll1).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll2).Count > 0)
            {
                return roll2;
            }
            else
            {
                return roll1;
            }
               
        }

        public override void UpdatePlayer()
        {
        }

        public override void RollChange(int roll)
        {
        }

        public override void NoValidMoves()
        {
        }
    }
}
