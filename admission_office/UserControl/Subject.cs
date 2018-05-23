using System.Windows.Forms;

namespace admission_office
{
    public partial class Subject : UserControl
    {
        private static Subject _instance;

        public static Subject Instance
        {
            get
            {
                if (_instance == null) _instance = new Subject();
                return _instance;
            }
        }
        public Subject()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            tbSubject.Text = "";
        }

        private void btnSave_Click( object sender, System.EventArgs e )
        {
            if (tbSubject.Text.Length != 0)
                if (AOffice.Instance.Create_subject(tbSubject.Text))
                    Clear();
        }
    }
}
