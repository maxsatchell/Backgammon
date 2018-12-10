using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer3B : AutomatedPlayer3A
    {
        private Random rnd = new Random();
        public AutomatedPlayer3B(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer, int movecount, Tuple<bool, int, int> doubleMove)
        {
            if (Board.EndGameChecker(currentplayer.Colour) == true)
            {
                return ChoosePieceInEndGame(roll, currentplayer, movecount, doubleMove);
            }
            else
            {
                return base.ChoosePiece(roll, currentplayer, movecount, doubleMove);
            }
            
        }

        public override void NoValidMoves()
        {
            base.NoValidMoves();
        }

        public override void RollChange(int roll)
        {
            base.RollChange(roll);
        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer, int moveCount)
        {
            return base.RollSelector(roll1, roll2, currentplayer, moveCount);
        }

        public override void UpdatePlayer()
        {
            base.UpdatePlayer();
        }

        protected override int ChoosePieceInEndGame(int roll, Player currentplayer, int movecount, Tuple<bool, int, int> doubleMove)
        {
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var safeLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);
            List<int> validTakeOffMoves = new List<int>();
            var minimumBlack = Board.CalculateMinimumBlack(roll);
            var maximumWhite = Board.CalculateMaximumWhite(roll);


            if (currentplayer.Colour == Colours.Black)
            {
                foreach (var location in safeLocations)
                {
                    var locator = location - roll;
                    if (locator == minimumBlack | locator == -1)
                    {
                        validTakeOffMoves.Add(location);
                    }
                }
            }
            else
            {
                foreach (var location in safeLocations)
                {
                    var locator = location + roll;
                    if (locator == minimumBlack | locator == 24)
                    {
                        validTakeOffMoves.Add(location);
                    }
                }
            }
            if (validTakeOffMoves.Count >0)
            {
                int randomLocation = rnd.Next(validTakeOffMoves.Count);
                int selection = validTakeOffMoves[randomLocation];
                return selection;
            }
            else
            {
                int randomLocation = rnd.Next(validMoves.Count);
                int selection = validMoves[randomLocation];
                return selection;
            }
                

        }

        protected override int ChoosePieceInNormalPlay(int roll, Player currentplayer, int movecount, Tuple<bool, int, int> doubleMove)
        {
            return base.ChoosePieceInNormalPlay(roll, currentplayer, movecount, doubleMove);
        }
    }
}
