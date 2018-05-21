using System;
using System.Windows.Forms;

namespace admission_office
{
    public partial class Form1 : Form
    {
        private LogAuthorize _logAuto = new LogAuthorize();
        private readonly string[] _connStr = { "server=localhost;user=root;database=admission_office;password=12345687", "server=localhost;user=root;database=admission_office_archive;password=12345687" };
        public Form1()
        {
            InitializeComponent();
            Text = "Авторизация";
            ConnectionString.Connection = _connStr[0];
            cbSelectDB.SelectedIndex = 0;
        }

        private void btnAuthorize_Click( object sender, EventArgs e )
        {
            //if (Check())
            //{
            //    if (log_auto.Authorize( tbLogin.Text, tbPass.Text))
            //    {
                    Hide();
                    var program = new Form2();
                    program.ShowDialog();
            //    }
            //}
           
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            if (Check())
            {
                MessageBox.Show( _logAuto.Register( tbLogin.Text, tbPass.Text ), "Сообщение" );
            }
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
    }
}