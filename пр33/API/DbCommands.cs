using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace API
{
    class DbCommands
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
        //Проверяет создана ли таблица группы
        private bool GroupCreated(string group)
        {
            MySqlConnection connection = MySqlOpen();
            string trasliteGroup = Translit.TranslitString(group);
            string query = $"SELECT EXISTS (SELECT TABLE_NAME FROM information_schema.TABLES " +
                $"WHERE TABLE_SCHEMA LIKE '{connection.Database}' AND TABLE_TYPE LIKE 'BASE TABLE' AND TABLE_NAME = '{trasliteGroup}'); ";
            MySqlDataReader reader = MySqlQuery(query, connection);
            if (reader.HasRows)
            {
                reader.Read();
                if(reader.GetString(0) == "1")
                {
                    connection.Close();
                    return true;
                }
            }
            connection.Close();
            return false;
        }
        //Создает таблицу группы
        private void GroupCreate(string group)
        {
            MySqlConnection connection = MySqlOpen();
            string trasliteGroup = Translit.TranslitString(group);
            string query = $"CREATE TABLE `{trasliteGroup}` (`id` int NOT NULL,`name` varchar(100) NOT NULL,PRIMARY KEY(`id`),UNIQUE KEY `id_UNIQUE` (`id`))";
            MySqlQuery(query, connection);
            connection.Close();
        }
        private void GroupTruncate(string group)
        {
            MySqlConnection connection = MySqlOpen();
            string trasliteGroup = Translit.TranslitString(group);
            string query = $"TRUNCATE TABLE `{trasliteGroup}`";
            MySqlQuery(query, connection);
            connection.Close();
        }
        //Добавляет группу в таблицу групп
        public void AddGroups(List<MainWindow.GroupList> groups)
        {
            MySqlConnection connection = MySqlOpen();
            string query = "TRUNCATE TABLE `groups`;";
            MySqlQuery(query, connection);
            connection.Close();
            foreach (MainWindow.GroupList group in groups)
            {
                connection = MySqlOpen();
                query = $"INSERT INTO `groups`(`id`,`name`) VALUES ('{group.id}', '{group.name}');";
                MySqlQuery(query, connection);
                connection.Close();
            }
        }
        //Добавляет учеников в таблицу группы
        public void AddGroup(List<MainWindow.GroupList> group, string groupName)
        {
            MySqlConnection connection;
            string query;
            if (!GroupCreated(groupName))
            {
                GroupCreate(groupName);
            }
            else
            {
                GroupTruncate(groupName);
            }
            groupName = Translit.TranslitString(groupName);
            foreach (MainWindow.GroupList person in group)
            {
                connection = MySqlOpen();
                query = $"INSERT INTO `{groupName}`(`id`,`name`) VALUES ('{person.id}', '{person.name}');";
                MySqlQuery(query, connection);
                connection.Close();
            }
        }
    }
}
