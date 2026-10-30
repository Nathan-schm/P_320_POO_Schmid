namespace Squirrels
{
    partial class FinDePartie
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
            labelMessage = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // labelMessage
            // 
            labelMessage.BackColor = Color.Gold;
            labelMessage.Font = new Font("Segoe UI", 15F);
            labelMessage.ForeColor = SystemColors.ControlLightLight;
            labelMessage.Location = new Point(219, 78);
            labelMessage.Name = "labelMessage";
            labelMessage.Size = new Size(278, 29);
            labelMessage.TabIndex = 2;
            labelMessage.Text = "label1";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(410, 565);
            button1.Name = "button1";
            button1.Size = new Size(155, 47);
            button1.TabIndex = 3;
            button1.Text = "QUITTER";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(131, 565);
            button2.Name = "button2";
            button2.Size = new Size(155, 46);
            button2.TabIndex = 4;
            button2.Text = "REJOUER";
            button2.UseVisualStyleBackColor = true;
            // 
            // FinDePartie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources._5371c6a1_cb13_4fc0_9e8d_cbfda4090dcf;
            ClientSize = new Size(677, 781);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(labelMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FinDePartie";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FinDePartie";
            ResumeLayout(false);
        }

        #endregion
        private Label labelMessage;
        private Button button1;
        private Button button2;
    }
}