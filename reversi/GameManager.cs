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
        public const int width = 100;
        public const int height = 100;

        public static Players playerTurn = Players.PLAYERS_BLUE;
        public static Tile[,] internalGameArea = new Tile[width, height];
        public static bool help = false;

        /// <summary>
        /// Creates the grid for a new game
        /// </summary>
        public static void generateStartingGrid()
        {
            GameManager.internalGameArea = new Tile[GameManager.width, GameManager.height];

            if (GameManager.width < 3 || GameManager.height < 3)
            {
                Console.Error.WriteLine("Width or height are incorrect, should be >=3");
                return;
            }

            //TODO: Check if this breaks when you put an uneven wide grid
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
