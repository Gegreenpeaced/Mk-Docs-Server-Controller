using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mk_Docs_Server
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            // Select combobox Editor Entry from Settings file variable EditorID and display it
            
            if (Properties.Settings.Default.EditorID == 0)  // 1 = Atom
            {
                cbEditors.SelectedIndex = 0;
            }
            if (Properties.Settings.Default.EditorID == 1) // 1 = Visual Studio Code
            {
                cbEditors.SelectedIndex = 1;
            }
            if (Properties.Settings.Default.EditorID == 2) // 2 = Other
            {
                cbEditors.SelectedIndex = 2;
            }

            tbEditorDownloadURL.Text = Properties.Settings.Default.EditorID.ToString();

        }

        // If cbEditors is changed, check if SelectedIndex is 2
        private void cbEditors_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbEditorDownloadURL.Text = Properties.Settings.Default.EditorID.ToString();
            if (cbEditors.SelectedIndex == 2)
            {
                // If SelectedIndex is 2, show the textbox and label
                tbEditorDownloadURL.Enabled = true;
            }
            else
            {
                // If SelectedIndex is not 2, hide the textbox and label
                tbEditorDownloadURL.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string message = "You will need to restart the Application!";
            string title = "Warning!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.EditorDownloadURL = tbEditorDownloadURL.Text;
            Properties.Settings.Default.EditorID = cbEditors.SelectedIndex;
            Properties.Settings.Default.Save();
        }
    }
}
