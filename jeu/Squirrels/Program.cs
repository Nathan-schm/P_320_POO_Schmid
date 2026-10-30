namespace Squirrels
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Ajoute le joueur dans l'espace de jeu
            Squirrel player = new Squirrel(Config.TREESPACE_WIDTH/2, 70, 300);

            List<TirJoueur> tirjoueur = new List<TirJoueur>();
            
            List<TirEnnemi> tirennemi = new List<TirEnnemi>();

            //Déclare une nouvelle flotte d'ennemis
            List<Ennemi> enemy = new List<Ennemi>();
            for (int i = 0; i <2 ; i++)
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

            // Démarrage
            Application.Run(new TreeSpace(player,enemy,tirjoueur,tirennemi));
        }
    }
}