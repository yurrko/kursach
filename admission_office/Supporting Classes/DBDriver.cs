using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace admission_office
{
    class DBDriver
    {
        private static DBDriver _instance;

        public static DBDriver Instance
        {
            get
            {
                if (_instance == null) _instance = new DBDriver();
                return _instance;
            }
        }
        private readonly string[] _connStr = { "server=localhost;user=root;database=admission_office;password=12345687",
                                        "server=localhost;user=root;database=admission_office_archive;password=12345687" };

        /*Начало. Удалить после полного переписования AOffice*/
        public string Connect

        {
            get { return _connStr[0]; }
        }
        /*Конец. Удалить после полного переписования AOffice*/

        public static int ConnectionNum { get; set; }

        public int SelectOneValue( string sql, string[] values )
        {
            using (MySqlConnection connection = new MySqlConnection( _connStr[ConnectionNum] ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = sql;
                for (int i = 0; i < values.Length; i++)
                    cmd.Parameters.AddWithValue( String.Concat( "@", i ), values[i] );
                int result;
                try
                {
                    var lastId = cmd.ExecuteScalar().ToString();
                    result = int.Parse( lastId );
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message, "Ошибка" );
                    return -1;
                }
                connection.Close();
                return result;
            }
        }

        public bool InsertValues( string sql, string[] values )
        {
            using (MySqlConnection connection = new MySqlConnection( _connStr[ConnectionNum]))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = sql;
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.AddWithValue( String.Concat( "@", i ), values[i] );
                }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message, "Ошибка" );
                    return false;
                }
                connection.Close();
                return true;
            }
        }

        public int InsertValuesAndReceiveIdentity( string sql, string[] values )
        {
            using (MySqlConnection connection = new MySqlConnection( _connStr[ConnectionNum] ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = sql;
                for (int i = 0; i < values.Length; i++)
                {
                    cmd.Parameters.AddWithValue( String.Concat( "@", i ), values[i] );
                }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message, "Ошибка" );
                    //return false;
                }
                cmd.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32( cmd.ExecuteScalar() );
                connection.Close();
                return lastId;
            }
        }
    }
}