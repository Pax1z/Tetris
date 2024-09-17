using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        // Stores the block's tiles positions in different rotation states
        protected abstract Position[][] Tiles { get; }
        
        // Start position of the block when it spawns
        protected abstract Position StartOffset { get; }

        // Unique identification for the block type
        public abstract int Id { get; }

        private int rotationState; // Tracks the current rotation of the block
        private Position offset; // Tracks the current position of the block

        public Block()
        {
            // Initialize the blocks position to the start offset
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        //Returns the current positions of the block's tiles relative to the grid
        public IEnumerable<Position> TilePositions()
        {
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        // Rotate the block clockwise
        public void RotateCW()
        {
            rotationState= (rotationState + 1) % Tiles.Length;
        }

        // Rotate the block counterclockwise
        public void RotateCCW()
        {
            if (rotationState==0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }
        }

        // Move the block by a certain number of rows and columns
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        // Resets the block to its initial rotation and position
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
