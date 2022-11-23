
namespace Mk_Docs_Server
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnInstallServer = new System.Windows.Forms.Button();
            this.gbWorkspace = new System.Windows.Forms.GroupBox();
            this.btnInstallAll = new System.Windows.Forms.Button();
            this.btnSaveWorkspaceFiles = new System.Windows.Forms.Button();
            this.btnInstallWorkspaceFiles = new System.Windows.Forms.Button();
            this.btnInstallVSC = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.btnServeServer = new System.Windows.Forms.Button();
            this.gbWorkspace.SuspendLayout();
            this.gbPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(343, 185);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(75, 23);
            this.btnSettings.TabIndex = 0;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnInstallServer
            // 
            this.btnInstallServer.Location = new System.Drawing.Point(6, 48);
            this.btnInstallServer.Name = "btnInstallServer";
            this.btnInstallServer.Size = new System.Drawing.Size(188, 23);
            this.btnInstallServer.TabIndex = 2;
            this.btnInstallServer.Text = "Server installieren";
            this.btnInstallServer.UseVisualStyleBackColor = true;
            // 
            // gbWorkspace
            // 
            this.gbWorkspace.Controls.Add(this.btnInstallAll);
            this.gbWorkspace.Controls.Add(this.btnSaveWorkspaceFiles);
            this.gbWorkspace.Controls.Add(this.btnInstallWorkspaceFiles);
            this.gbWorkspace.Controls.Add(this.btnInstallVSC);
            this.gbWorkspace.Controls.Add(this.btnInstallServer);
            this.gbWorkspace.Location = new System.Drawing.Point(218, 12);
            this.gbWorkspace.Name = "gbWorkspace";
            this.gbWorkspace.Size = new System.Drawing.Size(200, 167);
            this.gbWorkspace.TabIndex = 3;
            this.gbWorkspace.TabStop = false;
            this.gbWorkspace.Text = "Arbeitsumgebung";
            // 
            // btnInstallAll
            // 
            this.btnInstallAll.Location = new System.Drawing.Point(6, 19);
            this.btnInstallAll.Name = "btnInstallAll";
            this.btnInstallAll.Size = new System.Drawing.Size(188, 23);
            this.btnInstallAll.TabIndex = 6;
            this.btnInstallAll.Text = "Alles installieren";
            this.btnInstallAll.UseVisualStyleBackColor = true;
            this.btnInstallAll.Click += new System.EventHandler(this.btnInstallAll_Click);
            // 
            // btnSaveWorkspaceFiles
            // 
            this.btnSaveWorkspaceFiles.Location = new System.Drawing.Point(6, 135);
            this.btnSaveWorkspaceFiles.Name = "btnSaveWorkspaceFiles";
            this.btnSaveWorkspaceFiles.Size = new System.Drawing.Size(188, 23);
            this.btnSaveWorkspaceFiles.TabIndex = 5;
            this.btnSaveWorkspaceFiles.Text = "Arbeitsdateien exportieren";
            this.btnSaveWorkspaceFiles.UseVisualStyleBackColor = true;
            this.btnSaveWorkspaceFiles.Click += new System.EventHandler(this.btnSaveWorkspaceFiles_Click);
            // 
            // btnInstallWorkspaceFiles
            // 
            this.btnInstallWorkspaceFiles.Location = new System.Drawing.Point(6, 106);
            this.btnInstallWorkspaceFiles.Name = "btnInstallWorkspaceFiles";
            this.btnInstallWorkspaceFiles.Size = new System.Drawing.Size(188, 23);
            this.btnInstallWorkspaceFiles.TabIndex = 4;
            this.btnInstallWorkspaceFiles.Text = "Arbeitsdateien importieren";
            this.btnInstallWorkspaceFiles.UseVisualStyleBackColor = true;
            this.btnInstallWorkspaceFiles.Click += new System.EventHandler(this.btnInstallWorkspaceFiles_Click);
            // 
            // btnInstallVSC
            // 
            this.btnInstallVSC.Location = new System.Drawing.Point(6, 77);
            this.btnInstallVSC.Name = "btnInstallVSC";
            this.btnInstallVSC.Size = new System.Drawing.Size(188, 23);
            this.btnInstallVSC.TabIndex = 3;
            this.btnInstallVSC.Text = "Editor installieren";
            this.btnInstallVSC.UseVisualStyleBackColor = true;
            this.btnInstallVSC.Click += new System.EventHandler(this.btnInstallVSC_Click);
            // 
            // gbPanel
            // 
            this.gbPanel.Controls.Add(this.btnServeServer);
            this.gbPanel.Location = new System.Drawing.Point(12, 12);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Size = new System.Drawing.Size(200, 167);
            this.gbPanel.TabIndex = 7;
            this.gbPanel.TabStop = false;
            this.gbPanel.Text = "Panel";
            // 
            // btnServeServer
            // 
            this.btnServeServer.Location = new System.Drawing.Point(6, 19);
            this.btnServeServer.Name = "btnServeServer";
            this.btnServeServer.Size = new System.Drawing.Size(188, 23);
            this.btnServeServer.TabIndex = 5;
            this.btnServeServer.Text = "Starte Server";
            this.btnServeServer.UseVisualStyleBackColor = true;
            this.btnServeServer.Click += new System.EventHandler(this.btnServeServer_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 217);
            this.Controls.Add(this.gbPanel);
            this.Controls.Add(this.gbWorkspace);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSettings);
            this.Name = "frmMain";
            this.Text = "MK Docs Server Manager";
            this.gbWorkspace.ResumeLayout(false);
            this.gbPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnInstallServer;
        private System.Windows.Forms.GroupBox gbWorkspace;
        private System.Windows.Forms.Button btnInstallAll;
        private System.Windows.Forms.Button btnSaveWorkspaceFiles;
        private System.Windows.Forms.Button btnInstallWorkspaceFiles;
        private System.Windows.Forms.Button btnInstallVSC;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.Button btnServeServer;
    }
}

