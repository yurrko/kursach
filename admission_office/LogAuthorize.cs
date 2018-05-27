using System;
using System.Text;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace admission_office
{
    class LogAuthorize
    {
        private static LogAuthorize _instance;

        public static LogAuthorize Instance
        {
            get
            {
                if (_instance == null) _instance = new LogAuthorize();
                return _instance;
            }
        }

        public int Authorize( string login, string password, int DBNum )
        {
            using (MD5 md5Hash = MD5.Create())
            {
                DBDriver.ConnectionNum = DBNum;
                int result = DBDriver.Instance.SelectOneValue( SqlQueryList.Queries[(int)SqlQueryNum.SelectRole],
                                                                new string[] { login, Encrypt( md5Hash, password ) } );
                if (result == -1)
                    Log( login, "0" );
                else
                    Log( login, "1" );
                return result;
            }
        }

        public bool Register( string login, string password, string role )
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return DBDriver.Instance.InsertValues( SqlQueryList.Queries[(int)SqlQueryNum.Register],
                                                    new string[] { login, Encrypt( md5Hash, password ), role } );
            }
        }

        private void Log( string login, string result )
        {
            var date = String.Format( "{0:s}", DateTime.Now );
            DBDriver.Instance.InsertValues( SqlQueryList.Queries[(int)SqlQueryNum.Log],
                                            new string[] { date, login, result } );
        }

        private string Encrypt( MD5 md5Hash, string input )
        {
            byte[] data = md5Hash.ComputeHash( Encoding.UTF8.GetBytes( input ) );
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append( data[i].ToString( "x2" ) );
            return sBuilder.ToString();
        }
    }
}


