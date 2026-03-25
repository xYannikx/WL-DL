using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;
using System.Threading;

namespace WLDL
{
    public partial class Form1 : Form
    {
        private bool isGerman = true;
        private string downloadPath = "";
        private string iniPath = "";

        // Class for WoltLab server data
        private class VersionInfo
        {
            public string DisplayName { get; set; }
            public string ServerPath { get; set; }
            public string ApiVersion { get; set; }
            public string UserAgent { get; set; }

            public VersionInfo(string name, string path, string api, string ua)
            {
                DisplayName = name; ServerPath = path; ApiVersion = api; UserAgent = ua;
            }
            public override string ToString() { return DisplayName; }
        }

        // Class for a single WoltLab package
        private class PackageItem
        {
            public string Name { get; set; }
            public string Version { get; set; }
            public bool RequireAuth { get; set; }

            public override string ToString()
            {
                return Name + " (v" + Version + ")";
            }
        }

        public Form1()
        {
            InitializeComponent();

            // Set up application data directory for configuration file
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WLDL");
            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }
            iniPath = Path.Combine(appDataPath, "settings.ini");

            LoadSettings();
            SetupData();
            ApplyLanguage();
            
            // Disable lists and download buttons until fetched
            SetSelectionUIEnabled(false);
        }

        private void SetupData()
        {
            cbVersion.Items.Clear();
            cbVersion.Items.Add(new VersionInfo("WCF 2.0 (Maelstrom)", "maelstrom", "2.0", "WoltLab Community Framework/2.0.15 (de)"));
            cbVersion.Items.Add(new VersionInfo("WCF 2.1 (Typhoon)", "typhoon", "2.1", "WoltLab Community Framework/2.1.24 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 3.0 (Vortex)", "vortex", "3.0", "WoltLab Suite Core/3.0.27 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 3.1 (Tornado)", "tornado", "3.1", "WoltLab Suite Core/3.1.29 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 5.2 (2019)", "2019", "5.2", "WoltLab Suite Core/5.2.21 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 5.3 (5.3)", "5.3", "5.3", "WoltLab Suite Core/5.3.28 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 5.4 (5.4)", "5.4", "5.4", "WoltLab Suite Core/5.4.34 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 5.5 (5.5)", "5.5", "5.5", "WoltLab Suite Core/5.5.25 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 6.0 (6.0)", "6.0", "6.0", "WoltLab Suite Core/6.0.0 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 6.1 (6.1)", "6.1", "6.1", "WoltLab Suite Core/6.1.0 (de)"));
            cbVersion.Items.Add(new VersionInfo("WSC 6.2 (6.2)", "6.2", "6.2", "WoltLab Suite Core/6.2.0 (de)"));
            cbVersion.SelectedIndex = 1; 
        }

        private void LoadSettings()
        {
            if (File.Exists(iniPath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(iniPath);
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Language=")) isGerman = (line.Substring(9) != "EN");
                        if (line.StartsWith("Path=")) downloadPath = line.Substring(5);
                    }
                }
                catch { }
            }
            
