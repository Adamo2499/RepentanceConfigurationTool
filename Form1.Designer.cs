
namespace Repentance_Configuration_Tool
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOptionsFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setIsaacFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foldersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isaacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modsListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(485, 18);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(314, 429);
            this.checkedListBox1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 30);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.foldersToolStripMenuItem,
            this.modsListsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 30);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAllCtrlSToolStripMenuItem,
            this.restoreAllToolStripMenuItem,
            this.setOptionsFolderToolStripMenuItem,
            this.setIsaacFolderToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.testToolStripMenuItem.Text = "File";
            // 
            // saveAllCtrlSToolStripMenuItem
            // 
            this.saveAllCtrlSToolStripMenuItem.Name = "saveAllCtrlSToolStripMenuItem";
            this.saveAllCtrlSToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.saveAllCtrlSToolStripMenuItem.Text = "Save All (Ctrl+S)";
            // 
            // restoreAllToolStripMenuItem
            // 
            this.restoreAllToolStripMenuItem.Name = "restoreAllToolStripMenuItem";
            this.restoreAllToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.restoreAllToolStripMenuItem.Text = "Restore All";
            // 
            // setOptionsFolderToolStripMenuItem
            // 
            this.setOptionsFolderToolStripMenuItem.Name = "setOptionsFolderToolStripMenuItem";
            this.setOptionsFolderToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.setOptionsFolderToolStripMenuItem.Text = "Set Options folder";
            this.setOptionsFolderToolStripMenuItem.Click += new System.EventHandler(this.setOptionsFolderToolStripMenuItem_Click);
            // 
            // setIsaacFolderToolStripMenuItem
            // 
            this.setIsaacFolderToolStripMenuItem.Name = "setIsaacFolderToolStripMenuItem";
            this.setIsaacFolderToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.setIsaacFolderToolStripMenuItem.Text = "Set Isaac Folder";
            this.setIsaacFolderToolStripMenuItem.Click += new System.EventHandler(this.setIsaacFolderToolStripMenuItem_Click);
            // 
            // foldersToolStripMenuItem
            // 
            this.foldersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.isaacToolStripMenuItem});
            this.foldersToolStripMenuItem.Name = "foldersToolStripMenuItem";
            this.foldersToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.foldersToolStripMenuItem.Text = "Folders";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // isaacToolStripMenuItem
            // 
            this.isaacToolStripMenuItem.Name = "isaacToolStripMenuItem";
            this.isaacToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.isaacToolStripMenuItem.Text = "Isaac";
            // 
            // modsListsToolStripMenuItem
            // 
            this.modsListsToolStripMenuItem.Name = "modsListsToolStripMenuItem";
            this.modsListsToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.modsListsToolStripMenuItem.Text = "Mods Lists";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "options.ini|options.ini";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.Filter = "isaac-ng.exe|isaac-ng.exe";
            this.openFileDialog2.ReadOnlyChecked = true;
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Repentance Configuration Tool by Adamo2499";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foldersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modsListsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllCtrlSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setOptionsFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setIsaacFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isaacToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

