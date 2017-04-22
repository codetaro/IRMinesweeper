using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRMinesweeper
{
    class Hint : Mine, IEquatable<Hint>
    {
        private int adjacent_mines;
        public int Adjacent_mines
        {
            get { return adjacent_mines; }
            set { adjacent_mines = value; }
        }

        public Hint(int row, int col) : base(row, col)
        {
            this.adjacent_mines = 1;
        }

        public bool Equals(Hint other)
        {
            return this.Pos.Equals(other.Pos);
        }
    }
}
