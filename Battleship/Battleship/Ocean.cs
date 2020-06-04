using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    public class Ocean
    {
        private int size;
        private List<List<Square>> board;

        public Ocean(int size)
        {
            this.size = size;

            this.board = new List<List<Square>>();
            for (int i = 0; i < size; i++)
            {
                List<Square> row = new List<Square>();
                for (int j = 0; j < size; j++)
                {
                    row.Append(new Square());
                }
                board.Append(row);
            }
        }

        public int Size { get => size; set => size = value; }
        public List<List<Square>> Board { get => board; set => board = value; }
    }
}
