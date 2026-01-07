using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FileListClient
{
    public partial class Form1 : Form
    {
        private string username;
        private string passkey;
        private string downloadFolder;
        private Dictionary<string, string> categories;
        private List<TorrentInfo> currentSearchResults;
        private List<TorrentInfo> currentLatestResults;

        public Form1()
        {
            InitializeComponent();
            InitializeCategories();
            currentSearchResults = new List<TorrentInfo>();
            currentLatestResults = new List<TorrentInfo>();
        }

        private void InitializeCategories()
        {
            categories = new Dictionary<string, string>
            {
                { "All", "" },
                { "Filme SD", "1" },
                { "Filme DVD", "2" },
                { "Filme DVD-RO", "3" },
                { "Filme HD", "4" },
                { "FLAC", "5" },
                { "Filme 4K", "6" },
                { "XXX", "7" },
                { "Programe", "8" },
                { "Jocuri PC", "9" },
                { "Jocuri Console", "10" },
                { "Audio", "11" },
                { "Videoclip", "12" },
                { "Sport", "13" },
                { "TV", "14" },
                { "Desene", "15" },
                { "Docs", "16" },
                { "Linux", "17" },
                { "Diverse", "18" },
                { "Filme HD-RO", "19" },
                { "Filme Blu-Ray", "20" },
                { "Seriale HD", "21" },
                { "Mobile", "22" },
                { "Seriale SD", "23" },
                { "Anime", "24" },
                { "Filme 3D", "25" },
                { "Filme 4K Blu-Ray", "26" },
                { "Seriale 4K", "27" }
            };

            categoryCombo.DataSource = new BindingSource(categories, null);
            categoryCombo.DisplayMember = "Key";
            categoryCombo.ValueMember = "Value";

            searchTypeCombo.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passkey))
            {
                ShowLoginDialog();
            }
            else
            {
                UpdateStatus("Connected as: " + username);
            }

            if (string.IsNullOrEmpty(downloadFolder))
            {
                downloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                SaveSettings();
            }

            LoadLatestByCategory();
        }

        private void LoadSettings()
        {
            try
            {
                string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileListClient");
                string settingsFile = Path.Combine(appData, "settings.json");

                if (File.Exists(settingsFile))
                {
                    string json = File.ReadAllText(settingsFile);
                    JObject settings = JObject.Parse(json);
                    username = settings["username"]?.ToString();
                    passkey = settings["passkey"]?.ToString();
                    downloadFolder = settings["downloadFolder"]?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettings()
        {
            try
            {
                string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FileListClient");
                Directory.CreateDirectory(appData);
                string settingsFile = Path.Combine(appData, "settings.json");

                JObject settings = new JObject
                {
                    ["username"] = username,
                    ["passkey"] = passkey,
                    ["downloadFolder"] = downloadFolder
                };

                File.WriteAllText(settingsFile, settings.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLoginDialog()
        {
            Form loginForm = new Form
            {
                Text = "Login to FileList",
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label usernameLabel = new Label { Left = 20, Top = 20, Text = "Username:", Width = 100 };
            TextBox usernameBox = new TextBox { Left = 130, Top = 20, Width = 240 };
            Label passkeyLabel = new Label { Left = 20, Top = 60, Text = "Passkey:", Width = 100 };
            TextBox passkeyBox = new TextBox { Left = 130, Top = 60, Width = 240, UseSystemPasswordChar = true };
            Button loginButton = new Button { Text = "Login", Left = 200, Width = 80, Top = 110, DialogResult = DialogResult.OK };
            Button cancelButton = new Button { Text = "Cancel", Left = 290, Width = 80, Top = 110, DialogResult = DialogResult.Cancel };

            loginForm.Controls.Add(usernameLabel);
            loginForm.Controls.Add(usernameBox);
            loginForm.Controls.Add(passkeyLabel);
            loginForm.Controls.Add(passkeyBox);
            loginForm.Controls.Add(loginButton);
            loginForm.Controls.Add(cancelButton);

            loginForm.AcceptButton = loginButton;
            loginForm.CancelButton = cancelButton;

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                username = usernameBox.Text.Trim();
                passkey = passkeyBox.Text.Trim();

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(passkey))
                {
                    SaveSettings();
                    UpdateStatus("Connected as: " + username);
                }
                else
                {
                    MessageBox.Show("Username and passkey cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }

        private void UpdateApiStatus(string message)
        {
            apiStatusLabel.Text = "API: " + message;
        }

        private string BuildApiUrl(string action, Dictionary<string, string> parameters = null)
        {
            StringBuilder url = new StringBuilder($"https://filelist.io/api.php?username={Uri.EscapeDataString(username)}&passkey={Uri.EscapeDataString(passkey)}&action={action}");

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    if (!string.IsNullOrEmpty(param.Value))
                    {
                        url.Append($"&{param.Key}={Uri.EscapeDataString(param.Value)}");
                    }
                }
            }

            return url.ToString();
        }

        private string MakeApiRequest(string url)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    return client.DownloadString(url);
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    using (StreamReader reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string error = reader.ReadToEnd();
                        throw new Exception($"API Error: {error}");
                    }
                }
                throw;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                MessageBox.Show("Please enter a search query!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PerformSearch();
        }

        private void PerformSearch()
        {
            UpdateStatus("Searching torrents...");
            UpdateApiStatus("Requesting...");

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "type", searchTypeCombo.SelectedIndex == 0 ? "name" : "imdb" },
                    { "query", searchBox.Text.Trim() }
                };

                string categoryValue = ((KeyValuePair<string, string>)categoryCombo.SelectedItem).Value;
                if (!string.IsNullOrEmpty(categoryValue))
                {
                    parameters["category"] = categoryValue;
                }

                if (moderatedCheck.Checked) parameters["moderated"] = "1";
                if (internalCheck.Checked) parameters["internal"] = "1";
                if (freeleechCheck.Checked) parameters["freeleech"] = "1";
                if (doubleupCheck.Checked) parameters["doubleup"] = "1";

                string url = BuildApiUrl("search-torrents", parameters);
                string response = MakeApiRequest(url);

                JArray torrents = JArray.Parse(response);
                currentSearchResults.Clear();
                torrentsListView.Items.Clear();

                foreach (JObject torrent in torrents)
                {
                    TorrentInfo info = new TorrentInfo
                    {
                        Id = torrent["id"]?.ToString(),
                        Name = torrent["name"]?.ToString(),
                        Size = torrent["size"]?.ToString(),
                        Seeders = torrent["seeders"]?.ToString(),
                        Leechers = torrent["leechers"]?.ToString(),
                        Category = torrent["category"]?.ToString(),
                        DownloadLink = torrent["download_link"]?.ToString()
                    };

                    currentSearchResults.Add(info);

                    ListViewItem item = new ListViewItem(info.Name);
                    item.SubItems.Add(FormatSize(info.Size));
                    item.SubItems.Add(info.Seeders);
                    item.SubItems.Add(info.Leechers);
                    item.SubItems.Add(info.Category);
                    item.Tag = info;

                    torrentsListView.Items.Add(item);
                }

                UpdateStatus($"Found {torrents.Count} torrents");
                UpdateApiStatus("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Search failed");
                UpdateApiStatus("Error");
            }
        }

        private void LoadLatestByCategory()
        {
            UpdateStatus("Loading category torrents...");
            UpdateApiStatus("Requesting...");

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "limit", "100" }
                };

                string categoryValue = ((KeyValuePair<string, string>)categoryCombo.SelectedItem).Value;
                if (!string.IsNullOrEmpty(categoryValue))
                {
                    parameters["category"] = categoryValue;
                }

                string url = BuildApiUrl("latest-torrents", parameters);
                string response = MakeApiRequest(url);

                JArray torrents = JArray.Parse(response);
                currentSearchResults.Clear();
                torrentsListView.Items.Clear();

                foreach (JObject torrent in torrents)
                {
                    TorrentInfo info = new TorrentInfo
                    {
                        Id = torrent["id"]?.ToString(),
                        Name = torrent["name"]?.ToString(),
                        Size = torrent["size"]?.ToString(),
                        Seeders = torrent["seeders"]?.ToString(),
                        Leechers = torrent["leechers"]?.ToString(),
                        Category = torrent["category"]?.ToString(),
                        DownloadLink = torrent["download_link"]?.ToString()
                    };

                    currentSearchResults.Add(info);

                    ListViewItem item = new ListViewItem(info.Name);
                    item.SubItems.Add(FormatSize(info.Size));
                    item.SubItems.Add(info.Seeders);
                    item.SubItems.Add(info.Leechers);
                    item.SubItems.Add(info.Category);
                    item.Tag = info;

                    torrentsListView.Items.Add(item);
                }

                string categoryName = ((KeyValuePair<string, string>)categoryCombo.SelectedItem).Key;
                UpdateStatus($"Showing {torrents.Count} torrents in {categoryName}");
                UpdateApiStatus("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Failed to load torrents");
                UpdateApiStatus("Error");
            }
        }

        private void refreshLatestBtn_Click(object sender, EventArgs e)
        {
            UpdateStatus("Loading latest torrents...");
            UpdateApiStatus("Requesting...");

            try
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>
                {
                    { "limit", limitNumeric.Value.ToString() }
                };

                string url = BuildApiUrl("latest-torrents", parameters);
                string response = MakeApiRequest(url);

                JArray torrents = JArray.Parse(response);
                currentLatestResults.Clear();
                latestListView.Items.Clear();

                foreach (JObject torrent in torrents)
                {
                    TorrentInfo info = new TorrentInfo
                    {
                        Id = torrent["id"]?.ToString(),
                        Name = torrent["name"]?.ToString(),
                        Size = torrent["size"]?.ToString(),
                        Seeders = torrent["seeders"]?.ToString(),
                        Leechers = torrent["leechers"]?.ToString(),
                        Category = torrent["category"]?.ToString(),
                        DownloadLink = torrent["download_link"]?.ToString()
                    };

                    currentLatestResults.Add(info);

                    ListViewItem item = new ListViewItem(info.Name);
                    item.SubItems.Add(FormatSize(info.Size));
                    item.SubItems.Add(info.Seeders);
                    item.SubItems.Add(info.Leechers);
                    item.SubItems.Add(info.Category);
                    item.Tag = info;

                    latestListView.Items.Add(item);
                }

                UpdateStatus($"Loaded {torrents.Count} latest torrents");
                UpdateApiStatus("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Failed to load latest torrents");
                UpdateApiStatus("Error");
            }
        }

        private string FormatSize(string sizeStr)
        {
            if (long.TryParse(sizeStr, out long bytes))
            {
                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                double size = bytes;
                int order = 0;
                while (size >= 1024 && order < sizes.Length - 1)
                {
                    order++;
                    size /= 1024;
                }
                return $"{size:0.##} {sizes[order]}";
            }
            return sizeStr;
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            DownloadSelectedTorrent(torrentsListView);
        }

        private void downloadLatestBtn_Click(object sender, EventArgs e)
        {
            DownloadSelectedTorrent(latestListView);
        }

        private void DownloadSelectedTorrent(ListView listView)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a torrent to download!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(downloadFolder))
            {
                MessageBox.Show("Please set a download folder in Settings!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TorrentInfo info = (TorrentInfo)listView.SelectedItems[0].Tag;
                UpdateStatus($"Downloading: {info.Name}");

                string filename = SanitizeFileName(info.Name) + ".torrent";
                string filepath = Path.Combine(downloadFolder, filename);

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(info.DownloadLink, filepath);
                }

                UpdateStatus($"Downloaded: {filename}");
                MessageBox.Show($"Torrent file downloaded successfully to:\n{filepath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error downloading torrent: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus("Download failed");
            }
        }

        private string SanitizeFileName(string filename)
        {
            char[] invalid = Path.GetInvalidFileNameChars();
            foreach (char c in invalid)
            {
                filename = filename.Replace(c, '_');
            }
            return filename;
        }

        private void torrentsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            downloadBtn.Enabled = torrentsListView.SelectedItems.Count > 0;
        }

        private void latestListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            downloadLatestBtn.Enabled = latestListView.SelectedItems.Count > 0;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form settingsForm = new Form
            {
                Text = "Settings",
                Width = 500,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label folderLabel = new Label { Left = 20, Top = 20, Text = "Download Folder:", Width = 120 };
            TextBox folderBox = new TextBox { Left = 150, Top = 20, Width = 250, Text = downloadFolder, ReadOnly = true };
            Button browseButton = new Button { Left = 410, Top = 18, Width = 60, Text = "Browse" };

            Label usernameLabel = new Label { Left = 20, Top = 60, Text = "Username:", Width = 120 };
            Label usernameValue = new Label { Left = 150, Top = 60, Text = username, Width = 250 };

            Button clearLoginButton = new Button { Text = "Clear Cached Login", Left = 150, Width = 150, Top = 100 };
            Button saveButton = new Button { Text = "Save", Left = 230, Width = 80, Top = 150, DialogResult = DialogResult.OK };
            Button cancelButton = new Button { Text = "Cancel", Left = 320, Width = 80, Top = 150, DialogResult = DialogResult.Cancel };

            browseButton.Click += (s, ev) =>
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    dialog.SelectedPath = downloadFolder;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        folderBox.Text = dialog.SelectedPath;
                    }
                }
            };

            clearLoginButton.Click += (s, ev) =>
            {
                if (MessageBox.Show("Are you sure you want to clear your cached login? You will need to login again.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    username = "";
                    passkey = "";
                    SaveSettings();
                    MessageBox.Show("Login cleared. Please restart the application.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            };

            settingsForm.Controls.Add(folderLabel);
            settingsForm.Controls.Add(folderBox);
            settingsForm.Controls.Add(browseButton);
            settingsForm.Controls.Add(usernameLabel);
            settingsForm.Controls.Add(usernameValue);
            settingsForm.Controls.Add(clearLoginButton);
            settingsForm.Controls.Add(saveButton);
            settingsForm.Controls.Add(cancelButton);

            settingsForm.AcceptButton = saveButton;
            settingsForm.CancelButton = cancelButton;

            if (settingsForm.ShowDialog() == DialogResult.OK)
            {
                downloadFolder = folderBox.Text;
                SaveSettings();
                MessageBox.Show("Settings saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FileList Client v1.0\n\nA Windows client for FileList.io torrent tracker.\n\nFeatures:\n- Search torrents by name or IMDB ID (for movies)\n- Browse latest torrents\n- Filter by category and attributes\n- Download torrent files\n\n© 2026", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public class TorrentInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Seeders { get; set; }
        public string Leechers { get; set; }
        public string Category { get; set; }
        public string DownloadLink { get; set; }
    }
}