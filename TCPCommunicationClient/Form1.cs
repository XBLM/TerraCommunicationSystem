﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;

namespace TCPCommunicationClient
{
    public partial class Form1 : Form
    {
        //创建任务
        Task task;
        bool cancelTask = false;
        int IPcount = 0;
        Socket _socket;
        Socket sClient;
        //缓冲区长度
        int bufferLength = 1024*8;
        //客户端Socket链表
        List<Socket> clientSocket = new List<Socket>(); 

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] text = Encoding.UTF8.GetBytes(sendMsg.Text);
            if(ConnectionStatus.Text != "连接状态：已连接")
            {
                outputLog("未连接服务器，无法发送数据！");
                return;
            }
            try
            {
                if (Mode.SelectedIndex == 0)
                {
                    //客户端
                    int byteNum = _socket.Send(text);
                    outputLog(string.Format("{0}byte数据已发送", byteNum));
                    if (sendMsg.Text == "exit")
                    {
                        outputLog("连接已断开");
                        cancelTask = true;
                        _socket.Close();
                        _socket = null;
                        ConnectionStatus.Text = "连接状态：未连接";
                        ConnectionStatus.ForeColor = Color.Red;
                        return;
                    }
                }
                else
                {
                    //服务端
                    if(TargetClient.SelectedIndex == 0)
                    {
                        foreach(var sc in clientSocket)
                        {
                            outputLog(string.Format("{0}byte数据已发送 To:{1}", sc.Send(text), 
                                sc.LocalEndPoint.ToString()));
                        }
                    }
                    else
                    {
                        Socket sc = clientSocket[TargetClient.SelectedIndex - 1];
                        outputLog(string.Format("{0}byte数据已发送 To:{1}", sc.Send(text),
                                sc.LocalEndPoint.ToString()));
                    }
                    if (sendMsg.Text == "exit")
                    {
                        outputLog("连接已断开");
                        cancelTask = true;
                        foreach(var sc in clientSocket)
                        {
                            sc.Close();
                        }
                        clientSocket.Clear();
                        ConnectionStatus.Text = "连接状态：未连接";
                        ConnectionStatus.ForeColor = Color.Red;
                        return;
                    }
                }

            }
            catch(Exception ex)
            {
                outputLog(ex.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //启动自动获取IP地址
            try
            {
                HostIPLabel_Click(new object(), new EventArgs());
                outputLog("自动获取IP成功");
            }
            catch(Exception)
            {
                outputLog("获取IP信息失败，请检查网络连接！");
                HostIP.Text = "127.0.0.1";
            }
            //初始化本机角色
            Mode.SelectedIndex = 0;
            //初始化连接状态
            ConnectionStatus.Text = "连接状态：未连接";
            ConnectionStatus.ForeColor = Color.Red;
            //取消跨线程访问警告
            Control.CheckForIllegalCrossThreadCalls = false;
            //初始化发送消息字节数
            sendMsgLabel.Text = string.Format("发送消息（当前{0}byte）",
                Encoding.UTF8.GetBytes(sendMsg.Text).Length);
            //初始化完成
            outputLog("初始化完成");

        }

        private void HostIPLabel_Click(object sender, EventArgs e)
        {
            try
            {
                IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
                HostIP.Items.Clear();
                HostIP.Items.AddRange(ipEntry.AddressList);
                HostIP.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                outputLog(ex.ToString());
            }
        }

        private void ConnectBtn_Click(object sender, EventArgs e)
        {
            Mode.Enabled = false;
            cancelTask = false;
            if(Mode.SelectedIndex == 1)
            {
                //服务端
                if (_socket != null)
                    _socket.Close();
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //启动监听
                try
                {
                    IPAddress hostIP = IPAddress.Parse(HostIP.Text.Trim());
                    int portNum = int.Parse(Port.Text.Trim());
                    IPEndPoint endPoint = new IPEndPoint(hostIP, portNum);
                    outputLog(string.Format("正在监听{0}端口", portNum));
                    _socket.Bind(endPoint);
                    _socket.Listen(1);

                    task = new Task(ListenFunc);
                    task.Start();
                }
                catch(Exception errorStatus)
                {
                    outputLog(errorStatus.ToString());
                }

            }
            else
            {
                //客户端
                if (_socket != null)
                    _socket.Close();
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                try
                {
                    IPAddress targetIP = IPAddress.Parse(TargetIP.Text.Trim());
                    int portNum = int.Parse(Port.Text.Trim());
                    IPEndPoint endPoint = new IPEndPoint(targetIP, portNum);
                    outputLog(string.Format("正在向主机{0}建立连接", targetIP.ToString()));
                    //发送请求
                    _socket.Connect(endPoint);
                    outputLog(string.Format("成功连接到{0}主机", targetIP.ToString()));
                    //更新状态
                    ConnectionStatus.Text = "连接状态：已连接";
                    ConnectionStatus.ForeColor = Color.Green;
                    //创建接收数据线程
                    task = new Task(RecvFunc);
                    task.Start();
                }
                catch (Exception errorStatus)
                {
                    outputLog(errorStatus.ToString());
                }

            }
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            Mode.Enabled = true;
            if(_socket == null)
            {
                outputLog("当前未建立连接");
                return;
            }
            if(Mode.SelectedIndex == 1)
            {
                //服务端
                outputLog("已关闭监听");
                cancelTask = true;
                try
                {
                    sClient.Send(Encoding.UTF8.GetBytes("exit"));
                }
                catch (Exception) { };
                _socket.Close();
                _socket = null;
            }
            else
            {
                //客户端
                outputLog("已关闭连接");
                cancelTask = true; try
                {
                    _socket.Send(Encoding.UTF8.GetBytes("exit"));
                }
                catch (Exception) { };
                _socket.Close();
                _socket = null;
            }
            ConnectionStatus.Text = "连接状态：未连接";
            ConnectionStatus.ForeColor = Color.Red;
        }

        private void outputLog(string logInfo)
        {
            Log.AppendText(Environment.NewLine + DateTime.Now.ToString() + Environment.NewLine + logInfo);
        }

        private void LogLabel_Click(object sender, EventArgs e)
        {
            //清除日志
            Log.Text = "";
        }

        private void Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            outputLog(string.Format("切换为{0}模式", Mode.Text));
            if (Mode.SelectedIndex == 1)
            {
                ConnectBtn.Text = "监听";
            }
            else
            {
                ConnectBtn.Text = "连接";
            }
        }

