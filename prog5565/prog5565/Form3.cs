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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prog5565
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
            DB db = new DB(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("SELECT * FROM notes.notes WHERE id_users = @UN", db.getConnection()); // команда на поиск в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader = command.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data = new List<string[]>();//создание строкового масива
            while (reader.Read()) // если данные ещё имеются то
            {
                data.Add(new string[4]); // добавление новую строку в список 
                data[data.Count - 1][0] = reader[0].ToString(); // считываем строки при каждой интерации
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();

            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
            foreach (string[] s in data) // на каждой интерации будет оперироватся с одним из элементов
                dataGridView1.Rows.Add(s);  // ввывод в dataGridView
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB(); // подключение класса BD
            DataTable table = new DataTable(); // Создание объекта 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // Создание объекта 
            MySqlCommand command = new MySqlCommand("SELECT * FROM notes.notes WHERE `id_users` = @id", db.getConnection()); // команда на проверку в MySql
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            adapter.SelectCommand = command; // указываем какую команду нужно выполнить ,и выполнили 
            adapter.Fill(table); // получаем и записываем в масив данных (в table)
           // dataGridView1 = new DataGridView();
        //    dataGridView1.DataSource = table;
            Form4 form = new Form4();
            form.ID1 = ID1;
            form.ShowDialog();
            GC.Collect();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.ID1 = ID1;
            form.ShowDialog();
            GC.Collect();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LoadData();
        }
    }
}
