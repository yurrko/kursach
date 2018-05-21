using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Data;

namespace admission_office
{
    class LogAuthorize
    {
        MD5 _md5Hash;
        public bool Authorize( string login, string password)
        {
            _md5Hash = MD5.Create();
            string result;
            using (MySqlConnection connection = new MySqlConnection( ConnectionString.Connection ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "SELECT COUNT(*) FROM authorize WHERE Login = '@Login' AND password = '@Password'";
                cmd.Parameters.AddWithValue( "@Login", login );
                cmd.Parameters.AddWithValue( "@Password", Encrypt( _md5Hash, password ) );
                result = cmd.ExecuteScalar().ToString();
                connection.Close();
            }
            return (int.Parse(result) == 1) ? true : false;
        }

        public string Register( string login, string password )
        {
            int result;
            _md5Hash = MD5.Create();
            using (MySqlConnection connection = new MySqlConnection( ConnectionString.Connection))
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO authorize (login, password) VALUES (@Login, @Password)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue( "@Login", login );
                cmd.Parameters.AddWithValue( "@Password", Encrypt( _md5Hash, password ) );
                result = cmd.ExecuteNonQuery();
                connection.Close();
            }
            return result == 1 ? "Пользователь зарегистрирован" : "Произошла ошибка";
        }

        private string Encrypt( MD5 md5Hash, string input )
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash( Encoding.UTF8.GetBytes( input ) );

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append( data[i].ToString( "x2" ) );
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}

