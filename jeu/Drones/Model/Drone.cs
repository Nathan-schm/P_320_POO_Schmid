using Drones.Helpers;
using Drones.Properties;
using System.Configuration;

namespace Drones
{
    // Cette partie de la classe Drone définit ce qu'est un drone par un modèle numérique
    public class Drone
    {
        public int _x;                                 // Position en X depuis la gauche de l'espace aérien
        public int _y;                                 // Position en Y depuis le haut de l'espace aérien

        public Rectangle Hitbox => new Rectangle(_x - Config.PLAYER_WIDTH/2, _y - Config.PLAYER_HEIGHT/2, Config.PLAYER_WIDTH, Config.PLAYER_HEIGHT);

        // Constructeur
        public Drone(int x, int y)
        {
            this._x = x;
            this._y = y;
            DirectionLeft();
            DirectionRight();
        }

        // Cette méthode calcule le nouvel état dans lequel le joueur se trouve pour chaque frame
        public void Update(int interval)
        {
            
        }

        // Déplace le joueur à gauche dans les cadre de la fenêtre
        public void DirectionLeft()
        {
            if(_x - Config.PLAYER_SPEED <= 0 + (Config.PLAYER_WIDTH/2)+80)
            {
                _x -= 0;
            }
            else
            {
                _x -= Config.PLAYER_SPEED;
            }
        }

        // Déplace le joueur à droite dans les cadre de la fenêtre
        public void DirectionRight()
        {

            if (_x + Config.PLAYER_SPEED >= Config.AIRSPACE_WIDTH - Config.PLAYER_WIDTH / 2)
            {
                _x -= 0;
            }
            else
            {
                _x += Config.PLAYER_SPEED;
            }
                
        }

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.drone, _x - (Config.PLAYER_WIDTH/2), _y - (Config.PLAYER_HEIGHT/2), Config.PLAYER_WIDTH, Config.PLAYER_HEIGHT);
        }
    }
}
