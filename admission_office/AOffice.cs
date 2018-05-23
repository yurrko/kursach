using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using OfficeOpenXml;


namespace admission_office
{
    class AOffice
    {
        private static AOffice _instance;

        public static AOffice Instance
        {
            get
            {
                if (_instance == null) _instance = new AOffice();
                return _instance;
            }
        }

        public bool Create_entrant( string firstName, string lastName, string middleName, string birthDate, List<Exam> list, int education )
        {
            using (MySqlConnection connection = new MySqlConnection( ConnectionString.Connection ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `admission_office`.`entrants` (`first_name`, `middle_name`, `last_name`, `birth_date`) VALUES (@firstName, @middleName, @lastname, @birthDate)";
                cmd.Parameters.AddWithValue( "@firstName", firstName );
                cmd.Parameters.AddWithValue( "@lastName", lastName );
                cmd.Parameters.AddWithValue( "@middleName", middleName );
                cmd.Parameters.AddWithValue( "@birthDate", birthDate );
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32( cmd.ExecuteScalar() );
                cmd.CommandText = "INSERT INTO `admission_office`.`ege_result` (`id_entrant`, `id_subject`, `result`) VALUES (@id_entrant, @id_subject, @result)";
                foreach (var l in list) {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue( "@id_entrant", lastId );
                    cmd.Parameters.AddWithValue( "@id_subject", l.Id );
                    cmd.Parameters.AddWithValue( "@result", l.Result );
                    cmd.ExecuteNonQuery();
                }
                cmd.CommandText = "INSERT INTO `admission_office`.`entrance` (`id_entrant`, `id_education`, `date`) VALUES (@id_entrant, @id_education, @date)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue( "@id_entrant", lastId );
                cmd.Parameters.AddWithValue( "@id_education", education );
                var dt = DateTime.Now;
                cmd.Parameters.AddWithValue( "@date", dt);
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
        }

        public bool Create_speciality(string specName, int eduForm, int numOfFree,  int numOfPaid, List<Exam> list )
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString.Connection))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = 
                    "INSERT INTO `admission_office`.`speciality` (`speciality`) VALUES( @specName )";
                cmd.Parameters.AddWithValue( "@specName", specName );
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32( cmd.ExecuteScalar() );
                cmd.CommandText = 
                    "INSERT INTO `admission_office`.`education` (`id_speciality`, `id_education_form`, `num_of_free_places`, `num_of_paid_places`) VALUES( @id_speciality, @id_education_from, @num_of_free, @num_of_paid)";
                cmd.Parameters.AddWithValue( "@id_speciality", lastId );
                cmd.Parameters.AddWithValue( "@id_education_from", eduForm );
                cmd.Parameters.AddWithValue( "@num_of_free", numOfFree );
                cmd.Parameters.AddWithValue( "@num_of_paid", numOfPaid );
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                lastId = Convert.ToInt32( cmd.ExecuteScalar() );
                cmd.CommandText =
                    "INSERT INTO `admission_office`.`requirement` (`id_education`, `id_subject`, `min_requirement`) VALUES (@id_education, @id_subject, @min_requirement)";
                foreach (var l in list)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue( "@id_education", lastId );
                    cmd.Parameters.AddWithValue( "@id_subject", l.Id );
                    cmd.Parameters.AddWithValue( "@min_requirement", l.Result );
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
        }

        public bool Create_subject(string subjName)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString.Connection))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `admission_office`.`subject` (`subject`) VALUES (@subject)";
                cmd.Parameters.AddWithValue( "@subject", subjName );
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
        }

        public void Create_report()
        {
            using (var excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add( "MyWorksheet" );

                ws.Cells["A1"].Value = 100;
                ws.Cells["A2"].Formula = "A1*2";
                excel.SaveAs( new FileInfo( "test.xlsx" ) );
            }
        }

        public static ComboBoxItem[] FillCB( string sql )
        {
            using (MySqlConnection connection = new MySqlConnection( ConnectionString.Connection ))
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
    }
}