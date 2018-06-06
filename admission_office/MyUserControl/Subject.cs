using System;
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
            if (!String.IsNullOrEmpty( tbSubject.Text )) 
                if (AOffice.Instance.Create_subject(tbSubject.Text))
                    Clear();
        }
    }
}
