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
        public Board Board { get; set; }
        public Player(string name, Colours colour,Board board)
        {
            Colour = colour;
            Name = name;
            Board = board;
        }

        
        public abstract int ChoosePiece(int roll,Player currentplayer);

        public abstract int RollSelector(int roll1, int roll2, Player currentplayer);

        public abstract void UpdatePlayer();

        public abstract void RollChange(int roll);

        public abstract void NoValidMoves();
    }
}
