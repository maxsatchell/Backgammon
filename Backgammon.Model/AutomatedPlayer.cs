using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public abstract class AutomatedPlayer : Player
    {
        public AutomatedPlayer(string name, Colours colour, Board board) : base(name, colour, board)
        {
        }
      
    }
}
