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
    public partial class Form4 : Form
    {
        public string ID1;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date;
            if (textBox1.Text == "") // проверка на то что бы  все поля были заполнены  
            {
                MessageBox.Show("Не все поля заполнены, заполните пожалуйста все поля");
                return;
            }
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
            date = dateTime.ToString("yyyy-MM-dd H:mm:ss");
            string Name = textBox1.Text;
            BD db = new BD();
            MySqlCommand command = new MySqlCommand("INSERT INTO `listofnotes`(`id_auth`,`name`,`date`) VALUES (@iduser,@name,@date)", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@iduser", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name; // инцилизация заглушек 
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = date; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                string id = "";
                MySqlCommand command1 = new MySqlCommand("SELECT id FROM listofnotes WHERE `id_auth` = @iduser AND `name` = @name", db.getConnection()); // команда на поиск в MySql
                command1.Parameters.Add("@iduser", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
                command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;// инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader = command1.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data = new List<string[]>();//создание строкового масива
                if (reader.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id = reader[0].ToString(); // считываем строки при каждой интерации
                }
                db.CloseConnection(); // десконек
                MySqlCommand command3 = new MySqlCommand("INSERT INTO `notes`(`id_ListOfNotes`,`text`) VALUES (@idnotes,@text)", db.getConnection()); // команда на добавление в MySql
                command3.Parameters.Add("@idnotes", MySqlDbType.VarChar).Value = id; // инцилизация заглушек 
                command3.Parameters.Add("@text", MySqlDbType.VarChar).Value = richTextBox1.Text; // инцилизация заглушек 
                db.openConnection(); // подключение к бд
                if (command3.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
                {
                    MessageBox.Show("Заметка создана успешно успешно");
                    Close();

                }
                else
                {
                    MessageBox.Show("Заметка не создана");
                    GC.Collect();
                }
            }
            else
            {
                MessageBox.Show("Заметка не создана");
                GC.Collect();
            }

            db.openConnection(); // подключение к бд
            GC.Collect();

        }
    }
}
