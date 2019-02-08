using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon.Model;

namespace Fixtures
{
    public static class BoardPositions
    {
        public static Dictionary<int, Location> midGameA()
        {
            var Locations = new Dictionary<int, Location>();
            Locations[0] = new Location(0, Colours.Empty);
            Locations[1] = new Location(0, Colours.Empty);
            Locations[2] = new Location(0, Colours.Empty);
            Locations[3] = new Location(5, Colours.Black);
            Locations[4] = new Location(5, Colours.Black);
            Locations[5] = new Location(5, Colours.Black);
            Locations[6] = new Location(0, Colours.Empty);
            Locations[7] = new Location(0, Colours.Empty);
            Locations[8] = new Location(0, Colours.Empty);
            Locations[9] = new Location(0, Colours.Empty);
            Locations[10] = new Location(0, Colours.Empty);
            Locations[11] = new Location(0, Colours.Empty);
            Locations[12] = new Location(0, Colours.Empty);
            Locations[13] = new Location(0, Colours.Empty);
            Locations[14] = new Location(0, Colours.Empty);
            Locations[15] = new Location(0, Colours.Empty);
            Locations[16] = new Location(0, Colours.Empty);
            Locations[17] = new Location(0, Colours.Empty);
            Locations[18] = new Location(0, Colours.Empty);
            Locations[19] = new Location(5, Colours.White);
            Locations[20] = new Location(5, Colours.White);
            Locations[21] = new Location(5, Colours.White);
            Locations[22] = new Location(0, Colours.Empty);
            Locations[23] = new Location(0, Colours.Empty);
            Locations[40] = new Location(0, Colours.Empty);
            Locations[41] = new Location(0, Colours.Empty);
            Locations[50] = new Location(0, Colours.Empty);
            Locations[51] = new Location(0, Colours.Empty);
            return Locations;
        }
        public static Dictionary<int, Location> endGameWhite()//Work on returning out when you have won the game or if no valid moves have been completed.
        {
            var Locations = new Dictionary<int, Location>();
            Locations[0] = new Location(0, Colours.Empty);
            Locations[1] = new Location(0, Colours.Empty);
            Locations[2] = new Location(0, Colours.Empty);
            Locations[3] = new Location(5, Colours.Black);
            Locations[4] = new Location(5, Colours.Black);
            Locations[5] = new Location(5, Colours.Black);
            Locations[6] = new Location(0, Colours.Empty);
            Locations[7] = new Location(0, Colours.Empty);
            Locations[8] = new Location(0, Colours.Empty);
            Locations[9] = new Location(0, Colours.Empty);
            Locations[10] = new Location(0, Colours.Empty);
            Locations[11] = new Location(0, Colours.Empty);
            Locations[12] = new Location(0, Colours.Empty);
            Locations[13] = new Location(0, Colours.Empty);
            Locations[14] = new Location(0, Colours.Empty);
            Locations[15] = new Location(0, Colours.Empty);
            Locations[16] = new Location(0, Colours.Empty);
            Locations[17] = new Location(0, Colours.Empty);
            Locations[18] = new Location(0, Colours.White);
            Locations[19] = new Location(0, Colours.Empty);
            Locations[20] = new Location(0, Colours.Empty);
            Locations[21] = new Location(1, Colours.White);
            Locations[22] = new Location(0, Colours.Empty);
            Locations[23] = new Location(0, Colours.Empty);
            Locations[40] = new Location(0, Colours.Empty);
            Locations[41] = new Location(0, Colours.Empty);
            Locations[50] = new Location(0, Colours.Empty);
            Locations[51] = new Location(14, Colours.White);
            return Locations;
        }
        public static Dictionary<int, Location> midGameB()
        {
            var Locations = new Dictionary<int, Location>();
            Locations[0] = new Location(0, Colours.Empty);
            Locations[1] = new Location(0, Colours.Empty);
            Locations[2] = new Location(0, Colours.Empty);
            Locations[3] = new Location(3, Colours.Black);
            Locations[4] = new Location(5, Colours.Black);
            Locations[5] = new Location(5, Colours.Black);
            Locations[6] = new Location(0, Colours.Empty);
            Locations[7] = new Location(0, Colours.Empty);
            Locations[8] = new Location(0, Colours.Empty);
            Locations[9] = new Location(0, Colours.Empty);
            Locations[10] = new Location(0, Colours.Empty);
            Locations[11] = new Location(0, Colours.Empty);
            Locations[12] = new Location(0, Colours.Empty);
            Locations[13] = new Location(0, Colours.Empty);
            Locations[14] = new Location(0, Colours.Empty);
            Locations[15] = new Location(0, Colours.Empty);
            Locations[16] = new Location(0, Colours.Empty);
            Locations[17] = new Location(0, Colours.Empty);
            Locations[18] = new Location(0, Colours.Empty);
            Locations[19] = new Location(5, Colours.White);
            Locations[20] = new Location(5, Colours.White);
            Locations[21] = new Location(5, Colours.White);
            Locations[22] = new Location(0, Colours.Empty);
            Locations[23] = new Location(0, Colours.Empty);
            Locations[40] = new Location(2, Colours.Black);
            Locations[41] = new Location(0, Colours.Empty);
            Locations[50] = new Location(0, Colours.Empty);
            Locations[51] = new Location(0, Colours.Empty);
            return Locations;
        }
    }
}
