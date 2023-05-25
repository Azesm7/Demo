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
    public partial class Form6 : Form
    {
        public string ID1;
        public Form6()
        {
            InitializeComponent();
        }
        string idNotes;
        private void LoadData()
        {
            string Name = textBox1.Text;
            BD db = new BD(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("SELECT id FROM listofnotes WHERE name = @UN AND id_auth = @IDuser", db.getConnection()); // команда на поиск в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = Name; // инцилизация заглушек 
            command.Parameters.Add("@IDuser", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader = command.ExecuteReader(); // создание обекта в ктором будут хранится данные
            while (reader.Read()) // если данные ещё имеются то
            {
                idNotes = reader[0].ToString(); // считываем строки при каждой интерации
            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
        }

        private void Delite2()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command5 = new MySqlCommand("DELETE FROM notes WHERE id_ListOfNotes = @idas", db.getConnection()); // команда на добавление в MySql
            command5.Parameters.Add("@idas", MySqlDbType.VarChar).Value = idNotes; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command5.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                GC.Collect();
            }
            else
            {
                GC.Collect();
            }

            db.CloseConnection();// отключение от бд
            GC.Collect();
        }

        private void Delite1()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command5 = new MySqlCommand("DELETE FROM listofnotes WHERE id = @idas", db.getConnection()); // команда на добавление в MySql
            command5.Parameters.Add("@idas", MySqlDbType.VarChar).Value = idNotes; // инцилизация заглушек 
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
            LoadData();
            MessageBox.Show(idNotes);
            Delite2();
            Delite1();
            Close();
        }
    }
}
