using Squirrels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrels.Model
{
    public class TirJoueur
    {
        private int _x;
        private int _y;

        public Rectangle Hitbox => new Rectangle(_x , _y , 30, 30);

        public TirJoueur(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.noisette, _x -10, _y -10, 50, 50);
        }

        public void Update(int interval)
        {
            _y+=10;
        }
    }
}
