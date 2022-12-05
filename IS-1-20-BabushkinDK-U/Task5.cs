using ConnectDB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ConnectDB.Class1;

namespace IS_1_20_BabushkinDK_U
{
    public partial class Task5 : Form
    {
        MySqlConnection conn;
        Class1 connect;
        public Task5()
        {
            InitializeComponent();
        }

        private void Task5_Load(object sender, EventArgs e)
        {
            connect = new Class1();
            connect.Connectreturn();
            conn = new MySqlConnection(connect.connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string fioStud = textBox1.Text;
                string datetimeStud = textBox2.Text;
                conn.Open();
                string sql = $"INSERT INTO t_Uchebka_Babsuhkin(fioStud, datetimeStud) " +
                    $"VALUES ('{fioStud}', '{String.Format("{0:s}", datetimeStud)}');" +
                    $"SELECT idStud FROM t_Uchebka_Babsuhkin WHERE(idStud = LAST_INSERT_ID());";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteScalar();
                MessageBox.Show("введены данные");               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
