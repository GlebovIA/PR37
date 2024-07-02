using MySql.Data.MySqlClient;

namespace PR37.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=127.0.0.1;port=3308;database=MyShop;uid=root;pwd=;";
        public static MySqlConnection MySqlOpen()
        {
            MySqlConnection NewMySqlConnection = new MySqlConnection(ConnectionData);
            NewMySqlConnection.Open();
            return NewMySqlConnection;
        }
        public static MySqlDataReader MySqlQuery(string query, MySqlConnection connection)
        {
            MySqlCommand NewMySqlCommand = new MySqlCommand(query, connection);
            return NewMySqlCommand.ExecuteReader();
        }
        public static void MySqlClose(MySqlConnection connection)
        {
            connection.Close();
        }
    }
}
