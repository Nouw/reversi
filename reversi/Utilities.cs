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
        public static void GenerateGrid(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            int height = p.Size.Height / 6;
            int width = p.Size.Width / 6;

            Pen pen = new Pen(Color.Black, 1);
            //Loop through x cords
            for (int i = 0; i < Globals.internalGameArea.GetLength(0); i++)
            {
                int x = i * width;
                for (int j = 0; j < Globals.internalGameArea.GetLength(1); j++)
                {
                    int y = j * height;

                    int fieldValue = Globals.internalGameArea[i, j];

                    Brush brush = new SolidBrush(Color.Blue);

                    if (fieldValue == 1)
                    {
                        Utilities.drawCircle(Color.Blue, g, x, y, width, height);
                    } else if (fieldValue == 2)
                    {
                        Utilities.drawCircle(Color.Red, g, x, y, width, height);
                    }

                    g.DrawRectangle(pen, x, y, width, height);
                }
            }
        }

        private static void drawCircle(Color color, Graphics g, int x, int y, int width, int height)
        {
            Brush brush = new SolidBrush(color);
            g.FillEllipse(brush, x, y + 1, width - 2, height - 2);
        }

        public static bool validMove(int x, int y)
        {
            bool accepted = false;

            List<(int x, int y)> discs = Utilities.occupiedNeigborTiles(x, y);
            
            foreach (var disc in discs)
            {
                var dx = x - disc.x;
                var dy = y - disc.y;

                //var slope = Utilities.calculateSlope(disc.Item1, disc.Item2, x, y);
                //Check left
                if (dx > 0 && dy == 0)
                {
                    accepted = Utilities.CheckHorizontal(-1, x, y);
                }
                //Check right
                else if (dx < 0 && dy == 0)
                {
                    accepted = Utilities.CheckHorizontal(1, x, y);
                }
                //Check top
                else if (dx == 0 && dy < -1)
                {

                }
                //Check bottom
                else if (dx == 0 && dy > 1)
                {

                }
                //Check diagonal
                else
                {
                    accepted = Utilities.checkDiagonal(dx, dy, x, y);
                }
            }

 


            return accepted;
        }
        // TODO: Change opponent to enum
        // TODO: Prevent loop from going out of bounds
        public static List<(int, int)> occupiedNeigborTiles(int x, int y, int opponent = 2)
        {
            List<(int a, int b)> discs = new List<(int a, int b)>();
            //Check if any of the neighboring tiles have opponent discs
            //Loop through the x coords
            for (int i = x - 1; i < x + 2; i++)
            {
                if (i < 0 || i > Globals.internalGameArea.GetLength(0))
                {
                    break;
                }
                //Loop through the y coords
                for (int j = y - 1; i < y + 2; j++)
                {
                    //Don't check the own tile
                    if (i == x && j == y)
                    {
                        break;
                    }

                    if (j < 0 || j > (Globals.internalGameArea.GetLength(1) - 1))
                    {
                        break;
                    }

                    int currentTile = Globals.internalGameArea[i, j];

                    if (currentTile == opponent)
                    {
                        discs.Add((i, j));
                    }
                }
            }

            return discs;
        }

        public static double calculateSlope(int ax, int ay, int bx, int by)
        {
            return (by - ay) / (bx - ax);
        }

        public static bool CheckHorizontal(int a, int x, int y)
        {
             bool accepted = false;
            bool running = true;
            int i = x + a;
            while (running)
            {
                if (i > Globals.internalGameArea.Length || i < 0)
                {
                    running = false;
                    break;
                } else
                {
                    int tileInfo = Globals.internalGameArea[i, y];

                    if (tileInfo == 2)
                    {
                        accepted = true;
                        running = false;
                    }
                    //Make 1 and 2 dynamic
                    else if (tileInfo == 1)
                    {
                        i += a;
                    }
                    else if (tileInfo == 0)
                    {
                        running = false;
                        accepted = true;
                    }
                }
            }

            return accepted;
        }
    
        public static bool checkDiagonal(int dx, int dy, int x, int y)
        {
            bool accepted = false;
            bool running = true;
            int a = x + dx;
            int b = y + dy;

            while (running)
            {
                if (a < 0 || b < 0 || a > Globals.internalGameArea.Length || b > Globals.internalGameArea.Length)
                {
                    running = false;
                    break;
                } else
                {
                    int tileInfo = Globals.internalGameArea[a, b];

                    if (tileInfo == 0)
                    {
                        running = false;
                        break;
                    } else if (tileInfo == 1)
                    {
                        a += dx;
                        b += dy;
                    } else if (tileInfo == 2)
                    {
                        accepted = true;
                        running = false;
                        break;
                    }
                }
            }

            return accepted;
        }
    }
}
