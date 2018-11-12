using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class AutomatedPlayer1 : Player
    {
        static Board Board { get; set; }
        static Random rnd = new Random();
        public AutomatedPlayer1(string name, Colours colour) : base(name, colour)
        {
           
        }

        public override int ChoosePiece(int roll,Player currentplayer)
        {
            var list = Board.ValidMoves(currentplayer.Colour, roll);
            int r = rnd.Next(list.Count);
            return r;
        }

        public override int RollSelector(int roll1, int roll2, Player currentplayer)
        {
            return roll1;
        }
    }
}
