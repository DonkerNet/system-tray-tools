namespace Donker.SystemTrayTools.WeekNumber;

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
        weekTrayIcon = new NotifyIcon(components);
        foreColorDialog = new ColorDialog();
        backColorDialog = new ColorDialog();
        SuspendLayout();
        // 
        // weekTrayIcon
        // 
        weekTrayIcon.Visible = true;
        weekTrayIcon.MouseClick += WeekTrayIcon_MouseClick;
        // 
        // foreColorDialog
        // 
        foreColorDialog.AnyColor = true;
        foreColorDialog.Color = Color.White;
        foreColorDialog.FullOpen = true;
        // 
        // backColorDialog
        // 
        backColorDialog.AnyColor = true;
        backColorDialog.Color = Color.Transparent;
        backColorDialog.FullOpen = true;
        // 
        // MainForm
        // 
        AccessibleRole = AccessibleRole.None;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackgroundImageLayout = ImageLayout.None;
        ClientSize = new Size(260, 135);
        ControlBox = false;
        Enabled = false;
        FormBorderStyle = FormBorderStyle.None;
        MaximizeBox = false;
        MdiChildrenMinimizedAnchorBottom = false;
        MinimizeBox = false;
        Name = "MainForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.Manual;
        WindowState = FormWindowState.Minimized;
        ResumeLayout(false);
    }

    #endregion

    private NotifyIcon weekTrayIcon;
    private ColorDialog foreColorDialog;
    private ColorDialog backColorDialog;
}
