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
            
            string sql = "SELECT * FROM T_datatime";
            try
            {
                conn.Open();
                MySqlDataAdapter IDataAdapter = new MySqlDataAdapter(sql, conn);
                DataSet ds2 = new DataSet();
                IDataAdapter.Fill(ds2);
                dataGridView1.DataSource = ds2.Tables[0];
            }
            finally
            {
                conn.Close();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          try
            {
                int id = dataGridView1.SelectedCells[0].RowIndex +1;
                conn.Open();
                string sql = $"SELECT photoUrl FROM T_datatime WHERE Id = {id}";
                MySqlCommand command = new MySqlCommand(sql, conn);
                string picture = command.ExecuteScalar().ToString();
                pictureBox1.ImageLocation = picture;
            }
           finally
            {
                conn.Close();
            }
        }
    }
}
