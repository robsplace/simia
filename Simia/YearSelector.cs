using System;
using System.Windows.Forms;

namespace Simia
{
    public partial class YearSelector : Form
    {
        public int Year
        {
            get
            {
                return (int)numericUpDownYear.Value;
            }
            set
            {
                numericUpDownYear.Value = value;
            }
        }

        public YearSelector()
        {
            InitializeComponent();
            numericUpDownYear.Maximum = DateTime.Now.Year;
        }

        private void Create(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
