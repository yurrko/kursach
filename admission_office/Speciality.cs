using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            if(tbSpec.Text.Length != 0 
               && mtbFree.Text.Length != 0 
               && ucExam1.TbExamRes.Text.Length != 0
               && ucExam2.TbExamRes.Text.Length != 0
               && ucExam3.TbExamRes.Text.Length != 0
               && ucExam1.CbExam.SelectedIndex != -1
               && ucExam2.CbExam.SelectedIndex != -1
               && ucExam3.CbExam.SelectedIndex != -1
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
                    if (AOffice.Instance.Create_speciality( tbSpec.Text, list)) Clear();
                }
            }
           
        }

        private void Clear()
        {
            tbSpec.Text = "";
            mtbFree.Text = "";
            mtbPaid.Text = "";
            ucExam1.CbExam.SelectedIndex = -1;
            ucExam2.CbExam.SelectedIndex = -1;
            ucExam3.CbExam.SelectedIndex = -1;
            ucExam1.TbExamRes.Text = "";
            ucExam2.TbExamRes.Text = "";
            ucExam3.TbExamRes.Text = "";
        }
    }
}
