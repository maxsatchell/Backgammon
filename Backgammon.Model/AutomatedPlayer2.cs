using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer2 : Player
    {
        private Random rnd = new Random();
        public AutomatedPlayer2(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer)
        {
            List<int> validExposedMoves = new List<int>();
            List<int> validSafeMoves = new List<int>();
            var exposedPiecesLocations = Board.ExposedPieces(currentplayer.Colour);
            var safeLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);//All locations where it is your colour
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            if (currentplayer.Colour == Colours.Black)
            {
                foreach (var location in exposedPiecesLocations)
                {
                    var locator = location - roll;
                    if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator))
                    {
                        validExposedMoves.Add(location);
                    }
                }
                foreach (var location in safeLocations)
                {
                    var locator = location - roll;
                    if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                    {
                        validSafeMoves.Add(location);
                    }
                }
                if (validExposedMoves.Count >0)
                {
                    int randomLocation = rnd.Next(validExposedMoves.Count);
                    int selection = validExposedMoves[randomLocation];
                    return selection;
                }
                else if (validSafeMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validSafeMoves.Count);
                    int selection = validSafeMoves[randomLocation];
                    return selection;
                }
                else
                {
                    int randomLocation = rnd.Next(validMoves.Count);
                    int selection = validMoves[randomLocation];
                    return selection;
                }
            }
            else 
            {
                foreach (var location in exposedPiecesLocations)
                {
                    var locator = location + roll;
                    if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator))
                    {
                        validExposedMoves.Add(location);
                    }
                }
                foreach (var location in safeLocations)
                {
                    var locator = location + roll;
                    if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator))
                    {
                        validSafeMoves.Add(location);
                    }
                }
                if (validExposedMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validExposedMoves.Count);
                    int selection = validExposedMoves[randomLocation];
                    return selection;
                }
                else if (validSafeMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validSafeMoves.Count);
                    int selection = validSafeMoves[randomLocation];
                    return selection;
                }
                else
                {
                    int randomLocation = rnd.Next(validMoves.Count);
                    int selection = validMoves[randomLocation];
                    return selection;
                }
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
