using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Server
{
    class DBConnect
    {
        readonly static string ConnectionData = "server=localhost;port=3306;database=mydb;uid=root;pwd=root;";

        public static MySqlConnection Open()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();
            return NewMySqlConnection;
        }

    }
}
