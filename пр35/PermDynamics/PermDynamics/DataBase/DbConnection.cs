using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PermDynamics
{
    class DbConnection
    {
        readonly static string ConnectionData = "server=localhost;port=3306;database=mydb;uid=root;pwd=root;";

        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();
            return NewMySqlConnection;
        }

        public static MySqlDataReader MySqlQuery(string Query, MySqlConnection connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(Query, connection);
            return NewMySqlCommand.ExecuteReader();
        }
    }
}
