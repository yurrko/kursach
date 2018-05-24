using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using OfficeOpenXml;
using System.Drawing;
using System.Windows.Forms;
//using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

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

        public bool Create_entrant( string firstName, string lastName, string middleName, string birthDate, List<Exam> list, int education)
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
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( ex.Message, "Ошибка" );
                        return false;
                    }
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
                //Получаем id записи в таблицы speciality у которой название совпадает с введенным
                cmd.CommandText = SqlQuery.SqlQueries[(int)SqlQueryNum.SpecId];
                cmd.Parameters.AddWithValue( "@speciality", specName );
                int specId;
                try
                {
                    //Если возвращается null (таких записей нет), то преобразуется в 0.
                    specId = Convert.ToInt32( cmd.ExecuteScalar() );
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message, "Ошибка" );
                    return false;
                }

                if (specId == 0)/*Если id не вернулся, то такой специальности нет в БД. Создадим её*/
                {
                    cmd.CommandText =
                        "INSERT INTO `admission_office`.`speciality` (`speciality`) VALUES( @specName )";
                    cmd.Parameters.AddWithValue("@specName", specName);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка");
                        return false;
                    }
                    cmd.CommandText = "SELECT @@IDENTITY";
                    specId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                cmd.CommandText = 
                    "INSERT INTO `admission_office`.`education` (`id_speciality`, `id_education_form`, `num_of_free_places`, `num_of_paid_places`) VALUES( @id_speciality, @id_education_from, @num_of_free, @num_of_paid)";
                cmd.Parameters.AddWithValue( "@id_speciality", specId );
                cmd.Parameters.AddWithValue( "@id_education_from", eduForm );
                cmd.Parameters.AddWithValue( "@num_of_free", numOfFree );
                cmd.Parameters.AddWithValue( "@num_of_paid", numOfPaid );
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show( ex.Message, "Ошибка" );
                    return false;
                }
                cmd.CommandText = "SELECT @@IDENTITY";
                specId = Convert.ToInt32( cmd.ExecuteScalar() );
                cmd.CommandText =
                    "INSERT INTO `admission_office`.`requirement` (`id_education`, `id_subject`, `min_requirement`) VALUES (@id_education, @id_subject, @min_requirement)";
                foreach (var l in list)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue( "@id_education", specId );
                    cmd.Parameters.AddWithValue( "@id_subject", l.Id );
                    cmd.Parameters.AddWithValue( "@min_requirement", l.Result );
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show( ex.Message, "Ошибка" );
                        return false;
                    }
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
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                    return false;
                }
                connection.Close();
                return true;
            }
        }

        public void Create_report()
        {
            //Объявляем приложение
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();

            //Отобразить Excel
            ex.Visible = true;

            //Количество листов в рабочей книге
            ex.SheetsInNewWorkbook = 1;

            //Добавить рабочую книгу
            Excel.Workbook workBook = ex.Workbooks.Add( Type.Missing );

            //Отключить отображение окон с сообщениями
            ex.DisplayAlerts = false;

            //Получаем первый лист документа (счет начинается с 1)
            Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item( 1 );

            //Название листа (вкладки снизу)
            var dateTime = DateTime.Today;
            sheet.Name = "Отчет от " + dateTime.Date.ToShortDateString();

            //Пример заполнения ячеек

            //Данные для Excel
            using (MySqlConnection connection = new MySqlConnection( ConnectionString.Connection ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = SqlQuery.SqlQueries[(int) SqlQueryNum.Report];
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( cmd );
                System.Data.DataTable dt = new System.Data.DataTable();
                dataAdapter.Fill( dt );
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1] = String.Format("{0}", dt.Columns[i]);
                }
                
                //dt.Columns[]

                DataRow[] myDataRows = dt.Select();
                var dataToCombo = new ComboBoxItem[myDataRows.Length];
                for (int i = 0; i < myDataRows.Length; i++)
                {
                    for (int j = 0; j < myDataRows[i].ItemArray.Length; j++)
                        sheet.Cells[i+2, j+1] = String.Format( "{0}", myDataRows[i].ItemArray[j] );
                }
                connection.Close();
            }
            //Данные

            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j < 9; j++)
            //        sheet.Cells[i, j] = String.Format( "Boom {0} {1}", i, j );
            //}

            //Захватываем диапазон ячеек

            Excel.Range range1 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[9, 9]];
            //Excel.Range(sheet.Cells[1, 1], sheet.Cells[9, 9]);


            //Шрифт для диапазона
            range1.Cells.Font.Name = "Tahoma";
            //Размер шрифта для диапазона
            range1.Cells.Font.Size = 10;

            //Захватываем другой диапазон ячеек
            Excel.Range range2 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[9, 2]];
            range2.Cells.Font.Name = "Times New Roman";

            //Задаем цвет этого диапазона. Необходимо подключить System.Drawing
            range2.Cells.Font.Color = ColorTranslator.ToOle( Color.Green );
            //Фоновый цвет
            range2.Interior.Color = ColorTranslator.ToOle( Color.FromArgb( 0xFF, 0xFF, 0xCC ) );
        }

        public void Create_report1()
        {
            //using (var excel = new ExcelPackage())
            //{
            //    var ws = Workbook.Worksheets.Add( "MyWorksheet" );

            //    ws.Cells["A1"].Value = 100;
            //    ws.Cells["A2"].Formula = "A1*2";
            //    SaveAs( new FileInfo( "test.xlsx" ) );
            //}
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
    }
}