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
                return ChoosePieceInNormalPlay(roll, currentplayer, movecount, doubleMove);
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
            var colourLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);
            List<int> validTakeOffMoves = new List<int>();
           
            


            if (currentplayer.Colour == Colours.Black)
            {
                var minimumBlack = Board.CalculateMinimumBlack(roll, currentplayer.Colour);
                foreach (var location in colourLocations)
                {
                    var locator = location - roll;
                    if ((locator == minimumBlack & minimumBlack < 0) | locator == -1)
                    {
                        validTakeOffMoves.Add(location);
                    }
                }
            }
            else
            {
                var maximumWhite = Board.CalculateMaximumWhite(roll, currentplayer.Colour);
                foreach (var location in colourLocations)
                {
                    var locator = location + roll;
                    if ((locator == maximumWhite & maximumWhite > 23) | locator == 24)
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
                if (currentplayer.Colour == Colours.Black)
                {
                    return SelectionOfHighestVMBlack(roll, currentplayer);
                }
                else 
                {
                    return SelectionOfLowestVMWhite(roll, currentplayer);
                }

               
            }
                

        }

        protected override int ChoosePieceInNormalPlay(int roll, Player currentplayer, int movecount, Tuple<bool, int, int> doubleMove)
        {
            return base.ChoosePieceInNormalPlay(roll, currentplayer, movecount, doubleMove);
        }
    }
}
