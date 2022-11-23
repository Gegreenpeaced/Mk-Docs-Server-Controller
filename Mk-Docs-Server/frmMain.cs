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
        public string atomDownloadPath = "https://nxcloud.norku.de/index.php/s/4QWfpGcrzs8mjEC";
        public string mkdocsServerDownloadPath = "&nbsp;"
        public string WorkspacePath;


        // ----------------
        // Main Form
        // ----------------

        public frmMain()
        {
            if (!System.IO.Directory.Exists("/Files")) // Datei ordner erstellen wenn nicht vorhanden
            {
                System.IO.Directory.CreateDirectory("/Files");
            }
                if (!System.IO.Directory.Exists("/Files/mkdocs")) // mk docs ordner erstellen wenn nicht vorhanden
            {
                System.IO.Directory.CreateDirectory("/Files/mkdocs");
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


        // ----------------
        // Methods
        // ----------------


        public bool InstallMKDocsServer()
        {
            Application.Run(/*script.bat -mkdocs*/); // mkdocs mit pip3 installieren
            return true;
        }

        public bool InstallVSC()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.DownloadFile(atomDownloadPath, "/Files/atom-portable.zip");  // VSC Downloaden

                using (var unzip = new Internals.Unzip("/Files/atom-portable.zip"))  // VSC entpacken
                {
                    unzip.ExtractToDirectory("/Files");
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
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
