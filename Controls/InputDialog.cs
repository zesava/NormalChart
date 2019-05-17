using System;
using System.Windows.Forms;

namespace NormalChart
{
    public partial class InputDialog : Form
    {
        public string ResultText { get; private set; }

        public InputDialog(string title, string label_text, string textbox_string)
        {
            InitializeComponent();
            this.Text = title;
            this.lblInput.Text = label_text;
            this.txtInput.Text = textbox_string;
        }

        public InputDialog()
        {
            InitializeComponent();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            if (txtInput.Text.Trim().Length > 0)
            {
                btnOk.Enabled = true;
            }
            else
            {
                btnOk.Enabled = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ResultText = txtInput.Text.Trim();
        }
    }
}
