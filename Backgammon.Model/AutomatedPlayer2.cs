using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer2 : AutomatedPlayer
    {
        private Random rnd = new Random();
        public AutomatedPlayer2(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer,int moveCount, Tuple<bool,int, int> doubleMove)
        {
                      
            if (currentplayer.Colour == Colours.Black)
            {
                var validExposedMoves = ValidExposedMovesCreationBlack(roll, currentplayer);
                var validSafeMoves = ValidSafeMovesCreationBlack(roll, currentplayer);
                if (validExposedMoves.Count >0)
                {
                    return SelectionOfRandomVEM(roll, currentplayer, validExposedMoves);
                }
                else if (validSafeMoves.Count > 0)
                {
                    return SelectionOfRandomVSM(roll, currentplayer, validSafeMoves);
                }
                else
                {
                   return SelectionOfRandomVM(roll, currentplayer);
                }
            }
            else 
            {

                var validExposedMoves = ValidExposedMovesCreationWhite(roll, currentplayer);
                var validSafeMoves = ValidSafeMovesCreationWhite(roll, currentplayer);
                if (validExposedMoves.Count > 0)
                {
                   return SelectionOfRandomVEM(roll, currentplayer, validExposedMoves);
                }
                else if (validSafeMoves.Count > 0)
                {
                    return SelectionOfRandomVSM(roll, currentplayer, validSafeMoves);
                }
                else
                {
                    return SelectionOfRandomVM(roll, currentplayer);
                }
            }
            
        }

        public override void NoValidMoves()
        {
        }

        public override void RollChange(int roll)
        {
        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer,int moveCount)
        {
            if (Board.ValidMoves(currentplayer.Colour, roll1).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll2).Count > 0)
            {
                return roll2;
            }
            if (Board.ValidMoves(currentplayer.Colour, roll2).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll1).Count > 0)
            {
                return roll1;
            }
            if (Board.ValidMoves(currentplayer.Colour, roll1).Count >= Board.ValidMoves(currentplayer.Colour, roll2).Count)
            {
                return roll1;
            }
            if (Board.ValidMoves(currentplayer.Colour, roll2).Count >= Board.ValidMoves(currentplayer.Colour, roll1).Count)
            {
                return roll2;
            }
            return roll1;
 
        }

        public override void UpdatePlayer()
        {
        }
    }
}
