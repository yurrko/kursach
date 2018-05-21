using System.Windows.Forms;

namespace admission_office
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click( object sender, System.EventArgs e )
        {
            Application.Exit();
        }

        private void создатьToolStripMenuItem_Click( object sender, System.EventArgs e )
        {
            if (!panel.Controls.Contains(NewEntrant.Instance))
            {
                panel.Controls.Add(NewEntrant.Instance);
                NewEntrant.Instance.Dock = DockStyle.Fill;
            }
            NewEntrant.Instance.BringToFront();
        }

        private void создатьToolStripMenuItem1_Click( object sender, System.EventArgs e )
        {
            if (!panel.Controls.Contains( Speciality.Instance ))
            {
                panel.Controls.Add( Speciality.Instance );
                Speciality.Instance.Dock = DockStyle.Fill;
            }
            Speciality.Instance.BringToFront();
        }
    }
}
