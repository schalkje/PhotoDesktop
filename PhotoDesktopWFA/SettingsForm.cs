using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Schalken.PhotoDesktop.WFA
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void Settings_Shown(object sender, EventArgs e)
        {
            // todo: why do I need to resize the font this implementation is bla
            //foreach (Control c in this.Controls)
            //{
            //    c.Font = new Font(c.Font.FontFamily, c.Font.Size * 1.5F, c.Font.Style);
            //}

            LoadFromSettings();

            InitializeFromRegistry_cbStartWithWindows();
        }

        private void LoadFromSettings()
        {
            nudTimerValue.Value = Properties.Settings.Default.TimerValue;

            if (Properties.Settings.Default.TimerUnit.Equals("second", StringComparison.CurrentCultureIgnoreCase))
            {
                rbSeconds.Checked = true;
            }
            else if (Properties.Settings.Default.TimerUnit.Equals("minute", StringComparison.CurrentCultureIgnoreCase))
            {
                rbMinutes.Checked = true;
            }
            else if (Properties.Settings.Default.TimerUnit.Equals("hour", StringComparison.CurrentCultureIgnoreCase))
            {
                rbHours.Checked = true;
            }
            else
            {
                rbStartupOnly.Checked = true;
            }

            if (Properties.Settings.Default.Folders != null)
            {
                foreach (string settingFolder in Properties.Settings.Default.Folders)
                {
                    string[] setting = settingFolder.Split(';');
                    string folder = setting[0];
                    string baseFolder = "";
                    if (setting.Length > 1)
                        baseFolder = setting[1];
                    KeyValuePair<string, string> item = new KeyValuePair<string, string>(folder, baseFolder);
                    lbFolders.Items.Add(item);
                }

                tbFolder.Text = "";
                tbBaseFolder.Text = "";
            }

            cbChangeOnStartup.Checked = Properties.Settings.Default.ChangeOnStart;

        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.Cancel)
            {
                // do not persist the changes
            }
            else
                SaveSettings();

        }

        private void SaveSettings()
        {
            Properties.Settings.Default.TimerValue = (int)nudTimerValue.Value;

            if (rbSeconds.Checked)
                Properties.Settings.Default.TimerUnit = "second";
            else if (rbMinutes.Checked)
                Properties.Settings.Default.TimerUnit = "minute";
            else if (rbSeconds.Checked)
                Properties.Settings.Default.TimerUnit = "hour";
            else if (rbSeconds.Checked)
                Properties.Settings.Default.TimerUnit = "startup";
            else
                Properties.Settings.Default.TimerUnit = "unknown";

            if (Properties.Settings.Default.Folders == null)
                Properties.Settings.Default.Folders = new System.Collections.Specialized.StringCollection();
            else
                Properties.Settings.Default.Folders.Clear();
            foreach ( KeyValuePair<string,string> item in lbFolders.Items )
            {
                Properties.Settings.Default.Folders.Add(String.Format("{0};{1}", item.Key, item.Value));
            }

            Properties.Settings.Default.ChangeOnStart = cbChangeOnStartup.Checked;


            Properties.Settings.Default.Save();
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            if (tbFolder.Text.Length == 0)
            {
                MessageBox.Show("Enter a folder", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KeyValuePair<string, string> folder = new KeyValuePair<string, string>(
                tbFolder.Text,
                tbBaseFolder.Text);
            // avoid double entries
            // todo: this can be better; special class?
            bool found = false;
            KeyValuePair<string, string> foundItem = new KeyValuePair<string, string>();
            foreach (KeyValuePair<string, string> item in lbFolders.Items)
            {
                if (item.Key == folder.Key)
                {
                    found = true;
                    foundItem = item;
                    break;
                }
            }


            if (found)
            {
                lbFolders.Items.Remove(foundItem);
                // update base folder
                lbFolders.Items.Add(folder);
            }
            else
                lbFolders.Items.Add(folder);
        }

        private void lbFolders_Click(object sender, EventArgs e)
        {
            if (lbFolders.SelectedIndex >= 0)
            {
                //string[] setting = ((string)lbFolders.SelectedItem).Split(';');
                //string folder = setting[0];
                //string baseFolder = "";
                //if (setting.Length > 1)
                //    baseFolder = setting[1];
                KeyValuePair<string, string> folder = (KeyValuePair<string, string>)lbFolders.SelectedItem;


                tbFolder.Text = folder.Key;
                tbBaseFolder.Text = folder.Value;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbFolders.SelectedIndex >= 0)
            {
                lbFolders.Items.RemoveAt(lbFolders.SelectedIndex);
                tbFolder.Text = "";
                tbBaseFolder.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if ( folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = folderBrowserDialog1.SelectedPath;
                tbBaseFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cbStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            
            if (cbStartWithWindows.Checked)
                rk.SetValue(Application.ProductName, Application.ExecutablePath.ToString());
            else
                rk.DeleteValue(Application.ProductName, false);
        }

        private void InitializeFromRegistry_cbStartWithWindows()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            string value = rk.GetValue(Application.ProductName) as string;
            if (value == null)
                cbStartWithWindows.CheckState = CheckState.Unchecked;
            else if (value.Equals(Application.ExecutablePath.ToString(),StringComparison.CurrentCultureIgnoreCase))
                cbStartWithWindows.CheckState = CheckState.Checked;
            else
                cbStartWithWindows.CheckState = CheckState.Indeterminate;
        }

        private void rbStartupOnly_CheckedChanged(object sender, EventArgs e)
        {
            nudTimerValue.Enabled = !rbStartupOnly.Checked;
        }
    }
}
