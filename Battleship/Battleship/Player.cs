using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;

namespace Battleship
{
    class Player
    {
        private const int DEFAULT_SIZE = 30;

        private String name;

        private Ocean ocean;
        private List<Ship> ships;

        public Player(String name)
        {
            this.name = name;

            this.ocean = new Ocean(DEFAULT_SIZE);
            this.ships = new List<Ship>();
        }

        public void AddShip(Ship.Type type, int startX, int startY, Ship.Position position)
        {
            if (startX >= ocean.Size)
            {
                throw new ArgumentException(string.Empty, "X argument over board size!.");
            }
            if (startY >= ocean.Size)
            {
                throw new ArgumentException(string.Empty, "Y argument over board size!.");
            }

            List<Square> newShipSquares = new List<Square>();
            int nextX = startX;
            int nextY = startY;

            int maxX = 0;
            int maxY = 0;
            int minX = startX;
            int minY = startY;

            for (int i = 0; i < (int)type; i++)
            {
                Square nextSquare;
                try
                {
                    nextSquare = ocean.Board.ElementAt(nextX).ElementAt(nextY);
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentException(string.Empty, "Ship size and position would place if over board");
                }

                if (null != nextSquare.Ship)
                {
                    throw new ArgumentException(string.Empty, "Ship alredy exists on selected squares");
                }
                if (null != nextSquare.Ship)
                {
                    throw new ArgumentException(string.Empty, "Ship alredy exists on selected squares");
                }
                newShipSquares.Append(nextSquare);

                if (maxX < nextX)
                {
                    maxX = nextX;
                }
                if (maxY < nextY)
                {
                    maxY = nextY;
                }

                switch (position)
                {
                    case Ship.Position.DOWN:
                        startY++;

                        break;
                    case Ship.Position.RIGHT:
                        startX++;

                        break;
                }
            }

            for (int i = minX; i < maxX; i++)
            {
                for (int j = minY; j < maxY; j++)
                {
                    if (null != ocean.Board.ElementAt(i).ElementAt(j).Ship)
                    {
                        throw new ArgumentException(string.Empty, "Ship position collides with existing ship");
                    }
                }
            }

            Ship newShip = new Ship(type, newShipSquares);
            ships.Append(newShip);
            foreach (Square square in newShipSquares)
            {
                square.Ship = newShip;
            }
        }

        public Outcome Hit(int x, int y)
        {
            if (x >= ocean.Size)
            {
                throw new ArgumentException(string.Empty, "X argument over board size!.");
            }
            if (y >= ocean.Size)
            {
                throw new ArgumentException(string.Empty, "Y argument over board size!.");
            }

            Square hittingSquare = ocean.Board.ElementAt(x).ElementAt(y);

            if (hittingSquare.IsHit)
            {
                throw new ArgumentException(string.Empty, "This square was already hit!.");
            }

            hittingSquare.IsHit = true;
            if (null == hittingSquare.Ship)
            {
                return Outcome.MISS;
            }

            Ship hitShip = hittingSquare.Ship;
            foreach (Square square in hitShip.Squares)
            {
                if (!square.IsHit)
                {
                    return Outcome.HIT;
                }
            }
            hitShip.IsSunk = true;

            return Outcome.SUNK;
        }

        public bool AllShipsSunk()
        {
            foreach (Ship ship in ships)
            {
                if (!ship.IsSunk)
                {
                    return false;
                }
            }

            return true;
        }

        public enum Outcome
        {
            MISS,
            HIT,
            SUNK,
        }
    }
}
