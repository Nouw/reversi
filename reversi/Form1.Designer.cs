namespace reversi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameArea = new System.Windows.Forms.Panel();
            this.gameText = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.GameControls = new System.Windows.Forms.Panel();
            this.redDiscs = new System.Windows.Forms.Label();
            this.blueDiscs = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timeRed = new System.Windows.Forms.Label();
            this.timeBlue = new System.Windows.Forms.Label();
            this.GameControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameArea
            // 
            this.gameArea.AutoScroll = true;
            this.gameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameArea.Location = new System.Drawing.Point(299, 33);
            this.gameArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameArea.Name = "gameArea";
            this.gameArea.Size = new System.Drawing.Size(720, 600);
            this.gameArea.TabIndex = 0;
            this.gameArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameAreaClick);
            // 
            // gameText
            // 
            this.gameText.AutoSize = true;
            this.gameText.Location = new System.Drawing.Point(604, 11);
            this.gameText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gameText.Name = "gameText";
            this.gameText.Size = new System.Drawing.Size(92, 16);
            this.gameText.TabIndex = 1;
            this.gameText.Text = "Blauw aan zet!";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(75, 11);
            this.start.Margin = new System.Windows.Forms.Padding(4);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(100, 28);
            this.start.TabIndex = 2;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.start_MouseClick);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(75, 60);
            this.help.Margin = new System.Windows.Forms.Padding(4);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(100, 28);
            this.help.TabIndex = 3;
            this.help.Text = "Help";
            this.help.UseVisualStyleBackColor = true;
            this.help.MouseClick += new System.Windows.Forms.MouseEventHandler(this.help_MouseClick);
            // 
            // GameControls
            // 
            this.GameControls.Controls.Add(this.redDiscs);
            this.GameControls.Controls.Add(this.blueDiscs);
            this.GameControls.Controls.Add(this.start);
            this.GameControls.Controls.Add(this.help);
            this.GameControls.Location = new System.Drawing.Point(4, 4);
            this.GameControls.Margin = new System.Windows.Forms.Padding(4);
            this.GameControls.Name = "GameControls";
            this.GameControls.Size = new System.Drawing.Size(267, 629);
            this.GameControls.TabIndex = 4;
            // 
            // redDiscs
            // 
            this.redDiscs.AutoSize = true;
            this.redDiscs.ForeColor = System.Drawing.Color.Red;
            this.redDiscs.Location = new System.Drawing.Point(67, 262);
            this.redDiscs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.redDiscs.Name = "redDiscs";
            this.redDiscs.Size = new System.Drawing.Size(57, 16);
            this.redDiscs.TabIndex = 5;
            this.redDiscs.Text = "2 stenen";
            // 
            // blueDiscs
            // 
            this.blueDiscs.AutoSize = true;
            this.blueDiscs.ForeColor = System.Drawing.Color.Blue;
            this.blueDiscs.Location = new System.Drawing.Point(67, 201);
            this.blueDiscs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blueDiscs.Name = "blueDiscs";
            this.blueDiscs.Size = new System.Drawing.Size(57, 16);
            this.blueDiscs.TabIndex = 4;
            this.blueDiscs.Text = "2 stenen";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timeRed
            // 
            this.timeRed.AutoSize = true;
            this.timeRed.BackColor = System.Drawing.Color.Red;
            this.timeRed.ForeColor = System.Drawing.Color.White;
            this.timeRed.Location = new System.Drawing.Point(974, 11);
            this.timeRed.Name = "timeRed";
            this.timeRed.Size = new System.Drawing.Size(38, 16);
            this.timeRed.TabIndex = 5;
            this.timeRed.Text = "10:00";
            // 
            // timeBlue
            // 
            this.timeBlue.AutoSize = true;
            this.timeBlue.BackColor = System.Drawing.Color.Blue;
            this.timeBlue.ForeColor = System.Drawing.Color.White;
            this.timeBlue.Location = new System.Drawing.Point(299, 10);
            this.timeBlue.Name = "timeBlue";
            this.timeBlue.Size = new System.Drawing.Size(38, 16);
            this.timeBlue.TabIndex = 6;
            this.timeBlue.Text = "10:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1038, 644);
            this.Controls.Add(this.timeBlue);
            this.Controls.Add(this.timeRed);
            this.Controls.Add(this.GameControls);
            this.Controls.Add(this.gameText);
            this.Controls.Add(this.gameArea);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GameControls.ResumeLayout(false);
            this.GameControls.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gameArea;
        private System.Windows.Forms.Label gameText;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Panel GameControls;
        private System.Windows.Forms.Label blueDiscs;
        private System.Windows.Forms.Label redDiscs;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timeRed;
        private System.Windows.Forms.Label timeBlue;
    }
}

