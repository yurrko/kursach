using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace admission_office
{
    public partial class TextBoxExams : UserControl
    {
        public TextBoxExams(string str)
        {
            InitializeComponent();
            FillComboBox();
            lblExam1.Text += str;
        }

        public ComboBox CbExam => cbExam;

        public TextBox TbExamRes => tbExamRes;

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
                foreach (var t in myData)
                {
                    foreach (var val in t.ItemArray)
                    {
                        cbExam.Items.Add( val );
                    }
                }
                connection.Close();
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

        private void tbExamRes1_KeyPress( object sender, KeyPressEventArgs e )
        {
            if (!Check_tb( e, tbExamRes.Text ))
            {
                e.Handled = true;
            }
        }

        public void Clear()
        {
            cbExam.SelectedIndex = -1;
            tbExamRes.Text = "";
        }
    }
}
