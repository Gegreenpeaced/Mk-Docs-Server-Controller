namespace Mk_Docs_Server
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbEditorSettings = new System.Windows.Forms.GroupBox();
            this.tbEditorDownloadURL = new System.Windows.Forms.TextBox();
            this.lblEditorDownload = new System.Windows.Forms.Label();
            this.cbEditors = new System.Windows.Forms.ComboBox();
            this.lblEditor = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbEditorSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEditorSettings
            // 
            this.gbEditorSettings.Controls.Add(this.tbEditorDownloadURL);
            this.gbEditorSettings.Controls.Add(this.lblEditorDownload);
            this.gbEditorSettings.Controls.Add(this.cbEditors);
            this.gbEditorSettings.Controls.Add(this.lblEditor);
            this.gbEditorSettings.Location = new System.Drawing.Point(12, 12);
            this.gbEditorSettings.Name = "gbEditorSettings";
            this.gbEditorSettings.Size = new System.Drawing.Size(480, 90);
            this.gbEditorSettings.TabIndex = 0;
            this.gbEditorSettings.TabStop = false;
            this.gbEditorSettings.Text = "Editoren";
            // 
            // tbEditorDownloadURL
            // 
            this.tbEditorDownloadURL.Location = new System.Drawing.Point(195, 40);
            this.tbEditorDownloadURL.Name = "tbEditorDownloadURL";
            this.tbEditorDownloadURL.Size = new System.Drawing.Size(279, 20);
            this.tbEditorDownloadURL.TabIndex = 3;
            // 
            // lblEditorDownload
            // 
            this.lblEditorDownload.AutoSize = true;
            this.lblEditorDownload.Location = new System.Drawing.Point(9, 43);
            this.lblEditorDownload.Name = "lblEditorDownload";
            this.lblEditorDownload.Size = new System.Drawing.Size(180, 13);
            this.lblEditorDownload.TabIndex = 2;
            this.lblEditorDownload.Text = "Editor ZipFile Download URL (other):";
            // 
            // cbEditors
            // 
            this.cbEditors.FormattingEnabled = true;
            this.cbEditors.Items.AddRange(new object[] {
            "Atom",
            "Visual Studio Code",
            "Other"});
            this.cbEditors.Location = new System.Drawing.Point(195, 13);
            this.cbEditors.Name = "cbEditors";
            this.cbEditors.Size = new System.Drawing.Size(279, 21);
            this.cbEditors.TabIndex = 1;
            this.cbEditors.SelectedIndexChanged += new System.EventHandler(this.cbEditors_SelectedIndexChanged);
            // 
            // lblEditor
            // 
            this.lblEditor.AutoSize = true;
            this.lblEditor.Location = new System.Drawing.Point(9, 16);
            this.lblEditor.Name = "lblEditor";
            this.lblEditor.Size = new System.Drawing.Size(138, 13);
            this.lblEditor.TabIndex = 0;
            this.lblEditor.Text = "Select your preferred Editor:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 267);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(417, 267);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblVersion);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(480, 90);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informationen";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 16);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(104, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Aktuelle Version: 0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Author: Julius Reiter";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 300);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbEditorSettings);
            this.Name = "frmSettings";
            this.Text = "Einstellungen";
            this.gbEditorSettings.ResumeLayout(false);
            this.gbEditorSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbEditorSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblEditor;
        private System.Windows.Forms.ComboBox cbEditors;
        private System.Windows.Forms.TextBox tbEditorDownloadURL;
        private System.Windows.Forms.Label lblEditorDownload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label2;
    }
}