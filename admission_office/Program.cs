using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admission_office
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault( false );
            
            var authorizeForm = new Form1();
            authorizeForm.ShowDialog();
            Application.Run();
            //Application.Run( new Form1() );
            //Application.EnableVisualStyles();
            //Application.Run( new Form2() );
        }
    }
}
