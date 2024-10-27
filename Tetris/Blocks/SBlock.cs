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
            // S shape, default rotation facing right
            new Position[] { new(0, 1), new(0, 2), new(1, 0), new(1, 1) },  
            // S shape, rotated right (now facing up)
            new Position[] { new(0, 1), new(1, 1), new(1, 2), new(2, 2) },  
            // S shape, upside down (facing left, same as default)
            new Position[] { new(0, 1), new(0, 2), new(1, 0), new(1, 1) },  
            // S shape, rotated left (now facing down)
            new Position[] { new(0, 1), new(1, 1), new(1, 2), new(2, 2) }
        };

        public override int Id => 5;

        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}

