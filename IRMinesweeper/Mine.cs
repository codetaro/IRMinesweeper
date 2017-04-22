using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRMinesweeper
{
    class Mine
    {
        protected int row, col;
        public Tuple<int, int> Pos
        {
            get { return Tuple.Create(row, col); }
        }
        public Mine(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
}
