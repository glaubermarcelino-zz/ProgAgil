using System;
using System.Windows.Forms;

namespace Licenciamento.forms
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmSplash splash = new frmSplash();
            Application.Run(splash);
            switch (splash.Limberado)
            {
                case 1:
                    Application.Run(new frmTelaVencida());
                    break;
                case 2:
                    Application.Run(new frmPrincipal());
                    break;
                case 3:
                    Application.Run(new frmTelaBloqueio());
                    break;
                default:
                    break;
            }       
        }
    }
}
