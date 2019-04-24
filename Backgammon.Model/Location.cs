using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class Location
    {

        public Colours Colour { get; private set; }
        public int Number { get; private set; }
        public Location(int number,Colours colour)
        {
            Number = number;
            Colour = colour;
        }

        public override string ToString()
        {
            return Colour.ToString() +" "+ Number.ToString();
        }
        public void RemoveOnePiece()
        {
            Number -= 1;
            if (Number == 0)
            {
                Colour = Colours.Empty;
            }
        }

        internal void AddOnePiece(Colours colour)
        {
            Number += 1;
            if (Number ==1)
            {
                Colour = colour;
            }
           
        }
            
    }
}
