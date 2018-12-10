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
        private Board Board { get; set; }
        static Dice Dice { get; set; }//Not static
        private Player Player1 { get; }
        private Player Player2 { get; }
        private Player Currentplayer { get; set; }
        private Random rnd = new Random();


        public Game(Player player1,Player player2,Player currentPlayer,Board board)
        {
            Player1 = player1;
            Player2 = player2;
            Currentplayer = currentPlayer;
            Board = board;
     
        }

              
        public void Run()
        {
           
            Dice = new Dice();
            var roll1 = Dice.Throw();
            var roll2 = Dice.Throw();
            var doubleMoves = Board.DoubleMoves(roll1, roll2, Currentplayer);
            Tuple<bool, int, int> randomDoubleMove = new Tuple<bool, int, int>(false,0,0);//Tuple.create is more elegant.
            if (doubleMoves.Count == 0)
            {
                randomDoubleMove = Tuple.Create(false, 0, 0);
            }
            else
            {
                int doubleMoveSelector = rnd.Next(doubleMoves.Count);
                randomDoubleMove = doubleMoves[doubleMoveSelector];
            }
            


            if (Board.ValidMoves(Currentplayer.Colour, roll1).Count == 0 & Board.ValidMoves(Currentplayer.Colour, roll2).Count == 0)
            {
                Currentplayer.NoValidMoves();
                Playerswapper(Currentplayer);
                return;
            }


            if (roll1 == roll2)
            {
                for (int i = 1; i < 5; i++)
                {
                    Currentplayer.RollSelector(roll1, roll2, Currentplayer,i);
                    if (Board.ValidMoves(Currentplayer.Colour, roll1).Count == 0)
                    {
                        Currentplayer.NoValidMoves();
                        Playerswapper(Currentplayer);
                        return;
                    }
                    var piecelocation = Currentplayer.ChoosePiece(roll1, Currentplayer,i,randomDoubleMove);
                    Board.executeMove(Currentplayer.Colour, piecelocation, roll1);
                    if (Board.GameFinished() == true)
                    {
                        return;
                    }
                    Currentplayer.UpdatePlayer();
                }
            }
            else
            {
                var diceselection = Currentplayer.RollSelector(roll1, roll2, Currentplayer,1);
                if (diceselection == roll1)
                {
                    if (Board.ValidMoves(Currentplayer.Colour,roll1).Count == 0 & Board.ValidMoves(Currentplayer.Colour, roll2).Count > 0)
                    {
                        Currentplayer.RollChange(roll2);
                        var piecelocation = Currentplayer.ChoosePiece(roll2, Currentplayer,1,randomDoubleMove);
                        Board.executeMove(Currentplayer.Colour, piecelocation, roll2);
                        if (Board.GameFinished() == true)
                        {
                            return;
                        }
                        if (Board.ValidMoves(Currentplayer.Colour,roll1).Count == 0)
                        {
                            Currentplayer.NoValidMoves();
                            Playerswapper(Currentplayer);
                            return;
                        }
                        else
                        {
                            var piecelocation2 = Currentplayer.ChoosePiece(roll1, Currentplayer,2, randomDoubleMove);
                            Board.executeMove(Currentplayer.Colour, piecelocation2, roll1);
                        }
                    }
                    else
                    {
                        var piecelocation = Currentplayer.ChoosePiece(roll1, Currentplayer,1, randomDoubleMove);
                        Board.executeMove(Currentplayer.Colour, piecelocation, roll1);
                        if (Board.GameFinished() == true)
                        {
                            return;
                        }
                        Currentplayer.UpdatePlayer();
                        if (Board.ValidMoves(Currentplayer.Colour, roll2).Count == 0)
                        {
                            Currentplayer.NoValidMoves();
                            Playerswapper(Currentplayer);
                            return;
                        }
                        else
                        {
                            var piecelocation2 = Currentplayer.ChoosePiece(roll2, Currentplayer,2, randomDoubleMove);
                            Board.executeMove(Currentplayer.Colour, piecelocation2, roll2);
                        }
                                               
                    }                 
                }
                else
                {
                    if (Board.ValidMoves(Currentplayer.Colour, roll2).Count == 0 & Board.ValidMoves(Currentplayer.Colour, roll1).Count > 0)
                    {
                        Currentplayer.RollChange(roll1);
                        var piecelocation = Currentplayer.ChoosePiece(roll1, Currentplayer,1, randomDoubleMove);
                        Board.executeMove(Currentplayer.Colour, piecelocation, roll1);
                        if (Board.GameFinished() == true)
                        {
                            return;
                        }
                        if (Board.ValidMoves(Currentplayer.Colour, roll2).Count == 0)
                        {
                            Currentplayer.NoValidMoves();
                            Playerswapper(Currentplayer);
                            return;
                        }
                        else
                        {
                            var piecelocation2 = Currentplayer.ChoosePiece(roll2, Currentplayer,2, randomDoubleMove);
                            Board.executeMove(Currentplayer.Colour, piecelocation2, roll2);
                        }
                    }
                    else
                    {
                        var piecelocation = Currentplayer.ChoosePiece(roll2, Currentplayer,1, randomDoubleMove);
                        Board.executeMove(Currentplayer.Colour, piecelocation, roll2);
                        if (Board.GameFinished() == true)
                        {
                            return;
                        }
                        Currentplayer.UpdatePlayer();
                        if (Board.ValidMoves(Currentplayer.Colour, roll1).Count == 0)
                        {
                            Currentplayer.NoValidMoves();
                            Playerswapper(Currentplayer);
                            return;
                        }
                        else
                        {
                            var piecelocation2 = Currentplayer.ChoosePiece(roll1, Currentplayer,2, randomDoubleMove);
                            Board.executeMove(Currentplayer.Colour, piecelocation2, roll1);
                        }
                      
                    }
                    
                }
            }

            Playerswapper(Currentplayer);



        }


        public void Playerswapper(Player currentplayer)//Make this player swapper
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
