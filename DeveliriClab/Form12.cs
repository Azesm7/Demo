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

namespace DeveliriClab
{
    public partial class Form12 : Form
    {
        public string IDcompany;
        public string IDcargo;
        public string Namber;
        public Form12()
        {
            InitializeComponent();
        }


        private void UpdeteCargo()
        {
            string cargo_name = textBox5.Text;
            string addressCargo = textBox7.Text;
            string cargo_quarhtity = textBox6.Text;
            string Data = textBox8.Text; //2022-12-05 10:37:22
            BD db = new BD(); // подключение класса BD
            MySqlCommand command2 = new MySqlCommand("UPDATE cargo SET name_cargo = @namecargo, address = @address, cargo_quarhtity = @cargoquarhtity, data = @data WHERE id = @id; ", db.getConnection()); // команда на добавление в MySql
            command2.Parameters.Add("@id", MySqlDbType.VarChar).Value = IDcargo; // инцилизация заглушек 
            command2.Parameters.Add("@address", MySqlDbType.VarChar).Value = addressCargo; // инцилизация заглушек 
            command2.Parameters.Add("@cargoquarhtity", MySqlDbType.VarChar).Value = cargo_quarhtity; // инцилизация заглушек 
            command2.Parameters.Add("@namecargo", MySqlDbType.VarChar).Value = cargo_name; // инцилизация заглушек 
            command2.Parameters.Add("@data", MySqlDbType.VarChar).Value = Data; // инцилизация заглуш
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

        private void UpdeteCompany()
        {
            string Company_name = textBox1.Text;
            string addressCampany = textBox2.Text;
            string telephoneCompany = textBox3.Text; //2022-12-05 10:37:22
            BD db = new BD(); // подключение класса BD
            MySqlCommand command3 = new MySqlCommand("UPDATE company SET company_name = @company,address = @address, telephone = @telephone WHERE id = @id; ", db.getConnection()); // команда на добавление в MySql
            command3.Parameters.Add("@id", MySqlDbType.VarChar).Value = IDcompany; // инцилизация заглушек 
            command3.Parameters.Add("@address", MySqlDbType.VarChar).Value = addressCampany; // инцилизация заглушек 
            command3.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephoneCompany; // инцилизация заглушек 
            command3.Parameters.Add("@company", MySqlDbType.VarChar).Value = Company_name; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            if (command3.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
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


        private void UpdeteDevili()
        {   string iduser = textBox11.Text;
            string status = textBox9.Text;
            string Data = textBox4.Text; //2022-12-05 10:37:22
            BD db = new BD(); // подключение класса BD
            MySqlCommand command2 = new MySqlCommand("UPDATE deveniry SET  id_user = @iduser, id_company = @idcompany, data = @data, id_cargo = @idcargo, status = @status WHERE number = @number; ", db.getConnection()); // команда на добавление в MySql
            command2.Parameters.Add("@iduser", MySqlDbType.VarChar).Value = iduser; // инцилизация заглушек 
            command2.Parameters.Add("@number", MySqlDbType.VarChar).Value = Namber; // инцилизация заглушек 
            command2.Parameters.Add("@idcompany", MySqlDbType.VarChar).Value = IDcompany; // инцилизация заглушек 
            command2.Parameters.Add("@data", MySqlDbType.VarChar).Value = Data; // инцилизация заглуш
            command2.Parameters.Add("@idcargo", MySqlDbType.VarChar).Value = IDcargo; // инцилизация заглуш
            command2.Parameters.Add("@status", MySqlDbType.VarChar).Value = status; // инцилизация заглуш
            db.openConnection(); // подключение к бд
            if (command2.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
            {
                GC.Collect();
                MessageBox.Show("Новая заметка успешно создана");
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == ""  || textBox11.Text == "")
            {
                return;
            }
            else
            {
                UpdeteCargo();
                UpdeteCompany();
                UpdeteDevili();
                GC.Collect();
                MessageBox.Show("Новая заметка успешно создана");
                this.Close();
            }
        }
    }
}

