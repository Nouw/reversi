using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    internal class MoveManager
    {
        public static bool help = false;

        /// <summary>
        /// Validates if a clicked tile is a valid move by the rules,
        /// </summary>
        /// <param name="x">Clicked x coordinate</param>
        /// <param name="y">Clicked y coordinate</param>
        /// <returns>false or true depending if the move is valid</returns>
        public static bool moveValidator(int x, int y)
        {
            bool valid = false;
            bool moveValid = false;

            List<(int, int)> neighboringDiscs = MoveManager.neighboringDiscs(x, y);

            foreach (var neighboringDisc in neighboringDiscs)
            {
                int dx = neighboringDisc.Item1 - x;
                int dy = neighboringDisc.Item2 - y;

                //Check where the disc is located
                if (dx == 0 && dy > 0)
                {
                    valid = MoveManager.checkVertical(x, y);
                }
                else if (dx == 0 && dy < 0)
                {
                    valid = MoveManager.checkVertical(x, y, false);
                }
                else if (dx < 0 && dy == 0)
                {
                    valid = MoveManager.checkHorizontal(x, y, false);
                }
                else if (dx > 0 && dy == 0)
                {
                    valid = MoveManager.checkHorizontal(x, y);
                }
                else if (dx < 0 && dy < 0)
                {
                    valid = MoveManager.checkDiagonal(x, y);
                }
                else if (dx > 0 && dy < 0) 
                {
                    valid = MoveManager.checkDiagonal(x, y, false, true);
                }
                else if (dx < 0 && dy > 0)
                {
                    valid = MoveManager.checkDiagonal(x, y, true);
                } else if (dx > 0 && dy > 0)
                {
                    valid = MoveManager.checkDiagonal(x, y, true, true);
                }

                if (valid)
                {
                    moveValid = true;
                }
            }

            return moveValid;
        }
        /// <summary>
        /// Check for neighboring discs of the clicked location
        /// </summary>
        /// <param name="x">Clicked X coordinate</param>
        /// <param name="y">Clicked Y coordinate</param>
        /// <returns></returns>
        private static List<(int, int)> neighboringDiscs(int x, int y)
        {
            List<(int, int)> discs = new List<(int, int)> ();

            int xStart = x - 1;
            int yStart = y - 1;
            //Prevent the checker from going outside of the grid
            if (xStart < 0)
            {
                xStart = 0;
            }

            if (yStart < 0)
            {
                yStart = 0;
            }

            //Loop through the x coords of the neighbors
            for (int i = xStart; i <= (x - 1) + 2; i++)
            {
                //Prevent the loop from going out of bounds
                if (i >= GameManager.internalGameArea.GetLength(0))
                {
                    break;
                }
                //Loop through the y coords of the neighbors
                for (int j = yStart; j <= (y - 1) + 2; j++)
                {
                    if (j >= GameManager.internalGameArea.GetLength(1))
                    {
                        break;
                    }

                    Tile tile = GameManager.internalGameArea[i, j];
                    Tile opponentTileType = GameManager.getOpponentTileType();

                    if (tile == opponentTileType)
                    {
                        discs.Add((i, j));
                    }
                
                }
            }


            return discs;
        }
        /// <summary>
        /// Check the vertical tiles of the clicked location
        /// </summary>
        /// <param name="x">Clicked X coordinate</param>
        /// <param name="y">Clicked Y coordinate</param>
        /// <param name="bottom">If it has to check the tiles
        /// below the clicked position, set this to true.
        /// </param>
        /// <returns></returns>
        private static bool checkVertical(int x, int y, bool bottom = true)
        {
            bool valid = false;
            bool running = true;

            Tile playerTile = GameManager.getPlayerTile();

            int i = y - 1;

            if (bottom)
            {
                i = y + 1;
            }

            int previousY = i;

            while (running)
            {
                //Stop the checker when it goes out of bounds
                if (i >= GameManager.internalGameArea.GetLength(1) || i < 0)
                {
                    running = false;
                    break;
                }

                Tile currentTile = GameManager.internalGameArea[x, i];
                //Check if tile is of correct type
                if (currentTile == Tile.TILE_EMPTY)
                {
                    running = false;
                    valid = false;
                    break;
                } else if (currentTile == playerTile)
                {
                    valid = true;
                    running = false;
                    break;
                }

                previousY = i; 
                //Go to next tile
                if (bottom)
                {
                    i++;
                } else
                {
                    i--;
                }

            }

            //change all the tiles in this column
            if (valid && !help)
            {

                if (bottom)
                {
                    for (int j = y; j <= previousY; j++)
                    {
                        GameManager.internalGameArea[x, j] = playerTile;
                    }
                } else
                {
                    for (int j = previousY; j <= y; j++)
                    {
                        GameManager.internalGameArea[x, j] = playerTile;
                    }
                }
            }

            return valid;
        }

        /// <summary>
        /// Check the tiles on the left or the right of the clicked tile
        /// </summary>
        /// <param name="x">Clicked X coordinate</param>
        /// <param name="y">Clicked Y coordinate</param>
        /// <param name="right">If the tiles on the left have to be checked,
        /// set this to false</param>
        /// <returns></returns>
        public static bool checkHorizontal(int x, int y, bool right = true)
        {
            bool valid = false;
            bool running = true;

            Tile playerTile = GameManager.getPlayerTile();

            int i = x + 1;

            if (!right)
            {
                i = x - 1;
            }

            int previousX = i;


            while (running)
            {
                //Prevent i from going out of bounds
                if (i < 0 || i >= GameManager.internalGameArea.GetLength(0))
                {
                    valid = false;
                    running = false;
                    break;
                }

                Tile currentTile = GameManager.internalGameArea[i, y];
                //Check if tile is of correct type
                if (currentTile == Tile.TILE_EMPTY)
                {
                    running = false;
                    valid = false;
                    break;
                }
                else if (currentTile == playerTile)
                {
                    valid = true;
                    running = false;
                    break;
                }

                previousX = i;
                //Go to next tile
                if (right)
                {
                    i++;
                }
                else
                {
                    i--;
                }
            }
            ////change all the tiles in this row
            if (valid && !help)
            {

                if (right)
                {
                    for (int j = x; j <= previousX; j++)
                    {
                        GameManager.internalGameArea[j, y] = playerTile;
                    }
                }
                else
                {
                    for (int j = previousX; j <= x; j++)
                    {
                        GameManager.internalGameArea[j, y] = playerTile;
                    }
                }
            }

            return valid;
        }

        /// <summary>
        /// Checks all the diagonal tiles of the clicked tile
        /// </summary>
        /// <param name="x">Clicked X coordinate</param>
        /// <param name="y">Clicked Y coordinate</param>
        /// <param name="bottom">Set this to true, if you are checking the bottom row</param>
        /// <param name="right">Set this to true, if you are checking the right column</param>
        /// <returns></returns>
        public static bool checkDiagonal(int x, int y, bool bottom = false, bool right = false)
        {
            bool valid = false;
            bool running = true;

            Tile playerTile = GameManager.getPlayerTile();

            
            int iX = x - 1;
            int iY = y - 1;

            if (bottom)
            {
                iY = y + 1;
            }

            if (right)
            {
                iX = x + 1;
            }

            int previousIX = iX;
            int previousIY = iY;

            while (running)
            {
                //Prevent iX and iY from going out of bounds
                if (iX < 0 || iX >= GameManager.internalGameArea.GetLength(0) || iY < 0 || iY >= GameManager.internalGameArea.GetLength(1))
                {
                    valid = false;
                    running = false;
                    break;
                }

                Tile currentTile = GameManager.internalGameArea[iX, iY];
                //Check if tile is of correct type
                if (currentTile == Tile.TILE_EMPTY)
                {
                    running = false;
                    valid = false;
                    break;
                }
                else if (currentTile == playerTile)
                {
                    valid = true;
                    running = false;
                    break;
                }

                //Go to next tile
                if (bottom)
                {
                    iY++;
                } else
                {
                    iY--;
                }

                if (right)
                {
                    iX++;
                } else
                {
                    iX--;
                }

                previousIX = iX;
                previousIY = iY;
            }
            //Change all the tiles
            if (valid && !help)
            {
                running = true;

                int currentX = previousIX;
                int currentY = previousIY;

                while (running)
                {
                    bool yBoundsChecker = false;
                    bool xBoundsChecker = false;

                    if (bottom)
                    {
                        yBoundsChecker = currentY < 0 || currentY < y;
                    }
                    else
                    {
                        yBoundsChecker = currentY > y && currentY <= GameManager.internalGameArea.GetLength(1);
                    }

                    if (right)
                    {
                        xBoundsChecker = currentX < 0 || currentX < x;
                    } else
                    {
                        xBoundsChecker = currentX > x && currentX <= GameManager.internalGameArea.GetLength(0);
                    }

                    //Prevent x and y from going out of bounds
                    if (yBoundsChecker || xBoundsChecker)
                    {
                        running = false;
                        break;
                    }

                    GameManager.internalGameArea[currentX, currentY] = playerTile;

                    if (bottom)
                    {
                        currentY--;
                    } else
                    {
                        currentY++;
                    }

                    if (right)
                    {
                        currentX--;
                    } else
                    {
                        currentX++;
                    }
                }
            }

            return valid;
        }
    }
}
