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
            cbExam.Items.AddRange( AOffice.FillCB( SqlQuery.SqlQueries[(int)SqlQueryNum.Subject] ) );
            lblExam1.Text += str;
        }

        public ComboBox CbExam => cbExam;

        public TextBox TbExamRes => tbExamRes;

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
