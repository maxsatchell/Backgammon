using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class Player
    {      
        public Colours Colour { get; private set; }
        public string Name { get; private set; }
        public Player(string name, Colours colour)
        {
            Colour = colour;
            Name = name;
        }
        
    }
}
