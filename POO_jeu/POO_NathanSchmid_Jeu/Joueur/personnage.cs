using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_NathanSchmid_Jeu.Joueur
{
    internal class Personnage
    {
        private int _x;
        private int _y;

        public Personnage(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void Render(BufferedGraphics drawingSpace)
        {
            Image newImage = Image.FromFile("squirrel.png");

            float width = 600;
            float height = 300;

            drawingSpace.Graphics.DrawImage(newImage, width, height);
        }

    }
}
