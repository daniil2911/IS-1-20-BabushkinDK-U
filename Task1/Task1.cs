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
        public abstract class Complektation<T> // Абстракный класс Коплектующие обобщенный 
        {
            public int Price;
            public int Year_of_issue;
            public T Article;

            public Complektation(int price, int year_of_issue, T article) // конструктор Коплектующих
            {
                this.Price = price;
                this.Year_of_issue = year_of_issue;
                this.Article = article;
            }
            public void Display() // метод дисплей
            {
                MessageBox.Show($"цена{Price}, год выпуска{Year_of_issue}, артикул{Article}");
            }
        }
        class Harddrives<T> : Complektation<T> // Класс Жесткий диск наследует Коплектующие
        {
            public int number_of_Turns;
            public string Interface;
            public int volume;

            public Harddrives(int number_of_Turns, string Interface, int Volume, int Price, int Year_of_issue, T Article) : base(Price, Year_of_issue, Article) // конструктор Жеского диска
            {
                this.number_of_Turns = number_of_Turns;
                this.Interface = Interface;
                this.volume = Volume;
            }
            public void newDisplay() // метод дисплей
            {
                MessageBox.Show($"Количество Оборотов{number_of_Turns}, Интерфейс{Interface}, Объем{volume}, цена{Price}, год выпуска{Year_of_issue}, артикул{Article}");
            }
        }
        class Videoscard<T> : Complektation<T> // Класс видеократы наследует Коплектующие
        {
            public int gpu_frequency { get; set; }
            public string manufacturer { get; set; }
            public int memory_size { get; set; }

            public Videoscard(int Price, int Year_of_issue, T Atricle, int GPU_frequency, string Manufacturer, int Memory_size) : base(Price, Year_of_issue, Atricle) // конструктор Видеокарты
            {
                this.gpu_frequency = GPU_frequency;
                this.manufacturer = Manufacturer;
                this.memory_size = Memory_size;
            }
            public void newDisplay() // метод дисплей
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
            Harddrives<int> i1 = new Harddrives<int>(Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
