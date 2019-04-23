namespace AudioClient_Form
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
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SerialOutputLog = new System.Windows.Forms.RichTextBox();
            this.TextBoxLog = new System.Windows.Forms.RichTextBox();
            this.VolumeSensitivity = new System.Windows.Forms.NumericUpDown();
            this.BufferReadSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ConnectToComPort = new System.Windows.Forms.Button();
            this.SampleRateInput = new System.Windows.Forms.Label();
            this.SampleRateMS = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CSCoreOutputLog = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.serialDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cSCoreDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadArduinoCodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BufferReadSize)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SampleRateMS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.StartButton, "StartButton");
            this.StartButton.Name = "StartButton";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.Start_Click);
            // 
            // StopButton
            // 
            this.StopButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.StopButton, "StopButton");
            this.StopButton.Name = "StopButton";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.Stop_Click);
            // 
            // SerialOutputLog
            // 
            resources.ApplyResources(this.SerialOutputLog, "SerialOutputLog");
            this.SerialOutputLog.Name = "SerialOutputLog";
            this.SerialOutputLog.ReadOnly = true;
            // 
            // TextBoxLog
            // 
            resources.ApplyResources(this.TextBoxLog, "TextBoxLog");
            this.TextBoxLog.Name = "TextBoxLog";
            this.TextBoxLog.ReadOnly = true;
            // 
            // VolumeSensitivity
            // 
            resources.ApplyResources(this.VolumeSensitivity, "VolumeSensitivity");
            this.VolumeSensitivity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.VolumeSensitivity.Name = "VolumeSensitivity";
            // 
            // BufferReadSize
            // 
            resources.ApplyResources(this.BufferReadSize, "BufferReadSize");
            this.BufferReadSize.Maximum = new decimal(new int[] {
            1600,
            0,
            0,
            0});
            this.BufferReadSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.BufferReadSize.Name = "BufferReadSize";
            this.BufferReadSize.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.BufferReadSize.ValueChanged += new System.EventHandler(this.BufferReadSize_ValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // RestartButton
            // 
            this.RestartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.RestartButton, "RestartButton");
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.Restart_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ConnectToComPort);
            this.panel2.Controls.Add(this.SampleRateInput);
            this.panel2.Controls.Add(this.SampleRateMS);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.VolumeSensitivity);
            this.panel2.Controls.Add(this.BufferReadSize);
            this.panel2.Controls.Add(this.label2);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // ConnectToComPort
            // 
            this.ConnectToComPort.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.ConnectToComPort, "ConnectToComPort");
            this.ConnectToComPort.Name = "ConnectToComPort";
            this.ConnectToComPort.UseVisualStyleBackColor = true;
            this.ConnectToComPort.Click += new System.EventHandler(this.ConnectToComPort_Click);
            // 
            // SampleRateInput
            // 
            resources.ApplyResources(this.SampleRateInput, "SampleRateInput");
            this.SampleRateInput.Name = "SampleRateInput";
            // 
            // SampleRateMS
            // 
            this.SampleRateMS.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            resources.ApplyResources(this.SampleRateMS, "SampleRateMS");
            this.SampleRateMS.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SampleRateMS.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SampleRateMS.Name = "SampleRateMS";
            this.SampleRateMS.Value = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.SampleRateMS.ValueChanged += new System.EventHandler(this.SampleRateMS_ValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // listBox1
            // 
            this.listBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox1.FormattingEnabled = true;
            resources.ApplyResources(this.listBox1, "listBox1");
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Name = "label4";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.TextBoxLog);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            resources.ApplyResources(this.tabControl2, "tabControl2");
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Multiline = true;
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.SerialOutputLog);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.CSCoreOutputLog);
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CSCoreOutputLog
            // 
            this.CSCoreOutputLog.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.CSCoreOutputLog, "CSCoreOutputLog");
            this.CSCoreOutputLog.Name = "CSCoreOutputLog";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clearLogsToolStripMenuItem,
            this.uploadArduinoCodeToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // clearLogsToolStripMenuItem
            // 
            this.clearLogsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logDataToolStripMenuItem,
            this.serialDataToolStripMenuItem,
            this.cSCoreDataToolStripMenuItem,
            this.clearAllLogsToolStripMenuItem});
            this.clearLogsToolStripMenuItem.Name = "clearLogsToolStripMenuItem";
            resources.ApplyResources(this.clearLogsToolStripMenuItem, "clearLogsToolStripMenuItem");
            // 
            // logDataToolStripMenuItem
            // 
            this.logDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem2});
            this.logDataToolStripMenuItem.Name = "logDataToolStripMenuItem";
            resources.ApplyResources(this.logDataToolStripMenuItem, "logDataToolStripMenuItem");
            // 
            // clearToolStripMenuItem2
            // 
            this.clearToolStripMenuItem2.Name = "clearToolStripMenuItem2";
            resources.ApplyResources(this.clearToolStripMenuItem2, "clearToolStripMenuItem2");
            this.clearToolStripMenuItem2.Click += new System.EventHandler(this.clearToolStripMenuItem2_Click);
            // 
            // serialDataToolStripMenuItem
            // 
            this.serialDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.serialDataToolStripMenuItem.Name = "serialDataToolStripMenuItem";
            resources.ApplyResources(this.serialDataToolStripMenuItem, "serialDataToolStripMenuItem");
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            resources.ApplyResources(this.clearToolStripMenuItem, "clearToolStripMenuItem");
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // cSCoreDataToolStripMenuItem
            // 
            this.cSCoreDataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem1});
            this.cSCoreDataToolStripMenuItem.Name = "cSCoreDataToolStripMenuItem";
            resources.ApplyResources(this.cSCoreDataToolStripMenuItem, "cSCoreDataToolStripMenuItem");
            // 
            // clearToolStripMenuItem1
            // 
            this.clearToolStripMenuItem1.Name = "clearToolStripMenuItem1";
            resources.ApplyResources(this.clearToolStripMenuItem1, "clearToolStripMenuItem1");
            this.clearToolStripMenuItem1.Click += new System.EventHandler(this.clearToolStripMenuItem1_Click);
            // 
            // clearAllLogsToolStripMenuItem
            // 
            this.clearAllLogsToolStripMenuItem.Name = "clearAllLogsToolStripMenuItem";
            resources.ApplyResources(this.clearAllLogsToolStripMenuItem, "clearAllLogsToolStripMenuItem");
            this.clearAllLogsToolStripMenuItem.Click += new System.EventHandler(this.clearAllLogsToolStripMenuItem_Click);
            // 
            // uploadArduinoCodeToolStripMenuItem
            // 
            resources.ApplyResources(this.uploadArduinoCodeToolStripMenuItem, "uploadArduinoCodeToolStripMenuItem");
            this.uploadArduinoCodeToolStripMenuItem.Name = "uploadArduinoCodeToolStripMenuItem";
            this.uploadArduinoCodeToolStripMenuItem.Click += new System.EventHandler(this.uploadArduinoCodeToolStripMenuItem_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.VolumeSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BufferReadSize)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SampleRateMS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.NumericUpDown VolumeSensitivity;
        private System.Windows.Forms.NumericUpDown BufferReadSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TextBoxLog;
        private System.Windows.Forms.Label SampleRateInput;
        private System.Windows.Forms.NumericUpDown SampleRateMS;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox SerialOutputLog;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ConnectToComPort;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox CSCoreOutputLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cSCoreDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem clearAllLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadArduinoCodeToolStripMenuItem;
    }
}

