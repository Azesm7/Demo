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
    public partial class Form5 : Form
    {
        public string ID1;
        public string Name;
        public Form5()
        {
            InitializeComponent();
        }
        string idNotes;
        string strNotes;
        private void LoadData()
        {
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

        private void LoadData2()
        {
            BD db = new BD(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("SELECT text FROM notes WHERE id_ListOfNotes = @UN", db.getConnection()); // команда на поиск в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = idNotes; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader = command.ExecuteReader(); // создание обекта в ктором будут хранится данные

            while (reader.Read()) // если данные ещё имеются то
            {
                strNotes = reader[0].ToString(); // считываем строки при каждой интерации
            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = Name;
            LoadData();
            LoadData2();
            richTextBox1.Text = strNotes;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Text = richTextBox1.Text;
            BD db = new BD();
            MySqlCommand command = new MySqlCommand("UPDATE notes SET text = @text WHERE id_ListOfNotes = @UN ", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@text", MySqlDbType.VarChar).Value = Text; // инцилизация заглушек 
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = idNotes; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                MessageBox.Show("Текст изменён");
            }
        }
    }
}
