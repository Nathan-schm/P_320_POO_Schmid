using Squirrels.Helpers;

namespace Squirrels
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            bool rejouer;
            do
            {
                TreeSpace jeu = CreerPartie();
                Application.Run(jeu);
                rejouer = jeu.Rejouer;
            } while (rejouer);
        }

        // Crée une partie 
        static TreeSpace CreerPartie()
        {
            //Ajoute le joueur dans l'espace de jeu
            Squirrel player = new Squirrel(Config.TREESPACE_WIDTH / 2, 70, 300);

            List<TirJoueur> tirjoueur = new List<TirJoueur>();

            List<TirEnnemi> tirennemi = new List<TirEnnemi>();

            List<Defense> defense = new List<Defense>();
            for (int e = 0; e < 5; e++)
            {
                int centre = Config.TREESPACE_WIDTH / 6 * (e + 1);
                Defense feuille = new Defense(centre - 40, 0, 80);
                defense.Add(feuille);
            }

            //Déclare une nouvelle flotte d'ennemis
            List<Ennemi> enemy = new List<Ennemi>();
            for (int i = 0; i < 2; i++)
            {
                Ennemi normal = new Ennemi(Ennemi.Race.NORMAL, 100);
                normal.Spawn(player, enemy);
                enemy.Add(normal);

                Ennemi speedy = new Ennemi(Ennemi.Race.SPEEDY, 80);
                speedy.Spawn(player, enemy);
                enemy.Add(speedy);

                Ennemi tank = new Ennemi(Ennemi.Race.TANK, 150);
                tank.Spawn(player, enemy);
                enemy.Add(tank);

                Ennemi armor = new Ennemi(Ennemi.Race.ARMORED, 100);
                armor.Spawn(player, enemy);
                enemy.Add(armor);
            }

            return new TreeSpace(player, enemy, tirjoueur, tirennemi, defense);
        }
    }
}