using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BriansExcuseManager
{
    public partial class Form1 : Form
    {
        private readonly string DEFAULT_FOLDER = null;
        private string CurrentFolder = null;

        private Excuse CurrentExcuse = new Excuse();

        public Form1()
        {
            InitializeComponent();

            this.DEFAULT_FOLDER = Path.Combine(this.AssemblyDirectory(), "DefaultExcusesStore");
            if(!Directory.Exists(this.DEFAULT_FOLDER))
                Directory.CreateDirectory(this.DEFAULT_FOLDER);

            this.UpdateForm(this.CurrentExcuse);
        }

        private string AssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private void EnableControls()
        {
            this.buttonSave.Enabled = true;
            this.buttonOpen.Enabled = true;
            this.buttonRandom.Enabled = true;
        }

        private void DisableControls()
        {
            this.buttonSave.Enabled = true;
            this.buttonOpen.Enabled = true;
            this.buttonRandom.Enabled = true;
        }

        private void DataChanged()
        {
            // Add * to title
            var regex = new Regex(@"[*]+");
            if (!regex.IsMatch(this.Text))
            {
                this.Text += "*";
            }
        }

        private void DataChangedReset()
        {
            // Delete * from title
            var regex = new Regex("[*]+");
            this.Text = regex.Replace(this.Text, "");
        }

        private void UpdateForm(Excuse excuse)
        {
            if(excuse != null)
            {
                this.textBoxExcuse.Text = excuse.ExcuseText;
                this.textBoxResults.Text = excuse.Results;
                this.dateTimePickerLastUsed.Value = excuse.LastUsed;
                if (!String.IsNullOrWhiteSpace(this.CurrentExcuse.ExcusePath) && File.Exists(excuse.ExcusePath))
                {
                    this.dateTimePickerFileDate.Value = File.GetLastWriteTime(excuse.ExcusePath);
                }
            }
        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog() {
                SelectedPath = this.CurrentFolder ?? Path.Combine(DEFAULT_FOLDER),
                ShowNewFolderButton = true
            };

            var result = dialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.CurrentFolder = dialog.SelectedPath;
                EnableControls();
            }
        }

        private void buttonFolderDefault_Click(object sender, EventArgs e)
        {
            this.CurrentFolder = Path.Combine(DEFAULT_FOLDER);
            EnableControls();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.CurrentExcuse.Valid())
            {
                var dialog = new SaveFileDialog()
                {
                    InitialDirectory = this.CurrentFolder,
                    FileName = $"{this.CurrentExcuse.ExcuseText}.txt",
                    Title = "Save your excuse",
                    AddExtension = true,
                    Filter = "txt files (*.txt)|*txt",
                    FilterIndex = 0
                };
                var result = dialog.ShowDialog();
                if(result == DialogResult.OK)
                {
                    string path = dialog.FileName;
                    this.CurrentExcuse.Save(path);
                    this.DataChangedReset();
                    MessageBox.Show("Excuse Written");
                }
            }
            else
            {
                MessageBox.Show("Fill all fields for an Excuse!");
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                InitialDirectory = this.CurrentFolder,
                Title = "Open your excuse",
                Filter = "txt files (*.txt)|*txt",
                FilterIndex = 0
            };
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = dialog.FileName;
                this.CurrentExcuse.Open(path);
                this.UpdateForm(this.CurrentExcuse);
                this.DataChangedReset();
            }
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            var files = Directory.GetFiles(this.CurrentFolder);
            var randomFile = files[(new Random()).Next(0, files.Length)];
            this.CurrentExcuse.Open(randomFile);
            this.UpdateForm(this.CurrentExcuse);
        }

        private void textBoxExcuse_TextChanged(object sender, EventArgs e)
        {
            this.CurrentExcuse.ExcuseText = ((TextBox)sender).Text;
            this.DataChanged();
        }

        private void textBoxResults_TextChanged(object sender, EventArgs e)
        {
            this.CurrentExcuse.Results = ((TextBox)sender).Text;
            this.DataChanged();
        }

        private void dateTimePickerLastUsed_ValueChanged(object sender, EventArgs e)
        {
            this.CurrentExcuse.LastUsed = ((DateTimePicker)sender).Value;
            this.DataChanged();
        }

        
    }
}
