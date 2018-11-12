﻿using System;
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
        public Player(string name, Colours colour)
        {
            Colour = colour;
            Name = name;          
        }

        //public void RollDice()
        //{
        //    var roll1 = PlayerDice.Roll();
        //    var roll2 = PlayerDice.Roll();
            
        //}
        //pass dice value and expect back pieceloaction 
        public abstract int ChoosePiece(int roll,Player currentplayer);

        public abstract int RollSelector(int roll1, int roll2, Player currentplayer);

    }
}
