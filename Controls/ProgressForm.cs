using System;
using System.Windows.Forms;

namespace NormalChart
{
    public partial class ProgressForm : Form
    {

        #region PROPERTIES

        public string Message
        {
            set { labelMessage.Text = value; }
        }

        public int ProgressValue
        {
            set { progressBar1.Value = value; }
        }

        public bool Done
        {
            set
            {
                buttonCancel.Visible = false;
                btnOK.Visible = true;
                progressBar1.Style = ProgressBarStyle.Continuous;
                progressBar1.Value = 100;
            }
        }

        #endregion

        #region METHODS

        public ProgressForm()
        {
            InitializeComponent();
        }

        #endregion

        #region EVENTS

        public event EventHandler<EventArgs> Canceled;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Create a copy of the event to work with
            EventHandler<EventArgs> ea = Canceled;
            /* If there are no subscribers, eh will be null so we need to check
             * to avoid a NullReferenceException. */
            if (ea != null)
                ea(this, e);
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
