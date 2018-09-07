using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backgammon.Model;

namespace Backgammon.ConsoleUI
{
    public class Program
    {
        static Board Board{ get; set; }
        static Dice Dice { get; set; }
        static void Main(string[] args)
        {
            Dice = new Dice();
            Console.WriteLine("Welcome to the best backgammon game in the internet");
            Console.WriteLine("The game will start soon");
            Console.Write("Please pick a colour White or Black :");
            var ColourPicker = Console.ReadLine();
            Console.WriteLine("The Board is now initializing good luck :)");
            BoardRender();
            Console.WriteLine("White to move first ");
            Move(Colours.White);
            Console.ReadKey();    
        }
        public static void BoardRender()
        {
            Board = new Board(Dice);
            foreach (var location in Board.Locations)
            {
                Console.WriteLine(location.ToString());
                //Carry on working on the UI work out how to output board correctly.
            }
        }
        public static void Move(Colours colour)
        {
            //interation with the user only
            //Must know which colour it is to roll dice
            Console.WriteLine("Press D to roll the Dice :");
            Console.ReadKey();
            var roll1 = Dice.Throw();
            Console.WriteLine(roll1);
            var roll2 = Dice.Throw();
            Console.WriteLine(roll2);
            //outpt dice

            MoveOneDice(colour, roll1);
            MoveOneDice(colour, roll2);
           
    
        }

        private static void MoveOneDice(Colours colour, int roll)
        {
            //select piece you would like to move

            Console.WriteLine("Select a piece from the Board to move. E.G. press 1 to move the pieces in location 1 :");
            int pieceNumber = Convert.ToInt32(Console.ReadLine());

            var availableMoves = Board.ValidMoves(colour);
            foreach (var move in availableMoves)
            {
                Console.WriteLine(move.ToString());
            }
            
            //test validmove NEEDS RO BE PROGRAMMED
            Board.executeMove(colour, pieceNumber, roll);
            BoardOutputter();
        }
        public static void BoardOutputter()
        {
            foreach (var location in Board.Locations)
            {
                Console.WriteLine(location.ToString());
                //Carry on working on the UI work out how to output board correctly.
            }
        }
    }
}
