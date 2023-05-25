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
    public partial class Form4 : Form
    {
        public string ID1;
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NameNotes = textBox1.Text;
            string Text = richTextBox1.Text;
            DB db = new DB(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("INSERT INTO `notes`(`id_users`,`name_notes`,`text_notes`) VALUES (@id,@name,@txt)", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameNotes; // инцилизация заглушек 
            command.Parameters.Add("@txt", MySqlDbType.VarChar).Value = Text; // инцилизация заглушек 
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                MessageBox.Show("Новая заметка успешно создана");
                GC.Collect();
                this.Close();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");
                GC.Collect();
            }

            db.CloseConnection();// отключение от бд
            GC.Collect();
        }
    }
}
