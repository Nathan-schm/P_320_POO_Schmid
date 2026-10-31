using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squirrels.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squirrels.Model.Tests
{
    [TestClass()]
    public class EnnemiTests
    {
        [TestMethod()]
        public void Ennemi_ConserveSaRaceEtSesPointsDeVie()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.TANK, 150);

            Assert.AreEqual(Ennemi.Race.TANK, ennemi._race);
            Assert.AreEqual(150, ennemi._pointDeVie);
        }

        [TestMethod()]
        public void Width_LeTankEstPlusLargeQueLesAutres()
        {
            Ennemi tank = new Ennemi(Ennemi.Race.TANK, 150);
            Ennemi normal = new Ennemi(Ennemi.Race.NORMAL, 100);

            Assert.IsTrue(tank.Width > normal.Width);
        }

        [TestMethod()]
        public void Deplacement_VaVersLaGaucheAuDepart()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.NORMAL, 100);
            ennemi._x = 300;

            ennemi.Deplacement();

            Assert.AreEqual(300 - Config.ENNEMI_SPEED, ennemi._x);
        }

        [TestMethod()]
        public void Update_FaitAvancerL_EnnemiVersLaGauche()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.NORMAL, 100);
            ennemi._x = 300;

            ennemi.Update(15, new List<Ennemi>());

            Assert.AreEqual(300 - Config.ENNEMI_SPEED, ennemi._x);
        }

        [TestMethod()]
        public void Update_RebonditSurLeBordGauche()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.NORMAL, 100);
            List<Ennemi> autres = new List<Ennemi>();
            ennemi._x = 82;                      // tout près du bord gauche

            ennemi.Update(15, autres);           // il touche le bord et change de sens
            int apresLeBord = ennemi._x;

            ennemi.Update(15, autres);           // il repart vers la droite

            Assert.IsTrue(ennemi._x > apresLeBord);
        }

        [TestMethod()]
        public void Throw_CreeUnTirALaPositionDeL_Ennemi()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.SPEEDY, 80);
            ennemi._x = 200;
            ennemi._y = 400;

            TirEnnemi tir = ennemi.Throw();

            Assert.AreEqual(new TirEnnemi(200, 400, Ennemi.Race.SPEEDY).Hitbox, tir.Hitbox);
        }

        [TestMethod()]
        public void PeutTirer_RefuseSiAucunTempsNEstPasse()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.NORMAL, 100);

            Assert.IsFalse(ennemi.PeutTirer(0));
        }

        [TestMethod()]
        public void PeutTirer_AutoriseApresLeDelaiPuisRepartDeZero()
        {
            Ennemi ennemi = new Ennemi(Ennemi.Race.NORMAL, 100);

            Assert.IsTrue(ennemi.PeutTirer(2000));   
            Assert.IsFalse(ennemi.PeutTirer(10));    
        }
    }
}