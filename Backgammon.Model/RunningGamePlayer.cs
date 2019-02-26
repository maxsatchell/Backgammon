using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class RunningGamePlayer : AutomatedPlayer3A
    {
        public RunningGamePlayer(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer, int movecCount, Tuple<bool, int, int> doubleMove)
        {
            if (PipCount(currentplayer.Colour) <130)
            {
                if (doubleMove.Item1 == true)
                {
                    if (movecCount == 1)
                    {
                        return doubleMove.Item2;
                    }
                    else
                    {
                        return doubleMove.Item3;
                    }
                }
                if (currentplayer.Colour == Colours.Black)
                {
                    return SelectionOfHighestVMBlack(roll,currentplayer);
                }
                else 
                {
                    return SelectionOfLowestVMWhite(roll, currentplayer);
                }           
            }
            else
            {
                return base.ChoosePieceInNormalPlay(roll, currentplayer, movecCount, doubleMove);
            }
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
