using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_20_BabushkinDK_U
{
    public partial class Task1 : Form
    {
        abstract class Complektation<T>
        {
            public int Price;
            public int Year_of_issue;
            public T Article;

            public Complektation(int price, int year_of_issue, T article)
            {
                Price = price;
                Year_of_issue = year_of_issue;
                Article = article;
            }
            public void Display()
            {
                MessageBox.Show($"цена{Price}, год выпуска{Year_of_issue}");
            }
        }
        class Hard_drives<T>:Complektation<T>
        {
            public int Number_of_Turns;
            public string Interface;
            public int Volume;

            public Hard_drives(int Number_of_Turns, string Interface, int Volume, int Price, int Year_of_issue) : base(Price, Year_of_issue)
            {
                Number_of_Turns = Number_of_Turns;
                Interface = Interface;
                Volume = Volume;
            }
            public void Display()
            {
                MessageBox.Show($"Количество Оборотов{Number_of_Turns}, Интерфейс{Interface}, Объем{Volume}");
            }
        }
        class Videos_card<T>:Complektation<T>
        {
            public int GPU_frequency;
            public string Manufacturer;
            public int Memory_size;

            public Videos_card()
        }
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_Load(object sender, EventArgs e)
        {

        }
    }
}
