namespace POO_NathanSchmid_Jeu.view
{
    partial class GameSpace
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
            this.tmrRender = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tmrRender
            // 
            this.tmrRender.Enabled = true;
            this.tmrRender.Tick += new System.EventHandler(this.tmrRender_Tick);
            // 
            // GameSpace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GameSpace";
            this.Text = "GameSpace";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRender;
    }
}