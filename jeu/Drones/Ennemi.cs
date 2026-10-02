using Drones.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    public class Ennemi
    {
        public int _x;
        public int _y;
        private State _state;

        enum State { LEFT, RIGHT }; 

        public Ennemi(int x, int y)
        {
            _x = x;
            _y = y;
            _state = State.LEFT;
        }

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

        public void Update(int interval)
        {
            Deplacement();
            if (_x - Config.ENNEMI_SPEED <= 0 +10)
            {
                _state = State.RIGHT;
            }

            if (_x + Config.ENNEMI_SPEED >= Config.AIRSPACE_WIDTH -60)
            {
                _state = State.LEFT;
            }


        }

        // De manière graphique
        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.normal, _x -40, _y -40, 120, 120);
        }
    }
}
