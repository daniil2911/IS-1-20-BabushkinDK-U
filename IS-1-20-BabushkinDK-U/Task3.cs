using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using MySql.Data.MySqlClient;
using static ConnectDB.Class1;

namespace IS_1_20_BabushkinDK_U
{
    public partial class Task3 : Form
    {
        MySqlConnection conn;
        Class1 connect;
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_2;database=is_1_20_st2_KURS;password=34354559;";
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_2;database=is_1_20_st2_KURS;password=34354559;";
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();

        public Task3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sql = "SELECT id_Clients, fio_Clients, pasport_Clients, id_empl, fio_empl, phone_empl, email_empl, passport_empl FROM T_Clients INNER JOIN T_Empl ON id_Clients = id_empl";
                dataGridView1.Columns.Add("id_Clients", "ид Клиента");
                dataGridView1.Columns["id_Clients"].Width = 150;

                dataGridView1.Columns.Add("fio_Clients", "фио Клиента");
                dataGridView1.Columns["fio_Clients"].Width = 150;

                dataGridView1.Columns.Add("pasport_Clients", "паспорт Клиента");
                dataGridView1.Columns["pasport_Clients"].Width = 150;

                dataGridView1.Columns.Add("id_empl", "ид Сотрудника");
                dataGridView1.Columns["id_empl"].Width = 150;

                dataGridView1.Columns.Add("fio_empl", "фио Сотрудника");
                dataGridView1.Columns["fio_empl"].Width = 150;

                dataGridView1.Columns.Add("phone_empl", " телефон сотрудника");
                dataGridView1.Columns["phone_empl"].Width = 150;

                dataGridView1.Columns.Add("email_empl", "почта Сотрудника");
                dataGridView1.Columns["email_empl"].Width = 150;

                dataGridView1.Columns.Add("passport_empl", "паспорт Сотрудника");
                dataGridView1.Columns["passport_empl"].Width = 150;

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_Clients"].ToString(), reader["fio_Clients"].ToString(), reader["pasport_Clients"].ToString(), reader["id_empl"].ToString(),
                        reader["fio_empl"].ToString(), reader["phone_empl"].ToString(), reader["email_empl"].ToString(), reader["passport_empl"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Text, ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void Task3_Load(object sender, EventArgs e)
        {
            connect = new Class1();
            connect.Connectreturn();
            conn = new MySqlConnection(connect.connStr);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
