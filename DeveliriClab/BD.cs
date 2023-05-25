using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DeveliriClab
{
    internal class BD
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=Roman1125./;database=pr4"); // подключение к бд
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open(); // открытие соединения
            }
        }
        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close(); //Закрытие соединения
            }
        }
        public MySqlConnection getConnection()
        {
            return connection; // возрат соединения
        }
    }
}
