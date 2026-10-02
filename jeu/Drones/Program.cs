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
            int x = 0;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Drone player = new Drone(Config.AIRSPACE_WIDTH/2, 70);

            List<Ennemi> enemy = new List<Ennemi>();
            for (int i = 0; i <3 ; i++)
            {
                enemy.Add(new Ennemi(Config.AIRSPACE_WIDTH /2 +x , Config.AIRSPACE_HEIGHT /2 +x));
                x += 100;
            }

            // Démarrage
            Application.Run(new AirSpace(player,enemy ));
        }
    }
}