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
    public partial class Form1 : Form
    {
        bool started = false;

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

            //Map the cords to 0 -> columns / rows
            int x = e.X;
            int y = e.Y;

            int mappedX = (int)(Math.Floor((float)GameManager.columns / p.Size.Width * x));
            int mappedY = (int)(Math.Floor((float)GameManager.rows / p.Size.Height * y));
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

                if (Utilities.gameFinished() || timeRed.Text == "0:00" || timeBlue.Text == "0:00")
                {
                    this.timer1.Enabled = false;
                    this.gameText.Text = VisualUtilities.winnerText();
                    this.started = false;
                    this.timer1.Stop();
                }
                else
                {
                    this.gameText.Text = VisualUtilities.changeTurnText();

                    if (!started)
                    {
                        started = true;
                        timer1.Enabled = true;
                        timer1.Interval = 1000;
                    }
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

            this.gameText.Text = VisualUtilities.changeTurnText();
            this.started = false;

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (started)
            {
                Players player = GameManager.playerTurn;

                switch (player)
                {
                    case Players.PLAYERS_BLUE:
                        timeBlue.Text = VisualUtilities.updateTime(timeBlue.Text);
                        break;
                    case Players.PLAYERS_RED:
                        timeRed.Text = VisualUtilities.updateTime(timeRed.Text);
                        break;
                }
            }
        }
    }
}
