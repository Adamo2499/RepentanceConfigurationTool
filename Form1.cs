using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Repentance_Configuration_Tool
{
    public partial class Form1 : Form
    {
        public string isaacLocation { get; set; }
        public string optionsLocation { get; set; }

        public string[,] optionsValues = new string[39, 2];
        public Form1()
        {
            InitializeComponent();
        }

        private void setOptionsFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void setIsaacFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           optionsLocation = openFileDialog1.FileName;
            var fileStream = openFileDialog1.OpenFile();
            string[] fileOptions = new string[fileStream.Length];
            using (StreamReader reader = new StreamReader(fileStream))
            {
                 fileOptions = reader.ReadToEnd().Split('\n');
            }
            fileStream.Close();
            string[] simpleOption;
            for (int i = 2; i < fileOptions.Length-2; i++)
            {
                simpleOption = fileOptions[i].Split('=');
                optionsValues[i-2,0] = simpleOption[0];
                optionsValues[i-2,1] = simpleOption[1];
                optionsValues[i-2, 1] = optionsValues[i-2, 1].Replace(",", ".");
            }
            MessageBox.Show(optionsValues[0,0]+":"+optionsValues[0,1]);
            textBox1.Text = textBox1.Text.Replace("options.ini not found", "options.ini found");
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            string isaacFullLocation = openFileDialog2.FileName;
            string isaacFileName = "\\isaac-ng.exe";
            int index = isaacFullLocation.IndexOf(isaacFileName);
            isaacLocation = isaacFullLocation.Replace(isaacFileName,"");
            button3.Enabled = true;
            textBox1.Text = textBox1.Text.Replace("Isaac folder not found", "Isaac folder found");
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(domainUpDown1.Text+" Numer indeksu: "+domainUpDown1.SelectedIndex);
            

        }
        private void disableAllModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
        private void enableAllModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void inverseModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if(checkedListBox1.GetItemChecked(i) == true)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.Shift && e.KeyCode.ToString().Equals("D"))
            {
                disableAllModsToolStripMenuItem_Click(sender, e);
            }
            else if(e.Control && e.Shift && e.KeyCode.ToString().Equals("E"))
            {
                enableAllModsToolStripMenuItem_Click(sender, e);
            }
            else if(e.Control && e.KeyCode.ToString().Equals("S"))
            {
              //save values to file
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label8.Text = "Music Volume: " + trackBar1.Value;
            double value = Math.Round(trackBar1.Value%10.0)/10;
            string stringValue = value.ToString();
            if(trackBar1.Value == 0)
            {
                stringValue = "0.0000";
            }
            else if(trackBar1.Value == 10)
            {
                stringValue = "1.0000";
            }
            else
            {
                stringValue = stringValue.Replace(",", ".");
                stringValue += "000";
            }
            //MessageBox.Show(stringValue);
            try
            {
                lineChanger("MusicVolume=" + stringValue, optionsLocation, 3);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("options.ini wasn't selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label9.Text = "SFX Volume: " + trackBar2.Value;
            double SFXvalue = Math.Round(trackBar1.Value % 10.0) / 10;
            string stringValue = SFXvalue.ToString();
            if (trackBar1.Value == 0)
            {
                stringValue = "0.0000";
            }
            else if (trackBar1.Value == 10)
            {
                stringValue = "1.0000";
            }
            else
            {
                stringValue = stringValue.Replace(",", ".");
                stringValue += "000";
            }
            //MessageBox.Show(stringValue);
            try
            {
                lineChanger("SFXVolume=" + stringValue, optionsLocation, 3);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("options.ini wasn't selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //nullreferenceexception
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label10.Text = "Map Opacity: " + trackBar3.Value;
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label11.Text = "Exposure: " + trackBar4.Value;
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            label12.Text = "Gamma: " + trackBar5.Value;
        }
        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            label13.Text = "HUD offset: " + trackBar6.Value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string isaacExe = isaacLocation + "\\isaac-ng.exe";
            ProcessStartInfo startIsaac = new ProcessStartInfo();
            startIsaac.FileName = isaacExe;
            Process.Start(startIsaac);
        }

        private void lineChanger(string newText, string fileName, int line_to_edit)
        {
            try {
                string[] arrLine = File.ReadAllLines(fileName);
                arrLine[line_to_edit - 1] = newText;
                if (!IsFileLocked(fileName))
                {
                    File.WriteAllLines(fileName, arrLine);
                }  
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("options.ini wasn't selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool IsFileLocked(string filePath)
        {
            bool lockStatus = false;
            try
            {
                using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // File/Stream manipulating code here

                    lockStatus = !fileStream.CanWrite;

                }
            }
            catch
            {
                //check here why it failed and ask user to retry if the file is in use.
                lockStatus = true;
            }
            return lockStatus;
        }
    }
}
