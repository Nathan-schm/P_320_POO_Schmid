using POO_NathanSchmid_Jeu.Joueur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_NathanSchmid_Jeu.view
{
    public partial class GameSpace : Form
    {
        private BufferedGraphicsContext _currentContext;
        private BufferedGraphics _gamespace;
        private Personnage _joueur = new Personnage(config.GAMESPACE_WIDTH / 2, config.GAMESPACE_HEIGHT / 2);

        public GameSpace()
        {
            InitializeComponent();
            this.ClientSize = new Size(config.GAMESPACE_WIDTH, config.GAMESPACE_HEIGHT);

            _currentContext = BufferedGraphicsManager.Current;
            _gamespace = _currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        }
        private void Render()
        {
            _gamespace.Graphics.Clear(Color.Black);
            _joueur.Render(_gamespace);
            _gamespace.Render();
        }

        private void tmrRender_Tick(object sender, EventArgs e)
        {
            this.Render();

        }
    }
}
