using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using PermDynamics.Chart;

namespace PermDynamics
{
    class DbCommands
    {
        /// <summary>
        /// Сохраняет данные текущего графика в базу данных
        /// </summary>
        /// <param name="dataToSave">Данные графика</param>
        public static void SaveData(ObservableCollection<Stocks> dataToSave)
        {
            MySqlConnection connection = DbConnection.MySqlOpen();
            string now = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day} {DateTime.Now.ToString().Split(' ')[1]}";
            string query = $"INSERT INTO `{connection.Database}`.`saves` (`saveDate`) VALUES('{now}');";
            DbConnection.MySqlQuery(query, connection).Close();
            query = $"SELECT `id` FROM `{connection.Database}`.`saves` WHERE `saveDate` = '{now}'";
            MySqlDataReader reader = DbConnection.MySqlQuery(query, connection);
            reader.Read();
            int id = reader.GetInt32(0);
            reader.Close();
            string dataTimeToSave;
            string rubles;
            string avg;
            foreach (Stocks data in dataToSave)
            {
                rubles = data.rublesPerStock.ToString();
                rubles = rubles.Replace(',', '.');
                avg = data.avgRublesPerStock.ToString();
                avg = avg.Replace(',', '.');
                dataTimeToSave = $"{data.time.Year}-{data.time.Month}-{data.time.Day} {data.time.Hour}:{data.time.Minute}:{data.time.Second}";
                query = $"INSERT INTO `{connection.Database}`.`saveddata` (`rublesPerStocks`,`avgPerStocks`,`dataTime`,`saveRelated`) " +
                    $"VALUES ('{rubles}','{avg}','{dataTimeToSave}','{id}');";
                DbConnection.MySqlQuery(query, connection).Close();
            }
            connection.Close();
            MessageBox.Show("График сохранен", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        /// <summary>
        /// Получает из базы данных список всех сохранений графика
        /// </summary>
        /// <returns>Список сохранений графика</returns>
        public static List<Saves> GetSaves()
        {
            List<Saves> saves = new List<Saves>();
            MySqlConnection connection = DbConnection.MySqlOpen();
            string query = $"SELECT * FROM `{connection.Database}`.`saves`";
            MySqlDataReader reader = DbConnection.MySqlQuery(query, connection);
            while (reader.Read())
            {
                saves.Add(new Saves(reader.GetString(0), reader.GetString(1)));
            }
            connection.Close();
            return saves;
        }
        /// <summary>
        /// Удаляет сохранение в базе данных соответствующее полученному id
        /// </summary>
        /// <param name="id">Id сохранения в базе данных</param>
        public static void DeleteSave(string id)
        {
            MySqlConnection connection = DbConnection.MySqlOpen();
            string query = $"DELETE FROM `{connection.Database}`.`saves` WHERE `id` = '{id}'";
            DbConnection.MySqlQuery(query, connection);
            connection.Close();
        }
        /// <summary>
        /// Получает id сохранения и возвращает данные графика соответствующие ему
        /// </summary>
        /// <param name="id">Id сохранения в базе данных</param>
        /// <returns>Данные графика под полученным id</returns>
        public static ObservableCollection<Stocks> GetData(string id)
        {
            ObservableCollection<Stocks> data = new ObservableCollection<Stocks>();
            MySqlConnection connection = DbConnection.MySqlOpen();
            string query = $"SELECT * FROM `{connection.Database}`.`saveddata` WHERE `saveRelated` = '{id}'";
            MySqlDataReader reader = DbConnection.MySqlQuery(query, connection);
            double rublesPerStock;
            double avgPerStock;
            DateTime time;
            while (reader.Read())
            {
                rublesPerStock = reader.GetDouble(1);
                avgPerStock = reader.GetDouble(2);
                time = reader.GetDateTime(3);
                data.Add(new Stocks(rublesPerStock, avgPerStock, time));
            }
            return data;
        }
        public static string GetLastSaveId()
        {
            string id = "0";
            MySqlConnection connection = DbConnection.MySqlOpen();
            string query = $"SELECT MAX(`id`) FROM `{connection.Database}`.`saves`";
            MySqlDataReader reader = DbConnection.MySqlQuery(query, connection);
            if (reader.HasRows)
            {
                reader.Read();
                id = reader.GetValue(0).ToString();
            }
            connection.Close();
            return id;
        }
    }
}
