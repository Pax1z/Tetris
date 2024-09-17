using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        // Constructor to initialize the row and column
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
    }
}

