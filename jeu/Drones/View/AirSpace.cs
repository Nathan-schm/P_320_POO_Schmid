using Drones.Properties;

namespace Drones
{
    // La classe AirSpace représente le territoire au dessus duquel les drones peuvent voler
    // Il s'agit d'un formulaire (une fenêtre) qui montre une vue 2D depuis en dessus
    // Il n'y a donc pas de notion d'altitude qui intervient

    public partial class AirSpace : Form
    {

        // La flotte est l'ensemble des drones qui évoluent dans notre espace aérien
        private Drone _player;

        BufferedGraphicsContext currentContext;
        BufferedGraphics airspace;

        // Initialisation de l'espace aérien avec un certain nombre de drones
        public AirSpace(Drone player)
        {
            InitializeComponent();
            ClientSize = new Size(Config.AIRSPACE_WIDTH, Config.AIRSPACE_HEIGHT);

            // Gets a reference to the current BufferedGraphicsContext
            currentContext = BufferedGraphicsManager.Current;
            // Creates a BufferedGraphics instance associated with this form, and with
            // dimensions the same size as the drawing surface of the form.
            airspace = currentContext.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            this._player = player;
        }

        // Affichage de la situation actuelle
        private void Render()
        {
            airspace.Graphics.Clear(Color.White);
            airspace.Graphics.DrawImage(Resources.branche1, 0,0,Config.AIRSPACE_WIDTH,143);

            _player.Render(airspace);

            airspace.Render();
        }

        // Calcul du nouvel état après que 'interval' millisecondes se sont écoulées
        private void Update(int interval)
        {
            _player.Update(interval);
        }

        // Méthode appelée à chaque frame
        private void NewFrame(object sender, EventArgs e)
        {
            this.Update(ticker.Interval);
            this.Render();
        }

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
    }
}