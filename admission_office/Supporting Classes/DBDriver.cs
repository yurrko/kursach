using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Collections.Generic;

namespace admission_office
{
    class DBDriver
    {
        private static DBDriver _instance;

        public static DBDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBDriver();
                    _instance.connStr = _instance.ReadConnectionString();
                }
                return _instance;
            }
        }

        private List<string> connStr;

        //private readonly string[] connStr = { "server=localhost;user=root;database=admission_office;password=12345687",
        //                                "server=localhost;user=root;database=admission_office_archive;password=12345687" };

        private List<string> ReadConnectionString()
        {
            connStr = new List<string>();
            StreamReader sr = new StreamReader( "connection_string.txt" );
            while (!sr.EndOfStream)
            {
                connStr.Add( sr.ReadLine() );
            }
            return connStr;
        }

        public static int ConnectionNum { get; set; }

        public int SelectOneValue( string sql, string[] values )
        {
            using (MySqlConnection connection = new MySqlConnection( connStr[ConnectionNum] ))
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

        public ComboBoxItem[] SelectValuesToCB (string sql)
        {
            using (MySqlConnection connection = new MySqlConnection( connStr[ConnectionNum] ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( cmd );
                System.Data.DataTable dt = new System.Data.DataTable();
                dataAdapter.Fill( dt );
                DataRow[] myData = dt.Select();
                var dataToCombo = new ComboBoxItem[myData.Length];
                for (int i = 0; i < myData.Length; i++)
                {
                    dataToCombo[i] = new ComboBoxItem( Convert.ToInt32( myData[i].ItemArray[0] ), myData[i].ItemArray[1].ToString() );
                }
                connection.Close();
                return dataToCombo;
            }
        }

        public DataTable SelectValuesDataTable( string sql )
        {
            using (MySqlConnection connection = new MySqlConnection( connStr[ConnectionNum] ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( cmd );
                DataTable dt = new DataTable();
                dataAdapter.Fill( dt );
                return dt;
            }
        }

        public bool InsertValues( string sql, string[] values )
        {
            using (MySqlConnection connection = new MySqlConnection( connStr[ConnectionNum]))
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
            using (MySqlConnection connection = new MySqlConnection( connStr[ConnectionNum] ))
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
                }
                cmd.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32( cmd.ExecuteScalar() );
                connection.Close();
                return lastId;
            }
        }
    }
}