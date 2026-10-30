using Squirrels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrels.Model
{
    public class Defense
    {
        private int _x;
        private int _y;
        public int _pV;

        public Rectangle Hitbox => new Rectangle(_x + 25 , _y +105, 100, 55);

        public Defense(int x, int y, int pV)
        {
            _x = x;
            _y = y;
            _pV = pV;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.feuille, _x, _y +90, 150, 95);
        }
    }
}
