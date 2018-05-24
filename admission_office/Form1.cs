using System;
using System.Windows.Forms;

namespace admission_office
{
    public partial class Form1 : Form
    {
        Form2 program = new Form2();
        private LogAuthorize _logAuto = new LogAuthorize();
        private readonly string[] _connStr = { "server=localhost;user=root;database=admission_office;password=12345687", "server=localhost;user=root;database=admission_office_archive;password=12345687" };
        public Form1()
        {
            InitializeComponent();
            Text = "Авторизация";
            ConnectionString.Connection = _connStr[0];
            cbSelectDB.SelectedIndex = 0;
            btnRegister.Hide();
            program.Owner = this;
        }

        private void btnAuthorize_Click( object sender, EventArgs e )
        {
            //if (Check())
            //{
            //    if (log_auto.Authorize( tbLogin.Text, tbPass.Text))
            //    {
                    Hide();
                    program.ShowDialog();
                    Register_mode();
            //    }
            //}
           
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            if (Check())
            {
               if( _logAuto.Register( tbLogin.Text, tbPass.Text, cbSelectDB.SelectedIndex )) { 
                    Clear();
                    Visible = false;
                    program.Visible = true;
                }
            }
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

        private void cbSelectDB_SelectedIndexChanged( object sender, EventArgs e )
        {
            ConnectionString.Connection = _connStr[cbSelectDB.SelectedIndex];
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            tbLogin.Select();
        }

        private void Register_mode()
        {
            Text = "Регистрация";
            btnAuthorize.Hide();
            btnRegister.Show();
            cbSelectDB.Items.Clear();
            cbSelectDB.SelectedIndexChanged -= new EventHandler( cbSelectDB_SelectedIndexChanged );
            cbSelectDB.Items.AddRange( new string[] { "Админ", "Член комиссии", "Секретарь" } );
            lblSelectDB.Text = "Роль";
        }
    }
}