using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backgammon.Model
{
    public class Dice
    {
        public Random RNG { get; set; }
        public Dice()
        {
            RNG = new Random();
        }
        public virtual  int Throw()
        {
            int Dice = RNG.Next(1, 7);
            return Dice;
        }
       

    }
    public class PredictableDice:Dice
        {
        public int LastThrow { get; set; }
        public override int Throw()
        {
            var newThrow = LastThrow + 1;
            if (newThrow > 6)
            {
                newThrow = 1;
            }
            LastThrow = newThrow;
            return newThrow;
        }
    }
    //public static DiceRollResult Roll()
    //{
    //    var result = new DiceRollResult();
    //    result.Die1 = RNG.Next(1, 7);
    //    result.Die2 = RandomNumberGenerator.Next(1, 7);
    //    return result;
    //}


}