        private void Port_TextChanged(object sender, EventArgs e)
        {
            outputLog(string.Format("端口配置为{0}", Port.Text));
        }

        private void ListenFunc()
        {
            byte[] buffer = new byte[bufferLength];
            int byteNum;
            while(!cancelTask)
            {
                outputLog("正在等待连接...");
                sClient = _socket.Accept();
                clientSocket.Add(sClient);
                outputLog(string.Format("连接到{0}\r\n正在接收数据...", 
                    sClient.RemoteEndPoint.ToString()));
                //更新状态
                ConnectionStatus.Text = "连接状态：已连接";
                ConnectionStatus.ForeColor = Color.Green;
                RefreshTargetClientComboBox();
                //向对面机器发送欢迎
                sClient.Send(Encoding.UTF8.GetBytes(string.Format("你好，{0}", 
                    sClient.RemoteEndPoint.ToString())));
                Task.Factory.StartNew(() =>
                {
                    RecvFuncSever(sClient);
                });
            }
            return;
        }

        private void RecvFuncSever(Socket sClient)
        {
            int byteNum = 0;
            byte[] buffer = new byte[bufferLength];
            while(!cancelTask)
            {
                byteNum = sClient.Receive(buffer);
                string recvString = Encoding.UTF8.GetString(buffer).Trim();
                buffer = new byte[bufferLength];
                outputLog(string.Format("接收到{0}byte数据", byteNum));
                recvMsg.AppendText(string.Format("\r\n\r\n<{0}>\r\n{1} 说:\r\n{2}",
                    DateTime.Now.ToString(), sClient.LocalEndPoint.ToString(), recvString));
                if (string.Compare(recvString, "exit") == 0)
                {
                    outputLog("连接已断开，继续监听中...");
                    sClient.Close();
                    sClient = null;
                    ConnectionStatus.Text = "连接状态：未连接";
                    ConnectionStatus.ForeColor = Color.Red;
                    break;
                }
                if (recvString[0].ToString() != "*")
                    sClient.Send(Encoding.UTF8.GetBytes(string.Format("*接收到{0}byte数据",
                        byteNum)));
            }
        }

        private void RecvFunc()
        {
            byte[] buffer = new byte[bufferLength];
            while (!cancelTask)
            {
                //outputLog("正在接收数据...");
                int byteNum = _socket.Receive(buffer);
                string recvString = Encoding.UTF8.GetString(buffer).Trim();
                outputLog(string.Format("接收到{0}byte数据", byteNum));
                recvMsg.AppendText(string.Format("\r\n\r\n<{0}>\r\n{1}", DateTime.Now.ToString(),recvString));
                buffer = new byte[bufferLength]; 
                if (string.Compare(recvString, "exit") == 0)
                {
                    outputLog("连接已断开");
                    cancelTask = true;
                    _socket.Close();
                    _socket = null;
                    ConnectionStatus.Text = "连接状态：未连接";
                    ConnectionStatus.ForeColor = Color.Red;
                    break;
                }
                if (recvString[0].ToString() != "*")
                    _socket.Send(Encoding.UTF8.GetBytes(string.Format("*接收到{0}byte数据", 
                        byteNum)));
            }
            return;
        }

        private void recvMsgLabel_Click(object sender, EventArgs e)
        {
            recvMsg.Text = "";
        }

        private void sendMsg_TextChanged(object sender, EventArgs e)
        {
            sendMsgLabel.Text = string.Format("发送消息（当前{0}byte）",
                Encoding.UTF8.GetBytes(sendMsg.Text).Length);
        }

        private void TargetIPLabel_Click(object sender, EventArgs e)
        {
            int choice = (int)MessageBox.Show("要开始端口扫描吗？\r\n（该过程可能需要较长时间）", "请确认操作",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (choice == 1)
            {
                outputLog("开始端口扫描...");
                //NetworkInterface networkInterface = 
                outputLog("端口扫描结束");
            }
        }

        private void IPScan()
        {

        }

        private void AppInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terra灾后应急网络系统 V1.1.2\r\n基于TCPConnectClient\r\nCopyright © AyakaSoft 2024", "软件信息", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void RefreshTargetClientComboBox()
        {
            int i = TargetClient.SelectedIndex;
            TargetClient.Items.Clear();
            TargetClient.Items.Add("广播给所有用户");
            TargetClient.Items.Add(clientSocket);
            TargetClient.SelectedIndex = i;
        }
    }
}
