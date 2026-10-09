using Squirrels.Helpers;
using Squirrels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Squirrels
{
    //Cette partie de la classe Ennemis définit ce qu'est un ennemis
    public class Ennemi
    {
        public int _x;
        public int _y;
        public Race _race;
        private State _state;


        public int Width => _race == Race.TANK ? 100 : 80;
        public int Height => Width;
        public Rectangle Hitbox => new Rectangle(_x - 40, _y - 40, Width, Height);

        //Définit les différentes races d'ennemis qu'il existe
        public enum Race { NORMAL, TANK, ARMORED, SPEEDY};
        //Définit les 2 modes de déplacement de l'ennemis
        enum State { LEFT, RIGHT }; 

        //Constructeur de la classe Ennemis
        public Ennemi( Race race)
        {
            _race = race;
            _state = State.LEFT;
        }

        //Méthode qui permet de lancer les déplacement par rapport au mode de déplacement de l'ennemis
        public void Deplacement()
        {
            if(_state == State.LEFT)
            {
                _x -= Config.ENNEMI_SPEED;
            }
            if(_state == State.RIGHT)
            {
                _x += Config.ENNEMI_SPEED;
            }
        }

        public void Spawn(Squirrel player, List<Ennemi> autres)
        {
            do
            {
                _x = RandomHelpers.Next(Config.TREESPACE_WIDTH);
                _y = RandomHelpers.Next(Config.ZONE_MIN,Config.ZONE_MAX);
            } while (Hitbox.IntersectsWith(player.Hitbox) || autres.Any(e => Hitbox.IntersectsWith(e.Hitbox)));
        }

        //Méthode Update qui permet de mettre à jours les infos de la positions de l'ennemis à chaque frames
        public void Update(int interval, List<Ennemi> autres)
        {
            Deplacement();
            if (_x - Config.ENNEMI_SPEED <= 0 + Width )
            {
                _state = State.RIGHT;
            }

            if (_x + Config.ENNEMI_SPEED >= Config.TREESPACE_WIDTH - 60 )
            {
                _state = State.LEFT;
            }

            if (autres.Any(e => e != this && Hitbox.IntersectsWith(e.Hitbox)))
            {
                if (_state == State.LEFT) _state = State.RIGHT;
                else
                {
                    _state = State.LEFT;
                }
            }
        }

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            if (_race == Race.NORMAL)
            {
                drawingSpace.Graphics.DrawImage(Resources.normal, _x - 40, _y - 40, Width, Height);
            }
            if (_race == Race.SPEEDY)
            {
                drawingSpace.Graphics.DrawImage(Resources.speedy, _x - 40, _y - 40, Width, Height);
            }
            if (_race == Race.TANK)
            {
                drawingSpace.Graphics.DrawImage(Resources.bull, _x - 40, _y - 40, Width, Height);
            }
            if (_race == Race.ARMORED)
            {
                drawingSpace.Graphics.DrawImage(Resources.black11, _x - 40, _y - 40, Width, Height);
            }
        }
    }
}
