using System;
using System.Windows.Forms;

namespace EvoApp
{
    static class Program
    {
        public static EvoAppForm appForm = null;
        public static App app = new App();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            appForm = new EvoAppForm();
            Application.Run(appForm);
        }
    }
}
