
namespace WorkLog
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.entryTextBox = new System.Windows.Forms.TextBox();
            this.trayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayNotifyIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showCurrentLogButton = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllLogsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.trayNottifyIconContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitButton = new System.Windows.Forms.ToolStripMenuItem();
            this.trayNotifyIconContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // entryTextBox
            // 
            this.entryTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entryTextBox.Location = new System.Drawing.Point(0, 0);
            this.entryTextBox.Multiline = true;
            this.entryTextBox.Name = "entryTextBox";
            this.entryTextBox.Size = new System.Drawing.Size(624, 281);
            this.entryTextBox.TabIndex = 0;
            this.entryTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.entryTextBox_KeyDown);
            // 
            // trayNotifyIcon
            // 
            this.trayNotifyIcon.ContextMenuStrip = this.trayNotifyIconContextMenu;
            this.trayNotifyIcon.Visible = true;
            this.trayNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayNotifyIcon_MouseClick);
            // 
            // trayNotifyIconContextMenu
            // 
            this.trayNotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showCurrentLogButton,
            this.showAllLogsButton,
            this.trayNottifyIconContextMenuSeparator1,
            this.exitButton});
            this.trayNotifyIconContextMenu.Name = "contextMenuStrip1";
            this.trayNotifyIconContextMenu.Size = new System.Drawing.Size(165, 76);
            // 
            // showCurrentLogButton
            // 
            this.showCurrentLogButton.Name = "showCurrentLogButton";
            this.showCurrentLogButton.Size = new System.Drawing.Size(164, 22);
            this.showCurrentLogButton.Text = "Show current log";
            // 
            // showAllLogsButton
            // 
            this.showAllLogsButton.Name = "showAllLogsButton";
            this.showAllLogsButton.Size = new System.Drawing.Size(164, 22);
            this.showAllLogsButton.Text = "Show all logs";
            // 
            // trayNottifyIconContextMenuSeparator1
            // 
            this.trayNottifyIconContextMenuSeparator1.Name = "trayNottifyIconContextMenuSeparator1";
            this.trayNottifyIconContextMenuSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // exitButton
            // 
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(164, 22);
            this.exitButton.Text = "Exit";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 281);
            this.Controls.Add(this.entryTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add entry...";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.trayNotifyIconContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entryTextBox;
        private System.Windows.Forms.NotifyIcon trayNotifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayNotifyIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitButton;
        private System.Windows.Forms.ToolStripMenuItem showAllLogsButton;
        private System.Windows.Forms.ToolStripSeparator trayNottifyIconContextMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showCurrentLogButton;
    }
}

