using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class IBlock : Block
    {
        // Define the tile positions for the JBlock in its four rotation states.
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(1, 0), new(1, 1), new(1, 2), new(1, 3) },
            new Position[] { new(0, 2), new(1, 2), new(2, 2), new(3, 2) },
            new Position[] { new(2, 0), new(2, 1), new(2, 2), new(2, 3) },
            new Position[] { new(0, 1), new(1, 1), new(2, 1), new(3, 1) },
        };

        //Unique identifier for the IBlock
        public override int Id => 1;

        //The starting offset for the block's position on the grid
        protected override Position StartOffset => new Position(-1, 3);

        //The tile positions for the block
        protected override Position[][] Tiles => tiles;
    }
}
