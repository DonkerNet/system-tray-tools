namespace TrayWeekNumber
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.weekTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.foreColorDialog = new System.Windows.Forms.ColorDialog();
            this.backColorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // weekTrayIcon
            // 
            this.weekTrayIcon.Visible = true;
            this.weekTrayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.weekTrayIcon_MouseClick);
            // 
            // foreColorDialog
            // 
            this.foreColorDialog.AnyColor = true;
            this.foreColorDialog.Color = System.Drawing.Color.White;
            this.foreColorDialog.FullOpen = true;
            // 
            // backColorDialog
            // 
            this.backColorDialog.AnyColor = true;
            this.backColorDialog.Color = System.Drawing.Color.Transparent;
            this.backColorDialog.FullOpen = true;
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(260, 135);
            this.ControlBox = false;
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon weekTrayIcon;
        private System.Windows.Forms.ColorDialog foreColorDialog;
        private System.Windows.Forms.ColorDialog backColorDialog;
    }
}

