using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace SakuraHardwareRegister.Common
{
    public class DbConnector
    {
        public static DbConnection GetDbConnector()
        {
            // 接続文字列作成
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3306,
                UserID = "dev_user",
                Password = "password",
                Database = "shr"
            };

            return new MySqlConnection(builder.ToString());
        }
    }
}
