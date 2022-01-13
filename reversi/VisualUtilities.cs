using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reversi
{
    internal class VisualUtilities
    {

        /// <summary>
        /// This generates the grid on the screen, it also populates the tiles with
        /// discs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void GenerateGrid(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            int height = p.Size.Height / GameManager.rows;
            int width = p.Size.Width / GameManager.columns;

            Pen pen = new Pen(Color.Black, 1);
            //Loop through x cords
            for (int i = 0; i < GameManager.internalGameArea.GetLength(0); i++)
            {
                int x = i * width;
                for (int j = 0; j < GameManager.internalGameArea.GetLength(1); j++)
                {
                    int y = j * height;

                    Tile tileValue = GameManager.internalGameArea[i, j];

                    Brush brush = new SolidBrush(Color.Blue);

                    if (tileValue == Tile.TILE_BLUE)
                    {
                        VisualUtilities.drawCircle(Color.Blue, g, x, y, width, height);
                    }
                    else if (tileValue == Tile.TILE_RED)
                    {
                        VisualUtilities.drawCircle(Color.Red, g, x, y, width, height);
                    }

                    if (GameManager.help && tileValue == Tile.TILE_EMPTY)
                    {
                        VisualUtilities.drawHelpCircle(g, i, j, x, y, width, height);
                    }

                    g.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        /// <summary>
        /// Draw a circle on a tile
        /// </summary>
        /// <param name="color">The color of the current player</param>
        /// <param name="g">Graphics object</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">Width of the circle</param>
        /// <param name="height">Height of the circle</param>
        private static void drawCircle(Color color, Graphics g, int x, int y, int width, int height)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y + 1, width - 2, height - 2);
        }

        /// <summary>
        /// Changes the text to show which player has to place a disc.
        /// </summary>
        /// <returns></returns>
        public static string changeTurnText()
        {
            switch (GameManager.playerTurn)
            {
                case Players.PLAYERS_BLUE:
                    return "Blauw is aan de beurt";
                case Players.PLAYERS_RED:
                    return "Rood is aan de beurt";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Generate circles for the amount of tiles a player has occupied.
        /// </summary>
        /// <param name="sender">The panel the circles are located in</param>
        /// <param name="e"></param>
        public static void generateDiscInfo(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            int bottomMargin = 100;
            int height = 40;
            int width = 40;

            int x = 5;
            int y = 150;

            VisualUtilities.drawCircle(Color.Blue, g, x, y, height, width);
            VisualUtilities.drawCircle(Color.Red, g, x, y + height + 10, height, width);
        }

        /// <summary>
        /// Creates a circle of the possible position a player can put a disc.
        /// </summary>
        /// <param name="g">Graphics object to draw circles</param>
        /// <param name="i">Mapped x value</param>
        /// <param name="j">Mapped y value</param>
        /// <param name="x">X coordinate of the tile</param>
        /// <param name="y">Y coordinate of the tile</param>
        /// <param name="width">Width of the circle</param>
        /// <param name="height">Height of the circle</param>
        public static void drawHelpCircle(Graphics g, int i, int j, int x, int y, int width, int height)
        {
            MoveManager.help = true;
            bool valid = MoveManager.moveValidator(i, j);
            MoveManager.help = false;
            if (valid)
            {
                Pen brush = new Pen(Color.Black);
                g.DrawEllipse(brush, x, y, width, height);
            }
        }
        
        /// <summary>
        /// Gets the text for when the game is finished and calculates who has won
        /// </summary>
        /// <returns>A string with {color} is de winnaar!</returns>
        public static string winnerText()
        {
            string winner = "Blauw";

            if (GameManager.countDiscs(Players.PLAYERS_BLUE) < GameManager.countDiscs(Players.PLAYERS_RED))
            {
                winner = "Rood";
            }

            return $"{winner} is de winnaar!";
        }
        /// <summary>
        /// Update the timer of the player
        /// </summary>
        /// <param name="current">the text of the timer</param>
        /// <returns></returns>
        public static string updateTime(string current)
        {
            int minutes = int.Parse(current.Split(':')[0]);
            int seconds = int.Parse(current.Split(':')[1]);

            if (seconds == 0 && minutes != 0)
            {
                minutes--;
                seconds = 59;
            }
            else if (minutes == 0 && seconds == 0)
            {
                return "0:00";
            }
            {
                seconds--;
            }

            return $"{minutes} : {seconds}";
        }
    }
}
