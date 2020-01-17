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
        private VideoCapabilities[] snapshotCapabilities;
        public Form1()
        {
            InitializeComponent();
        }
        public bool camerastatus = false;
      
       

        private void buttonrandom_Click(object sender, EventArgs e)
        {
            int max = cmbCamera.Items.Count;
            Random num = new Random();
            int rad = num.Next(0, max);
            cmbCamera.SelectedIndex = rad;
            if (videoDevice != null)
            {
                    if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                    {
                        videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

                        vispShoot.VideoSource = videoDevice;
                        vispShoot.Start();
                        camerastatus = true;
                    }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)
            {
                foreach (FilterInfo device in videoDevices)
                {
                    cmbCamera.Items.Add(device.Name);
                }
            }
            else
            {
                cmbCamera.Items.Add("没有找到摄像头");
            }

            cmbCamera.SelectedIndex = 0;
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[cmbCamera.SelectedIndex].MonikerString);
                GetDeviceResolution(videoDevice);
                if (camerastatus != true)
                {
                    if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                    {
                        videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

                        vispShoot.VideoSource = videoDevice;
                        vispShoot.Start();
                        camerastatus = true;
                    }
                }
                else
                {
                    DisConnect();
                    if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                    {
                        videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

                        vispShoot.VideoSource = videoDevice;
                        vispShoot.Start();
                        camerastatus = true;
                    }
                }
            }
        }
        private void GetDeviceResolution(VideoCaptureDevice videoCaptureDevice)
        {
            cmbResolution.Items.Clear();
            videoCapabilities = videoCaptureDevice.VideoCapabilities;
            foreach (VideoCapabilities capabilty in videoCapabilities)
            {
                cmbResolution.Items.Add($"{capabilty.FrameSize.Width} x {capabilty.FrameSize.Height}");
            }
            cmbResolution.SelectedIndex = 0;
            string res = cmbResolution.SelectedItem.ToString();
            string[] num = res.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
            vispShoot.Size = new System.Drawing.Size(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]));

        }

        //private void buttonopen_Click(object sender, EventArgs e)
        //{
        //    if (videoDevice != null)
        //    {
        //        if (camerastatus != true)
        //        {
        //            if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
        //            {
        //                videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

        //                vispShoot.VideoSource = videoDevice;
        //                vispShoot.Start();
        //                camerastatus = true;
        //            }
        //        }
        //        else
        //        {
        //            DisConnect();
        //            if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
        //            {
        //                videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

        //                vispShoot.VideoSource = videoDevice;
        //                vispShoot.Start();
        //                camerastatus = true;
        //            }
        //        }
        //    }
        //}

        private void cmbResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            string res = cmbResolution.SelectedItem.ToString();
            string[] num = res.Split(new string[] { "x" }, StringSplitOptions.RemoveEmptyEntries);
            vispShoot.Size = new System.Drawing.Size(Convert.ToInt32(num[0]), Convert.ToInt32(num[1]));
            if (camerastatus != true)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

                    vispShoot.VideoSource = videoDevice;
                    vispShoot.Start();
                    camerastatus = true;
                }
            }
            else
            {
                DisConnect();
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[cmbResolution.SelectedIndex];

                    vispShoot.VideoSource = videoDevice;
                    vispShoot.Start();
                    camerastatus = true;
                }
            }
        }
        private void DisConnect()
        {
            if (vispShoot.VideoSource != null)
            {
                vispShoot.SignalToStop();
                vispShoot.WaitForStop();
                vispShoot.VideoSource = null;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisConnect();
        }
    }
}
