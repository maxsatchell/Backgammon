using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public abstract class AutomatedPlayer : Player
    {
        private Random rnd = new Random();
        public AutomatedPlayer(string name, Colours colour, Board board) : base(name, colour, board)
        {
        }


        protected int SelectionOfHighestVMBlack(int roll,Player currentplayer)
        {
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var highestValue = -1;
                for (int i = 0; i < validMoves.Count; i++)
                {
                    if (validMoves[i] > highestValue)
                    {
                        highestValue = validMoves[i];
                    }
                }

                int selection = highestValue;             
            
            return selection;
        }
        protected int SelectionOfLowestVMWhite(int roll,Player currentplayer)
        {
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var lowestValue = 100;
            for (int i = 0; i < validMoves.Count; i++)
            {
                if (validMoves[i] < lowestValue)
                {
                    lowestValue = validMoves[i];
                }
            }
            int selection = lowestValue;
            return selection;
        }

        protected int SelectionOfRandomVM(int roll,Player currentplayer)
        {
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            int randomLocation = rnd.Next(validMoves.Count);
            int selection = validMoves[randomLocation];
            return selection;
        }
        protected int SelectionOfRandomVEM(int roll, Player currentplayer, List<int> validExposedMoves)
        {
            int randomLocation = rnd.Next(validExposedMoves.Count);
            int selection = validExposedMoves[randomLocation];
            return selection;
        }
        protected int SelectionOfRandomVSM(int roll, Player currentplayer,List<int> validSafeMoves)
        {
            int randomLocation = rnd.Next(validSafeMoves.Count);
            int selection = validSafeMoves[randomLocation];
            return selection;
        }

        protected List<int> ValidSafeMovesCreationBlack(int roll, Player currentplayer)
        {
            List<int> validSafeMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);

            var safeLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);//All locations where it is your colour
            foreach (var location in safeLocations)
            {
                var locator = location - roll;
                if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator)& validMoves.Contains(locator) )
                {
                    validSafeMoves.Add(location);
                }
            }
            return validSafeMoves;
        }

        protected List<int> ValidExposedMovesCreationBlack(int roll, Player currentplayer)
        {
            List<int> validExposedMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var exposedPiecesLocations = Board.ExposedPieces(currentplayer.Colour);
            foreach (var location in exposedPiecesLocations)
            {
                var locator = location - roll;
                if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator)& validMoves.Contains(locator))
                {
                    validExposedMoves.Add(location);
                }
            }
            return validExposedMoves;
        }

        protected List<int> ValidSafeMovesCreationWhite(int roll, Player currentplayer)
        {
            List<int> validSafeMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var colourLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);//All locations where it is your colour
            foreach (var location in colourLocations)
            {
                var locator = location + roll;
                if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator)& validMoves.Contains(locator))
                {
                    validSafeMoves.Add(location);
                }
            }
            return validSafeMoves;
        }

        protected List<int> ValidExposedMovesCreationWhite(int roll, Player currentplayer)
        {
            List<int> validExposedMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var exposedPiecesLocations = Board.ExposedPieces(currentplayer.Colour);
            foreach (var location in exposedPiecesLocations)
            {
                var locator = location + roll;
                if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator)& validMoves.Contains(locator))
                {
                    validExposedMoves.Add(location);
                }
            }
            return validExposedMoves;
        }

        protected int PipCount(Colours colour)
        {
            int counter = 0;
            int PipCount = 0;
            if (colour == Colours.Black)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (Board.Locations[i].Colour == colour)
                    {
                        counter = Board.Locations[i].Number * (i + 1);
                        PipCount = PipCount + counter;
                    }
                }
            }          
            else if(colour == Colours.White)
            {
                for (int i = 0; i < 24; i++)
                {
                    if (Board.Locations[i].Colour == colour)
                    {
                        counter = (24 - i) * Board.Locations[i].Number;
                        PipCount = PipCount + counter;
                    }
                }
               
            }
            
            return PipCount;
        }

    }
}
