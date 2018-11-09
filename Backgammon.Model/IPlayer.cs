using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{   

    public interface IPlayer
    {
        Colours Colour { get; }
        IList<DiceRollResult> DiceRollResults { get; }
        int RollNumber { get; }
        DiceRollResult CurrentRollResult { get; }

        void RollDice();
        bool Move();


    }
}

