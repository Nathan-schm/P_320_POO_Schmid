namespace Drones
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
            Drone player = new Drone(Config.AIRSPACE_WIDTH/2, 70);

            //Déclare une nouvelle flotte d'ennemis
            List<Ennemi> enemy = new List<Ennemi>();
            for (int i = 0; i <2 ; i++)
            {
                enemy.Add(new Ennemi(Ennemi.Race.NORMAL));                
                enemy.Add(new Ennemi(Ennemi.Race.SPEEDY));
                enemy.Add(new Ennemi(Ennemi.Race.ARMORED));
                enemy.Add(new Ennemi(Ennemi.Race.TANK));
            }

            // Démarrage
            Application.Run(new AirSpace(player,enemy ));
        }
    }
}