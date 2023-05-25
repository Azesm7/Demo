using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DeveliriClab
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void Company()
        {
            string company_name = textBox1.Text;
            string addrescompani = textBox2.Text;
            string telephone = textBox3.Text;
            BD db = new BD(); // подключение класса BD
            MySqlCommand command = new MySqlCommand("INSERT INTO company (`company_name`,`address`,`telephone`) VALUES (@company,@address,@telephone)", db.getConnection()); // команда на добавление в MySql
            command.Parameters.Add("@address", MySqlDbType.VarChar).Value = addrescompani; // инцилизация заглушек 
            command.Parameters.Add("@telephone", MySqlDbType.VarChar).Value = telephone; // инцилизация заглушек 
            command.Parameters.Add("@company", MySqlDbType.VarChar).Value = company_name; // инцилизация заглушек 
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

        private void Cargo()
        {
            string cargo_name = textBox4.Text;
            string addressCargo = textBox7.Text;
            string cargo_quarhtity = textBox5.Text;
            string Data = textBox6.Text; //2022-12-05 10:37:22
            BD db = new BD(); // подключение класса BD
            MySqlCommand command2 = new MySqlCommand("INSERT INTO cargo (`name_cargo`,`address`,`cargo_quarhtity`,`data`) VALUES (@namecargo,@address,@cargoquarhtity,@data)", db.getConnection()); // команда на добавление в MySql
            command2.Parameters.Add("@address", MySqlDbType.VarChar).Value = addressCargo; // инцилизация заглушек 
            command2.Parameters.Add("@cargoquarhtity", MySqlDbType.VarChar).Value = cargo_quarhtity; // инцилизация заглушек 
            command2.Parameters.Add("@namecargo", MySqlDbType.VarChar).Value = cargo_name; // инцилизация заглушек 
            command2.Parameters.Add("@data", MySqlDbType.VarChar).Value = Data; // инцилизация заглушек 
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

        private void delivery()
        {
            BD db = new BD(); // подключение класса BD

            string idcompany = "";
            MySqlCommand command3 = new MySqlCommand("SELECT id FROM company WHERE company_name = @UN", db.getConnection()); // команда на поиск в MySql
            command3.Parameters.Add("@UN", MySqlDbType.VarChar).Value = textBox1.Text; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader3 = command3.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data3 = new List<string[]>();//создание строкового масива
            if (reader3.Read()) // если данные ещё имеются то
            {
                data3.Add(new string[1]); // добавление новую строку в список 
                idcompany = reader3[0].ToString(); // считываем строки при каждой интерации
            }
            reader3.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект



            string idcargo = "";
            MySqlCommand command4 = new MySqlCommand("SELECT id FROM cargo WHERE name_cargo = @UN", db.getConnection()); // команда на поиск в MySql
            command4.Parameters.Add("@UN", MySqlDbType.VarChar).Value = textBox4.Text; // инцилизация заглушек 
            db.openConnection(); // подключение
            MySqlDataReader reader4 = command4.ExecuteReader(); // создание обекта в ктором будут хранится данные
            List<string[]> data4 = new List<string[]>();//создание строкового масива
            if (reader4.Read()) // если данные ещё имеются то
            {
                data4.Add(new string[1]); // добавление новую строку в список 
                idcargo = reader4[0].ToString(); // считываем строки при каждой интерации
            }
            reader4.Close(); // закрытие обекта 
            db.CloseConnection(); // десконект


            string number = textBox8.Text;
            string datadevileri = textBox10.Text;
            string status = textBox9.Text;
            string IDUser = textBox11.Text;
            MySqlCommand command5 = new MySqlCommand("INSERT INTO deveniry (`number`,`id_user`,`id_company`,`data`,`id_cargo`,`status`) VALUES (@num,@iduser,@idcompany,@data,@idcargo,@status)", db.getConnection()); // команда на добавление в MySql
            command5.Parameters.Add("@num", MySqlDbType.VarChar).Value = number; // инцилизация заглушек 
            command5.Parameters.Add("@iduser", MySqlDbType.VarChar).Value = IDUser; // инцилизация заглушек 
            command5.Parameters.Add("@data", MySqlDbType.VarChar).Value = datadevileri; // инцилизация заглушек 
            command5.Parameters.Add("@idcargo", MySqlDbType.VarChar).Value = idcargo; // инцилизация заглушек 
            command5.Parameters.Add("@status", MySqlDbType.VarChar).Value = status; // инцилизация заглушек 
            command5.Parameters.Add("@idcompany", MySqlDbType.VarChar).Value = idcompany; // инцилизация заглушек 
            db.openConnection(); // подключение к бд
            MessageBox.Show(idcompany);
            MessageBox.Show(idcargo);
            if (command5.ExecuteNonQuery() == 1) // выполнили MySql команду и происходит проверка на успешность выполнения команды 
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                return;
            }
            else
            {
                Company();
                Cargo();
                delivery();

            }
        }
    }
}
