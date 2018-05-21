namespace admission_office
{
    class Class1
    {
        //string sql = "SELECT * FROM table1"; // Строка запроса
        //MySqlConnection connection = new MySqlConnection( connStr );
        //MySqlCommand sqlCom = new MySqlCommand( sql, connection );
        //connection.Open();
        //    sqlCom.ExecuteNonQuery();
        //    MySqlDataAdapter dataAdapter = new MySqlDataAdapter( sqlCom );
        //DataTable dt = new DataTable();
        //dataAdapter.Fill(dt);

        //    var myData = dt.Select();
        //    for(int i = 0; i<myData.Length;i++)
        //    {
        //        for (int j = 0; j<myData[i].ItemArray.Length; j++)
        //            richTextBox1.Text += myData[i].ItemArray[j] + " ";
        //        richTextBox1.Text += "\n";
        //    }


//using (MySqlConnection connection = new MySqlConnection( connStr ))
//            {
//                connection.Open();
//                MySqlCommand cmd = connection.CreateCommand();
//    cmd.CommandType = CommandType.Text;
//                cmd.CommandText = "INSERT INTO authorize (login, password) VALUES (@Login, @Password)";
//                cmd.Parameters.Clear();
//                cmd.Parameters.AddWithValue( "@Login", Login );
//                cmd.Parameters.AddWithValue( "@Password", Encrypt( md5Hash, Password ) );
//                cmd.ExecuteNonQuery();
//                cmd.CommandText = "SELECT @@IDENTITY";
//                int lastId = Convert.ToInt32( cmd.ExecuteScalar() );
//    MessageBox.Show(lastId.ToString() );
//                connection.Close();
//            }
    }
}

