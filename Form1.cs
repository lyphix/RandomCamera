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
      
       
        
        private void buttonrandom_Click(object sender, EventArgs e)//按下随机按钮
        {
            int max = cmbCamera.Items.Count;//取设备数
            Random num = new Random();
            int rad = num.Next(0, max);
            cmbCamera.SelectedIndex = rad;//下拉菜单随机
            reConnect();//连接相机
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
                cmbCamera.Items.Add("没有找到摄像头");
            }

            cmbCamera.SelectedIndex = 0;//默认第一个
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)//摄像头菜单
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[cmbCamera.SelectedIndex].MonikerString);
                GetDeviceResolution(videoDevice);
                reConnect();
            }
        }
        private void GetDeviceResolution(VideoCaptureDevice videoCaptureDevice)//分辨率函数
        {
            cmbResolution.Items.Clear();
            videoCapabilities = videoCaptureDevice.VideoCapabilities;
            foreach (VideoCapabilities capabilty in videoCapabilities)
            {
                cmbResolution.Items.Add($"{capabilty.FrameSize.Width} x {capabilty.FrameSize.Height}");
            }
            cmbResolution.SelectedIndex = 0;
            string res = cmbResolution.SelectedItem.ToString();
            string[] num = res.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);//检出分辨率数值
            vispShoot.Size = new System.Drawing.Size(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]));//赋值给视频窗体

        }

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)//分辨率菜单
        {
            string res = cmbResolution.SelectedItem.ToString();
            string[] num = res.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
            vispShoot.Size = new System.Drawing.Size(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]));
            reConnect();
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


    }
}
