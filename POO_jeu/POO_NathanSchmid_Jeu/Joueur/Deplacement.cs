using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_NathanSchmid_Jeu.Joueur
{
    internal class Deplacement
    {
        public float posX = 0;
        public char keyChar { get; set; }

        public Deplacement(float posX)
        {
            this.posX = posX;
        }
        
        public void Update()
        {
            
        }

    }
}
