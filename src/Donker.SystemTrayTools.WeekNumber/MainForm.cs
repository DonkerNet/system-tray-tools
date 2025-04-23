using Donker.SystemTrayTools.WeekNumber.Graphics;
using Donker.SystemTrayTools.WeekNumber.Helpers;
using System.Configuration;
using Timer = System.Timers.Timer;

namespace Donker.SystemTrayTools.WeekNumber;

public partial class MainForm : Form
{
    private readonly AppSettings _settings;
    private readonly Timer _updateTimer;
    private int _currentWeekNumber;

    public MainForm()
    {
        _settings = AppSettings.Default;

        InitializeComponent();
        InitializeTrayContextMenu();

        int refreshInterval = GetRefreshInterval();
        _updateTimer = new Timer(refreshInterval);
        _updateTimer.Elapsed += (sender, args) => UpdateWeekNumber();

        // Create and set an invisible parent window
        // This, in combination with MainForm's current settings, prevents the window from showing up in ALT+TAB
        Owner = new Form
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            ShowInTaskbar = false
        };
    }

    private static int GetRefreshInterval()
    {
        const int fallback = 60000;
        string? intervalString = ConfigurationManager.AppSettings["RefreshInterval"];
        return int.TryParse(intervalString, out int interval) ? interval : fallback;
    }

    private void InitializeTrayContextMenu()
    {
        backColorDialog.Color = _settings.BackColor;
        foreColorDialog.Color = _settings.ForeColor;

        weekTrayIcon.ContextMenuStrip = new ContextMenuStrip();

        weekTrayIcon.ContextMenuStrip.Items.AddRange([
            new ToolStripMenuItem("Show background color", null, (sender, args) => ToggleBackground((ToolStripMenuItem)sender!)) { Checked = _settings.ShowBackColor },
            new ToolStripMenuItem("Set background color", null, (sender, args) => PickBackColor()),
            new ToolStripMenuItem("Set text color", null, (sender, args) => PickForeColor()),
            new ToolStripSeparator(),
            new ToolStripMenuItem("Exit", null, (sender, args) => Exit())
        ]);
    }

    protected override void OnLoad(EventArgs e)
    {
        UpdateWeekNumber(allowDispose: false);
        _updateTimer.Start();
    }

    private void UpdateWeekNumber(bool allowDispose = true)
    {
        int weekNumber = DateTimeOffsetHelper.GetIso8601WeekNumber(DateTimeOffset.Now);

        var renderer = new WeekNumberRenderer(_settings);
        var icon = renderer.RenderIcon(weekNumber);

        if (allowDispose)
            weekTrayIcon.Icon?.Dispose();

        weekTrayIcon.Icon = icon;
        _currentWeekNumber = weekNumber;
    }

    private void ToggleBackground(ToolStripMenuItem menuItem)
    {
        menuItem.Checked = !menuItem.Checked;
        _settings.ShowBackColor = menuItem.Checked;
        _settings.Save();
        UpdateWeekNumber();
    }

    private void PickBackColor()
    {
        switch (backColorDialog.ShowDialog())
        {
            case DialogResult.OK:
            case DialogResult.Yes:
                _settings.BackColor = backColorDialog.Color;
                _settings.Save();
                UpdateWeekNumber();
                break;
        }
    }

    private void PickForeColor()
    {
        switch (foreColorDialog.ShowDialog())
        {
            case DialogResult.OK:
            case DialogResult.Yes:
                _settings.ForeColor = foreColorDialog.Color;
                _settings.Save();
                UpdateWeekNumber();
                break;
        }
    }

    private void Exit()
    {
        weekTrayIcon.Visible = false;
        weekTrayIcon.Icon?.Dispose();
        weekTrayIcon.Icon = null;
        Close();
        Application.Exit();
    }

    private void WeekTrayIcon_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left)
            return;

        DateTimeOffset currentOffSet = DateTimeOffset.Now;

        weekTrayIcon.BalloonTipText = string.Format(
            "{0}\r\nWeek {1}",
            currentOffSet.LocalDateTime.ToString("yyyy-MM-dd HH:mm:ss zzz"),
            _currentWeekNumber);

        weekTrayIcon.ShowBalloonTip(10000);
    }
}
