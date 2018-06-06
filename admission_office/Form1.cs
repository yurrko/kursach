using System;
using System.Windows.Forms;

namespace admission_office
{
    delegate void ClickDelegate();

    public partial class Form1 : Form
    {
        ClickDelegate cd;
        Form2 program = new Form2();
        public int Role { get; set; }
        public Form1()
        {
            InitializeComponent();
            Text = "Авторизация";
            cbSelectDB.SelectedIndex = 0;
            program.Owner = this;
            cd += Authorize;
            btnAuthorize.Click += new EventHandler( ClickMethod );
            tbLogin.Select();
        }

        private void ClickMethod ( object sender, EventArgs e )
        {
            cd?.Invoke();
        }

        private void Authorize()
        {
            if (Check())
            {
                var userRole = LogAuthorize.Authorize( tbLogin.Text, tbPass.Text, cbSelectDB.SelectedIndex );
                if (userRole != -1)
                {
                    Hide();
                    Clear();
                    Role = userRole;
                    program.SetAccess();
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
                if (LogAuthorize.Register( tbLogin.Text, tbPass.Text, cbSelectDB.SelectedIndex.ToString() ))
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
            cbSelectDB.SelectedIndex = 2;
            lblSelectDB.Text = "Роль";
            cd = null;
            cd += Register;
        }

        private bool Check()
        {
            if (String.IsNullOrEmpty( tbLogin.Text ) && String.IsNullOrEmpty( tbPass.Text ))
            {
                MessageBox.Show( "Логин или пароль не могут быть пустыми", "Предупреждение" );
                return false;
            }
            return true;
        }

        private void Clear()
        {
            tbLogin.Text = "";
            tbPass.Text = "";
        }
    }
}