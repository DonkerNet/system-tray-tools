using System;
using System.Drawing;
using System.Windows.Forms;
using TrayWeekNumber.Graphics;
using TrayWeekNumber.Helpers;
using Timer = System.Timers.Timer;

namespace TrayWeekNumber
{
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

            _updateTimer = new Timer(5000);
            _updateTimer.Elapsed += (sender, args) => UpdateWeekNumber();

            // Create and set an invisible parent window
            // This, in combination with MainForm's current settings, prevents the window from showing up in ALT+TAB
            Owner = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                ShowInTaskbar = false
            };
        }

        private void InitializeTrayContextMenu()
        {
            backColorDialog.Color = _settings.BackColor;
            foreColorDialog.Color = _settings.ForeColor;

            weekTrayIcon.ContextMenu = new ContextMenu(new []
            {
                new MenuItem("Show background color", (sender, args) => ToggleBackground(sender as MenuItem)) { Checked = _settings.ShowBackColor},
                new MenuItem("Set background color", (sender, args) => PickBackColor()),
                new MenuItem("Set text color", (sender, args) => PickForeColor()),
                new MenuItem("Exit", (sender, args) => Exit()){ BarBreak = true }
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            UpdateWeekNumber(allowDispose: false);
            _updateTimer.Start();
        }

        private void UpdateWeekNumber(bool allowDispose = true, bool forceUpdate = false)
        {
            int weekNumber = DateTimeOffsetHelper.GetIso8601WeekNumber(DateTimeOffset.Now);

            if (weekNumber == _currentWeekNumber && !forceUpdate)
                return;

            WeekNumberRenderer renderer = new WeekNumberRenderer(_settings);
            Icon icon = renderer.RenderIcon(weekNumber);
            
            if (allowDispose)
                weekTrayIcon.Icon.Dispose();

            weekTrayIcon.Icon = icon;
            _currentWeekNumber = weekNumber;
        }

        private void ToggleBackground(MenuItem menuItem)
        {
            menuItem.Checked = !menuItem.Checked;
            _settings.ShowBackColor = menuItem.Checked;
            _settings.Save();
            UpdateWeekNumber(forceUpdate: true);
        }

        private void PickBackColor()
        {
            switch (backColorDialog.ShowDialog())
            {
                case DialogResult.OK:
                case DialogResult.Yes:
                    _settings.BackColor = backColorDialog.Color;
                    _settings.Save();
                    UpdateWeekNumber(forceUpdate: true);
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
                    UpdateWeekNumber(forceUpdate: true);
                    break;
            }
        }

        private void Exit()
        {
            weekTrayIcon.Visible = false;
            weekTrayIcon.Icon.Dispose();
            weekTrayIcon.Icon = null;
            Close();
            Application.Exit();
        }

        private void weekTrayIcon_MouseClick(object sender, MouseEventArgs e)
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
}
