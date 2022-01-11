using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reversi
{
    internal class Utilities
    {
        /// <summary>
        /// Checks if there are any possible moves left for the player.
        /// If there are no moves left, it returns false.
        /// </summary>
        /// <returns>true or false</returns>
        public static bool gameFinished()
        {
            bool finished = false;

            List<(int, int)> tiles = new List<(int, int)> ();

            for (int x = 0; x < GameManager.internalGameArea.GetLength(0); x++)
            {
                for (int y = 0; y < GameManager.internalGameArea.GetLength(1); y++)
                {
                    Tile tile = GameManager.internalGameArea[x, y];

                    if (tile == Tile.TILE_EMPTY)
                    {
                        tiles.Add((x, y));
                    }

                }
            }

            bool validMove = false;

            foreach ((int, int) tile in tiles)
            {
                if (!validMove)
                {
                    MoveManager.help = true;
                    validMove = MoveManager.moveValidator(tile.Item1, tile.Item2);
                    MoveManager.help = false;
                }
            }

            if (!validMove)
            {
                finished = true;
            }

            return finished;
        }
    }
}
