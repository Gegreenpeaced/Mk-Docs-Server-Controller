﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;
using System.IO;

namespace Mk_Docs_Server
{
    public partial class frmMain : Form
    {
        // ---------------
        // Global Variables
        // ---------------
        public string atomDownloadPath = "https://nxcloud.norku.de/index.php/s/oiaEg8KdjB4j9qL/download/atom-editor.zip";
        public string mkdocsserverinstallcommand = "pip --proxy http://kjs-03.lan.dd-schulen.de:3128 install mkdocs mkdocs-material break";
        public string WorkspacePath;


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

        private void btnInstallVSC_Click(object sender, EventArgs e)
        {
            InstallVSC(true);
        }

        private void btnInstallAll_Click(object sender, EventArgs e)
        {
            InstallMKDocsServer(false);
            InstallVSC(false);
            OpenWorkspacePath(false);
            string message = "Everything was sucessfully installed.";
            string title = "Sucessfully installed";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
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


        public bool InstallMKDocsServer(bool ms)
        {
            // rund cmd.exe /c mkdocsserverinstallcommand
            System.Diagnostics.Process.Start("cmd.exe", "/c " + mkdocsserverinstallcommand);
            if (ms)
            {
                string message = "Server installed.";
                string title = "Sucessfully installed";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
            }
            return true;
        }

        public bool InstallVSC(bool ms)
        {
            // Download file from atomDownloadPath to /Files/atom-portable.zip and extract it to /Files/atom-portable
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(atomDownloadPath, Application.StartupPath + "\\Files\\atom-portable.zip");
            }
            ZipFile.ExtractToDirectory(Application.StartupPath + "\\Files\\atom-portable.zip", Application.StartupPath + "\\Files\\atom-portable");
            // Delete /Files/atom-portable.zip
            File.Delete(Application.StartupPath + "\\Files\\atom-portable.zip");
            // Message Box Check
            if (ms)
            {
                string message = "Editor installed. Do you want to start it?";
                string title = "Sucessfully installed";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(Application.StartupPath + "\\Files\\atom-portable\\AtomPortable.exe");
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
            WorkspacePath = openFileDialog1.FileName;
            // Extract zip file to /Files/mkdocs
            ZipFile.ExtractToDirectory(WorkspacePath, Application.StartupPath + "\\Files\\mkdocs");
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
