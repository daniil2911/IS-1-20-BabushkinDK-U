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
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        string id_selected_rows = "0";
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
