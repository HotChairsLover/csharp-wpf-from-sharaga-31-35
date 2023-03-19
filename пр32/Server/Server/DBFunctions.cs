using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Server
{
    class DBFunctions
    {
        public static void UploadMessage(string message)
        {
            MySqlConnection connection = DBConnect.Open();
            string sqlQuery = $"INSERT INTO `mydb`.`messages`(`text`) VALUES ('{message}');";
            MySqlCommand command = new MySqlCommand(sqlQuery, connection);
            command.ExecuteReader();
            connection.Close();
        }
    }
}
