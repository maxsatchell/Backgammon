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


        protected int SelectionOfHighestVMBlack(int roll, Player currentplayer)
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
        protected int SelectionOfLowestVMWhite(int roll, Player currentplayer)
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

        protected int SelectionOfRandomVM(int roll, Player currentplayer)
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
        protected int SelectionOfRandomVSM(int roll, Player currentplayer, List<int> validSafeMoves)
        {
            int randomLocation = rnd.Next(validSafeMoves.Count);
            int selection = validSafeMoves[randomLocation];
            return selection;
        }
        protected int SelectionOfRandomTakingMove(int roll, Player currentplayer, List<int> validTakingMoves)
        {
            int randomLocation = rnd.Next(validTakingMoves.Count);
            int selection = validTakingMoves[randomLocation];
            return selection;
        }
        protected int SelectionOfVMTULEGB(int roll, Player currentplayer, List<int> validmovestounocupiedlocationsEGB)
        {
            int randomLocation = rnd.Next(validmovestounocupiedlocationsEGB.Count);
            int selection = validmovestounocupiedlocationsEGB[randomLocation];
            return selection;
        }
        protected int SelectionOfVMTULEGW(int roll, Player currentplayer, List<int> validmovestounocupiedlocationsEGW)
        {
            int randomLocation = rnd.Next(validmovestounocupiedlocationsEGW.Count);
            int selection = validmovestounocupiedlocationsEGW[randomLocation];
            return selection;
        }
        protected int SelectionOfRandomVSMEGB(int roll, Player currentplayer, List<int> validsafetymovesEGB)
        {
            int randomLocation = rnd.Next(validsafetymovesEGB.Count);
            int selection = validsafetymovesEGB[randomLocation];
            return selection;
        }
        protected int SelectionOfRandomVSMEGW(int roll, Player currentplayer, List<int> validsafetymovesEGW)
        {
            int randomLocation = rnd.Next(validsafetymovesEGW.Count);
            int selection = validsafetymovesEGW[randomLocation];
            return selection;
        }

        protected List<int> ValidSafeMovesCreationBlack(int roll, Player currentplayer)

        {
            List<int> validSafeMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);

            var safeLocations = Board.ValidSafePieceLocationsColour(currentplayer.Colour);//All locations where it is your colour
            foreach (var location in safeLocations)
            {
                var locator = location - roll;
                if (validMoves.Contains(location) & Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator))
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
                if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator) & validMoves.Contains(location))
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
            var colourLocations = Board.ValidSafePieceLocationsColour(currentplayer.Colour);//All locations where it is your colour
            foreach (var location in colourLocations)
            {
                var locator = location + roll;
                if (validMoves.Contains(location) & Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator)) //rework
                {
                    validSafeMoves.Add(location);
                }
            }
            return validSafeMoves;
        }
        protected List<int> TakingMovesCreationWhite(int roll, Player currentplayer)
        {
            List<int> validTakingMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var takingPiecesLocations = Board.ExposedPieces(ColourFlipper(currentplayer));
            foreach (var location in takingPiecesLocations)
            {
                var locator = location - roll;
                if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                {
                    validTakingMoves.Add(locator);
                }
                
            }
            return validTakingMoves;
        }
        protected List<int> TakingMovesCreationBlack(int roll, Player currentplayer)
        {
            List<int> validTakingMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var takingPiecesLocations = Board.ExposedPieces(ColourFlipper(currentplayer));
            foreach (var location in takingPiecesLocations)
            {
                var locator = location + roll;//due to colour flipper its a plus
                if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                {
                    validTakingMoves.Add(locator);
                }
                
            }
            return validTakingMoves;
        }

        protected List<int> CreationOfValidMovesToUnocupiedLocationsEGW(int roll, Player currentplayer)
        {
            List<int> validUnocupiedMovesEGW = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var unocupiedlocationsEGW = Board.UnocupiedLocationsEGW(currentplayer.Colour);
            foreach (var location in unocupiedlocationsEGW)
            {
                int locator = location - roll;//review this under the logic section and see what to do then..
                if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                {
                    validUnocupiedMovesEGW.Add(locator);
                }
            }
            return validUnocupiedMovesEGW;
        }

        protected List<int> CreationOfValidMovesToUnocupiedLocationsEGB(int roll, Player currentplayer)
        {
            List<int> validUnocupiedMovesEGB = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var unocupiedlocationsEGB = Board.UnocupiedLocationsEGB(currentplayer.Colour);
            foreach (var location in unocupiedlocationsEGB)
            {
                int locator = location + roll;
                if (Board.ValidPieceLocationsColour(currentplayer.Colour).Contains(locator))
                {
                    validUnocupiedMovesEGB.Add(locator);
                }
            }
            return validUnocupiedMovesEGB;
        }

        protected List<int> CreationOfSafetyMovesEGB(int roll, Player currentplayer)
        {
            List<int> validSafetyMovesEGB = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var exposedlocationsinEGB = Board.ExposedPiecesEGB(currentplayer.Colour);
            var safeMovesEGB = Board.Locations.Where(kvp => (kvp.Key <= 5 & kvp.Key >= 0) & (kvp.Value.Number > 2)).Select(kvp => kvp.Key).ToList();
            var colourLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);
            foreach (var location in exposedlocationsinEGB)
            {
                int locator = location - roll;
                if ((location <= 5 & location >=0) & validMoves.Contains(location) & safeMovesEGB.Contains(location) & exposedlocationsinEGB.Contains(locator))
                {
                    validSafetyMovesEGB.Add(location);
                }
                else if (location > 5 & validMoves.Contains(location) & exposedlocationsinEGB.Contains(locator))
                {
                    validSafetyMovesEGB.Add(location);
                }
            }
            return validSafetyMovesEGB;
        }
        protected List<int> CreationOfSafetyMovesEGW(int roll, Player currentplayer)
        {
            List<int> validSafetyMovesEGW = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var exposedlocationsinEGW = Board.ExposedPiecesEGW(currentplayer.Colour);
            var safeMovesEGW = Board.Locations.Where(kvp => (kvp.Key <= 23 & kvp.Key >= 18) & (kvp.Value.Number > 2)).Select(kvp => kvp.Key).ToList();
            var colourLocations = Board.ValidPieceLocationsColour(currentplayer.Colour);
            foreach (var location in colourLocations)
            {
                int locator = location + roll;
                if ((location <= 23 & location >= 18) & validMoves.Contains(location) & safeMovesEGW.Contains(location) & exposedlocationsinEGW.Contains(locator))
                {
                    validSafetyMovesEGW.Add(location);
                }
                else if (location <18 & validMoves.Contains(location) & exposedlocationsinEGW.Contains(locator))
                {
                    validSafetyMovesEGW.Add(location);
                }
            } 
            return validSafetyMovesEGW;
        }

        protected List<int> ValidExposedMovesCreationWhite(int roll, Player currentplayer)
        {
            List<int> validExposedMoves = new List<int>();
            var validMoves = Board.ValidMoves(currentplayer.Colour, roll);
            var exposedPiecesLocations = Board.ExposedPieces(currentplayer.Colour);
            foreach (var location in exposedPiecesLocations)
            {
                var locator = location + roll;
                if (Board.ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(locator) & validMoves.Contains(location))
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
            else if (colour == Colours.White)
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

      protected Colours ColourFlipper(Player CurrentPlayer)
        {
            if (CurrentPlayer.Colour == Colours.Black)
            {
                return Colours.White;
            }
            else
            {
                return Colours.Black;
            }
        }

        protected int BuildingUpTheBackBoard(int roll,Player currentplayer, int movecCount, Tuple<bool, int, int> doubleMove)
        {

            if (currentplayer.Colour == Colours.Black)
            {
                var colourLocationsEGB = Board.Locations.Where(kvp => (kvp.Key <= 5 & kvp.Key >= 0)).Select(kvp => kvp.Key).ToList();
                


                var validmovestounocupiedlocationsEGB = CreationOfValidMovesToUnocupiedLocationsEGB(roll, currentplayer);
                var validsafetymovesEGB = CreationOfSafetyMovesEGB(roll, currentplayer);

                if (doubleMove.Item1 == true & colourLocationsEGB.Contains(doubleMove.Item2 - roll))
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
                else if (validmovestounocupiedlocationsEGB.Count > 0)
                {
                    return SelectionOfVMTULEGB(roll, currentplayer, validmovestounocupiedlocationsEGB);
                }
                else if (validsafetymovesEGB.Count > 0)
                {
                    return SelectionOfRandomVSMEGB(roll, currentplayer, validsafetymovesEGB);
                }
                else
                {
                    return -1;
                }

            }
            else
            {
                var colourLocationsEGW = Board.Locations.Where(kvp => (kvp.Key <= 23 & kvp.Key >= 18)).Select(kvp => kvp.Key).ToList();

                var validmovestounocupiedlocationsEGW = CreationOfValidMovesToUnocupiedLocationsEGW(roll, currentplayer);

                var validsafetymovesEGW = CreationOfSafetyMovesEGW(roll, currentplayer);

                if (doubleMove.Item1 == true & colourLocationsEGW.Contains(doubleMove.Item2 + roll))
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
                else if (validmovestounocupiedlocationsEGW.Count >0)
                {
                    return SelectionOfVMTULEGW(roll,currentplayer, validmovestounocupiedlocationsEGW);
                }
                else if (validsafetymovesEGW.Count > 0)
                {
                    return SelectionOfRandomVSMEGW(roll, currentplayer, validsafetymovesEGW);
                }
                else
                {
                    return -1;
                }
                
              
            }

        }

        
    }
}
