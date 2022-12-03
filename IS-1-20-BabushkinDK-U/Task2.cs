using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace IS_1_20_BabushkinDK_U
{
    public partial class Task2 : Form
    {
        class СonnectionSQL // Класс
        {
            public MySqlConnection connDD() // скрока поключения
            {
                string host = "10.90.12.110";
                string port = "33333";
                string user = "uchebka";
                string dd = "uchebka";
                string password = "uchebka";
                string connStr = $"server={host};port={port};user={user};database={dd};password={password};";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }
        public Task2()
        {
            InitializeComponent();
        }

        private void Task2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            СonnectionSQL connectiondd = new СonnectionSQL(); // экземпляр класса 
            try
            {
                connectiondd.connDD().Open(); // открывается соеднинение
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            finally
            {
                MessageBox.Show("ЕЕЕЕЕЕ ВСЕ НОРМ!!!!!!!"); // Если все норм выводит это сообщение 
                connectiondd.connDD().Close(); // закрывается соедниение 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
