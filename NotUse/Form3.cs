using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotUse
{
    public partial class Form3 : Form
    {
        public string ID1;
        public Form3()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("SELECT name, date FROM listofnotes WHERE id_auth = @UN", db.getConnection()); // команда на поиск в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader = command.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data = new List<string[]>();//создание строкового масива
            while (reader.Read()) // если данные ещё имеются то
            {
                data.Add(new string[2]); // добавление новую строку в список 
                data[data.Count - 1][0] = reader[0].ToString(); // считываем строки при каждой интерации
                data[data.Count - 1][1] = reader[1].ToString(); // считываем строки при каждой интерации
            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
            foreach (string[] s in data) // на каждой интерации будет оперироватся с одним из элементов
                dataGridView1.Rows.Add(s);  // ввывод в dataGridView
            return;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ID1 = ID1;
            form.ShowDialog();
            GC.Collect();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str;
            str = dataGridView1.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            Form5 form = new Form5();
            form.Name = str ;
            form.ID1 = ID1;
            form.ShowDialog();
            GC.Collect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.ID1 = ID1;
            form.ShowDialog();
            GC.Collect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();
        }
    }
}

