using MySql.Data.MySqlClient;
using System.Data;

namespace WinWMS
{
    public class DbHelper
    {
        // 请根据你的MySQL设置修改此连接字符串
        private static readonly string connectionString = "server=dbserver.erosli.com;port=3306;user=WinWMS;password=Li123456;database=winwms;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = GetConnection())
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }
    }
}
