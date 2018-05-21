using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admission_office
{
    public partial class Form2 : Form
    {
        AOffice _admOffice = new AOffice();
        public Form2()
        {
            InitializeComponent();
            FillComboBox();

        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            if (tbFirstName.Text.Length == 0 
                || tbLastname.Text.Length == 0 
                || cbExam1.SelectedIndex != -1 
                || cbExam2.SelectedIndex != -1 
                || cbExam2.SelectedIndex != -1 
                || tbExamRes1.Text.Length == 0 
                || tbExamRes2.Text.Length == 0
                || tbExamRes3.Text.Length == 0 
                )
            {
                MessageBox.Show( "Заполните все обязательные поля", "Ошибка" );
            }
            else
            {
                if (cbExam1.SelectedIndex == cbExam2.SelectedIndex
                    || cbExam1.SelectedIndex == cbExam3.SelectedIndex
                    || cbExam2.SelectedIndex == cbExam2.SelectedIndex)
                {
                    MessageBox.Show( "Выберите различные экзамены", "Ошибка" );
                }
                else
                {
                    List<Exam> list = new List<Exam>() {
                    new Exam(cbExam1.SelectedIndex+1,int.Parse(tbExamRes1.Text)),
                    new Exam(cbExam2.SelectedIndex+1,int.Parse(tbExamRes2.Text)),
                    new Exam(cbExam3.SelectedIndex+1,int.Parse(tbExamRes3.Text))};
                    _admOffice.Create_entrant( tbFirstName.Text, tbLastname.Text, tbMiddleName.Text, dtpBirthdate.Text, list );
                }
            }
        }

        private void Clear()
        {
            tbFirstName.Text = "";
            tbMiddleName.Text = "";
            tbLastname.Text = "";
            dtpBirthdate.Text = "";
        }

        private void FillComboBox()
        {
            using (MySqlConnection connection = new MySqlConnection( ConnectionString.Connection ))
            {
                MySqlCommand cmd = new MySqlCommand();
                connection.Open();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.CommandText = "SELECT subject FROM admission_office.subject ORDER BY id";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( cmd );
                DataTable dt = new DataTable();
                dataAdapter.Fill( dt );

                DataRow[] myData = dt.Select();
                for (int i = 0; i < myData.Length; i++)
                {
                    for (int j = 0; j < myData[i].ItemArray.Length; j++)
                    {
                        cbExam1.Items.Add( myData[i].ItemArray[j] + "" );
                        cbExam2.Items.Add( myData[i].ItemArray[j] + "" );
                        cbExam3.Items.Add( myData[i].ItemArray[j] + "" );
                    }
                }
                connection.Close();
            }
        }

        private void tbExamRes1_KeyPress( object sender, KeyPressEventArgs e )
        {
            if (!Check_tb( e, tbExamRes1.Text ))
            {
                e.Handled = true; 
            }
        }

        private void tbExamRes2_KeyPress( object sender, KeyPressEventArgs e )
        {
            if (!Check_tb( e, tbExamRes2.Text ))
            {
                e.Handled = true;
            }
        }

        private void tbExamRes3_KeyPress( object sender, KeyPressEventArgs e )
        {
            if (!Check_tb( e, tbExamRes3.Text ))
            {
                e.Handled = true;
            }
        }

        private bool Check_tb( KeyPressEventArgs e, string value )
        {
            char number = e.KeyChar;
            if (number == 8) return true;
            if (Char.IsDigit( number ))
            {
                if (value.Length != 0)
                {
                    return (int.Parse( value ) * 10 + int.Parse( number.ToString() )) <= 100;
                }
                return true;
            }
            return false;
        }
    }
}
