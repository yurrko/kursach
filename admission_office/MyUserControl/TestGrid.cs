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
    public partial class TestGrid : UserControl
    {
        private static TestGrid _instance;

        public static TestGrid Instance
        {
            get
            {
                if (_instance == null) _instance = new TestGrid();
                return _instance;
            }
        }

        private TestGrid()
        {
            InitializeComponent();
            var ds = new DataSet();
            ds = DBDriver.Instance.SelectValuesDataSet(SqlQueryList.Queries[(int) SqlQueryNum.Report]);
            dgvEntrants.DataSource = ds.Tables[0];
        }
    }
}
