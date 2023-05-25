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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD db = new BD(); // подключение класса BD
            string number = textBox1.Text;
            string idcompany = "";
            string idcargo = "";
            MySqlCommand command1 = new MySqlCommand("SELECT id_company, id_cargo FROM deveniry WHERE `number` = @UN", db.getConnection()); // команда на поиск в MySql
            command1.Parameters.Add("@UN", MySqlDbType.VarChar).Value = number; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader = command1.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data = new List<string[]>();//создание строкового масива
            if (reader.Read()) // если данные ещё имеются то
            {
                data.Add(new string[2]); // добавление новую строку в список 
                idcompany = reader[0].ToString(); // считываем строки при каждой интерации
                idcargo = reader[1].ToString(); // считываем строки при каждой интерации
            }
            reader.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект
            db.CloseConnection(); // десконект
            this.Hide();
            Form6 form = new Form6();
            form.IDcompany = idcompany;
            form.IDcargo = idcargo;
            form.ShowDialog();
            GC.Collect();
            Close();
        }
    }
}
