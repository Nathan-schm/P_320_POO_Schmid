using Drones.Properties;

namespace Drones
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {

        // Le joueur 
        private Drone _player;

        // L'ennemis
        private List<Ennemi> _enemy;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(Drone player, List<Ennemi> enemy)
        {
            InitializeComponent();
            ClientSize = new Size(Config.AIRSPACE_WIDTH, Config.AIRSPACE_HEIGHT);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this._player = player;
            this._enemy = enemy;
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.White);
            airspace.Graphics.DrawImage(Resources.fond, 0, 0, Config.AIRSPACE_WIDTH, Config.AIRSPACE_HEIGHT);
            airspace.Graphics.DrawImage(Resources.branche1, 0, 0, Config.AIRSPACE_WIDTH, 143);
            

            _player.Render(airspace);

            foreach (Ennemi ennemi in _enemy)
            {
                ennemi.Render(airspace);
            }


            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            _player.Update(interval);
            foreach (Ennemi ennemi in _enemy)
            {
                ennemi.Update(interval);
            }
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }


        // Regarde quelles touches sont appuyée pour et envoie a la méthode en lien
        private void AirSpace_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    _player.DirectionLeft();
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.D:
                    _player.DirectionRight();
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _player.DirectionLeft();
                    break;
            }
            switch (e.KeyCode)
            {
                case Keys.Right:
                    _player.DirectionRight();
                    break;
            }
        }

        private void AirSpace_Load(object sender, EventArgs e)
        {

        }
    }
}