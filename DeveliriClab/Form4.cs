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

namespace DeveliriClab
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("SELECT * FROM deveniry", db.getConnection()); // команда на поиск в MySql
            db.openConnection(); // подключение
            MySqlDataReader reader = command.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data = new List<string[]>();//создание строкового масива
            while (reader.Read()) // если данные ещё имеются то
            {
                data.Add(new string[6]); // добавление новую строку в список 
                data[data.Count - 1][0] = reader[0].ToString(); // считываем строки при каждой интерации
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString(); // считываем строки при каждой интерации
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();


            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
            foreach (string[] s in data) // на каждой интерации будет оперироватся с одним из элементов
                dataGridView1.Rows.Add(s);  // ввывод в dataGridView
            return;
        }
        private void Form4_Load_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                LoadData();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
            GC.Collect();
        }

        private void infoUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
            GC.Collect();
        }

        private void deliteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form9 form = new Form9();
            form.Show();
            GC.Collect();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form10 form = new Form10();
            form.Show();
            GC.Collect();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 form = new Form11();
            form.Show();
            GC.Collect();
        }

    }
}
