using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace admission_office
{
    public partial class NewEntrant : UserControl
    {
        private static NewEntrant _instance;

        public static NewEntrant Instance
        {
            get
            {
                if (_instance == null) _instance = new NewEntrant();
                return _instance;
            }
        }
        TextBoxExams ucExam1 = new TextBoxExams( "1" );
        TextBoxExams ucExam2 = new TextBoxExams( "2" );
        TextBoxExams ucExam3 = new TextBoxExams( "3" );

        public NewEntrant()
        {
            InitializeComponent();
            panel1.Controls.Add(ucExam1);
            panel2.Controls.Add(ucExam2);
            panel3.Controls.Add(ucExam3);
            ucExam1.Dock = DockStyle.Fill;
            ucExam2.Dock = DockStyle.Fill;
            ucExam3.Dock = DockStyle.Fill;
            cbSpec.Items.AddRange(AOffice.FillCB( SqlQuery.SqlQueries[(int)SqlQueryNum.EduSpec] ) );
            cbEduType.Items.AddRange(AOffice.FillCB(SqlQuery.SqlQueries[(int) SqlQueryNum.EduType]));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbFirstName.Text.Length == 0
                || tbLastname.Text.Length == 0
                || ucExam1.CbExam.SelectedIndex == -1
                || ucExam2.CbExam.SelectedIndex == -1
                || ucExam3.CbExam.SelectedIndex == -1
                || ucExam1.TbExamRes.Text.Length == 0
                || ucExam2.TbExamRes.Text.Length == 0
                || ucExam3.TbExamRes.Text.Length == 0
            )
            {
                MessageBox.Show("Заполните все обязательные поля", "Ошибка");
            }
            else
            {
                if (ucExam1.CbExam.SelectedIndex == ucExam2.CbExam.SelectedIndex
                    || ucExam1.CbExam.SelectedIndex == ucExam3.CbExam.SelectedIndex
                    || ucExam2.CbExam.SelectedIndex == ucExam3.CbExam.SelectedIndex)
                {
                    MessageBox.Show( "Выберите различные экзамены", "Ошибка" );
                }
                else
                {
                    List<Exam> list = new List<Exam>()
                {
                    new Exam((ucExam1.CbExam.SelectedItem as ComboBoxItem).Value, int.Parse(ucExam1.TbExamRes.Text)),
                    new Exam((ucExam2.CbExam.SelectedItem as ComboBoxItem).Value, int.Parse(ucExam2.TbExamRes.Text)),
                    new Exam((ucExam3.CbExam.SelectedItem as ComboBoxItem).Value, int.Parse(ucExam3.TbExamRes.Text))
                };
                if (AOffice.Instance.Create_entrant(tbFirstName.Text, tbLastname.Text, tbMiddleName.Text, dtpBirthdate.Text, list, (cbSpec.SelectedItem as ComboBoxItem).Value)) Clear();
                }
            }
        }

        private void Clear()
        {
            tbFirstName.Text = "";
            tbMiddleName.Text = "";
            tbLastname.Text = "";
            dtpBirthdate.Text = "";
            ucExam1.Clear();
            ucExam2.Clear();
            ucExam3.Clear();
            cbSpec.Text="";
        }
    }
}
