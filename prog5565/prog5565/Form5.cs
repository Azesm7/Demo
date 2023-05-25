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
    public partial class Form5 : Form
    {
        public string ID1;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NameNotesDelite = textBox1.Text;
            DB db = new DB(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("DELETE FROM `notes` WHERE `name_notes` = @name AND `id_users` = @id", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = ID1; // инцилизация заглушек 
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = NameNotesDelite; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                MessageBox.Show("Заметка успешно удолена");
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
