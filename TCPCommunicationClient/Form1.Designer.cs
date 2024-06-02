namespace TCPCommunicationClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.recvMsg = new System.Windows.Forms.TextBox();
            this.sendMsg = new System.Windows.Forms.TextBox();
            this.recvMsgLabel = new System.Windows.Forms.Label();
            this.sendMsgLabel = new System.Windows.Forms.Label();
            this.sendBtn = new System.Windows.Forms.Button();
            this.HostIPLabel = new System.Windows.Forms.Label();
            this.TargetIPLabel = new System.Windows.Forms.Label();
            this.TargetIP = new System.Windows.Forms.TextBox();
            this.ConnectionStatus = new System.Windows.Forms.Label();
            this.DisconnectBtn = new System.Windows.Forms.Button();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.Port = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.LogLabel = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TextBox();
            this.ModeLabel = new System.Windows.Forms.Label();
            this.Mode = new System.Windows.Forms.ComboBox();
            this.AppInfo = new System.Windows.Forms.Label();
            this.HostIP = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // recvMsg
            // 
            this.recvMsg.AcceptsReturn = true;
            this.recvMsg.AcceptsTab = true;
            this.recvMsg.Location = new System.Drawing.Point(280, 36);
            this.recvMsg.Multiline = true;
            this.recvMsg.Name = "recvMsg";
            this.recvMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.recvMsg.Size = new System.Drawing.Size(793, 333);
            this.recvMsg.TabIndex = 0;
            // 
            // sendMsg
            // 
            this.sendMsg.AcceptsReturn = true;
            this.sendMsg.AcceptsTab = true;
            this.sendMsg.Location = new System.Drawing.Point(280, 418);
            this.sendMsg.Multiline = true;
            this.sendMsg.Name = "sendMsg";
            this.sendMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.sendMsg.Size = new System.Drawing.Size(793, 333);
            this.sendMsg.TabIndex = 1;
            this.sendMsg.Text = resources.GetString("sendMsg.Text");
            this.sendMsg.TextChanged += new System.EventHandler(this.sendMsg_TextChanged);
            // 
            // recvMsgLabel
            // 
            this.recvMsgLabel.AutoSize = true;
            this.recvMsgLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.recvMsgLabel.Location = new System.Drawing.Point(276, 10);
            this.recvMsgLabel.Name = "recvMsgLabel";
            this.recvMsgLabel.Size = new System.Drawing.Size(209, 20);
            this.recvMsgLabel.TabIndex = 2;
            this.recvMsgLabel.Text = "接收消息（点击刷新）";
            this.recvMsgLabel.Click += new System.EventHandler(this.recvMsgLabel_Click);
            // 
            // sendMsgLabel
            // 
            this.sendMsgLabel.AutoSize = true;
            this.sendMsgLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.sendMsgLabel.Location = new System.Drawing.Point(276, 392);
            this.sendMsgLabel.Name = "sendMsgLabel";
            this.sendMsgLabel.Size = new System.Drawing.Size(89, 20);
            this.sendMsgLabel.TabIndex = 3;
            this.sendMsgLabel.Text = "发送消息";
            // 
            // sendBtn
            // 
            this.sendBtn.Location = new System.Drawing.Point(912, 758);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(161, 56);
            this.sendBtn.TabIndex = 4;
            this.sendBtn.Text = "发送";
            this.sendBtn.UseVisualStyleBackColor = true;
            this.sendBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // HostIPLabel
            // 
            this.HostIPLabel.AutoSize = true;
            this.HostIPLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.HostIPLabel.Location = new System.Drawing.Point(9, 10);
            this.HostIPLabel.Name = "HostIPLabel";
            this.HostIPLabel.Size = new System.Drawing.Size(189, 20);
            this.HostIPLabel.TabIndex = 5;
            this.HostIPLabel.Text = "本机IP（点击刷新）";
            this.HostIPLabel.Click += new System.EventHandler(this.HostIPLabel_Click);
            // 
            // TargetIPLabel
            // 
            this.TargetIPLabel.AutoSize = true;
            this.TargetIPLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.TargetIPLabel.Location = new System.Drawing.Point(9, 70);
            this.TargetIPLabel.Name = "TargetIPLabel";
            this.TargetIPLabel.Size = new System.Drawing.Size(69, 20);
            this.TargetIPLabel.TabIndex = 7;
            this.TargetIPLabel.Text = "目标IP";
            this.TargetIPLabel.Click += new System.EventHandler(this.TargetIPLabel_Click);
            // 
            // TargetIP
            // 
            this.TargetIP.Location = new System.Drawing.Point(13, 96);
            this.TargetIP.Name = "TargetIP";
            this.TargetIP.Size = new System.Drawing.Size(260, 30);
            this.TargetIP.TabIndex = 8;
            // 
            // ConnectionStatus
            // 
            this.ConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.ConnectionStatus.Location = new System.Drawing.Point(14, 252);
            this.ConnectionStatus.Name = "ConnectionStatus";
            this.ConnectionStatus.Size = new System.Drawing.Size(260, 26);
            this.ConnectionStatus.TabIndex = 9;
            this.ConnectionStatus.Text = "连接状态：未连接";
            this.ConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DisconnectBtn
            // 
            this.DisconnectBtn.Font = new System.Drawing.Font("宋体", 10F);
            this.DisconnectBtn.Location = new System.Drawing.Point(13, 281);
            this.DisconnectBtn.Name = "DisconnectBtn";
            this.DisconnectBtn.Size = new System.Drawing.Size(123, 33);
            this.DisconnectBtn.TabIndex = 10;
            this.DisconnectBtn.Text = "断开";
            this.DisconnectBtn.UseVisualStyleBackColor = true;
            this.DisconnectBtn.Click += new System.EventHandler(this.DisconnectBtn_Click);
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Font = new System.Drawing.Font("宋体", 10F);
            this.ConnectBtn.Location = new System.Drawing.Point(152, 281);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(121, 33);
            this.ConnectBtn.TabIndex = 11;
            this.ConnectBtn.Text = "连接";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(13, 155);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(260, 30);
            this.Port.TabIndex = 13;
            this.Port.Text = "11451";
            this.Port.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.PortLabel.Location = new System.Drawing.Point(9, 129);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(69, 20);
            this.PortLabel.TabIndex = 12;
            this.PortLabel.Text = "端口号";
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.LogLabel.Location = new System.Drawing.Point(9, 317);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(169, 20);
            this.LogLabel.TabIndex = 15;
            this.LogLabel.Text = "日志（点击刷新）";
            this.LogLabel.Click += new System.EventHandler(this.LogLabel_Click);
            // 
            // Log
            // 
            this.Log.AcceptsReturn = true;
            this.Log.Location = new System.Drawing.Point(13, 340);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(261, 411);
            this.Log.TabIndex = 14;
            // 
            // ModeLabel
            // 
            this.ModeLabel.AutoSize = true;
            this.ModeLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.ModeLabel.Location = new System.Drawing.Point(9, 188);
            this.ModeLabel.Name = "ModeLabel";
            this.ModeLabel.Size = new System.Drawing.Size(89, 20);
            this.ModeLabel.TabIndex = 12;
            this.ModeLabel.Text = "本机角色";
            // 
            // Mode
            // 
            this.Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Mode.FormattingEnabled = true;
            this.Mode.Items.AddRange(new object[] {
            "客户端",
            "服务端"});
            this.Mode.Location = new System.Drawing.Point(13, 212);
            this.Mode.Name = "Mode";
            this.Mode.Size = new System.Drawing.Size(260, 28);
            this.Mode.TabIndex = 16;
            this.Mode.SelectedIndexChanged += new System.EventHandler(this.Mode_SelectedIndexChanged);
            // 
            // AppInfo
            // 
            this.AppInfo.AutoSize = true;
            this.AppInfo.BackColor = System.Drawing.SystemColors.Control;
            this.AppInfo.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppInfo.ForeColor = System.Drawing.Color.Blue;
            this.AppInfo.Location = new System.Drawing.Point(9, 770);
            this.AppInfo.Name = "AppInfo";
            this.AppInfo.Size = new System.Drawing.Size(314, 44);
            this.AppInfo.TabIndex = 17;
            this.AppInfo.Text = "TCPConnectClient  Version1.1.0_Beta\r\nPoweredBy Sibei@UESTC";
            // 
            // HostIP
            // 
            this.HostIP.FormattingEnabled = true;
            this.HostIP.Location = new System.Drawing.Point(13, 36);
            this.HostIP.Name = "HostIP";
            this.HostIP.Size = new System.Drawing.Size(260, 28);
            this.HostIP.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 827);
            this.Controls.Add(this.HostIP);
            this.Controls.Add(this.AppInfo);
            this.Controls.Add(this.Mode);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.ModeLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.DisconnectBtn);
            this.Controls.Add(this.ConnectionStatus);
            this.Controls.Add(this.TargetIP);
            this.Controls.Add(this.TargetIPLabel);
            this.Controls.Add(this.HostIPLabel);
            this.Controls.Add(this.sendBtn);
            this.Controls.Add(this.sendMsgLabel);
            this.Controls.Add(this.recvMsgLabel);
            this.Controls.Add(this.sendMsg);
            this.Controls.Add(this.recvMsg);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TCPConnectClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox recvMsg;
        private System.Windows.Forms.TextBox sendMsg;
        private System.Windows.Forms.Label recvMsgLabel;
        private System.Windows.Forms.Label sendMsgLabel;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.Label HostIPLabel;
        private System.Windows.Forms.Label TargetIPLabel;
        private System.Windows.Forms.TextBox TargetIP;
        private System.Windows.Forms.Label ConnectionStatus;
        private System.Windows.Forms.Button DisconnectBtn;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label ModeLabel;
        private System.Windows.Forms.ComboBox Mode;
        private System.Windows.Forms.Label AppInfo;
        private System.Windows.Forms.ComboBox HostIP;
    }
}

