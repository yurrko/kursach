using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;

namespace admission_office
{
    static class AOffice
    {
        public static bool Create_entrant( string firstName, string lastName, string middleName, string birthDate, List<Exam> list, int education)
        {
            int insertedID = DBDriver.Instance.InsertValuesAndReceiveIdentity( SqlQueryList.Queries[(int)SqlQueryNum.AddEntrant],
                                                                new string[] { firstName, lastName, middleName, birthDate } );
            foreach (var l in list)
                DBDriver.Instance.InsertValues( SqlQueryList.Queries[(int)SqlQueryNum.AddEgeResult],
                                                               new string[] {insertedID.ToString(), l.Id.ToString(), l.Result.ToString() } );

            DBDriver.Instance.InsertValues( SqlQueryList.Queries[(int)SqlQueryNum.AddEntrance],
                                            new string[] { insertedID.ToString(), education.ToString(), birthDate } );
            return true;
        }

        public static bool Create_speciality( string specName, int eduForm, int numOfFree, int numOfPaid, List<Exam> list )
        {
            int specId = DBDriver.Instance.SelectOneValue( SqlQueryList.Queries[(int)SqlQueryNum.SpecId],
                                            new string[] { specName } );

            if (specId == -1)/*Если id не вернулся, то такой специальности нет в БД. Создадим её*/
            {
                specId = DBDriver.Instance.InsertValuesAndReceiveIdentity( SqlQueryList.Queries[(int)SqlQueryNum.AddSpeciality],
                                                                    new string[] { specName } );
            }
            int eduId = DBDriver.Instance.InsertValuesAndReceiveIdentity( SqlQueryList.Queries[(int)SqlQueryNum.AddEducation],
                                                new string[] { specId.ToString(), eduForm.ToString(), numOfFree.ToString(), numOfPaid.ToString() } );

            foreach (var l in list)
            {
                DBDriver.Instance.InsertValues( SqlQueryList.Queries[(int)SqlQueryNum.AddRequirement],
                                                new string[] { eduId.ToString(), l.Id.ToString(), l.Result.ToString() } );
            }
            return true;
        }

        public static bool Create_subject( string subjName )
        {
            return DBDriver.Instance.InsertValues( SqlQueryList.Queries[(int)SqlQueryNum.AddSubject], new string[] { subjName } );
        }

        public static void Create_report()
        {
            //Объявляем приложение
            Excel.Application ex = new Excel.Application();

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

            //Данные для Excel
            var dt = DBDriver.Instance.SelectValuesDataTable( SqlQueryList.Queries[(int)SqlQueryNum.Report] );

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.Cells[1, i + 1] = String.Format("{0}", dt.Columns[i]);
                }
                
                DataRow[] myDataRows = dt.Select();
                var dataToCombo = new ComboBoxItem[myDataRows.Length];
                for (int i = 0; i < myDataRows.Length; i++)
                {
                    for (int j = 0; j < myDataRows[i].ItemArray.Length; j++)
                        sheet.Cells[i+2, j+1] = String.Format( "{0}", myDataRows[i].ItemArray[j] );
                }

            //Отобразить Excel
            ex.Visible = true;

            ////Захватываем диапазон ячеек
            //Excel.Range range1 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[9, 9]];
            ////Excel.Range(sheet.Cells[1, 1], sheet.Cells[9, 9]);

            ////Шрифт для диапазона
            //range1.Cells.Font.Name = "Tahoma";
            ////Размер шрифта для диапазона
            //range1.Cells.Font.Size = 10;

            ////Захватываем другой диапазон ячеек
            //Excel.Range range2 = sheet.Range[sheet.Cells[1, 1], sheet.Cells[9, 2]];
            //range2.Cells.Font.Name = "Times New Roman";

            ////Задаем цвет этого диапазона. Необходимо подключить System.Drawing
            //range2.Cells.Font.Color = ColorTranslator.ToOle( Color.Green );
            ////Фоновый цвет
            //range2.Interior.Color = ColorTranslator.ToOle( Color.FromArgb( 0xFF, 0xFF, 0xCC ) );
        }
    }
}