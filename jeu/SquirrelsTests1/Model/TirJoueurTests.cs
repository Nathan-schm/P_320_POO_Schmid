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
    public class TirJoueurTests
    {
        [TestMethod()]
        public void TirJoueur_SeCreeALaPositionDemandee()
        {
            TirJoueur tir = new TirJoueur(100, 200);

            // la hitbox est décalée de 10 pixels vers le haut et la gauche
            Assert.AreEqual(new Rectangle(90, 190, 50, 50), tir.Hitbox);
        }

        [TestMethod()]
        public void Update_FaitDescendreLaNoisetteSansLaDeplacerSurX()
        {
            TirJoueur tir = new TirJoueur(100, 100);
            int xAvant = tir.Hitbox.X;
            int yAvant = tir.Hitbox.Y;

            tir.Update(15);

            Assert.AreEqual(yAvant + 10, tir.Hitbox.Y);   // elle descend de 10
            Assert.AreEqual(xAvant, tir.Hitbox.X);        // pas de déplacement horizontal
        }

        [TestMethod()]
        public void Noisette_ToucheUnEnnemiSeulementSiElleEstSurLui()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.NORMAL, 100);
            ennemi._x = 300;
            ennemi._y = 400;

            TirJoueur dessus = new TirJoueur(300, 400);
            TirJoueur loin = new TirJoueur(50, 50);

            Assert.IsTrue(ennemi.Hitbox.IntersectsWith(dessus.Hitbox));
            Assert.IsFalse(ennemi.Hitbox.IntersectsWith(loin.Hitbox));
        }
    }
}