using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admission_office
{
    class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }

        public ComboBoxItem( int value, string text)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
