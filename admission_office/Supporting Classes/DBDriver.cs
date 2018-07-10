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
                }
                return _instance;
            }
        }

        private static readonly List<string> connStr;

        private static List<string> ReadConnectionString()
        {
            StreamReader sr = new StreamReader( "connection_string.txt" );
            while (!sr.EndOfStream)
            {
                connStr.Add( sr.ReadLine() );
            }
            return connStr;
        }

        static DBDriver()
        {
            connStr = new List<string>();
            connStr = ReadConnectionString();
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
                DataTable dt = new DataTable();
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

        public DataSet SelectValuesDataSet( string sql )
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
                DataSet ds = new DataSet();
                dataAdapter.Fill( ds );
                return ds;
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