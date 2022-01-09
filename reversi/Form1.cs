using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reversi
{
    //TODO: Change color to enums
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.generateStartingGrid();
            this.gameArea.Paint += Utilities.GenerateGrid;
        }

        private void generateStartingGrid()
        {
            //TODO: Check if this breaks when you put an uneven wide grid
            int width = Globals.internalGameArea.GetLength(0) / 2 - 1;
            int height = Globals.internalGameArea.GetLength(1) / 2 - 1;
            //Red starting circles
            Globals.internalGameArea[width, height] = 1;
            Globals.internalGameArea[width + 1, height + 1] = 1;
            //Blue starting circles
            Globals.internalGameArea[width + 1, height] = 2;
            Globals.internalGameArea[width, height + 1] = 2;
        }
        //Just going to create an area
        private void gameAreaClick(object sender, MouseEventArgs e)
        {
            var p = sender as Panel;

            //Map the cords to 0, 6
            int x = e.X;
            int y = e.Y;
            //The 6.0 means the amount of grids
            int mappedX = (int)(Math.Floor(6.0 / p.Size.Width * x));
            int mappedY = (int)(Math.Floor(6.0 / p.Size.Height * y));
            //Prevent users from overriding a filled box
            if (Globals.internalGameArea[mappedX, mappedY] != 0)
            {
                return;
            }

            if (!Utilities.validMove(mappedX, mappedY))
            {
                return;
            }

            Globals.internalGameArea[mappedX, mappedY] = 1;

            this.gameArea.Invalidate();

            return;
        }
    }
}
