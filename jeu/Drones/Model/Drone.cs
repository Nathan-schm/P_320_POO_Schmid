using Drones.Helpers;
using Drones.Properties;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public class Drone
    {
        public int x;                                 // Position en X depuis la gauche de l'espace aérien
        public int y;                                 // Position en Y depuis le haut de l'espace aérien
        public int speed_x;                           // Déplacement horizontal

        // Constructeur
        public Drone(int x, int y)
        {
            Random alea = new Random();
            this.x = x;
            this.y = y;
            DirectionLeft();
            DirectionRight();
        }

        // Cette méthode calcule le nouvel état dans lequel le drone se trouve après
        // que 'interval' millisecondes se sont écoulées
        public void Update(int interval)
        {
            x += speed_x;   
        }

        // Choisit une nouvelle vitesse aléatoirement
        public void DirectionLeft()
        {
            x-=10;
        }
        public void DirectionRight()
        {
            x += 10;
        }

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.drone, x - (Config.PLAYER_WIDTH/2), y - (Config.PLAYER_HEIGHT/2), Config.PLAYER_WIDTH, Config.PLAYER_HEIGHT);
        }



    }
}
