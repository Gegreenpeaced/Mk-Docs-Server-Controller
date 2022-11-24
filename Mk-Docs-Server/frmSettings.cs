using System;
using System.Windows.Forms;

namespace Mk_Docs_Server
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            // Load Version number
            lblVersion.Text = Link.GetVersion();


            // Select combobox Editor Entry from Settings file variable EditorID and display it
            
            if (Properties.Settings.Default.EditorID == 0)  // 1 = Atom
            {
                cbEditors.SelectedIndex = 0;
                tbEditorDownloadURL.Enabled = false;
                lblEditorDownload.Text = "Not Available:";
            }
            if (Properties.Settings.Default.EditorID == 1) // 1 = Visual Studio Code
            {
                cbEditors.SelectedIndex = 1;
                tbEditorDownloadURL.Enabled = false;
                lblEditorDownload.Text = "Not Available:";
            }
            if (Properties.Settings.Default.EditorID == 2) // 2 = Notepad++
            {
                cbEditors.SelectedIndex = 2;
                tbEditorDownloadURL.Enabled = false;
                lblEditorDownload.Text = "Not Available:";
            }
            if (Properties.Settings.Default.EditorID == 3) // 3 = URL
            {
                cbEditors.SelectedIndex = 3;
                tbEditorDownloadURL.Text = Properties.Settings.Default.EditorDownloadURL;
                tbEditorDownloadURL.Enabled = true;
                lblEditorDownload.Text = "Editor ZipFile Download URL (other):";
            }
            if (Properties.Settings.Default.EditorID == 4) // 4 = Editor
            {
                cbEditors.SelectedIndex = 4;
                tbEditorDownloadURL.Enabled = false;
                lblEditorDownload.Text = "Not Available:";
            }
            if (Properties.Settings.Default.EditorID == 5) // 5 = Filepath
            {
                cbEditors.SelectedIndex = 5;
                tbEditorDownloadURL.Text = Properties.Settings.Default.EditorDownloadURL;
                tbEditorDownloadURL.Enabled = true;
                lblEditorDownload.Text = "Path to the executeable:";
            }
        }

        // If cbEditors is changed, check if SelectedIndex is 3 or 5
        private void cbEditors_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbEditorDownloadURL.Enabled = false;
            lblEditorDownload.Text = "Not Available:";

            if (cbEditors.SelectedIndex == 3) // Option if you selected to download a path
            {
                tbEditorDownloadURL.Enabled = true;
                lblEditorDownload.Text = "Editor ZipFile Download URL (other):";
            }
            if (cbEditors.SelectedIndex == 5) // Option to select a executeable
            {
                tbEditorDownloadURL.Enabled = true;
                lblEditorDownload.Text = "Path to the executeable:";
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
            if(cbEditors.SelectedIndex == 3) // URL Editor
            {
                if(tbEditorDownloadURL.Text == "") 
                {
                    string message = "Please specify a valid URL";
                    string title = "Error!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                }
                else
                {
                    Properties.Settings.Default.EditorDownloadURL = tbEditorDownloadURL.Text;
                    Properties.Settings.Default.EditorID = cbEditors.SelectedIndex;
                    Properties.Settings.Default.Save();
                }
            }
            if(cbEditors.SelectedIndex == 5)  // Filepath Editor
            {
                if (tbEditorDownloadURL.Text == "")
                {
                    string message = "Please specify a Path to a valid executeable!";
                    string title = "Error!";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                }
                else
                {
                    Properties.Settings.Default.EditorDownloadURL = tbEditorDownloadURL.Text;
                    Properties.Settings.Default.EditorID = cbEditors.SelectedIndex;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                Properties.Settings.Default.EditorID = cbEditors.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }
    }
}
