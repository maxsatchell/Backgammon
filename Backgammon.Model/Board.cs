using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class Board
    {
        public Dice Dice { get; set; }
        public Dictionary<int, Location> Locations { get; set; }
        public Board(Dice dice, Dictionary<int,Location> nonStandardBoard)
        {
            Dice = dice;
            Locations = nonStandardBoard;
        }
        public Board(Dice dice)
        {
            Dice = dice;
            Locations = new Dictionary<int, Location>();
            //Creation of the board alocating the location to a name.
            Locations[0] = new Location(2, Colours.White);
            Locations[1] = new Location(0, Colours.Empty);
            Locations[2] = new Location(0, Colours.Empty);
            Locations[3] = new Location(0, Colours.Empty);
            Locations[4] = new Location(0, Colours.Empty);
            Locations[5] = new Location(5, Colours.Black);
            Locations[6] = new Location(0, Colours.Empty);
            Locations[7] = new Location(3, Colours.Black);
            Locations[8] = new Location(0, Colours.Empty);
            Locations[9] = new Location(0, Colours.Empty);
            Locations[10] = new Location(0, Colours.Empty);
            Locations[11] = new Location(5, Colours.White);
            Locations[12] = new Location(5, Colours.Black);
            Locations[13] = new Location(0, Colours.Empty);
            Locations[14] = new Location(0, Colours.Empty);
            Locations[15] = new Location(0, Colours.Empty);
            Locations[16] = new Location(3, Colours.White);
            Locations[17] = new Location(0, Colours.Empty);
            Locations[18] = new Location(5, Colours.White);
            Locations[19] = new Location(0, Colours.Empty);
            Locations[20] = new Location(0, Colours.Empty);
            Locations[21] = new Location(0, Colours.Empty);
            Locations[22] = new Location(0, Colours.Empty);
            Locations[23] = new Location(2, Colours.Black);
            Locations[40] = new Location(0, Colours.Empty);//where exposed pieces go(black)
            Locations[41] = new Location(0, Colours.Empty);//where exposed pieces go(white)
            Locations[50] = new Location(0, Colours.Empty);//Where black pieces are taken off the board in end game
            Locations[51] = new Location(0, Colours.Empty);//Where white pieces are taken off the board in end game
        }

        public bool EndGameChecker(Colours colour)//Checks for the condtions of end game for black pieces.
        {
            var adder = 0;
            if (colour == Colours.Black)
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (Locations[i].Colour == Colours.White)
                    {
                        adder = adder + 0;
                    }
                    else
                    {
                        adder = adder + Locations[i].Number;
                    }
                }
                if (adder == 15 - Locations[50].Number)//minus the location of the pieces where they are taken off as he might be taken 
                {
                    return true;
                }
                else
                { return false; };
            }
            else
            {
                for (int i = 18; i <= 23; i++)
                {
                    if (Locations[i].Colour == Colours.Black)
                    {
                        adder = adder + 0;
                    }
                    else
                    {
                        adder = adder + Locations[i].Number;
                    }
                }
                if (adder == 15-Locations[51].Number)
                {
                    return true;
                }
                else
                { return false; };
            }

        }
        public bool GameFinished()
        {
            if (Locations[50].Number == 15 || Locations[51].Number == 15)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //make a valid moves that can see if there is any validmoves on the board with dev on thurs
        public List<int> ValidMoves(Colours colour,int diceValue)
        {
            List<int> validMoves = new List<int>();
            var colourLocations = Locations.Where(kvp => kvp.Value.Colour == colour).Select(kvp => kvp.Key).Take(24).ToList();
            var colourLocationsEndGameW = Locations.Where(kvp => kvp.Value.Colour == Colours.White & kvp.Key <= 23 & kvp.Key >= 17).Select(kvp => kvp.Key).ToList();
            var colourLocationsEndGameB = Locations.Where(kvp => kvp.Value.Colour == Colours.Black & kvp.Key <=5 & kvp.Key >=0).Select(kvp => kvp.Key).ToList();
            if (EndGameChecker(colour) == true)
            {
                if (colour == Colours.Black)
                {
                    var minimumBlack = CalculateMinimumBlack(diceValue);
                    foreach (var location in colourLocationsEndGameB)
                    {
                        var locator = location - diceValue;
                        if (locator == minimumBlack | locator == -1 |locator >=0)
                        {
                            validMoves.Add(location);
                        }
                    }
                    return validMoves;
                }
                else
                {
                    var maximumWhite = CalculateMaximumWhite(diceValue);
                    foreach (var location in colourLocationsEndGameW)
                    {
                        var locator = location + diceValue;
                        if (locator == maximumWhite | locator == 24 | locator <= 23)
                        {
                            validMoves.Add(location);
                        }
                    }
                    return validMoves;
                }
            }
            if (colour == Colours.Black & Locations[40].Number >= 1)
            {                
              var locator = 23 - diceValue + 1;
                if (ValidLocationsPiecesCanGoWhenTakenBlack(colour).Contains(locator))
                {
                    validMoves.Add(locator);
                }
                return validMoves;
                
            }
            else if (colour == Colours.White & Locations[41].Number >= 1)
            {
                var locator = diceValue - 1;
                if (ValidLocationsPiecesCanGoWhenTakenWhite(colour).Contains(locator))
                {
                    validMoves.Add(locator);
                }
                return validMoves;
            }
            if (colour == Colours.Black)
            {
                foreach (var location in colourLocations)
                {
                    var locator = location - diceValue;
                    if (ValidLocationsPiecesCanGo(colour).Contains(locator))
                    {
                        validMoves.Add(location);
                    }
                }
                return validMoves;
            }
            else
            {
                foreach (var location in colourLocations)
                {
                    var locator = location + diceValue;
                    if (ValidLocationsPiecesCanGo(colour).Contains(locator))
                    {
                        validMoves.Add(location);
                    }
                }
                return validMoves;
            }          
           
        }

        public List<int> ValidLocationsPiecesCanGo(Colours colour)
        {
            return Locations.Where(kvp => kvp.Key >= 0 & kvp.Key <= 23 & (kvp.Value.Colour == colour || kvp.Value.Number <= 1)).Select(kvp => kvp.Key).ToList();
        }
        public List<int> ValidPieceLocationsColour(Colours colour)
        {
            return Locations.Where(kvp => kvp.Key >= 0 & kvp.Key <= 23 &(kvp.Value.Colour == colour)).Select(kvp => kvp.Key).ToList();
        }
        public List<int> ValidLocationsPiecesCanGoWhenTakenWhite(Colours colour)
        {
            return Locations.Where(kvp => kvp.Key >=0 & kvp.Key <=5 &(kvp.Value.Colour == colour || kvp.Value.Number <= 1)).Select(kvp => kvp.Key).ToList();
        }
        public List<int> ValidLocationsPiecesCanGoWhenTakenBlack(Colours colour)
        {
            return Locations.Where(kvp => kvp.Key >= 17 & kvp.Key <=23 &(kvp.Value.Colour == colour || kvp.Value.Number <= 1)).Select(kvp => kvp.Key).ToList();
        }
        public List<int> ExposedPieces(Colours colour)
        {
            return Locations.Where(kvp => kvp.Key >= 0 & kvp.Key <= 23 &(kvp.Value.Colour == colour & kvp.Value.Number == 1)).Select(kvp => kvp.Key).ToList();
        }
        public List<int> StackGreaterThanFour(Colours colour)
        {
            return Locations.Where(kvp => kvp.Key >= 0 & kvp.Key <= 23 & (kvp.Value.Number >= 4)).Select(kvp => kvp.Key).ToList();
        }

        public List<Tuple<bool,int, int>> DoubleMoves(int roll1, int roll2, Player currentplayer)
        {
            List<Tuple<bool,int, int>> results = new List<Tuple<bool,int, int>>();
            var difference = 0;
            var smallerRoll = 0;
            var locationsOfAllPieces = ValidPieceLocationsColour(currentplayer.Colour);
            List<int> validDifferenceeBetweenLocations = new List<int>();
            if (roll1 > roll2)
            {
                difference = roll1 - roll2;
            }
            else
            {
                difference = roll2 - roll1;
            }
            if (roll1 < roll2)
            {
                smallerRoll = roll1;
            }
            else
            {
                smallerRoll = roll2;
            }
            if (currentplayer.Colour == Colours.Black)
            {
                foreach (var location in locationsOfAllPieces)
                {
                    if (ValidPieceLocationsColour(currentplayer.Colour).Contains(location + difference) & ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(location - smallerRoll))
                    {
                        //tuple.add location and location + differnce
                        results.Add(Tuple.Create(true,location, location + difference));
                    }
                }
            }
            else
            {
                foreach (var location in locationsOfAllPieces)
                {
                    if (ValidPieceLocationsColour(currentplayer.Colour).Contains(location - difference) & ValidLocationsPiecesCanGo(currentplayer.Colour).Contains(location + smallerRoll))
                    {
                        //tuple.add location and location - differnce
                        results.Add(Tuple.Create(true, location, location - difference));
                    }
                }
            }
            return results;
            
        }

        public void executeMove(Colours colour, int piecelocation, int diceValue)
        {
            //roll dice
            //select piece to move(must be a valid piece white cannot move black
            //show valid moves
            //move piece number shown on dice
            //add to the location the new piece
            //use index of key of dictionary to add onto pieces  
            //output board to the user 
            //cant output to the console in model so that is the problem with this get the move implemented tommorow.
            var validMoves = ValidMoves(colour, diceValue);
            var availableLocations = ValidLocationsPiecesCanGo(colour);
            var availableLocationsTakenWhite = ValidLocationsPiecesCanGoWhenTakenWhite(colour);
            var availableLocationsTakenBlack = ValidLocationsPiecesCanGoWhenTakenBlack(colour);
            var minimumBlack = CalculateMinimumBlack(diceValue);
            var maximumWhite = CalculateMaximumWhite(diceValue);

            if (GameFinished() == true)
            {
                return;
            }

            if (piecelocation - diceValue <=-1  & (piecelocation - diceValue == minimumBlack|piecelocation - diceValue == -1) & Locations[piecelocation].Colour == Colours.Black & EndGameChecker(Colours.Black) == true)//Add when = 0 its valid
            {
                var fromLocation = Locations[piecelocation];
                fromLocation.RemoveOnePiece();
                var toLocation = Locations[50];
                toLocation.AddOnePiece(Colours.Black);
                return;
            }
            else if (piecelocation +diceValue >=24 & (piecelocation + diceValue == maximumWhite | piecelocation + diceValue == 24) & Locations[piecelocation].Colour == Colours.White & EndGameChecker(Colours.White) == true)
            {
                var fromLocation = Locations[piecelocation];
                fromLocation.RemoveOnePiece();
                var toLocation = Locations[51];
                toLocation.AddOnePiece(Colours.White);
                return;                           
            }
            if (colour == Colours.White & Locations[41].Number >= 1 & availableLocationsTakenWhite.Contains(diceValue - 1))   //valid moves for the colour white are between the the numbers 0-5 and this is the only place where you can come back into if you have been taken.
            {
                var fromLocation = Locations[41];
                fromLocation.RemoveOnePiece();
                var toLocation = Locations[diceValue - 1];
                if (colour == Colours.White & Locations[diceValue - 1].Number == 1 & Locations[diceValue - 1].Colour != colour)
                {
                    toLocation.RemoveOnePiece();
                    Locations[40].AddOnePiece(Colours.Black);
                    toLocation.AddOnePiece(colour);
                    return;
                }
                else
                {
                    toLocation = Locations[diceValue - 1];
                    toLocation.AddOnePiece(colour);
                    return ;
                }
            }
            else if (colour == Colours.Black & Locations[40].Number >= 1 & availableLocationsTakenBlack.Contains(23 - diceValue + 1))   //valid moves for the colour white are between the the numbers 0-5 and this is the only place where you can come back into if you have been taken.
            {
                var fromLocation = Locations[40];
                fromLocation.RemoveOnePiece();
                var toLocation = Locations[23 - diceValue + 1];
                if (colour == Colours.Black & Locations[23 - diceValue + 1].Number == 1 & Locations[23 - diceValue + 1].Colour != colour)
                {
                    toLocation.RemoveOnePiece();
                    Locations[41].AddOnePiece(Colours.White);
                    toLocation.AddOnePiece(colour);
                    return;
                }
                else
                {
                    toLocation = Locations[23 - diceValue + 1];
                    toLocation.AddOnePiece(colour);
                    return ;
                }
            }
            if (validMoves.Count == 0)
            {
                return ;
            }
            if (colour == Colours.White & availableLocations.Contains(piecelocation + diceValue) == false)
            {
                return;
            }
            if (colour == Colours.Black & availableLocations.Contains(piecelocation - diceValue) == false)
            {
                return;
            }
            if (Locations[piecelocation].Colour != colour)
            {
                return;
            }
            if (colour == Colours.White & availableLocations.Contains(piecelocation + diceValue))//used when exposed
            {
                
                var fromLocation = Locations[piecelocation];
                fromLocation.RemoveOnePiece();

                var toLocation = Locations[piecelocation + diceValue];
                if (colour == Colours.White & Locations[piecelocation + diceValue].Number == 1 & Locations[piecelocation + diceValue].Colour != colour)
                {
                    toLocation.RemoveOnePiece();
                    Locations[40].AddOnePiece(Colours.Black);
                    toLocation.AddOnePiece(colour);
                    return;
                }
                else
                {
                    toLocation = Locations[piecelocation + diceValue];
                    toLocation.AddOnePiece(colour);
                    return;
                }

            }
            else if (colour == Colours.Black & availableLocations.Contains(piecelocation - diceValue))//used when exposed
            {
                var fromLocation = Locations[piecelocation];
                fromLocation.RemoveOnePiece();
                var toLocation = Locations[piecelocation - diceValue];

                if (colour == Colours.Black & Locations[piecelocation - diceValue].Number == 1 & Locations[piecelocation - diceValue].Colour != colour)
                {
                    toLocation.RemoveOnePiece();
                    Locations[41].AddOnePiece(Colours.White);
                    toLocation.AddOnePiece(colour);
                    return;
                }
                else
                {
                    toLocation = Locations[piecelocation - diceValue];
                    toLocation.AddOnePiece(colour);
                    return ;
                }

            }
            else
            {
                return;
            }


        }
        public int CalculateMinimumBlack(int dice)
        {
            int minimum = 5;
            int count = 0;
            do
            {
                if (Locations[5 - count].Number == 0)
                {
                    minimum = minimum - 1;
                    count = count + 1;
                }
                else
                {
                    return minimum - dice;
                }

            } while (!(Locations[5 - (count - 1)].Number >0));
            return minimum - dice;
        }
        public int CalculateMaximumWhite(int dice)
        {
            int maximum = 18;
            int count = 0;
            do
            {
                if (Locations[18 + count].Number==0)
                {
                    maximum = maximum + 1;
                    count = count + 1;
                }
                else
                {
                    return maximum + dice; 
                }

            } while (!(Locations[18 - (count - 1)].Number > 0));
            return maximum + dice;

        }

    }
}