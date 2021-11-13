using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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
        private void setTrackBarValue(TrackBar trackbarName, int value)
        {
            if (value < trackbarName.Minimum)
            {
                trackbarName.Value = trackbarName.Minimum;
            }
            else if (value > trackbarName.Maximum)
            {
                trackbarName.Value = trackbarName.Maximum;
            }
            else
            {
                trackbarName.Value = value;
            }
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
            for (int i = 2; i < fileOptions.Length - 2; i++)
            {
                simpleOption = fileOptions[i].Split('=');
                optionsValues[i - 2, 0] = simpleOption[0];
                optionsValues[i - 2, 1] = simpleOption[1];
                optionsValues[i - 2, 1] = optionsValues[i - 2, 1].Replace("\r", "");
                optionsValues[i - 2, 1] = optionsValues[i - 2, 1].Replace(".", ",");
            }
            #region transfering data from options.ini to Rep Conf Tool
            int value1 = convertValuesFromFileToProgram(optionsValues[0, 1]);
            setTrackBarValue(trackBar1, value1);
            label8.Text = "Music Volume: " + trackBar1.Value;
            int value2 = convertValuesFromFileToProgram(optionsValues[2, 1]);
            setTrackBarValue(trackBar2, value2);
            label9.Text = "SFX Volume: " + trackBar2.Value;
            int value3 = convertValuesFromFileToProgram(optionsValues[3, 1]);
            setTrackBarValue(trackBar3, value3);
            label10.Text = "Map Opacity: " + trackBar3.Value;
            int value4 = convertValuesFromFileToProgram(optionsValues[6, 1]) * 10;
            setTrackBarValue(trackBar4, value4);
            label11.Text = "Exposure: " + trackBar4.Value;
            int value5 = convertValuesFromFileToProgram(optionsValues[7, 1]) * 10;
            setTrackBarValue(trackBar5, value5);
            label12.Text = "Gamma: " + trackBar5.Value;
            int value6 = convertValuesFromFileToProgram(optionsValues[12, 1]);
            setTrackBarValue(trackBar6, value6);
            label13.Text = "HUD offset: " + trackBar6.Value;
            if (optionsValues[5, 1].Equals("1"))
            {
                checkBox4.Checked = true;
            }
            if (optionsValues[8, 1].Equals("1"))
            {
                checkBox11.Checked = true;
            }
            if (optionsValues[9, 1].Equals("1"))
            {
                checkBox15.Checked = true;
            }
            if (optionsValues[10, 1].Equals("1"))
            {
                checkBox3.Checked = true;
            }
            if (optionsValues[13, 1].Equals("1"))
            {
                checkBox10.Checked = true;
            }
            if (optionsValues[14, 1].Equals("1"))
            {
                checkBox7.Checked = true;
            }
            if (optionsValues[15, 1].Equals("1"))
            {
                checkBox16.Checked = true;
            }
            if (optionsValues[16, 1].Equals("1"))
            {
                checkBox13.Checked = true;
            }
            if (optionsValues[17, 1].Equals("1"))
            {
                checkBox6.Checked = true;
            }
            if (optionsValues[18, 1].Equals("1"))
            {
                checkBox8.Checked = true;
            }
            if (optionsValues[19, 1].Equals("1"))
            {
                checkBox29.Checked = true;
            }
            if (optionsValues[22, 1].Equals("1"))
            {
                checkBox2.Checked = true;
            }
            if (optionsValues[23, 1].Equals("1"))
            {
                checkBox12.Checked = true;
            }
            if (optionsValues[24, 1].Equals("1"))
            {
                checkBox9.Checked = true;
            }
            if (optionsValues[25, 1].Equals("1"))
            {
                checkBox14.Checked = true;
            }
            if (optionsValues[26, 1].Equals("1"))
            {
                checkBox5.Checked = true;
            }
            if (optionsValues[28, 1].Equals("1"))
            {
                checkBox18.Checked = true;
            }
            if (optionsValues[29, 1].Equals("1"))
            {
                checkBox20.Checked = true;
            }
            if (optionsValues[30, 1].Equals("1"))
            {
                checkBox22.Checked = true;
            }
            numericUpDown1.Value = int.Parse(optionsValues[20, 1]);
            numericUpDown2.Value = int.Parse(optionsValues[21, 1]);
            numericUpDown3.Value = int.Parse(optionsValues[31, 1]);
            numericUpDown4.Value = int.Parse(optionsValues[32, 1]);
            numericUpDown5.Value = int.Parse(optionsValues[33, 1]);
            numericUpDown6.Value = int.Parse(optionsValues[34, 1]);
            domainUpDown1.SelectedIndex = int.Parse(optionsValues[11, 1]);
            comboBox1.SelectedIndex = int.Parse(optionsValues[27, 1]);
            comboBox2.SelectedIndex = 0;
            #endregion
            textBox1.Text = textBox1.Text.Replace("options.ini not found", "options.ini found");
            #region add mods to list
            String modsPath = "";
            checkedListBox1.Items.RemoveAt(0);
            if (isaacLocation != null)
            {
                modsPath = isaacLocation + "\\mods";
            }
            else
            {
                MessageBox.Show("Select isaac-ng.exe!");
            }
                if(Directory.GetDirectories(modsPath) != null)
                {
                    string[] modList = Directory.GetDirectories(modsPath);
                    for(int i = 0; i < modList.Length; i++)
                    {
                    String[] modFiles = Directory.GetFiles(modList[i]);
                    for(int j = 0; j < modFiles.Length; j++) 
                    {
                        //modFiles[j].EndsWith("metadata.xml")
                            if (modFiles[j].EndsWith("metadata.xml"))
                            {
                                String xmlLocation = modFiles[j];
                                XmlTextReader xtr = new XmlTextReader(xmlLocation);
                            while (xtr.Read())
                            {
                                if(xtr.NodeType == XmlNodeType.Element && xtr.Name == "name")
                                {
                                    string modName = xtr.ReadString();
                                    checkedListBox1.Items.Add(modName, true);
                                    break;
                                }
                            }
                            }
                        } 
                    }
                }
            #endregion
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
            changeSetting("ShowRecentItems=" + domainUpDown1.SelectedIndex, 14);
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
                changeSetting("MusicVolume=" + stringValue, 3);
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
            try
            {
                lineChanger("SFXVolume=" + stringValue, optionsLocation, 3);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("options.ini wasn't selected!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public int convertValuesFromFileToProgram(string value)
        {
            string testOptionValue = value;
            double testValue = double.Parse(testOptionValue);
            testValue *= 10;
            return (int)testValue;
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox18.Checked == true)
            {
                changeSetting("ConsoleFont=1", 31);
            }
            else
            {
                changeSetting("ConsoleFont=0", 31);
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked == true)
            {
                changeSetting("FadedConsoleDisplay=1", 32);
            }
            else
            {
                changeSetting("FadedConsoleDisplay=0", 32);
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                changeSetting("SaveCommandHistory=1", 33);
            }
            else
            {
                changeSetting("SaveCommandHistory=0", 33);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox6.Checked == true)
            {
                changeSetting("ChargeBars=1", 20);
            }
            else
            {
                changeSetting("ChargeBars=0", 20);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                changeSetting("Fullscreen=1", 7);
            }
            else
            {
                changeSetting("Fullscreen=0", 7);
            }
        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                changeSetting("Vsync=1", 25);
            }
            else
            {
                changeSetting("Vsync=0", 25);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                changeSetting("CameraStyle=1", 13);
            }
            else
            {
                changeSetting("CameraStyle=0", 13);
            }
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                changeSetting("BossHpOnBottom=1", 29);
            }
            else
            {
                changeSetting("BossHpOnBottom=0", 29);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int voiceOption = comboBox1.SelectedIndex;
            changeSetting("AnnouncerVoiceMode=" + voiceOption, 30);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            changeSetting("MaxScale=" + numericUpDown1.Value, 23);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            lineChanger("MaxScale=" + numericUpDown1.Value, optionsLocation, 24);
        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            changeSetting("WindowWidth=" + numericUpDown3.Value,34);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            changeSetting("WindowHeight=" + numericUpDown4.Value, 35);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            changeSetting("WindowPosX=" + numericUpDown5.Value, 36);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            changeSetting("WindowPosY=" + numericUpDown6.Value, 37);
        }

        
        private void changeSetting(string newValue, int lineToChange)
        {
            lineChanger(newValue, optionsLocation, lineToChange);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox4.Checked == true)
            {
                changeSetting("Filter=1", 8);
            }
            else
            {
                changeSetting("Filter=0", 8);
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox8.Checked == true)
            {
                changeSetting("BulletVisibility=1", 21);
            }
            else
            {
                changeSetting("BulletVisibility=0", 21);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox7.Checked == true)
            {
                changeSetting("FoundHUD=1", 17);
            }
            else
            {
                changeSetting("FoundHUD=0", 17);
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox16.Checked == true)
            {
                changeSetting("EnableMods=1", 18);
            }
            else
            {
                changeSetting("EnableMods=0", 18);
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox15.Checked == true)
            {
                changeSetting("PopUps=1", 12);
            }
            else
            {
                changeSetting("PopUps=0", 12);
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox14.Checked == true)
            {
                changeSetting("MouseControl=1", 28);
            }
            else
            {
                changeSetting("MouseControl=0", 28);
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox13.Checked == true)
            {
                changeSetting("RumbleEnabled=1", 19);
            }
            else
            {
                changeSetting("RumbleEnabled=0", 19);
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox12.Checked == true)
            {
                changeSetting("PauseOnFocusLost=1", 26);
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox11.Checked == true)
            {
                changeSetting("ControllerHotplug=1", 11);
            }
            else
            {
                changeSetting("ControllerHotplug=0", 11);
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox10.Checked == true)
            {
                changeSetting("TryImportSave=1", 16);
            }
            else
            {
                changeSetting("TryImportSave=0", 16);
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox9.Checked == true)
            {
                changeSetting("SteamCloud=1", 27);
            }
            else
            {
                changeSetting("SteamCloud=0", 27);
            }
        }

        private void checkBox29_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox29.Checked == true)
            {
                changeSetting("EnableDebugConsole=1", 22);
            }
            else
            {
                changeSetting("EnableDebugConsole=0", 22);
            }
        }
    }
}
