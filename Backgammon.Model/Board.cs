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
            Locations[24] = new Location(0, Colours.Empty);//where exposed pieces go
            Locations[25] = new Location(0, Colours.Empty);//where exposed pieces go
        }

        public List<int> ValidMoves(Colours colour)
        {
            return Locations.Where(kvp => kvp.Value.Colour == colour||kvp.Value.Number <=1).Select(kvp => kvp.Key).ToList();
        }
        public void executeMove(Colours colour,int piecelocation,int diceValue)
        {
            //roll dice
            //select piece to move(must be a valid piece white cannot move black
            //show valid moves
            //move piece number shown on dice
            //add to the location the new piece
            //use index of key of dictionary to add onto pieces  
            //output board to the user 
            //cant output to the console in model so that is the problem with this get the move implemented tommorow.
            var availableMoves = ValidMoves(colour);
            if (availableMoves.Contains(piecelocation + diceValue) == false)
            {
                return;
            }
            if (Locations[piecelocation].Colour != colour)
            {
                return;
            }
            if (availableMoves.Contains(piecelocation + diceValue) & Locations[piecelocation + diceValue].Number ==1)//used when exposed
            {
                //this will mean the not gcoulor will be added to a location out of board only to be brought in when it can with the help of avilable exposed moves.
                var fromLocation = Locations[piecelocation];
                fromLocation.RemoveOnePiece();
                
                var toLocation = Locations[piecelocation + diceValue];
                if (colour == Colours.White & Locations[piecelocation + diceValue].Colour != colour)
                {
                    toLocation.RemoveOnePiece();
                    Locations[24].AddOnePiece(Colours.Black);
                }
                else if (colour == Colours.Black & Locations[piecelocation + diceValue].Colour != colour)
                {
                    Locations[25].AddOnePiece(Colours.White);
                }
                else
                {
                    toLocation.AddOnePiece(colour);
                }           
                
            }
            else
            {
                var fromLocation = Locations[piecelocation];
                fromLocation.RemoveOnePiece();
                var toLocation = Locations[piecelocation + diceValue];
                toLocation.AddOnePiece(colour);
            }
            
            
        }

        

    }
}
