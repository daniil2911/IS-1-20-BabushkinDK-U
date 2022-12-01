using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_20_BabushkinDK_U
{
    public partial class Task1 : Form
    {
        public abstract class Complektation<T>
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
                MessageBox.Show($"цена{Price}, год выпуска{Year_of_issue}, артикул{Article}");
            }
        }
        class Harddrives<T>:Complektation<T>
        {
            public int number_of_Turns;
            public string Interface;
            public int volume;

            public Harddrives(int number_of_Turns, string Interface, int Volume, int Price, int Year_of_issue, T Article) : base(Price, Year_of_issue, Article)
            {
                number_of_Turns = number_of_Turns;
                Interface = Interface;
                volume = Volume;
            }
            public void Display()
            {
                MessageBox.Show($"Количество Оборотов{number_of_Turns}, Интерфейс{Interface}, Объем{volume}, цена{Price}, год выпуска{Year_of_issue}, артикул{Article}");
            }
        }
        class Videoscard<T>:Complektation<T>
        {
            public int gpu_frequency;
            public string manufacturer;
            public int memory_size;        
            
            public Videoscard(int Price, int Year_of_issue, T Atricle, int GPU_frequency,string Manufacturer, int Memory_size) : base (Price, Year_of_issue, Atricle)
            {
                gpu_frequency = GPU_frequency;
                manufacturer = Manufacturer;
                memory_size = Memory_size;
            }
            public void Display()
            {
                MessageBox.Show($"цена{Price}, год выпуска{Year_of_issue}, артикул{Article},частота{gpu_frequency}, изготовитель{manufacturer}, Объем памяти{memory_size} гб");
            }
            
        }
        public Task1()
        {
            InitializeComponent();
        }

        private void Task1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                listBox1.Items.Clear();
                listBox1.Items.Add($"Цена {textBox1.Text}");
                listBox1.Items.Add($"Год {textBox2.Text}");
                listBox1.Items.Add($"Артикул {textBox3.Text}");
                listBox1.Items.Add($"Кол-во оборотов {textBox4.Text}");
                listBox1.Items.Add($"Интерфейс {textBox5.Text}");
                listBox1.Items.Add($"Объем {textBox6.Text}");
                Harddrives<int> i1 = new Harddrives<int>(Convert.ToInt32(textBox1.Text), textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
                i1.Display();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.Add($"Цена {textBox1.Text}");
            listBox1.Items.Add($"Год {textBox2.Text}");
            listBox1.Items.Add($"Артикул {textBox3.Text}");
            listBox1.Items.Add($"Частота {textBox7.Text}");
            listBox1.Items.Add($"Производитель {textBox8.Text}");
            listBox1.Items.Add($"Объем памяти {textBox9.Text}");
            Videoscard<int> i1 = new Videoscard<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox7.Text), textBox8.Text, Convert.ToInt32(textBox9.Text));
            i1.Display();
        }
    }
}
