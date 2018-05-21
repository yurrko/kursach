using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;


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

        public bool Create_entrant( string firstName, string lastName, string middleName, string birthDate, List<Exam> list )
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
                connection.Close();
                return true;
            }
        }

        public bool Create_speciality(string specName, List<Exam> list )
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString.Connection))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `admission_office`.`speciality` (`speciality`) VALUES( @specName )";
                cmd.Parameters.AddWithValue( "@specName", specName );
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@IDENTITY";
                int lastId = Convert.ToInt32( cmd.ExecuteScalar() );
                cmd.CommandText = "INSERT INTO `admission_office`.`education` (`id_speciality`, `id_education_form`, `num_of_free_places`, `num_of_paid_places`) VALUES( @id_speciality, @id_education_from, @num_of_free, @num_of_paid)";
                foreach (var l in list)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue( "@id_speciality", lastId );
                    cmd.Parameters.AddWithValue( "@id_education_from", l.Id );
                    cmd.Parameters.AddWithValue( "@num_of_free", l.Result );
                    cmd.Parameters.AddWithValue( "@num_of_paid", l.Result );
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
                return true;
            }
        }
    }
}
