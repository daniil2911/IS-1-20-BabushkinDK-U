using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using MySql.Data.MySqlClient;
using static ConnectDB.Class1;

namespace IS_1_20_BabushkinDK_U
{
    public partial class Task4 : Form
    {
        MySqlConnection conn;
        Class1 connect;
        public Task4()
        {
            InitializeComponent();
        }

        private void Task4_Load(object sender, EventArgs e)
        {
            connect = new Class1();
            connect.Connectreturn();
            conn = new MySqlConnection(connect.connStr);
            try
            {
                conn.Open();
                string sql = "SELECT * FROM t_datatime";
                dataGridView1.Columns.Add("fio", "ФИО");
                dataGridView1.Columns["fio"].Width = 140;
                dataGridView1.Columns.Add("date_of_Birth", "Дата.рож-я");
                dataGridView1.Columns["date_of_Birth"].Width = 140;
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["fio"].ToString(), reader["date_of_Birth"].ToString());
                }
                reader.Close();
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
    }
}
