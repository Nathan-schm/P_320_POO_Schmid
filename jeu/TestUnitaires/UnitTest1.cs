using Squirrels;

namespace TestUnitaires
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PeutLancer_RefuseTantQueLeDelaiNEstPasPasse()
        {
            Squirrel joueur = new Squirrel(300, 70, 300);

            Assert.IsTrue(joueur.PeutLancer());     // premier lancer autorisé
            Assert.IsFalse(joueur.PeutLancer());    // trop tôt, refusé

            joueur.Update(Config.PLAYER_DELAI_TIR); // le temps passe
            Assert.IsTrue(joueur.PeutLancer());     // de nouveau autorisé
        }

        [TestMethod]
        public void Deplacement_GaucheEtDroite_ChangeXDeLaVitesse()
        {
            Squirrel joueur = new Squirrel(300, 70, 300);

            joueur.DirectionLeft();
            Assert.AreEqual(300 - Config.PLAYER_SPEED, joueur._x);

            joueur.DirectionRight();
            joueur.DirectionRight();
            Assert.AreEqual(300 + Config.PLAYER_SPEED, joueur._x);
        }

        [TestMethod]
        public void DirectionLeft_NeSortPasDeLEcranAGauche()
        {
            Squirrel joueur = new Squirrel(300, 70, 300);
            joueur._x = 100;                         // près du bord gauche

            joueur.DirectionLeft();

            Assert.AreEqual(100, joueur._x);         // il n'a pas bougé
        }

        [TestMethod]
        public void DirectionRight_NeSortPasDeLEcranADroite()
        {
            Squirrel joueur = new Squirrel(300, 70, 300);
            int limite = Config.TREESPACE_WIDTH - Config.PLAYER_WIDTH / 2;
            joueur._x = limite;                      // contre le bord droit

            joueur.DirectionRight();

            Assert.AreEqual(limite, joueur._x);
        }

        [TestMethod]
        public void Throw_CreeUneNoisetteALaPositionDuJoueur()
        {
            Squirrel joueur = new Squirrel(300, 70, 300);

            TirJoueur tir = joueur.Throw();

            Assert.AreEqual(new TirJoueur(joueur._x, joueur._y).Hitbox, tir.Hitbox);
        }
    }
}
