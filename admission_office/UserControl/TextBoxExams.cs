using System;
using System.Data;
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
                cmd.CommandText = "SELECT id, subject FROM admission_office.subject ORDER BY id";
                cmd.ExecuteNonQuery();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter( cmd );
                DataTable dt = new DataTable();
                dataAdapter.Fill( dt );
                DataRow[] myData = dt.Select();
                var dataToCombo = new ComboBoxItem[myData.Length];
                for (int i = 0; i < myData.Length; i++)
                {
                    dataToCombo[i] = new ComboBoxItem(Convert.ToInt32(myData[i].ItemArray[0]),
                        myData[i].ItemArray[1].ToString());
                }
                cbExam.Items.AddRange(dataToCombo);
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
