using Squirrels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrels
{
    public class TirJoueur
    {
        private int _x;
        private int _y;

        public TirJoueur(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            drawingSpace.Graphics.DrawImage(Resources.noisette, _x -10, _y -10, 20, 20);
        }

        public void Update(int interval)
        {
            _y++;
        }
    }
}
