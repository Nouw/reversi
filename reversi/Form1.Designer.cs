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
            this.gameArea = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.GameControls = new System.Windows.Forms.Panel();
            this.blueDiscs = new System.Windows.Forms.Label();
            this.redDiscs = new System.Windows.Forms.Label();
            this.GameControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameArea
            // 
            this.gameArea.AutoScroll = true;
            this.gameArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameArea.Location = new System.Drawing.Point(224, 27);
            this.gameArea.Margin = new System.Windows.Forms.Padding(2);
            this.gameArea.Name = "gameArea";
            this.gameArea.Size = new System.Drawing.Size(527, 476);
            this.gameArea.TabIndex = 0;
            this.gameArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gameAreaClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Blauw aan zet!";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(56, 9);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 2;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.MouseClick += new System.Windows.Forms.MouseEventHandler(this.start_MouseClick);
            // 
            // help
            // 
            this.help.Location = new System.Drawing.Point(56, 49);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(75, 23);
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
            this.GameControls.Location = new System.Drawing.Point(3, 3);
            this.GameControls.Name = "GameControls";
            this.GameControls.Size = new System.Drawing.Size(200, 499);
            this.GameControls.TabIndex = 4;
            // 
            // blueDiscs
            // 
            this.blueDiscs.AutoSize = true;
            this.blueDiscs.ForeColor = System.Drawing.Color.Blue;
            this.blueDiscs.Location = new System.Drawing.Point(50, 163);
            this.blueDiscs.Name = "blueDiscs";
            this.blueDiscs.Size = new System.Drawing.Size(48, 13);
            this.blueDiscs.TabIndex = 4;
            this.blueDiscs.Text = "2 stenen";
            // 
            // redDiscs
            // 
            this.redDiscs.AutoSize = true;
            this.redDiscs.ForeColor = System.Drawing.Color.Red;
            this.redDiscs.Location = new System.Drawing.Point(50, 213);
            this.redDiscs.Name = "redDiscs";
            this.redDiscs.Size = new System.Drawing.Size(48, 13);
            this.redDiscs.TabIndex = 5;
            this.redDiscs.Text = "2 stenen";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(762, 514);
            this.Controls.Add(this.GameControls);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameArea);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button help;
        private System.Windows.Forms.Panel GameControls;
        private System.Windows.Forms.Label blueDiscs;
        private System.Windows.Forms.Label redDiscs;
    }
}

