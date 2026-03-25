namespace WLDL
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileReset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPath = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPathChange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPathReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLangDe = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLangEn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInfoCredits = new System.Windows.Forms.ToolStripMenuItem();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.lblSecurityInfo = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.rbStoreServer = new System.Windows.Forms.RadioButton();
            this.rbUpdateServer = new System.Windows.Forms.RadioButton();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.lblVer = new System.Windows.Forms.Label();
            this.btnFetch = new System.Windows.Forms.Button();
            this.chkPackages = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSelectNone = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.bgwFetch = new System.ComponentModel.BackgroundWorker();
            this.bgwDownload = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuPath,
            this.menuLang,
            this.menuInfo});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileReset,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(46, 20);
            this.menuFile.Text = "Datei";
            // 
            // menuFileReset
            // 
            this.menuFileReset.Image = ((System.Drawing.Image)(resources.GetObject("menuFileReset.Image")));
            this.menuFileReset.Name = "menuFileReset";
            this.menuFileReset.Size = new System.Drawing.Size(152, 22);
            this.menuFileReset.Text = "Zurücksetzen";
            this.menuFileReset.Click += new System.EventHandler(this.menuFileReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Image = ((System.Drawing.Image)(resources.GetObject("menuFileExit.Image")));
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(152, 22);
            this.menuFileExit.Text = "Beenden";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuPath
            // 
            this.menuPath.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPathChange,
            this.menuPathReset});
            this.menuPath.Name = "menuPath";
            this.menuPath.Size = new System.Drawing.Size(43, 20);
            this.menuPath.Text = "Pfad";
            // 
            // menuPathChange
            // 
            this.menuPathChange.Image = ((System.Drawing.Image)(resources.GetObject("menuPathChange.Image")));
            this.menuPathChange.Name = "menuPathChange";
            this.menuPathChange.Size = new System.Drawing.Size(226, 22);
            this.menuPathChange.Text = "Ausgabeordner ändern...";
            this.menuPathChange.Click += new System.EventHandler(this.menuPathChange_Click);
            // 
            // menuPathReset
            // 
            this.menuPathReset.Image = ((System.Drawing.Image)(resources.GetObject("menuPathReset.Image")));
            this.menuPathReset.Name = "menuPathReset";
            this.menuPathReset.Size = new System.Drawing.Size(226, 22);
            this.menuPathReset.Text = "Ausgabeordner zurücksetzen";
            this.menuPathReset.Click += new System.EventHandler(this.menuPathReset_Click);
            // 
            // menuLang
            // 
            this.menuLang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLangDe,
            this.menuLangEn});
            this.menuLang.Name = "menuLang";
            this.menuLang.Size = new System.Drawing.Size(61, 20);
            this.menuLang.Text = "Sprache";
            // 
            // menuLangDe
            // 
            this.menuLangDe.Name = "menuLangDe";
            this.menuLangDe.Size = new System.Drawing.Size(152, 22);
            this.menuLangDe.Text = "Deutsch";
            this.menuLangDe.Click += new System.EventHandler(this.menuLangDe_Click);
            // 
            // menuLangEn
            // 
            this.menuLangEn.Name = "menuLangEn";
            this.menuLangEn.Size = new System.Drawing.Size(152, 22);
            this.menuLangEn.Text = "English";
            this.menuLangEn.Click += new System.EventHandler(this.menuLangEn_Click);
            // 
            // menuInfo
            // 
            this.menuInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuInfoCredits});
            this.menuInfo.Name = "menuInfo";
            this.menuInfo.Size = new System.Drawing.Size(40, 20);
            this.menuInfo.Text = "Info";
            // 
            // menuInfoCredits
            // 
            this.menuInfoCredits.Image = ((System.Drawing.Image)(resources.GetObject("menuInfoCredits.Image")));
            this.menuInfoCredits.Name = "menuInfoCredits";
            this.menuInfoCredits.Size = new System.Drawing.Size(152, 22);
            this.menuInfoCredits.Text = "Info / Credits";
            this.menuInfoCredits.Click += new System.EventHandler(this.menuInfoCredits_Click);
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.lblSecurityInfo);
            this.grpConfig.Controls.Add(this.txtPass);
            this.grpConfig.Controls.Add(this.lblPass);
            this.grpConfig.Controls.Add(this.txtUser);
            this.grpConfig.Controls.Add(this.lblUser);
            this.grpConfig.Controls.Add(this.rbStoreServer);
            this.grpConfig.Controls.Add(this.rbUpdateServer);
            this.grpConfig.Controls.Add(this.cbVersion);
            this.grpConfig.Controls.Add(this.lblVer);
            this.grpConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpConfig.Location = new System.Drawing.Point(12, 35);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(610, 215);
            this.grpConfig.TabIndex = 1;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Konfiguration";
            // 
            // lblSecurityInfo
            // 
            this.lblSecurityInfo.AutoSize = true;
            this.lblSecurityInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblSecurityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecurityInfo.ForeColor = System.Drawing.Color.DimGray;
            this.lblSecurityInfo.Location = new System.Drawing.Point(157, 185);
            this.lblSecurityInfo.Name = "lblSecurityInfo";
            this.lblSecurityInfo.Size = new System.Drawing.Size(244, 13);
            this.lblSecurityInfo.TabIndex = 8;
            this.lblSecurityInfo.Text = "Hinweis: Zugangsdaten werden nicht gespeichert.";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(160, 155);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(300, 20);
            this.txtPass.TabIndex = 7;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPass.Location = new System.Drawing.Point(20, 158);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(130, 15);
            this.lblPass.TabIndex = 6;
            this.lblPass.Text = "Serien-Nr.:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(160, 125);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(300, 20);
            this.txtUser.TabIndex = 5;
            // 
            // lblUser
            // 
            this.lblUser.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblUser.Location = new System.Drawing.Point(20, 128);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(130, 15);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Lizenz-Nr.:";
            // 
            // rbStoreServer
            // 
            this.rbStoreServer.AutoSize = true;
            this.rbStoreServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbStoreServer.Location = new System.Drawing.Point(160, 90);
            this.rbStoreServer.Name = "rbStoreServer";
            this.rbStoreServer.Size = new System.Drawing.Size(156, 18);
            this.rbStoreServer.TabIndex = 3;
            this.rbStoreServer.Text = "Store Server (Plugin Store)";
            this.rbStoreServer.UseVisualStyleBackColor = true;
            // 
            // rbUpdateServer
            // 
            this.rbUpdateServer.AutoSize = true;
            this.rbUpdateServer.Checked = true;
            this.rbUpdateServer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.rbUpdateServer.Location = new System.Drawing.Point(160, 65);
            this.rbUpdateServer.Name = "rbUpdateServer";
            this.rbUpdateServer.Size = new System.Drawing.Size(200, 18);
            this.rbUpdateServer.TabIndex = 2;
            this.rbUpdateServer.TabStop = true;
            this.rbUpdateServer.Text = "Update Server (WCF/WBB Pakete)";
            this.rbUpdateServer.UseVisualStyleBackColor = true;
            this.rbUpdateServer.CheckedChanged += new System.EventHandler(this.ServerType_CheckedChanged);
            // 
            // cbVersion
            // 
            this.cbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVersion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Location = new System.Drawing.Point(160, 30);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(300, 21);
            this.cbVersion.TabIndex = 1;
            // 
            // lblVer
            // 
            this.lblVer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblVer.Location = new System.Drawing.Point(20, 33);
            this.lblVer.Name = "lblVer";
            this.lblVer.Size = new System.Drawing.Size(130, 15);
            this.lblVer.TabIndex = 0;
            this.lblVer.Text = "WCF/WSC Version:";
            // 
            // btnFetch
            // 
            this.btnFetch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnFetch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetch.Location = new System.Drawing.Point(12, 260);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(610, 35);
            this.btnFetch.TabIndex = 2;
            this.btnFetch.Text = "Paketliste abrufen";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // chkPackages
            // 
            this.chkPackages.CheckOnClick = true;
            this.chkPackages.FormattingEnabled = true;
            this.chkPackages.Location = new System.Drawing.Point(12, 305);
            this.chkPackages.Name = "chkPackages";
            this.chkPackages.Size = new System.Drawing.Size(610, 139);
            this.chkPackages.TabIndex = 3;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectAll.Location = new System.Drawing.Point(12, 455);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(150, 25);
            this.btnSelectAll.TabIndex = 4;
            this.btnSelectAll.Text = "Alle auswählen";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelectNone
            // 
            this.btnSelectNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectNone.Location = new System.Drawing.Point(170, 455);
            this.btnSelectNone.Name = "btnSelectNone";
            this.btnSelectNone.Size = new System.Drawing.Size(150, 25);
            this.btnSelectNone.TabIndex = 5;
            this.btnSelectNone.Text = "Keine auswählen";
            this.btnSelectNone.UseVisualStyleBackColor = true;
            this.btnSelectNone.Click += new System.EventHandler(this.btnSelectNone_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.Location = new System.Drawing.Point(12, 490);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(610, 40);
            this.btnDownload.TabIndex = 6;
            this.btnDownload.Text = "Ausgewählte herunterladen";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 540);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(610, 20);
            this.progressBar1.TabIndex = 7;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(12, 565);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(610, 15);
            this.lblStatus.TabIndex = 8;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Location = new System.Drawing.Point(12, 585);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(610, 110);
            this.txtLog.TabIndex = 9;
            // 
            // bgwFetch
            // 
            this.bgwFetch.WorkerReportsProgress = true;
            this.bgwFetch.WorkerSupportsCancellation = true;
            this.bgwFetch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFetch_DoWork);
            this.bgwFetch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwFetch_RunWorkerCompleted);
            this.bgwFetch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            // 
            // bgwDownload
            // 
            this.bgwDownload.WorkerReportsProgress = true;
            this.bgwDownload.WorkerSupportsCancellation = true;
            this.bgwDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDownload_DoWork);
            this.bgwDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDownload_RunWorkerCompleted);
            this.bgwDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_ProgressChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 705);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnSelectNone);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.chkPackages);
            this.Controls.Add(this.btnFetch);
            this.Controls.Add(this.grpConfig);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WL-DL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuPath;
        private System.Windows.Forms.ToolStripMenuItem menuPathChange;
        private System.Windows.Forms.ToolStripMenuItem menuPathReset;
        private System.Windows.Forms.ToolStripMenuItem menuLang;
        private System.Windows.Forms.ToolStripMenuItem menuLangDe;
        private System.Windows.Forms.ToolStripMenuItem menuLangEn;
        private System.Windows.Forms.ToolStripMenuItem menuInfo;
        private System.Windows.Forms.ToolStripMenuItem menuInfoCredits;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.ComboBox cbVersion;
        private System.Windows.Forms.Label lblVer;
        private System.Windows.Forms.RadioButton rbStoreServer;
        private System.Windows.Forms.RadioButton rbUpdateServer;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblSecurityInfo;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.CheckedListBox chkPackages;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSelectNone;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtLog;
        private System.ComponentModel.BackgroundWorker bgwFetch;
        private System.ComponentModel.BackgroundWorker bgwDownload;
    }
}
