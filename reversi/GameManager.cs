using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reversi
{
    enum Players
    {
        PLAYERS_BLUE,
        PLAYERS_RED,
    }

    enum Tile
    {
        TILE_EMPTY,
        TILE_BLUE,
        TILE_RED
    }
    internal class GameManager
    {
        /*
         * Columns should be bigger than 3 and smaller 25
         * Rows should be bigger than 3 and smaller than 21
         */
        public const int columns = 3;
        public const int rows = 3;

        public static Players playerTurn = Players.PLAYERS_BLUE;
        public static Tile[,] internalGameArea = new Tile[columns, rows];
        public static bool help = false;

        /// <summary>
        /// Creates the grid for a new game
        /// </summary>
        public static void generateStartingGrid()
        {
            GameManager.internalGameArea = new Tile[GameManager.columns, GameManager.rows];
            //Prevent the user from inputting too small of a field
            if (GameManager.columns < 3 || GameManager.rows < 3)
            {
                Console.Error.WriteLine("Rows or Columns are incorrect, should be >= 3");
                return;
            } 
            //Prevent the player from inputting too big of a field
            else if (GameManager.columns > 24 || GameManager.rows > 20)
            {
                Console.Error.WriteLine("Rows should be < 20 and columns should be < 20");
                return;
            }
            
            int width = GameManager.internalGameArea.GetLength(0) / 2 - 1;
            int height = GameManager.internalGameArea.GetLength(1) / 2 - 1;
            //Blue starting circles
            GameManager.internalGameArea[width, height] = Tile.TILE_BLUE;
            GameManager.internalGameArea[width + 1, height + 1] = Tile.TILE_BLUE;
            //Red starting circles
            GameManager.internalGameArea[width + 1, height] = Tile.TILE_RED;
            GameManager.internalGameArea[width, height + 1] = Tile.TILE_RED;

            GameManager.playerTurn = Players.PLAYERS_BLUE;
        }
        
        /// <summary>
        /// Gets the opponent tile color
        /// </summary>
        /// <returns>Tile (Blue, Red or Empty)</returns>
        public static Tile getOpponentTileType()
        {
            switch (playerTurn)
            {
                case Players.PLAYERS_BLUE:
                    return Tile.TILE_RED;
                case Players.PLAYERS_RED:
                    return Tile.TILE_BLUE;
                default:
                    return Tile.TILE_EMPTY;
            }
        }

        /// <summary>
        /// Gets the current player tile color
        /// </summary>
        /// <returns>Tile (Blue, Red or Empty)</returns>
        public static Tile getPlayerTile()
        {
            switch (playerTurn)
            {
                case Players.PLAYERS_BLUE:
                    return Tile.TILE_BLUE;
                case Players.PLAYERS_RED:
                    return Tile.TILE_RED;
                default:
                    return Tile.TILE_EMPTY;
            }
        }

        /// <summary>
        /// Ends the turn of the current player, is automatically called
        /// when the player clicks a tile.
        /// </summary>
        public static void endTurn()
        {
            if (playerTurn == Players.PLAYERS_BLUE)
            {
                playerTurn = Players.PLAYERS_RED;
            } else if (playerTurn == Players.PLAYERS_RED)
            {
                playerTurn = Players.PLAYERS_BLUE;
            }
        }

        /// <summary>
        /// Counts the discs that the player has placed.
        /// </summary>
        /// <param name="player">Get the discs for each player</param>
        /// <returns>int</returns>
        public static int countDiscs(Players player)
        {
            Tile tile = Tile.TILE_BLUE;

            if (player == Players.PLAYERS_RED)
            {
                tile = Tile.TILE_RED;
            }

            int count = 0;
            //Loop through the game area and increase count if tile is the same
            for (int i = 0; i < internalGameArea.GetLength(0); i++)
            {
                for (int j = 0; j < internalGameArea.GetLength(1); j++)
                {
                    if (internalGameArea[i, j] == tile)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
