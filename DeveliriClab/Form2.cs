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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DeveliriClab
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "") // проверка на то что бы  все поля были заполнены  
            {
                MessageBox.Show("Не все поля заполнены, заполните пожалуйста все поля");
                return;
            }

            if (isUserExists()) // защита от одинаковых пользователей 
            {
                return;
            }

            string Fio = textBox1.Text;
            string Nick = textBox2.Text;
            string Password = textBox3.Text;
            string phone = textBox4.Text;
            string Post = comboBox1.Text;
            BD db = new BD();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`fio`,`nick`,`password`,`talephone`) VALUES (@FIO,@Nic,@pass,@phone)", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@Nic", MySqlDbType.VarChar).Value = Nick; // инцилизация заглушек 
            command.Parameters.Add("@FIO", MySqlDbType.VarChar).Value = Fio; // инцилизация заглушек 
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password; // инцилизация заглушек 
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {

                string id = "";
                MySqlCommand command1 = new MySqlCommand("SELECT id FROM users WHERE `nick` = @UN AND `password` = @Pass", db.getConnection()); // команда на поиск в MySql
                command1.Parameters.Add("@UN", MySqlDbType.VarChar).Value = textBox2.Text; // инцилизация заглушек 
                command1.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = textBox3.Text;// инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader = command1.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data = new List<string[]>();//создание строкового масива
                if (reader.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id = reader[0].ToString(); // считываем строки при каждой интерации
                }
                db.CloseConnection(); // десконект

                MySqlCommand command2 = new MySqlCommand("INSERT INTO `post`(`id_user`,`post_name`) VALUES (@id,@pos)", db.getConnection()); // команда на добавление в MySql
                command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = id; // инцилизация заглушек 
                command2.Parameters.Add("@pos", MySqlDbType.VarChar).Value = Post; // инцилизация заглушек 
                db.openConnection(); // подключение к бд
                if (command2.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
                {
                    reader.Close(); // закрытие обекта 
                    MessageBox.Show(id);
                    MessageBox.Show("Регистрация прошла успешно");
                    GC.Collect();
                    this.Close();
                    db.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Регистрация не прошла");
                    GC.Collect();
                }
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
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE `nick` = @UN AND `talephone` = @tel", db.getConnection()); // команда на проверку в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = textBox1.Text; // инцилизация заглушек 
            command.Parameters.Add("@tel", MySqlDbType.VarChar).Value = textBox2.Text;// инцилизация заглушек 
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
