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

namespace NotUse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;// чтение из поля ввода текста имя пользователя
            string Password = textBox2.Text; //  чтение из поля ввода текста пароля
            BD db = new BD(); // подключение класса BD
            DataTable table = new DataTable(); // Создание объекта 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // Создание объекта 
            MySqlCommand command = new MySqlCommand("SELECT * FROM auth WHERE `login` = @UN AND `password` = @Pass", db.getConnection()); // команда на проверку в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName; // инцилизация заглушек 
            command.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// инцилизация заглушек 
            adapter.SelectCommand = command; // указываем какую команду нужно выполнить ,и выполнили 
            adapter.Fill(table); // получаем и записываем в масив данных (в table)
            if (table.Rows.Count > 0) // проверка сколько есть записей 
            {

                string id = "";
                MySqlCommand command1 = new MySqlCommand("SELECT id FROM auth WHERE `login` = @UN AND `password` = @Pass", db.getConnection()); // команда на поиск в MySql
                command1.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName; // инцилизация заглушек 
                command1.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader = command1.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data = new List<string[]>();//создание строкового масива
                if (reader.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id = reader[0].ToString(); // считываем строки при каждой интерации
                }
                reader.Close(); // закрытие обекта 
                db.CloseConnection(); // десконект


                    db.CloseConnection(); // десконект
                    this.Hide();
                    MessageBox.Show("авторизация прошла успешно");
                   Form3 form = new Form3();
                  form.ID1 = id;
                   form.ShowDialog();
                    GC.Collect();
                    Close();
            }
            else // если записей нет
            {
                MessageBox.Show("Данные введены неправельно");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            //  form.ID1 = id;
            form.ShowDialog();
            GC.Collect();
            //Close();
        }
    }
}
