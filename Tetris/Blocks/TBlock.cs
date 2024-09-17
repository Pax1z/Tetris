using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class TBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(1, 2) },  // T shape, default rotation
            new Position[] { new(0, 1), new(1, 1), new(1, 2), new(2, 1) },  // T shape, rotated right
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(2, 1) },  // T shape, upside down
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 1) }   // T shape, rotated left
        };

        public override int Id => 6;

        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
