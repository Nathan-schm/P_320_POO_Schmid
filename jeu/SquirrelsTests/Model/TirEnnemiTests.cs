using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squirrels.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrels.Model.Tests
{
    [TestClass()]
    public class TirEnnemiTests
    {
        [TestMethod()]
        public void TirEnnemi_SeCreeALaPositionDemandee()
        {
            TirEnnemi tir = new TirEnnemi(100, 200, Ennemi.Race.NORMAL);

            // la hitbox est décalée de 10 pixels vers le haut et la gauche
            Assert.AreEqual(new Rectangle(90, 190, 50, 100), tir.Hitbox);
        }

        [TestMethod()]
        public void Degats_LeTirDuSpeedyFaitPlusMalQueLeTirNormal()
        {
            TirEnnemi normal = new TirEnnemi(0, 0, Ennemi.Race.NORMAL);
            TirEnnemi speedy = new TirEnnemi(0, 0, Ennemi.Race.SPEEDY);

            Assert.IsTrue(speedy.Degats > normal.Degats);
        }

        [TestMethod()]
        public void Update_FaitMonterLeTirSansLeDeplacerSurX()
        {
            TirEnnemi tir = new TirEnnemi(100, 500, Ennemi.Race.NORMAL);
            int xAvant = tir.Hitbox.X;
            int yAvant = tir.Hitbox.Y;

            tir.Update(15);

            Assert.AreEqual(yAvant - 7, tir.Hitbox.Y);   // il monte de 7
            Assert.AreEqual(xAvant, tir.Hitbox.X);       // pas de déplacement horizontal
        }

        [TestMethod()]
        public void Update_LeTirDuSpeedyMonteePlusVite()
        {
            TirEnnemi normal = new TirEnnemi(100, 500, Ennemi.Race.NORMAL);
            TirEnnemi speedy = new TirEnnemi(100, 500, Ennemi.Race.SPEEDY);

            normal.Update(15);
            speedy.Update(15);

            Assert.IsTrue(speedy.Hitbox.Y < normal.Hitbox.Y);   // plus petit Y = plus haut
        }

        [TestMethod()]
        public void Tir_ToucheLeJoueurSeulementSiIlEstSurLui()
        {
            Squirrel joueur = new Squirrel(300, 70, 300);

            TirEnnemi dessus = new TirEnnemi(300, 70, Ennemi.Race.NORMAL);
            TirEnnemi loin = new TirEnnemi(600, 700, Ennemi.Race.NORMAL);

            Assert.IsTrue(joueur.Hitbox.IntersectsWith(dessus.Hitbox));
            Assert.IsFalse(joueur.Hitbox.IntersectsWith(loin.Hitbox));
        }
    }
}