using Squirrels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrels.Model
{
    public class TirEnnemi
    {
        private int _x;
        private int _y;
        private Ennemi.Race _race;
        public int Degats => _race == Ennemi.Race.SPEEDY ? 50 : 25;

        public Rectangle Hitbox => new Rectangle(_x +2, _y , 15, 75);

        public TirEnnemi(int x, int y, Ennemi.Race race)
        {
            _x = x;
            _y = y;
            _race = race;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            Image image = _race == Ennemi.Race.SPEEDY ? Resources.TirSpeedy : Resources.tirsennemi;
            drawingSpace.Graphics.DrawImage(image, _x - 10, _y - 10, 50, 100);
        }

        public void Update(int interval)
        {
            _y -= _race == Ennemi.Race.SPEEDY ? 13 : 7;
        }
    }
}