            // Default download folder is Documents to avoid permission issues
            if (string.IsNullOrEmpty(downloadPath))
            {
                downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        private void SaveSettings()
        {
            try
            {
                File.WriteAllText(iniPath, "Language=" + (isGerman ? "DE" : "EN") + Environment.NewLine + "Path=" + downloadPath);
            }
            catch { }
        }

        private void ApplyLanguage()
        {
            menuFile.Text = isGerman ? "Datei" : "File";
            menuFileReset.Text = isGerman ? "Zurücksetzen" : "Reset";
            menuFileExit.Text = isGerman ? "Beenden" : "Exit";

            menuPath.Text = isGerman ? "Pfad" : "Path";
            menuPathChange.Text = isGerman ? "Ausgabeordner ändern..." : "Change Output Folder...";
            menuPathReset.Text = isGerman ? "Ausgabeordner zurücksetzen" : "Reset Output Folder";

            menuLang.Text = isGerman ? "Sprache" : "Language";
            menuInfo.Text = "Info";
            menuInfoCredits.Text = "Info / Credits";

            // Set the checkmark according to the selected language
            menuLangDe.Checked = isGerman;
            menuLangEn.Checked = !isGerman;

            grpConfig.Text = isGerman ? "Konfiguration" : "Configuration";
            lblVer.Text = isGerman ? "WCF/WSC Version:" : "WCF/WSC Version:";
            rbUpdateServer.Text = isGerman ? "Update Server (WCF/WBB Pakete)" : "Update Server (WCF/WBB Packages)";
            rbStoreServer.Text = isGerman ? "Store Server (Plugin Store)" : "Store Server (Plugin Store)";
            
            btnFetch.Text = isGerman ? "Paketliste abrufen" : "Fetch Package List";
            btnSelectAll.Text = isGerman ? "Alle auswählen" : "Select All";
            btnSelectNone.Text = isGerman ? "Keine auswählen" : "Select None";
            btnDownload.Text = isGerman ? "Ausgewählte herunterladen" : "Download Selected";
            
            lblSecurityInfo.Text = isGerman ? "Hinweis: Zugangsdaten werden nicht gespeichert." : "Note: Credentials are never stored permanently.";

            if (rbUpdateServer.Checked)
            {
                lblUser.Text = isGerman ? "Lizenz-Nr.:" : "License No.:";
                lblPass.Text = isGerman ? "Serien-Nr.:" : "Serial No.:";
            }
            else
            {
                lblUser.Text = isGerman ? "Benutzername:" : "Username:";
                lblPass.Text = isGerman ? "Kennwort:" : "Password:";
            }
            lblStatus.Text = isGerman ? "Bereit." : "Ready.";
        }

        private void SetSelectionUIEnabled(bool state)
        {
            chkPackages.Enabled = state;
            btnSelectAll.Enabled = state;
            btnSelectNone.Enabled = state;
            btnDownload.Enabled = state;
        }

        private void Log(string msg)
        {
            if (txtLog.InvokeRequired) 
            { 
                txtLog.Invoke(new MethodInvoker(delegate { Log(msg); })); 
            }
            else 
            { 
                txtLog.AppendText(msg + Environment.NewLine); 
                txtLog.SelectionStart = txtLog.Text.Length; 
                txtLog.ScrollToCaret(); 
            }
        }

        private void menuFileReset_Click(object sender, EventArgs e)
        {
            cbVersion.SelectedIndex = 1;
            rbUpdateServer.Checked = true;
            txtUser.Clear();
            txtPass.Clear();
            txtLog.Clear();
            chkPackages.Items.Clear();
            SetSelectionUIEnabled(false);
            progressBar1.Value = 0;
            lblStatus.Text = isGerman ? "Bereit." : "Ready.";
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuPathChange_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = isGerman ? "Bitte wähle den Ordner für die Downloads aus:" : "Please select the folder for downloads:";
                fbd.SelectedPath = downloadPath;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    downloadPath = fbd.SelectedPath;
                    SaveSettings();
                    MessageBox.Show((isGerman ? "Pfad geändert zu:\n" : "Path changed to:\n") + downloadPath, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void menuPathReset_Click(object sender, EventArgs e)
        {
            downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            SaveSettings();
            MessageBox.Show(isGerman ? "Pfad auf 'Eigene Dokumente' zurückgesetzt." : "Path reset to 'Documents'.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuLangDe_Click(object sender, EventArgs e)
        {
            isGerman = true;
            SaveSettings();
            ApplyLanguage();
        }

        private void menuLangEn_Click(object sender, EventArgs e)
        {
            isGerman = false;
            SaveSettings();
            ApplyLanguage();
        }

        private void menuInfoCredits_Click(object sender, EventArgs e)
        {
            Form frmCredits = new Form();
            frmCredits.Icon = this.Icon;
            frmCredits.Text = "Info / Credits";
            frmCredits.Size = new Size(400, 320);
            frmCredits.StartPosition = FormStartPosition.CenterParent;
            frmCredits.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmCredits.MaximizeBox = false;
            frmCredits.MinimizeBox = false;

            Label lblTitle = new Label() { Text = "WL-DL", Font = new Font(this.Font.FontFamily, 16, FontStyle.Bold), Location = new Point(15, 15), AutoSize = true };
            
            GroupBox grpSys = new GroupBox() { Text = isGerman ? "System-Informationen" : "System Information", Location = new Point(15, 55), Size = new Size(355, 90) };
            Label lblOS = new Label() { Text = (isGerman ? "Betriebssystem:" : "Operating System:") + " " + Environment.OSVersion.VersionString, Location = new Point(15, 25), AutoSize = true };
            Label lblVer = new Label() { Text = (isGerman ? "Programmversion:" : "Program Version:") + " 1.0", Location = new Point(15, 45), AutoSize = true };
            Label lblDisclaimer = new Label() { Text = isGerman ? "Hinweis: Dies ist KEIN offizielles WoltLab Tool!" : "Note: This is NOT an official WoltLab tool!", ForeColor = Color.DarkRed, Location = new Point(15, 65), AutoSize = true, Font = new Font(this.Font, FontStyle.Bold) };
            grpSys.Controls.AddRange(new Control[] { lblOS, lblVer, lblDisclaimer });

            GroupBox grpCred = new GroupBox() { Text = "Credits", Location = new Point(15, 155), Size = new Size(355, 75) };
            Label lblAuthor = new Label() { Text = (isGerman ? "Ersteller:" : "Creator:") + " xYannikx", Location = new Point(15, 25), AutoSize = true };
            LinkLabel lnkGit = new LinkLabel() { Text = "GitHub Profil", Location = new Point(220, 25), AutoSize = true };
            lnkGit.LinkClicked += new LinkLabelLinkClickedEventHandler(delegate(object s, LinkLabelLinkClickedEventArgs ev) {
                System.Diagnostics.Process.Start("https://github.com/xYannikx");
            });
            grpCred.Controls.AddRange(new Control[] { lblAuthor, lnkGit });

            Button btnOk = new Button() { Text = "OK", Location = new Point(150, 240), Size = new Size(80, 25), FlatStyle = FlatStyle.System };
            btnOk.Click += new EventHandler(delegate(object s, EventArgs ev) { frmCredits.Close(); });

            frmCredits.Controls.AddRange(new Control[] { lblTitle, grpSys, grpCred, btnOk });
            frmCredits.ShowDialog();
        }

        private void ServerType_CheckedChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
            chkPackages.Items.Clear();
            SetSelectionUIEnabled(false);
        }

        // ==========================================
        // FETCH LOGIC
        // ==========================================

        private void btnFetch_Click(object sender, EventArgs e)
        {
            btnFetch.Enabled = false;
            SetSelectionUIEnabled(false);
            chkPackages.Items.Clear();
            txtLog.Clear();
            progressBar1.Value = 0;
            
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["version"] = cbVersion.SelectedItem;
            args["isStore"] = rbStoreServer.Checked;

            bgwFetch.RunWorkerAsync(args);
        }

        private void bgwFetch_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> args = (Dictionary<string, object>)e.Argument;
            VersionInfo vInfo = (VersionInfo)args["version"];
            bool isStore = (bool)args["isStore"];

            string serverType = isStore ? "store" : "update";
            string baseUrl = "https://" + serverType + ".woltlab.com/" + vInfo.ServerPath + "/";

            bgwFetch.ReportProgress(0, (isGerman ? "Verbinde mit " : "Connecting to ") + baseUrl + " ...");

            try
            {
                HttpWebRequest reqXml = (HttpWebRequest)WebRequest.Create(baseUrl);
                reqXml.UserAgent = vInfo.UserAgent;
                reqXml.Method = "GET";

                string xmlContent = "";
                using (HttpWebResponse resp = (HttpWebResponse)reqXml.GetResponse())
                using (StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8))
                {
                    xmlContent = sr.ReadToEnd();
                }

                xmlContent = Regex.Replace(xmlContent, " xmlns=\"[^\"]+\"", "");

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlContent);

                XmlNodeList packages = doc.SelectNodes("//package");
                if (packages == null || packages.Count == 0)
                {
                    bgwFetch.ReportProgress(100, isGerman ? "Keine Pakete gefunden." : "No packages found.");
                    e.Result = null;
                    return;
                }

                List<PackageItem> resultList = new List<PackageItem>();
                foreach (XmlNode package in packages)
                {
                    string pkgName = package.Attributes["name"] != null ? package.Attributes["name"].Value : "";
                    if (string.IsNullOrEmpty(pkgName)) continue;

                    foreach (XmlNode versionNode in package.SelectNodes(".//version"))
                    {
                        string version = versionNode.Attributes["name"] != null ? versionNode.Attributes["name"].Value : "";
                        bool requireAuth = versionNode.Attributes["requireAuth"] != null && versionNode.Attributes["requireAuth"].Value == "true";
                        
                        if (!string.IsNullOrEmpty(version))
                        {
                            resultList.Add(new PackageItem { Name = pkgName, Version = version, RequireAuth = requireAuth });
                        }
                    }
                }
                
                bgwFetch.ReportProgress(100, isGerman ? "Paketliste erfolgreich geladen." : "Package list fetched successfully.");
                e.Result = resultList;
            }
            catch (Exception ex)
            {
                bgwFetch.ReportProgress(100, (isGerman ? "Fehler beim Abrufen: " : "Error fetching: ") + ex.Message);
                e.Result = null;
            }
        }

        private void bgwFetch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnFetch.Enabled = true;
            if (e.Result != null)
            {
                List<PackageItem> list = (List<PackageItem>)e.Result;
                foreach (var item in list)
                {
                    chkPackages.Items.Add(item);
                }
                SetSelectionUIEnabled(true);
                Log((isGerman ? "Anzahl Pakete: " : "Packages found: ") + list.Count);
            }
        }

