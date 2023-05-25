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

namespace prog5565
{
    public partial class Form2 : Form
    {
        public string ID1;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "") // проверка на то что бы  все поля были заполнены  
            {
                MessageBox.Show("Не все поля заполнены, заполните пожалуйста все поля");
                return; 
            }
            if (isUserExists()) // защита от одинаковых пользователей 
            {
                return;
            }

            string Nick = textBox1.Text;// чтение из поля ввода текста имя пользователя
            string Fio = textBox5.Text; //  чтение из поля ввода текста ФИО
            string PasswordUser = textBox4.Text; //  чтение из поля ввода текста пароля
            string Telephone = textBox2.Text; //  чтение из поля ввода текста Номера телевона 
            DB db = new DB(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`user_name`,`fio`,`password`,`telephone`) VALUES (@Nic,@FIO,@pass,@phone)", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@Nic",MySqlDbType.VarChar).Value = Nick; // инцилизация заглушек 
            command.Parameters.Add("@FIO", MySqlDbType.VarChar).Value = Fio; // инцилизация заглушек 
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PasswordUser; // инцилизация заглушек 
            command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = Telephone; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if(command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                MessageBox.Show("Регистрация прошла успешно");
                GC.Collect();
                this.Close();
            }
            else
            {
                MessageBox.Show("Регистрация не прошла");
                GC.Collect();
            }

            db.CloseConnection();// отключение от бд
            GC.Collect();


        }
       public Boolean isUserExists()
        {
            DB db = new DB(); // подключение класса BD
            DataTable table = new DataTable(); // Создание объекта 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // Создание объекта 
            MySqlCommand command = new MySqlCommand("SELECT * FROM notes.users WHERE `user_name` = @UN AND `telephone` = @tel", db.getConnection()); // команда на проверку в MySql
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
