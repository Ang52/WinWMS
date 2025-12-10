using MySql.Data.MySqlClient;
using System.Data;

namespace WinWMS
{
    public class DbHelper
    {
        // 数据库连接字符串（请根据实际 MySQL 环境修改）
        private static readonly string connectionString = "server=dbserver.erosli.com;port=3306;user=WinWMS;password=Li123456;database=winwms;charset=utf8;";

        // 获取一个新的 MySQL 连接对象
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // 执行查询语句，返回 DataTable 结果集
        public static DataTable ExecuteQuery(string query, MySqlParameter[]? parameters = null)
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

        // 执行非查询语句（INSERT、UPDATE、DELETE），返回受影响的行数
        public static int ExecuteNonQuery(string query, MySqlParameter[]? parameters = null)
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
