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
            GameManager.generateStartingGrid();
            this.gameArea.Paint += VisualUtilities.GenerateGrid;
            this.GameControls.Paint += VisualUtilities.generateDiscInfo;
        }
        
        private void gameAreaClick(object sender, MouseEventArgs e)
        {
            var p = sender as Panel;

            //Map the cords to 0, 6
            int x = e.X;
            int y = e.Y;
            //The 6.0 means the amount of grids
            int mappedX = (int)(Math.Floor((float)GameManager.width / p.Size.Width * x));
            int mappedY = (int)(Math.Floor((float)GameManager.height / p.Size.Height * y));
            //Prevent users from overriding a filled box
            if (GameManager.internalGameArea[mappedX, mappedY] != Tile.TILE_EMPTY)
            {
                return;
            }

            bool a = MoveManager.moveValidator(mappedX, mappedY);

            if (!a)
            {
                return;
            } else
            {
                //For some reason the validator sometimes bugs out
                GameManager.endTurn();

                if (Utilities.gameFinished())
                {
                    this.label1.Text = VisualUtilities.winnerText();
                } else
                {
                    this.label1.Text = VisualUtilities.changeTurnText();
                }

                this.updateDiscInfo();
                this.gameArea.Invalidate();

            }

            return;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void start_MouseClick(object sender, MouseEventArgs e)
        {
            GameManager.generateStartingGrid();
            this.gameArea.Paint += VisualUtilities.GenerateGrid;
            this.gameArea.Invalidate();

            this.label1.Text = VisualUtilities.changeTurnText();

            this.updateDiscInfo();

            return;
        }

        public void updateDiscInfo()
        {
            List<Players> players = new List<Players>() { Players.PLAYERS_BLUE, Players.PLAYERS_RED };

            foreach (Players player in players)
            {
                int count = GameManager.countDiscs(player);

                string text = $"{count.ToString()} stenen";

                switch (player)
                {
                    case Players.PLAYERS_BLUE:
                        this.blueDiscs.Text = text;
                        break;
                    case Players.PLAYERS_RED:
                        this.redDiscs.Text = text;
                        break;
                }
            }
        }

        private void help_MouseClick(object sender, MouseEventArgs e)
        {
            GameManager.help = !GameManager.help;
        }
    }
}
