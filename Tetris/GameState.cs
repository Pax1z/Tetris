using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameState
    {   // Property to get and set the current block, resetting it when a new block is set
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock; // Avoids circular reference
            private set
            {
                currentBlock = value;
                currentBlock.Reset();  // Resets the block's position and rotation
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }

        public GameState()
        {
            // Initialize game grid and block queue
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            // Set the current block to the first block from the queue
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        // Check if the current block fits in its position on the grid
        private bool BlockFits()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(p.Row, p.Column))
                {
                    return false;
                }
            }
            
            return true;
        }

        //Rotate block clockwise, but revert if block doesn't fit
        public void rotateBlockCW()
        {
            CurrentBlock.RotateCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
            }
        }

        //Rotate block counterclockwise, but revert if block doesn't fit
        public void rotateBlockCCW()
        {
            CurrentBlock.RotateCCW();

            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
            }
        }

        //Move the block to the left, but revert if block doesn't fit
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);

            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        //Move the block to the right, but revert if block doesn't fit
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);

            if(!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        //Check if the game is over (top rows are filled)
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        // Place the block on the grid and check if the game is over
        private void PlaceBlock()
        {
            foreach (Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        // Move the block down, but place it if it doesn't fit
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
    }
}
