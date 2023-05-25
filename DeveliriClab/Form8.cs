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
    public partial class Form8 : Form
    {
        public string ID1;
        public Form8()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE id = @UN", db.getConnection()); // команда на поиск в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader = command.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data = new List<string[]>();//создание строкового масива
            while (reader.Read()) // если данные ещё имеются то
            {
                data.Add(new string[5]); // добавление новую строку в список 
                data[data.Count - 1][0] = reader[0].ToString(); // считываем строки при каждой интерации
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString(); // считываем строки при каждой интерации
                data[data.Count - 1][4] = reader[4].ToString();


            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
            foreach (string[] s in data) // на каждой интерации будет оперироватся с одним из элементов
                dataGridView1.Rows.Add(s);  // ввывод в dataGridView
            return;
        }

        private void LoadData2()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command2 = new MySqlCommand("SELECT post_name FROM post WHERE id_user = @UN2", db.getConnection()); // команда на поиск в MySql
            command2.Parameters.Add("@UN2", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader2 = command2.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data2 = new List<string[]>();//создание строкового масива
            while (reader2.Read()) // если данные ещё имеются то
            {
                data2.Add(new string[1]); // добавление новую строку в список 
                data2[data2.Count - 1][0] = reader2[0].ToString(); // считываем строки при каждой интерации

            }
            reader2.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
            foreach (string[] s2 in data2) // на каждой интерации будет оперироватся с одним из элементов
                dataGridView2.Rows.Add(s2);  // ввывод в dataGridView
            return;
        }


        private void Form8_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();

            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            LoadData2();
        }
    }
}
