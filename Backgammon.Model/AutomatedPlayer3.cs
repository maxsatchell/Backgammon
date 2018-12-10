using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer3 : AutomatedPlayer
    {
        private Random rnd = new Random();
        public AutomatedPlayer3(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll, Player currentplayer,int movecount, Tuple<bool,int, int> doubleMove)
        {
           return ChoosePieceInNormalPlay(roll, currentplayer, movecount, doubleMove);
        }
       
        protected virtual int ChoosePieceInEndGame(int roll, Player currentplayer, int movecount, Tuple<bool, int, int> doubleMove)
        {
            throw new NotImplementedException();
        }
        protected virtual int ChoosePieceInNormalPlay(int roll, Player currentplayer, int movecount, Tuple<bool, int, int> doubleMove)
        {
            var exposedPiecesLocations = Board.ExposedPieces(currentplayer.Colour);
            var safeLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var stackGreaterThanFourMoves = Board.StackGreaterThanFour(currentplayer.Colour);
            List<int> validExposedMoves = new List<int>();
            List<int> validSafeMoves = new List<int>();
            List<int> validStackMoves = new List<int>();



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
                if (validExposedMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validExposedMoves.Count);
                    int selection = validExposedMoves[randomLocation];
                    return selection;
                }
                if (doubleMove.Item1 == true)
                {
                    if (movecount == 1)
                    {
                        return doubleMove.Item2;
                    }
                    else
                    {
                        return doubleMove.Item3;
                    }
                }
                foreach (var location in stackGreaterThanFourMoves)//this one will only move the stack in the event of there being a safe move available
                {
                    var locator = location - roll;
                    if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                    {
                        validStackMoves.Add(location);
                    }
                }
                if (validStackMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validStackMoves.Count);
                    int selection = validStackMoves[randomLocation];
                    return selection;
                }

                foreach (var location in safeLocations)
                {
                    var locator = location - roll;
                    if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                    {
                        validSafeMoves.Add(location);
                    }
                }
                if (validSafeMoves.Count > 0)
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
                if (validExposedMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validExposedMoves.Count);
                    int selection = validExposedMoves[randomLocation];
                    return selection;
                }
                if (doubleMove.Item1 == true)
                {
                    if (movecount == 1)
                    {
                        return doubleMove.Item2;
                    }
                    else
                    {
                        return doubleMove.Item3;
                    }
                }
                foreach (var location in stackGreaterThanFourMoves)//this one will only move the stack in the event of there being a safe move available
                {
                    var locator = location + roll;
                    if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                    {
                        validStackMoves.Add(location);
                    }
                }
                if (validStackMoves.Count > 0)
                {
                    int randomLocation = rnd.Next(validStackMoves.Count);
                    int selection = validStackMoves[randomLocation];
                    return selection;
                }

                foreach (var location in safeLocations)
                {
                    var locator = location + roll;
                    if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                    {
                        validSafeMoves.Add(location);
                    }
                }
                if (validSafeMoves.Count > 0)
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

        public override int RollSelector(int roll1, int roll2, Player currentplayer,int moveCount)
        {
            var doubleMoves = Board.DoubleMoves(roll1,roll2,currentplayer);
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
                if (moveCount ==  1)
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
