namespace Donker.SystemTrayTools.WorkLog;

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
        components = new System.ComponentModel.Container();
        var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        entryTextBox = new TextBox();
        trayNotifyIcon = new NotifyIcon(components);
        trayNotifyIconContextMenu = new ContextMenuStrip(components);
        showCurrentLogButton = new ToolStripMenuItem();
        showAllLogsButton = new ToolStripMenuItem();
        contextMenuSeparator = new ToolStripSeparator();
        exitButton = new ToolStripMenuItem();
        trayNotifyIconContextMenu.SuspendLayout();
        SuspendLayout();
        // 
        // entryTextBox
        // 
        entryTextBox.Dock = DockStyle.Fill;
        entryTextBox.Location = new Point(0, 0);
        entryTextBox.Multiline = true;
        entryTextBox.Name = "entryTextBox";
        entryTextBox.Size = new Size(624, 281);
        entryTextBox.TabIndex = 0;
        entryTextBox.KeyDown += EntryTextBox_KeyDown;
        // 
        // trayNotifyIcon
        // 
        trayNotifyIcon.ContextMenuStrip = trayNotifyIconContextMenu;
        trayNotifyIcon.Visible = true;
        trayNotifyIcon.MouseClick += TrayNotifyIcon_MouseClick;
        // 
        // trayNotifyIconContextMenu
        // 
        trayNotifyIconContextMenu.Items.AddRange(new ToolStripItem[] { showCurrentLogButton, showAllLogsButton, contextMenuSeparator, exitButton });
        trayNotifyIconContextMenu.Name = "trayNotifyIconContextMenu";
        trayNotifyIconContextMenu.Size = new Size(165, 76);
        // 
        // showCurrentLogButton
        // 
        showCurrentLogButton.Name = "showCurrentLogButton";
        showCurrentLogButton.Size = new Size(164, 22);
        showCurrentLogButton.Text = "Show current log";
        showCurrentLogButton.Click += ShowCurrentLogButton_Click;
        // 
        // showAllLogsButton
        // 
        showAllLogsButton.Name = "showAllLogsButton";
        showAllLogsButton.Size = new Size(164, 22);
        showAllLogsButton.Text = "Show all logs";
        showAllLogsButton.Click += ShowAllLogsButton_Click;
        // 
        // contextMenuSeparator
        // 
        contextMenuSeparator.Name = "contextMenuSeparator";
        contextMenuSeparator.Size = new Size(161, 6);
        // 
        // exitButton
        // 
        exitButton.Name = "exitButton";
        exitButton.Size = new Size(164, 22);
        exitButton.Text = "Exit";
        exitButton.Click += ExitButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(624, 281);
        Controls.Add(entryTextBox);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MainForm";
        SizeGripStyle = SizeGripStyle.Hide;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Add entry...";
        TopMost = true;
        FormClosing += MainForm_FormClosing;
        trayNotifyIconContextMenu.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox entryTextBox;
    private NotifyIcon trayNotifyIcon;
    private ContextMenuStrip trayNotifyIconContextMenu;
    private ToolStripMenuItem showCurrentLogButton;
    private ToolStripMenuItem showAllLogsButton;
    private ToolStripSeparator contextMenuSeparator;
    private ToolStripMenuItem exitButton;
}
