using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Ship
    {
        private readonly Type type;
        private readonly List<Square> squares;

        private bool isSunk;

        public Ship(Type type, List<Square> squares)
        {
            this.type = type;
            this.squares = squares;
        }

        public List<Square> Squares => squares;

        public bool IsSunk { get => isSunk; set => isSunk = value; }

        public enum Type
        {
            DESTROYER = 2,
            SUBMARINE = 3,
            CRUISER = 4,
            BATTLESHIP = 5,
            CARRIER = 6,
        }

        public enum Position
        {
            RIGHT,
            DOWN,
        }
    }

    
}
