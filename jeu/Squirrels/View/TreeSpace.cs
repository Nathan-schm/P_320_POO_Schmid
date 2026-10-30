using Squirrels.Helpers;
using Squirrels.Properties;
using System.Numerics;
using System.Windows.Forms;

namespace Squirrels
{
    // La classe TreeSpace représente le territoire sur lequel les squirrels peuvent grimper
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class TreeSpace : Form
    {

        private bool _gauche;
        private bool _droite;

        private int _score;

        // Le joueur 
        private Squirrel _player;

        private List<Defense> _defense;

        // L'ennemis
        private List<Ennemi> _enemy;

        // Le tir
        private List<TirJoueur> _tirjoueur;

        private List<TirEnnemi> _tirennemi;

        BufferedGraphicsContext currentContext;
        BufferedGraphics treespace;

        // Initialisation de l'espace arboré avec un certain nombre de squirrels
        public TreeSpace(Squirrel player, List<Ennemi> enemy, List<TirJoueur> tirjoueur, List<TirEnnemi> tirennemi, List<Defense> defense)
        {
            InitializeComponent();
            this.KeyUp += TreeSpace_KeyUp;
            ClientSize = new Size(Config.TREESPACE_WIDTH, Config.TREESPACE_HEIGHT);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            treespace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this._player = player;
            this._enemy = enemy;
            this._tirjoueur = tirjoueur;
            this._tirennemi = tirennemi;
            this._defense = defense;
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            treespace.Graphics.Clear(Color.White);
            treespace.Graphics.DrawImage(Resources.fond, 0, 0, Config.TREESPACE_WIDTH, Config.TREESPACE_HEIGHT);
            treespace.Graphics.DrawImage(Resources.branche1, 0, 0, Config.TREESPACE_WIDTH, 143);

            treespace.Graphics.DrawString($"Vie : {_player._vie}", TextHelpers.drawFont, TextHelpers.writingBrush, 10, 10);
            treespace.Graphics.DrawString($"Score : {_score}", TextHelpers.drawFont, TextHelpers.writingBrush, 10, 30);


            _player.Render(treespace);

            foreach (Ennemi ennemi in _enemy)
            {
                ennemi.Render(treespace);
            }

            foreach (TirJoueur tirjoueur in _tirjoueur)
            {
                tirjoueur.Render(treespace);
            }

            foreach (TirEnnemi tirennemi in _tirennemi)
            {
                tirennemi.Render(treespace);
            }

            foreach(Defense defense in _defense)
            {
                defense.Render(treespace);
            }

            treespace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            _player.Update(interval);
            if (_gauche) _player.DirectionLeft();
            if (_droite) _player.DirectionRight();
            foreach (Ennemi ennemi in _enemy)
            {
                ennemi.Update(interval, _enemy);

                if (ennemi.PeutTirer(interval))
                {
                    _tirennemi.Add(ennemi.Throw());
                }
            }
            foreach (TirJoueur tirjoueur in _tirjoueur)
            {
                tirjoueur.Update(interval);
            }

            foreach (TirEnnemi tirennemi in _tirennemi)
            {
                tirennemi.Update(interval);
            }

            for (int i = _tirjoueur.Count - 1; i >= 0; i--)
            {
                Ennemi touche = _enemy.FirstOrDefault(e => e.Hitbox.IntersectsWith(_tirjoueur[i].Hitbox));

                if (touche != null)
                {
                    _tirjoueur.RemoveAt(i);
                    touche._pointDeVie -= 25;
                    if (touche._pointDeVie <= 0)
                    {
                        _enemy.Remove(touche);
                        _score += 50;
                    }
                }
            }

            for (int a = _tirennemi.Count - 1; a >= 0; a--)
            {
                Defense contact = _defense.FirstOrDefault(y => y.Hitbox.IntersectsWith(_tirennemi[a].Hitbox));

                if (contact != null)
                {
                    _tirennemi.RemoveAt(a);
                    contact._pV -= 20;
                    if (contact._pV <= 0)
                    {
                        _defense.Remove(contact);
                    }
                    continue;
                }

                if (_tirennemi[a].Hitbox.IntersectsWith(_player.Hitbox))
                {
                    _player._vie -= _tirennemi[a].Degats;
                    _tirennemi.RemoveAt(a);                    

                    if (_player._vie <= 0)
                    {
                        ticker.Stop();
                        MessageBox.Show("Perdu !");
                        return;
                    }
                }

            }
            for (int b = _tirennemi.Count - 1; b >= 0; b--)
            {
                if (_tirennemi[b].Hitbox.Bottom < 0)
                {
                    _tirennemi.RemoveAt(b);
                }
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval = 15);
            this.Render();
        }


        // Regarde quelles touches sont appuyée pour et envoie a la méthode en lien
        private void TreeSpace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    _gauche = true;
                    break;

                case Keys.D:
                case Keys.Right:
                    _droite = true;
                    break;

                case Keys.Space:
                    if (_player.PeutLancer())
                    {
                        _tirjoueur.Add(_player.Throw());
                    }
                    break;
            }
        }

        private void TreeSpace_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    _gauche = false;
                    break;

                case Keys.D:
                case Keys.Right:
                    _droite = false;
                    break;
            }
        }

        private void TreeSpace_Load(object sender, EventArgs e)
        {

        }
    }
}