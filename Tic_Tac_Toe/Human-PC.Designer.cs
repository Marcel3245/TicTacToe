namespace Tic_Tac_Toe
{
    partial class Human_PC
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
            this.SuspendLayout();
            // 
            // Human_PC
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Human_PC";
            this.Load += new System.EventHandler(this.Human_PC_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CPUScoreLabel;
        private System.Windows.Forms.Label PlayerScoreLabel;
        private System.Windows.Forms.Label CPU;
        private System.Windows.Forms.Label Player;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Button BackHP;
        private System.Windows.Forms.Button C3;
        private System.Windows.Forms.Button C2;
        private System.Windows.Forms.Button C1;
        private System.Windows.Forms.Button B3;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.Button B1;
        private System.Windows.Forms.Button A3;
        private System.Windows.Forms.Button A2;
        private System.Windows.Forms.Button A1;
    }
}