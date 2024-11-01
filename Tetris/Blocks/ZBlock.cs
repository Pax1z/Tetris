﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tetris
{
    public class ZBlock : Block
    {
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },  // Z shape, default rotation (horizontal)
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 0) },  // Z shape, rotated right (vertical)
            new Position[] { new(0, 0), new(0, 1), new(1, 1), new(1, 2) },  // Z shape, upside down (same as default)
            new Position[] { new(0, 1), new(1, 0), new(1, 1), new(2, 0) }   // Z shape, rotated left (same as right)
        };
        
        public override int Id => 7;

        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}

