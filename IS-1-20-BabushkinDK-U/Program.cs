using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_1_20_BabushkinDK_U
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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }

        class СonnectionSQL // Класс
        {
            public MySqlConnection connDD() // скрока поключения
            {
                string connStr = "server=10.90.12.110;port=33333;user=st_1_20_2;database=is_1_20_st2_KURS;password=34354559;";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }
    }
}


