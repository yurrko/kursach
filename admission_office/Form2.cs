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

        private void создатьToolStripMenuItem2_Click( object sender, System.EventArgs e )
        {
            if (!panel.Controls.Contains( Subject.Instance ))
            {
                panel.Controls.Add( Subject.Instance );
                Subject.Instance.Dock = DockStyle.Fill;
            }
            Subject.Instance.BringToFront();
        }

        private void Form2_FormClosed( object sender, FormClosedEventArgs e )
        {
            Application.Exit();
        }

        private void отчётToolStripMenuItem_Click( object sender, System.EventArgs e )
        {
            AOffice.Instance.Create_report();
        }

        private void добавитьToolStripMenuItem_Click( object sender, System.EventArgs e )
        {
            Owner.Visible = true;
            Visible = false;
        }
    }
}
