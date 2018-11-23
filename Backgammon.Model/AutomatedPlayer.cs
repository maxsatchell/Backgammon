using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer1 : Player
    {
        private Board Board { get; set; }
        private Random rnd = new Random();
        public AutomatedPlayer1(string name, Colours colour, Board board) : base(name, colour, board)
        {
            Board = board;
        }

        public override int ChoosePiece(int roll,Player currentplayer)
        {
                var validMoves = Board.ValidMoves(currentplayer.Colour, roll);       
                              
                if (validMoves.Count == 0)
                {
                    return 100;                                      
                }
                int randomLocation = rnd.Next(validMoves.Count);
                int selection = validMoves[randomLocation];
                return selection;

        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer)
        {
            return roll1;
        }

        public override void UpdatePlayer()
        {
        }
    }
}
