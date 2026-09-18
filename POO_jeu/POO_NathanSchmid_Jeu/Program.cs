using POO_NathanSchmid_Jeu.Joueur;
using POO_NathanSchmid_Jeu.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO_NathanSchmid_Jeu
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Personnage joueur = new Personnage(config.GAMESPACE_WIDTH / 2, config.GAMESPACE_HEIGHT / 2);


            Application.Run(new GameSpace());
        }
    }
}
