using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class BlockQueue
    {
        // Array holding all the block types
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock(),
        };

        // Random instance for selecting random blocks
        private readonly Random random = new Random();

        // Holds the next block to be spawned
        public Block NextBlock { get; private set; }

        public BlockQueue()
        {
            // Initializes with a random block when the game starts
            NextBlock = RandomBlock();
        }

        // Selected a random block from the available blocks
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        // Gets the current block and updates to a new random block
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }

}
