using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Appender;

namespace WorkLog
{
    public partial class MainForm : Form
    {
        private readonly ILog _log;
        private readonly RollingFileAppender _logAppender;

        public MainForm()
        {
            _log = LogManager.GetLogger(GetType());
            _logAppender = _log.Logger.Repository.GetAppenders().OfType<RollingFileAppender>().First();

            InitializeComponent();
            
            // Create and set an invisible parent window
            // This, in combination with MainForm's current settings, prevents the window from showing up in ALT+TAB
            Owner = new Form
            {
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                ShowInTaskbar = false
            };

            trayNotifyIcon.Icon = Icon;
            exitButton.Click += exitButton_Click;
            showCurrentLogButton.Click += showCurrentLogButton_Click;
            showAllLogsButton.Click += showAllLogsButton_Click;
        }
                
        protected override void OnShown(EventArgs e)
        {
            Visible = false;
        }
        
        private void OnEnter(KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;

            if (e.Shift)
            {
                // Insert newline on the current position

                int selectionStart = entryTextBox.SelectionStart;

                entryTextBox.Text = string.Concat(
                    entryTextBox.Text.Substring(0, selectionStart),
                    Environment.NewLine,
                    entryTextBox.Text.Substring(selectionStart + entryTextBox.SelectionLength));

                entryTextBox.SelectionStart = selectionStart + Environment.NewLine.Length;
                entryTextBox.SelectionLength = 0;
            }
            else if (!string.IsNullOrEmpty(entryTextBox.Text))
            {
                AddEntry();
            }
            else
            {
                Hide();
            }
        }

        private string NormalizeWhiteSpace(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            StringBuilder result = new StringBuilder();

            bool prevWasWs = false;

            foreach (char c in text.Trim())
            {
                if (char.IsWhiteSpace(c))
                {
                    prevWasWs = true;
                }
                else
                {
                    if (prevWasWs)
                    {
                        result.Append(' ');
                        prevWasWs = false;
                    }

                    result.Append(c);
                }
            }

            return result.ToString();
        }

        private void EnsureLogSetup()
        {
            if (File.Exists(_logAppender.File))
            {
                // File exists, check if it already has text content

                List<string> firstLines = File.ReadLines(_logAppender.File, Encoding.UTF8).Take(2).ToList();

                if (firstLines.Count > 1)
                    return; // File already has multiple lines

                if (firstLines.Count == 1 && string.IsNullOrEmpty(firstLines[0]))
                    return; // File has one line that is not empty
            }

            // We manually add the current date to the beginning of a new or empty log file
            using FileStream logStream = File.OpenWrite(_logAppender.File);
            using StreamWriter logWriter = new StreamWriter(logStream, Encoding.UTF8);
            logWriter.Write(DateTime.Now.ToString("yyyy-MM-dd"));
            logWriter.Flush();
        }

        private void AddEntry()
        {
            EnsureLogSetup();

            string entryText = NormalizeWhiteSpace(entryTextBox.Text);
            
            _log.Info(entryText);

            entryTextBox.Clear();
            Hide();
        }

        #region Event handlers

        private void trayNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Show();
            Focus();
            entryTextBox.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            trayNotifyIcon.Visible = false;
            trayNotifyIcon.Icon = null;
            Close();
            Application.Exit();
        }

        private void showCurrentLogButton_Click(object sender, EventArgs e)
        {
            Process.Start("notepad", _logAppender.File);
        }

        private void showAllLogsButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", Path.GetDirectoryName(_logAppender.File));
        }

        private void entryTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    OnEnter(e);
                    break;

                case Keys.Escape:
                    Hide();
                    break;
            }
        }

        #endregion

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
    }
}
