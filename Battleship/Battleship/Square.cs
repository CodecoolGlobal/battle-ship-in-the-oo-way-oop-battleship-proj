using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship
{
    public class Square
    {
        private bool isHit;
        private Ship ship;

        public bool IsHit { get => isHit; set => isHit = value; }
        public Ship Ship { get => ship; set => ship = value; }

        public Square()
        {
            this.isHit = false;
            this.ship = null;
        }
    }
}
