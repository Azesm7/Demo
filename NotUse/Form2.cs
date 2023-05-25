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

namespace NotUse
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ) // проверка на то что бы  все поля были заполнены  
            {
                MessageBox.Show("Не все поля заполнены, заполните пожалуйста все поля");
                return;
            }

            if (isUserExists()) // защита от одинаковых пользователей 
            {
                return;
            }

            string Login = textBox1.Text;
            string Password = textBox2.Text;
            BD db = new BD();
            MySqlCommand command = new MySqlCommand("INSERT INTO `auth`(`Login`,`password`) VALUES (@Nic,@pass)", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@Nic", MySqlDbType.VarChar).Value = Login; // инцилизация заглушек 
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {

                string id = "";
                MySqlCommand command1 = new MySqlCommand("SELECT id FROM auth WHERE `login` = @UN AND `password` = @Pass", db.getConnection()); // команда на поиск в MySql
                command1.Parameters.Add("@UN", MySqlDbType.VarChar).Value = Login; // инцилизация заглушек 
                command1.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader = command1.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data = new List<string[]>();//создание строкового масива
                if (reader.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id = reader[0].ToString(); // считываем строки при каждой интерации
                }
                db.CloseConnection(); // десконект
                MessageBox.Show("Регистрация прошла успешно");
                Close();
            }
            else
            {
                MessageBox.Show("Регистрация не прошла");
                GC.Collect();
            }

            db.openConnection(); // подключение к бд
            GC.Collect();
        }
        public Boolean isUserExists()
        {
            BD db = new BD(); // подключение класса BD
            DataTable table = new DataTable(); // Создание объекта 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // Создание объекта 
            MySqlCommand command = new MySqlCommand("SELECT * FROM auth WHERE `login` = @UN", db.getConnection()); // команда на проверку в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = textBox1.Text; // инцилизация заглушек 
            adapter.SelectCommand = command; // указываем какую команду нужно выполнить ,и выполнили 
            adapter.Fill(table); // получаем и записываем в масив данных (в table)
            if (table.Rows.Count > 0) // проверка сколько есть записей 
            {
                MessageBox.Show("Данный пользователь уже существует");
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
