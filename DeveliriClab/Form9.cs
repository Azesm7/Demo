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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DeveliriClab
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private void Delite()
        {
            BD db = new BD(); // подключение класса BD
            string number = textBox1.Text;
            MySqlCommand command = new MySqlCommand("DELETE FROM deveniry WHERE number = @number", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@number", MySqlDbType.VarChar).Value = number; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                GC.Collect();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                GC.Collect();
            }

            db.CloseConnection();// отключение от бд
            GC.Collect();
        }
        private void Delite2(string id_company)
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command2 = new MySqlCommand("DELETE FROM company WHERE id = @ids", db.getConnection()); // команда на добавление в MySql
            command2.Parameters.Add("@ids", MySqlDbType.VarChar).Value = id_company; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command2.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                GC.Collect();
             
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                GC.Collect();
            }

            db.CloseConnection();// отключение от бд
            GC.Collect();
        }

        private void Delite3(string id_cargo)
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command5 = new MySqlCommand("DELETE FROM cargo WHERE id = @idas", db.getConnection()); // команда на добавление в MySql
            command5.Parameters.Add("@idas", MySqlDbType.VarChar).Value = id_cargo; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command5.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                GC.Collect();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                GC.Collect();
            }

            db.CloseConnection();// отключение от бд
            GC.Collect();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            else
            {
                string id_company = "";
                BD db = new BD(); // подключение класса BD
                MySqlCommand command3 = new MySqlCommand("SELECT id_company FROM deveniry WHERE number = @number", db.getConnection()); // команда на поиск в MySql
                command3.Parameters.Add("@number", MySqlDbType.VarChar).Value = textBox1.Text; // инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader = command3.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data = new List<string[]>();//создание строкового масива
                if (reader.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id_company = reader[0].ToString(); // считываем строки при каждой интерации
                }
                reader.Close(); // закрытие обекта 
                db.CloseConnection(); // десконект


                string id_cargo = "";
                MySqlCommand command4 = new MySqlCommand("SELECT id_cargo FROM deveniry WHERE number = @number", db.getConnection()); // команда на поиск в MySql
                command4.Parameters.Add("@number", MySqlDbType.VarChar).Value = textBox1.Text; // инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader2 = command4.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data2 = new List<string[]>();//создание строкового масива
                if (reader2.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id_cargo = reader2[0].ToString(); // считываем строки при каждой интерации
                }
                reader2.Close(); // закрытие обекта 
                db.CloseConnection(); // десконект

                Delite();
                Delite2(id_company);
                Delite3(id_cargo);
                MessageBox.Show("Заметка успешно удолена");
                GC.Collect();
                this.Close();
            }
        }
    }
}
