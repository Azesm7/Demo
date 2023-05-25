using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DeveliriClab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;// чтение из поля ввода текста имя пользователя
            string Password = textBox2.Text; //  чтение из поля ввода текста пароля
            BD db = new BD(); // подключение класса BD
            DataTable table = new DataTable(); // Создание объекта 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // Создание объекта 
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE `nick` = @UN AND `password` = @Pass", db.getConnection()); // команда на проверку в MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName; // инцилизация заглушек 
            command.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// инцилизация заглушек 
            adapter.SelectCommand = command; // указываем какую команду нужно выполнить ,и выполнили 
            adapter.Fill(table); // получаем и записываем в масив данных (в table)
            if (table.Rows.Count > 0) // проверка сколько есть записей 
            {

                string id = "";
                MySqlCommand command1 = new MySqlCommand("SELECT id FROM users WHERE `nick` = @UN AND `password` = @Pass", db.getConnection()); // команда на поиск в MySql
                command1.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName; // инцилизация заглушек 
                command1.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader = command1.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data = new List<string[]>();//создание строкового масива
                if (reader.Read()) // если данные ещё имеются то
                {
                    data.Add(new string[1]); // добавление новую строку в список 
                    id = reader[0].ToString(); // считываем строки при каждой интерации
                }
                reader.Close(); // закрытие обекта 
                db.CloseConnection(); // десконект

                string Post = "";
                MySqlCommand command2 = new MySqlCommand("SELECT post_name FROM post WHERE `id_user` = @idus", db.getConnection()); // команда на поиск в MySql
                command2.Parameters.Add("@idus", MySqlDbType.VarChar).Value = id; // инцилизация заглушек 
                db.openConnection(); // подключение
                MySqlDataReader reader2 = command2.ExecuteReader(); // создание обекта в ктором будут хранится данные
                List<string[]> data2 = new List<string[]>();//создание строкового масива
                if (reader2.Read()) // если данные ещё имеются то
                {
                    data2.Add(new string[1]); // добавление новую строку в список 
                    Post = reader2[0].ToString(); // считываем строки при каждой интерации
                }
                reader2.Close(); // закрытие обекта 

                if (Post == "Admin")
                {
                    db.CloseConnection(); // десконект
                    this.Hide();
                    MessageBox.Show("авторизация прошла успешно");
                    Form4 form = new Form4();
                    //    form.ID1 = id;
                    form.ShowDialog();
                    GC.Collect();
                    Close();
                }
                else
                {

                    db.CloseConnection(); // десконект
                    this.Hide();
                    MessageBox.Show("авторизация прошла успешно");
                    Form3 form = new Form3();
                    form.ID1 = id;
                    form.ShowDialog();
                    GC.Collect();
                    Close();
                }
            }
            else // если записей нет
            {
                MessageBox.Show("иди от сюда абэмэ");
            }
        }
    }
}