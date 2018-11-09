using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public abstract class Player  
    {      
        //Commmon superclass of human player and automated player
        //abstract methods that both can implement
        //concrete subclass called human player
        public Colours Colour { get;  set; }
        public string Name { get;  private set; }
        public string Type { get;  private set; }
        public Player(string name, Colours colour,string type)
        {
            Colour = colour;
            Name = name;
            Type = type;
        }
        
    }
}
