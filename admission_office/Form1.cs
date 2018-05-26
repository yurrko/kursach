using System;
using System.Windows.Forms;

namespace admission_office
{
    public partial class Form1 : Form
    {
        Form2 program = new Form2();
        private LogAuthorize _logAuto = new LogAuthorize();
        public int Role { get; set; }
        public Form1()
        {
            InitializeComponent();
            Text = "Авторизация";
            cbSelectDB.SelectedIndex = 0;
            //btnRegister.Hide();
            program.Owner = this;
        }
        
        private void btnAuthorize_Click( object sender, EventArgs e )
        {
            Authorize();
            Register_mode();
        }

        private void Clear()
        {
            tbLogin.Text = "";
            tbPass.Text = "";
        }

        private bool Check()
        {
            if (tbLogin.Text.Length == 0 && tbPass.Text.Length == 0)
            {
                MessageBox.Show( "Логин или пароль не могут быть пустыми", "Предупреждение" );
                return false;
            }
            return true;
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            tbLogin.Select();
        }

        private void Authorize()
        {
            if (Check())
            {
                var userRole = _logAuto.Authorize( tbLogin.Text, tbPass.Text, cbSelectDB.SelectedIndex );
                if (userRole != -1)
                {
                    Hide();
                    Role = userRole;
                    program.setAccess();
                    program.ShowDialog();
                    Register_mode();
                }
                else
                    MessageBox.Show( "Неверный логин/пароль", "Ошибка" );
            }
        }

        private void Register()
        {
            if (Check())
            {
                if (_logAuto.Register( tbLogin.Text, tbPass.Text, cbSelectDB.SelectedIndex.ToString() ))
                {
                    MessageBox.Show( "Пользователь зарегистрирован", "Сообщение" );
                    Clear();
                    Visible = false;
                    program.Visible = true;
                }
            }
        }

        private void Register_mode()
        {
            Text = "Регистрация";
            btnAuthorize.Text = "Регистрация";
            cbSelectDB.Items.Clear();
            cbSelectDB.Items.AddRange( new string[] { "Админ", "Член комиссии", "Секретарь" } );
            lblSelectDB.Text = "Роль";
        }
    }
}