using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{

    public class Game
    {
        //used for Running the game
        //if no valid moves available then flips back to the last player
        //returns the colour of which turn it is.
        public Colours Colour { get; private set; }
        static Board Board { get; set; }
        static Dice Dice { get; set; }
        private Player Player1;
        private Player Player2;
        private Player Currentplayer;


        public Game(Colours colour)
        {
            Colour = colour;
        }

              
        public static void Run(Player Player1,Player Player2)
        {          
            var roll1 = Dice.Throw();
            var roll2 = Dice.Throw();
            
            

            if (Board.ValidMoves(Currentplayer.Colour, roll1).Count == 0 & Board.ValidMoves(currentplayer.Colour, roll2).Count == 0)
            {
                Console.WriteLine("No valid moves available");
                Playerswapper(currentplayer);
                return;
            }


            if (roll1 == roll2)
            {
                for (int i = 0; i < 4; i++)
                {
                    Currentplayer.RollSelector(roll1, roll2, currentplayer);
                    var piecelocation = Currentplayer.ChoosePiece(roll1, currentplayer);
                    Board.executeMove(currentplayer.Colour, piecelocation, roll1);
                }
            }
            else
            {
                var diceselection = currentplayer.RollSelector(roll1, roll2, currentplayer);
                if (diceselection == roll1)
                {
                    var piecelocation = currentplayer.ChoosePiece(roll1, currentplayer);
                    Board.executeMove(currentplayer.Colour, piecelocation, roll1);
                    var piecelocation2 = currentplayer.ChoosePiece(roll2, currentplayer);
                    Board.executeMove(currentplayer.Colour, piecelocation2, roll2);
                }
                else
                {
                    var piecelocation = currentplayer.ChoosePiece(roll2, currentplayer);
                    Board.executeMove(currentplayer.Colour, piecelocation, roll2);
                    var piecelocation2 = currentplayer.ChoosePiece(roll1, currentplayer);
                    Board.executeMove(currentplayer.Colour, piecelocation2, roll1);
                }
            }

            Playerswapper(currentplayer);



        }


        public static void Playerswapper(Player currentplayer)//Make this player swapper
        {
            if (currentplayer == Player1)
            {
                Currentplayer = Player2;
            }
            else
            {
                Currentplayer = Player1;
            }
        }



    




        



      
        
    }
}
