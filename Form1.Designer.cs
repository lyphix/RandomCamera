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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cmbResolution = new System.Windows.Forms.ComboBox();
            this.vispShoot = new AForge.Controls.VideoSourcePlayer();
            this.buttonrandom = new System.Windows.Forms.Button();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbFullScreen = new System.Windows.Forms.CheckBox();
            this.tbTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmbResolution
            // 
            this.cmbResolution.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbResolution.FormattingEnabled = true;
            this.cmbResolution.Location = new System.Drawing.Point(535, 323);
            this.cmbResolution.Name = "cmbResolution";
            this.cmbResolution.Size = new System.Drawing.Size(108, 20);
            this.cmbResolution.TabIndex = 1;
            // 
            // vispShoot
            // 
            this.vispShoot.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vispShoot.Location = new System.Drawing.Point(12, 12);
            this.vispShoot.Name = "vispShoot";
            this.vispShoot.Size = new System.Drawing.Size(897, 513);
            this.vispShoot.TabIndex = 2;
            this.vispShoot.Text = "videoSourcePlayer1";
            this.vispShoot.VideoSource = null;
            // 
            // buttonrandom
            // 
            this.buttonrandom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonrandom.Location = new System.Drawing.Point(406, 272);
            this.buttonrandom.Name = "buttonrandom";
            this.buttonrandom.Size = new System.Drawing.Size(108, 23);
            this.buttonrandom.TabIndex = 3;
            this.buttonrandom.Text = "开始";
            this.buttonrandom.UseVisualStyleBackColor = true;
            this.buttonrandom.Click += new System.EventHandler(this.buttonrandom_Click);
            // 
            // cmbCamera
            // 
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(139, 12);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(121, 20);
            this.cmbCamera.TabIndex = 5;
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 531);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(897, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // cbFullScreen
            // 
            this.cbFullScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFullScreen.AutoSize = true;
            this.cbFullScreen.Location = new System.Drawing.Point(535, 301);
            this.cbFullScreen.Name = "cbFullScreen";
            this.cbFullScreen.Size = new System.Drawing.Size(84, 16);
            this.cbFullScreen.TabIndex = 7;
            this.cbFullScreen.Text = "是否全屏化";
            this.cbFullScreen.UseVisualStyleBackColor = true;
            // 
            // tbTimer
            // 
            this.tbTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbTimer.Location = new System.Drawing.Point(604, 274);
            this.tbTimer.Name = "tbTimer";
            this.tbTimer.Size = new System.Drawing.Size(39, 21);
            this.tbTimer.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "倒计时(秒)";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 566);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTimer);
            this.Controls.Add(this.cbFullScreen);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonrandom);
            this.Controls.Add(this.vispShoot);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.cmbResolution);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "随机摄像头";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbResolution;
        private AForge.Controls.VideoSourcePlayer vispShoot;
        private System.Windows.Forms.Button buttonrandom;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cbFullScreen;
        private System.Windows.Forms.TextBox tbTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

