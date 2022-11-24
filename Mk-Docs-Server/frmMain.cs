﻿using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace Mk_Docs_Server
{
    public partial class frmMain : Form
    {
        // ---------------
        // Global Variables
        // ---------------


        public string editorDownloadPath;
        public string workspacePath;


        // ----------------
        // Main Form
        // ----------------

        public frmMain()
        { 
            // Create Files folder in Application Path if not exsistant
            if (!Directory.Exists(Application.StartupPath + "\\Files"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Files");
            }
            // Create Files/mkdocs folder in Application Path if not exsistant
            if (!Directory.Exists(Application.StartupPath + "\\Files\\mkdocs"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Files\\mkdocs");
            }
            InitializeComponent();
        }


        // ----------------
        // Form Buttons
        // ----------------

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Open Settings Form
            frmSettings frmSettings = new frmSettings();
            frmSettings.Show();
        }

        private void btnServeServer_Click(object sender, EventArgs e)
        {
            if (ServeServer(true) == 3)
            {
                string message2 = "MkDocs Server was not installed. Please install it first.";
                string title2 = "MkDocs Server not installed";
                MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Error);
            }
        }

        private void btnInstallEditor_Click(object sender, EventArgs e)
        {
            InstallEditor(true);
        }

        private void btnInstallAll_Click(object sender, EventArgs e)
        {
            InstallMKDocsServer(false);
            InstallEditor(false);
            OpenWorkspacePath(false);
            string message = "Everything was sucessfully installed.";
            string title = "Sucessfully installed";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            if (DialogResult.Yes == result)
            {
                // if ServeServer(true) returns 3, then mkdocs server was not installed
                if (ServeServer(true) == 3)
                {
                    string message2 = "MkDocs Server was not installed. Please install it first.";
                    string title2 = "MkDocs Server not installed";
                    MessageBoxButtons buttons2 = MessageBoxButtons.OK;
                    DialogResult result2 = MessageBox.Show(message2, title2, buttons2, MessageBoxIcon.Error);
                }


            }
        }

        private void btnInstallWorkspaceFiles_Click(object sender, EventArgs e)
        {
            OpenWorkspacePath(true);
        }

        private void btnSaveWorkspaceFiles_Click(object sender, EventArgs e)
        {
            ZipWorkspaceFiles(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            string message = "Do you really want to close the Application?";
            string title = "Close Application?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ----------------
        // Methods
        // ----------------

        public int ServeServer(bool ms)
        {
            // Check if mkdocsokfile is exsistant in mkdocs folder
            if (File.Exists(Application.StartupPath + "\\Files\\mkdocs\\mkdocsokfile.file"))
            {
                // open file dialog to select folder to serve
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select the folder you want to serve";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // open cmd and serve selected folder
                    System.Diagnostics.Process.Start("cmd.exe", "/c mkdocs serve -a" + fbd.SelectedPath);
                    if (ms == true)
                    {
                        string message = "The Server is now running.";
                        string title = "Server running";
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    }
                    return 1;
                }
                else
                {
                    // Promt message box with invalid folder
                    string message = "The selected folder is invalid. Try again";
                    string title = "Invalid folder";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Error);
                }
            }
            return 3;
        }

        public bool InstallMKDocsServer(bool ms)
        {
            // rund cmd.exe /c mkdocsserverinstallcommand
            System.Diagnostics.Process.Start("cmd.exe", "/c " + Link.downloadCommandMKDocs());
            // Create mkdocsokfile
            File.Create(Application.StartupPath + "\\Files\\mkdocs\\mkdocsokfile.file");
            if (ms)
            {
                string message = "Server installed.";
                string title = "Sucessfully installed";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            return true;
        }

        public bool InstallEditor(bool ms)
        {
            // Download file from atomDownloadPath to /Files/atom-portable.zip and extract it to /Files/atom-portable
            if (Properties.Settings.Default.EditorID == 4)
            {
                // EDITOR (Windows)
            }
            if (Properties.Settings.Default.EditorID == 5)
            {
                // FILEPATH (Windows)
            }
            else // IF EDITOR NEEDS TO BE DOWNLOADED
            {
                using (WebClient client = new WebClient())
                {
                    if (Properties.Settings.Default.EditorID == 0) // Download für Atom
                    {
                        editorDownloadPath = Link.downloadPathAtom();
                        client.DownloadFile(editorDownloadPath, Application.StartupPath + "\\Files\\editor-portable.zip");
                    }
                    if (Properties.Settings.Default.EditorID == 1) // Download für VSC
                    {
                        editorDownloadPath = Link.downloadPathVSC();
                        client.DownloadFile(editorDownloadPath, Application.StartupPath + "\\Files\\editor-portable.zip");
                    }
                    if (Properties.Settings.Default.EditorID == 2) // Download für Notepad++
                    {
                        editorDownloadPath = Link.dowloadPathNotepadPP();
                        client.DownloadFile(editorDownloadPath, Application.StartupPath + "\\Files\\editor-portable.zip");
                    }
                    if(Properties.Settings.Default.EditorID == 3) // Download für den Spezifizierten Editor
                    {
                        editorDownloadPath = Properties.Settings.Default.EditorDownloadURL;
                        client.DownloadFile(editorDownloadPath, Application.StartupPath + "\\Files\\editor-portable.zip");
                    }
                }

                ZipFile.ExtractToDirectory(Application.StartupPath + "\\Files\\editor-portable.zip", Application.StartupPath + "\\Files\\editor-portable");
                // Delete /Files/editor-portable.zip
                File.Delete(Application.StartupPath + "\\Files\\editor-portable.zip");
                // Message Box Check
                if (ms)
                {
                    string message = "Editor installed. Do you want to start it?";
                    string title = "Sucessfully installed";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(Application.StartupPath + "\\Files\\editor-portable\\editor.exe");
                    }
                }
            }
            return true;
        }

        public bool OpenWorkspacePath(bool ms)
        {
            // Open zip file in filedialog and store in WorkspacePath
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Zip Files|*.zip";
            openFileDialog1.Title = "Select a Zip File";
            openFileDialog1.ShowDialog();
            workspacePath = openFileDialog1.FileName;
            // Extract zip file to /Files/mkdocs
            ZipFile.ExtractToDirectory(workspacePath, Application.StartupPath + "\\Files\\mkdocs");
            // Message Box Check
            if (ms == true)
            {
                string message = "Workspace files installed.";
                string title = "Sucessfully installed";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);

            }
            return true;
        }

        public bool ZipWorkspaceFiles(bool ms)
        {
            // Select Path to Zip mkdocs to
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.ShowDialog();
            string ZipPath = folderBrowserDialog1.SelectedPath;
            // Zip /Files/mkdocs to ZipPath with date and time
            ZipFile.CreateFromDirectory(Application.StartupPath + "\\Files\\mkdocs", ZipPath + "\\mkdocs-" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".zip");
            // Message Box Check
            if (ms == true)
            {
                string message = "Workspace sucessfully exported.";
                string title = "Sucessfully exported";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            return true;
        }
    }
}