        // ==========================================
        // LIST SELECTION LOGIC
        // ==========================================

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkPackages.Items.Count; i++)
                chkPackages.SetItemChecked(i, true);
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkPackages.Items.Count; i++)
                chkPackages.SetItemChecked(i, false);
        }

        // ==========================================
        // DOWNLOAD LOGIC
        // ==========================================

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (chkPackages.CheckedItems.Count == 0)
            {
                MessageBox.Show(isGerman ? "Bitte wähle mindestens ein Paket aus!" : "Please select at least one package!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show(isGerman ? "Bitte fülle die Zugangsdaten aus!" : "Please fill in the credentials!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PackageItem> selectedPackages = new List<PackageItem>();
            foreach (var item in chkPackages.CheckedItems)
            {
                selectedPackages.Add((PackageItem)item);
            }

            btnFetch.Enabled = false;
            SetSelectionUIEnabled(false);
            txtLog.Clear();
            progressBar1.Value = 0;
            
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["version"] = cbVersion.SelectedItem;
            args["isStore"] = rbStoreServer.Checked;
            args["user"] = txtUser.Text;
            args["pass"] = txtPass.Text;
            args["packages"] = selectedPackages;

            bgwDownload.RunWorkerAsync(args);
        }

        private void bgwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string, object> args = (Dictionary<string, object>)e.Argument;
            VersionInfo vInfo = (VersionInfo)args["version"];
            bool isStore = (bool)args["isStore"];
            string user = (string)args["user"];
            string pass = (string)args["pass"];
            List<PackageItem> packagesToDownload = (List<PackageItem>)args["packages"];

            string serverType = isStore ? "store" : "update";
            string baseUrl = "https://" + serverType + ".woltlab.com/" + vInfo.ServerPath + "/";
            
            // Add WL-DL as parent directory
            string targetDir = Path.Combine(downloadPath, "WL-DL");
            targetDir = Path.Combine(targetDir, "Downloads_" + (isStore ? "Store_" : "Update_") + vInfo.ServerPath);
            
            if (!Directory.Exists(targetDir)) Directory.CreateDirectory(targetDir);

            bgwDownload.ReportProgress(0, (isGerman ? "Starte Download-Prozess..." : "Starting download process..."));

            int totalCount = packagesToDownload.Count;
            int currentCount = 0;

            foreach (PackageItem pkg in packagesToDownload)
            {
                currentCount++;
                int progress = (int)(((double)currentCount / totalCount) * 100);

                string fileName = Path.Combine(targetDir, pkg.Name + "_" + pkg.Version + ".tar");
                bgwDownload.ReportProgress(progress, (isGerman ? "Lade: " : "Downloading: ") + pkg.Name + " (v" + pkg.Version + ")... ");

                try
                {
                    HttpWebRequest reqDl = (HttpWebRequest)WebRequest.Create(baseUrl);
                    reqDl.UserAgent = vInfo.UserAgent;
                    reqDl.Method = "POST";
                    reqDl.ContentType = "application/x-www-form-urlencoded";

                    if (pkg.RequireAuth)
                    {
                        string authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(user + ":" + pass));
                        reqDl.Headers["Authorization"] = "Basic " + authInfo;
                    }

                    string postData = "apiVersion=" + Uri.EscapeDataString(vInfo.ApiVersion) + 
                                      "&packageName=" + Uri.EscapeDataString(pkg.Name) + 
                                      "&packageVersion=" + Uri.EscapeDataString(pkg.Version);
                    
                    byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                    reqDl.ContentLength = postBytes.Length;

                    using (Stream reqStream = reqDl.GetRequestStream())
                    {
                        reqStream.Write(postBytes, 0, postBytes.Length);
                    }

                    using (HttpWebResponse dlResp = (HttpWebResponse)reqDl.GetResponse())
                    {
                        string cType = dlResp.ContentType.ToLower();
                        if (cType.Contains("xml") || cType.Contains("text/html"))
                        {
                            bgwDownload.ReportProgress(progress, isGerman ? " -> Übersprungen (Fehlende Lizenz/Rechte)" : " -> Skipped (Missing License/Rights)");
                        }
                        else
                        {
                            using (Stream respStream = dlResp.GetResponseStream())
                            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                            {
                                byte[] buffer = new byte[8192];
                                int bytesRead;
                                while ((bytesRead = respStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    fs.Write(buffer, 0, bytesRead);
                                }
                            }

                            FileInfo fi = new FileInfo(fileName);
                            bgwDownload.ReportProgress(progress, " -> OK (" + (fi.Length / 1024) + " KB)");
                        }
                    }
                }
                catch (WebException wex)
                {
                    bgwDownload.ReportProgress(progress, " -> " + (isGerman ? "Fehler: " : "Error: ") + wex.Message);
                }

                // 300ms pause to prevent server overload
                Thread.Sleep(300);
            }
            
            bgwDownload.ReportProgress(100, isGerman ? "Vorgang abgeschlossen!" : "Process finished!");
        }

        private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage >= 0 && e.ProgressPercentage <= 100)
            {
                progressBar1.Value = e.ProgressPercentage;
                lblStatus.Text = (isGerman ? "Fortschritt: " : "Progress: ") + e.ProgressPercentage + "%";
            }
            if (e.UserState != null)
            {
                Log(e.UserState.ToString());
            }
        }

        private void bgwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnFetch.Enabled = true;
            SetSelectionUIEnabled(true);
        }
    }
}
