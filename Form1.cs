using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace Camera
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        public Form1()
        {
            InitializeComponent();
        }
        public bool camerastatus = false;//相机状态
        int count=0;
        int time =1200;//毫秒
        int CameraNum = 0;
        int[] CameraArray = new int[10];
        Random rd = new Random();


        private void buttonrandom_Click(object sender, EventArgs e)//按下开始按钮
        {
            if (cbFullScreen.Checked)//检查全屏模式
            {
                this.FormBorderStyle = FormBorderStyle.None;     //设置窗体为无边框样式
                this.WindowState = FormWindowState.Maximized;    //最大化窗体 
            }
            GameBegin();//游戏开始
        }

        private void Form1_Load_1(object sender, EventArgs e)//窗体加载时
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)//如果电脑里有摄像头
            {
                foreach (FilterInfo device in videoDevices)
                {
                    cmbCamera.Items.Add(device.Name);//给下拉菜单添加摄像头
                }
            }
            else//没有摄像头
            {
                MessageBox.Show("没有找到摄像头", "错误");
            }
            tbTimer.Text = (time/10).ToString();//给tb默认值2分钟
            cmbCamera.SelectedIndex = 0;//默认第一个
            CameraNum = cmbCamera.Items.Count;
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)//摄像头菜单
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[cmbCamera.SelectedIndex].MonikerString);
                GetDeviceResolution(videoDevice);
            }
        }
        private void GetDeviceResolution(VideoCaptureDevice videoCaptureDevice)//分辨率函数
        {
            int MaxResid = 0;
            int Resid = 0;
            int Res1 = 0;
            cmbResolution.Items.Clear();
            videoCapabilities = videoCaptureDevice.VideoCapabilities;
            foreach (VideoCapabilities capabilty in videoCapabilities)
            {
                cmbResolution.Items.Add($"{capabilty.FrameSize.Width} x {capabilty.FrameSize.Height}");
                int Res2 = capabilty.FrameSize.Width * capabilty.FrameSize.Height;
                if (Res2 > Res1)//计算摄像头支持的最大分辨率
                {
                    MaxResid = Resid;
                }
                Res1 = Res2;
                Resid++;
            }
            cmbResolution.SelectedIndex = MaxResid;
            string res = cmbResolution.SelectedItem.ToString();
            string[] num = res.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);//检出分辨率数值
            //vispShoot.Size = new System.Drawing.Size(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]));//赋值给视频窗体

        }
        
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//窗体关闭
        {
            DisConnect();
        }

        private void DisConnect()//断开相机
        {
            if (camerastatus == true)
            {
                vispShoot.SignalToStop();
                vispShoot.WaitForStop();
                camerastatus = false;
            }
        }
        private void Connect()//连接相机
        {
            if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
            {
                videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];
                vispShoot.VideoSource = videoDevice;
                vispShoot.Start();
                camerastatus = true;
            }
        }
        private void reConnect()//重连接相机
        {
                DisConnect();
                Connect();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)//按键时间
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                ResetSetting();
            }
            if(e.KeyChar == (char)Keys.Space)
            {
                if (this.buttonrandom.Visible == false)
                {
                    NextCamera();
                }
                else
                {
                    MessageBox.Show("请先按开始", "");
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            progressBar1.Value = count;//设置进度条进度
            if (count == time)
            {
                timer1.Stop();//停止计时
                progressBar1.Value = 0;
                count = 0;
                MessageBox.Show("You Lose", "");
                ResetCamera();
            }
        }

        private void GameBegin()
        {
            this.buttonrandom.Visible = false;
            this.label1.Visible = false;
            this.cbFullScreen.Visible = false;
            this.tbTimer.Visible = false;



            CameraArray = Enumerable.Range(0,cmbCamera.Items.Count)
                        .OrderBy(n => (rd.Next()))
                        .ToArray<int>();
            cmbCamera.SelectedIndex = CameraArray[CameraNum-1];
            reConnect();
            time = Convert.ToInt32(tbTimer.Text) * 10;
            progressBar1.Maximum = time;
            timer1.Start();
        }

        private void NextCamera()
        {
            CameraNum--;
            if (CameraNum != 0)
            {
                cmbCamera.SelectedIndex = CameraArray[CameraNum-1];
                reConnect();
                timer1.Stop();//停止计时
                progressBar1.Value = 0;
                count = 0;
                timer1.Start();
            }
            else
            {
                MessageBox.Show("You Win", "");
                ResetCamera();
            }
        }

        private void ResetCamera()
        {
            timer1.Stop();//停止计时
            progressBar1.Value = 0;
            count = 0;
            DisConnect();
            this.buttonrandom.Visible = true;
            CameraNum = cmbCamera.Items.Count;
        }

        private void ResetSetting()
        {
            ResetCamera();
            this.label1.Visible = true;
            this.cbFullScreen.Visible = true;
            this.tbTimer.Visible = true;
        }

    }
}
