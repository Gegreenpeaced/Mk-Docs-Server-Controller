using System;
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
            InstallVSC();
        }

        private void btnInstallAll_Click(object sender, EventArgs e)
        {
            InstallMKDocsServer();
            InstallVSC();
            OpenWorkspacePath();

        }

        private void btnInstallWorkspaceFiles_Click(object sender, EventArgs e)
        {
            OpenWorkspacePath();
        }

        private void btnSaveWorkspaceFiles_Click(object sender, EventArgs e)
        {
            ZipWorkspaceFiles();
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


        public bool InstallMKDocsServer()
        {
            // rund cmd.exe /c mkdocsserverinstallcommand
            System.Diagnostics.Process.Start("cmd.exe", "/c " + mkdocsserverinstallcommand);
            return true;
        }

        public bool InstallVSC()
        {
            // Download file from atomDownloadPath to /Files/atom-portable.zip and extract it to /Files/atom-portable
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(atomDownloadPath, Application.StartupPath + "\\Files\\atom-portable.zip");
            }
            ZipFile.ExtractToDirectory(Application.StartupPath + "\\Files\\atom-portable.zip", Application.StartupPath + "\\Files\\atom-portable");
            // Delete /Files/atom-portable.zip
            File.Delete(Application.StartupPath + "\\Files\\atom-portable.zip");
            string message = "Editor installed. Do you want to start it?";
            string title = "Sucessfully installed";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Success);
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(Application.StartupPath + "\\Files\\atom-portable\\AtomPortable.exe");
            }
            return true;
        }

        public bool OpenWorkspacePath()
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog // File Dialog spezifizieren
                {
                    InitialDirectory = @"D:\",
                    Title = "Gezippte Arbeitsdateien",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "zip",
                    Filter = "zip files (*.zip)|*.zip",
                    FilterIndex = 2,
                    RestoreDirectory = true,

                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK) // Arbeitspfad angeben
                {
                    WorkspacePath = openFileDialog1.FileName;

                    using (var unzip = new Internals.Unzip(WorkspacePath))
                    {
                        unzip.ExtractToDirectory("/Files/mkdocs"); // Datein entpacken und kopieren
                    }
                    return true;
                }

                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ZipWorkspaceFiles()
        {
            string ZipFileName = "/Files/" + DateTime.Now.ToString("ddMMyyyy-HHmmssfffff") + ".zip"; // Name des Zip Files
            string PathToZip; // Pfad zum Zippen

            DialogResult result = folderBrowserDialog1.ShowDialog(); // Auswahl des Speicherpfades
            //to check user pressed OK button or CANCEL button in show dialog  
            if (result == DialogResult.OK)
            {
                //Paste the selected folder path to textbox  
                PathToZip = folderBrowserDialog1.SelectedPath;
                ZipFile.CreateFromDirectory(PathToZip, ZipFileName); // zippen der Datei
                return true;
            }
            return false;
        }
    }
}
