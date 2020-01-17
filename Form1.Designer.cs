namespace Camera
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.vispShoot = new AForge.Controls.VideoSourcePlayer();
            this.buttonrandom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分辨率：";
            // 
            // cmbResolution
            // 
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(72, 10);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(121, 20);
            this.cmbResolution.TabIndex = 1;
            this.cmbResolution.SelectedIndexChanged += new System.EventHandler(this.cmbResolution_SelectedIndexChanged);
            // 
            // vispShoot
            // 
            this.vispShoot.Location = new System.Drawing.Point(12, 36);
            this.vispShoot.Name = "vispShoot";
            this.vispShoot.Size = new System.Drawing.Size(629, 344);
            this.vispShoot.TabIndex = 2;
            this.vispShoot.Text = "videoSourcePlayer1";
            this.vispShoot.VideoSource = null;
            // 
            // buttonrandom
            // 
            this.buttonrandom.Location = new System.Drawing.Point(385, 7);
            this.buttonrandom.Name = "buttonrandom";
            this.buttonrandom.Size = new System.Drawing.Size(108, 23);
            this.buttonrandom.TabIndex = 3;
            this.buttonrandom.Text = "打开随机摄像头";
            this.buttonrandom.UseVisualStyleBackColor = true;
            this.buttonrandom.Click += new System.EventHandler(this.buttonrandom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "摄像头：";
            // 
            // cmbCamera
            // 
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(258, 9);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(121, 20);
            this.cmbCamera.TabIndex = 5;
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonrandom);
            this.Controls.Add(this.vispShoot);
            this.Controls.Add(this.cmbResolution);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "随机相机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbResolution;
        private AForge.Controls.VideoSourcePlayer vispShoot;
        private System.Windows.Forms.Button buttonrandom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCamera;
    }
}

