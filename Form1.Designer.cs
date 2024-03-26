namespace BACKROOMS
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
            this.levelDisplay = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playerPart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerPart)).BeginInit();
            this.SuspendLayout();
            // 
            // levelDisplay
            // 
            this.levelDisplay.AutoSize = true;
            this.levelDisplay.Font = new System.Drawing.Font("OCR A Extended", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levelDisplay.ForeColor = System.Drawing.Color.White;
            this.levelDisplay.Location = new System.Drawing.Point(12, 610);
            this.levelDisplay.Name = "levelDisplay";
            this.levelDisplay.Size = new System.Drawing.Size(132, 29);
            this.levelDisplay.TabIndex = 5;
            this.levelDisplay.Text = "LEVEL 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // playerPart
            // 
            this.playerPart.BackColor = System.Drawing.Color.Red;
            this.playerPart.Location = new System.Drawing.Point(0, 0);
            this.playerPart.Name = "playerPart";
            this.playerPart.Size = new System.Drawing.Size(15, 15);
            this.playerPart.TabIndex = 4;
            this.playerPart.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 648);
            this.Controls.Add(this.levelDisplay);
            this.Controls.Add(this.playerPart);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "BACKROOMS";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.playerPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox playerPart;
        private System.Windows.Forms.Label levelDisplay;
        private System.Windows.Forms.Timer gameTimer;
    }
}

