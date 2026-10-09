using Squirrels.Properties;

namespace Squirrels
{
    // La classe TreeSpace représente le territoire sur lequel les squirrels peuvent grimper
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class TreeSpace : Form
    {

        // Le joueur 
        private Squirrel _player;

        // L'ennemis
        private List<Ennemi> _enemy;

        // Le tir
        private List<TirJoueur> _tirjoueur;

        BufferedGraphicsContext currentContext;
        BufferedGraphics treespace;

        // Initialisation de l'espace arboré avec un certain nombre de squirrels
        public TreeSpace(Squirrel player, List<Ennemi> enemy, List<TirJoueur> tirjoueur)
        {
            InitializeComponent();
            ClientSize = new Size(Config.TREESPACE_WIDTH, Config.TREESPACE_HEIGHT);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            treespace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this._player = player;
            this._enemy = enemy;
            this._tirjoueur = tirjoueur;
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            treespace.Graphics.Clear(Color.White);
            treespace.Graphics.DrawImage(Resources.fond, 0, 0, Config.TREESPACE_WIDTH, Config.TREESPACE_HEIGHT);
            treespace.Graphics.DrawImage(Resources.branche1, 0, 0, Config.TREESPACE_WIDTH, 143);


            _player.Render(treespace);

            foreach (Ennemi ennemi in _enemy)
            {
                ennemi.Render(treespace);
            }

            foreach (TirJoueur tirjoueur in _tirjoueur)
            {
                tirjoueur.Render(treespace);
            }

            treespace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            _player.Update(interval);
            foreach (Ennemi ennemi in _enemy)
            {
                ennemi.Update(interval, _enemy);
            }
            foreach (TirJoueur tirjoueur in _tirjoueur)
            {
                tirjoueur.Update(interval);
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }


        // Regarde quelles touches sont appuyée pour et envoie a la méthode en lien
        private void TreeSpace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _player.DirectionLeft();
                    break;

                case Keys.D:
                    _player.DirectionRight();
                    break;

                case Keys.Left:
                    _player.DirectionLeft();
                    break;

                case Keys.Right:
                    _player.DirectionRight();
                    break;
                case Keys.Space:
                    _tirjoueur.Add(_player.Throw());
                    break;
            }
        }

        private void TreeSpace_Load(object sender, EventArgs e)
        {

        }
    }
}