using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace LinkedinAutoMessanger
{
    class DataAccess
    {

        List<String> Users = new List<String>();
        public void AddUser(string username)
        {
            using (MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.Connection("linkednDb")))
            {
                try
                {
                    connection.Open();
                    MySqlCommand com = new MySqlCommand("INSERT INTO usernames (UserName) VALUES (@UserName)", connection);
                    MySqlParameter param = new MySqlParameter();
                    param.ParameterName = "@UserName";
                    param.Value = username;
                    com.Parameters.Add(param);
                    com.ExecuteReader();

                }
                catch (MySqlException mysqlex)
                {

                }
            }
        }

        public List<String> GetAllUsers()
        {
            using (MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(Helper.Connection("linkednDb")))
            {
                try
                {
                    connection.Open();
                    MySqlCommand com = new MySqlCommand("SELECT * FROM usernames", connection);
                    var reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Users.Add(reader["UserName"].ToString());
                    }
                }
                catch (MySqlException mysqlex)
                {

                }
                return Users;
            }
        }
    }
}
