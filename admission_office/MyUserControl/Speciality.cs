using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace admission_office
{
    public partial class Speciality : UserControl
    {
        private static Speciality _instance;

        public static Speciality Instance
        {
            get
            {
                if (_instance == null) _instance = new Speciality();
                return _instance;
            }
        }
        TextBoxExams ucExam1 = new TextBoxExams("1");
        TextBoxExams ucExam2 = new TextBoxExams("2");
        TextBoxExams ucExam3 = new TextBoxExams("3");

        public Speciality()
        {
            InitializeComponent();
            panel1.Controls.Add( ucExam1 );
            panel2.Controls.Add( ucExam2 );
            panel3.Controls.Add( ucExam3 );
            ucExam1.Dock = DockStyle.Fill;
            ucExam2.Dock = DockStyle.Fill;
            ucExam3.Dock = DockStyle.Fill;
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            if(   String.IsNullOrEmpty(tbSpec.Text)
               && String.IsNullOrEmpty(mtbFree.Text)
               && String.IsNullOrEmpty(ucExam1.TbExamRes.Text)
               && String.IsNullOrEmpty(ucExam2.TbExamRes.Text)
               && String.IsNullOrEmpty(ucExam3.TbExamRes.Text)
               && ucExam1.CbExam.SelectedIndex == -1
               && ucExam2.CbExam.SelectedIndex == -1
               && ucExam3.CbExam.SelectedIndex == -1
               )
            {
                MessageBox.Show( "Заполните все обязательные поля", "Ошибка" );
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
                        new Exam(ucExam1.CbExam.SelectedIndex + 1, int.Parse(ucExam1.TbExamRes.Text)),
                        new Exam(ucExam2.CbExam.SelectedIndex + 1, int.Parse(ucExam2.TbExamRes.Text)),
                        new Exam(ucExam3.CbExam.SelectedIndex + 1, int.Parse(ucExam3.TbExamRes.Text))
                    };
                    if (AOffice.Create_speciality( tbSpec.Text, (cbDaily.Checked) ? 1 : 2, int.Parse(mtbFree.Text), int.Parse(mtbPaid.Text), list)) Clear();
                }
            }
        }

        private void Clear()
        {
            tbSpec.Text = "";
            mtbFree.Text = "";
            mtbPaid.Text = "";
            ucExam1.Clear();
            ucExam2.Clear();
            ucExam3.Clear();
        }
    }
}