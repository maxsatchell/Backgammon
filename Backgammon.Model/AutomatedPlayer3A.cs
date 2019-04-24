using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer3A : AutomatedPlayer
    {
        private Random rnd = new Random();
        public AutomatedPlayer3A(string name, Colours colour, Board board) : base(name, colour, board)
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
           
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var stackGreaterThanFiveMoves = Board.StackGreaterThanFive(currentplayer.Colour);         
            List<int> validStackMoves = new List<int>();



            if (currentplayer.Colour == Colours.Black)
            {
                
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
                var validExposedMoves = ValidExposedMovesCreationBlack(roll, currentplayer);
                if (validExposedMoves.Count > 0)
                {
                    return SelectionOfRandomItemInList(roll, currentplayer, validExposedMoves);
                }
                foreach (var location in stackGreaterThanFiveMoves)//this one will only move the stack in the event of there being a safe move available
                {
                    var locator = location - roll;
                    if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator) & validMoves.Contains(location))
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

                var validSafeMoves = ValidSafeMovesCreationBlack(roll, currentplayer);
                if (validSafeMoves.Count > 0)
                {
                    return SelectionOfRandomItemInList(roll, currentplayer, validSafeMoves);
                }
                else
                {                   
                    return SelectionOfHighestVMBlack(roll, currentplayer);           
                }
            }
            else
            {
                
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
                var validExposedMoves = ValidExposedMovesCreationWhite(roll, currentplayer);
                if (validExposedMoves.Count > 0)
                {
                    return SelectionOfRandomItemInList(roll, currentplayer, validExposedMoves);
                }
                foreach (var location in stackGreaterThanFiveMoves)//this one will only move the stack in the event of there being a safe move available
                {
                    var locator = location + roll;
                    if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator) & validMoves.Contains(location))
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

                var validSafeMoves = ValidSafeMovesCreationWhite(roll, currentplayer);
                if (validSafeMoves.Count > 0)
                {
                    return SelectionOfRandomItemInList(roll, currentplayer, validSafeMoves);
                }
                else
                {
                    return SelectionOfLowestVMWhite(roll, currentplayer);
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
