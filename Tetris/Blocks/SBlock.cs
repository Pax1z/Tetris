using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class SBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(1, 0), new(1, 1), new(2, 1), new(2, 2) },  // S shape, default rotation
            new Position[] { new(0, 1), new(1, 1), new(1, 0), new(2, 0) },  // S shape, rotated right
            new Position[] { new(1, 0), new(1, 1), new(2, 1), new(2, 2) },  // S shape, upside down (same as default)
            new Position[] { new(0, 1), new(1, 1), new(1, 0), new(2, 0) }   // S shape, rotated left (same as right)
        };

        public override int Id => 5;

        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
