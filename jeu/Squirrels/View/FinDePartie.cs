using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Squirrels
{
    public partial class FinDePartie : Form
    {
        public FinDePartie(string message, int score)
        {
            InitializeComponent();
            labelMessage.Text = $"{message}\nScore : {score}";

            button2.Click += Rejouer_Click;
            button1.Click += Quitter_Click;
        }

        private void Rejouer_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void Quitter_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
