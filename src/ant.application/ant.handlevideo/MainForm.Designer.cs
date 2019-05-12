namespace ant.handlevideo
{
    partial class MainForm
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
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHandleVideo = new System.Windows.Forms.Button();
            this.cboIsAutoCutVideo = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurVideoSencodStart = new System.Windows.Forms.NumericUpDown();
            this.txtCurVideoSencodEnd = new System.Windows.Forms.NumericUpDown();
            this.cboVideoHeader = new System.Windows.Forms.CheckBox();
            this.cboVideoFloor = new System.Windows.Forms.CheckBox();
            this.btnHandleTestUp = new System.Windows.Forms.Button();
            this.cboDeleteResourceFile = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurVideoSencodStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurVideoSencodEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Location = new System.Drawing.Point(115, 22);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.Size = new System.Drawing.Size(421, 21);
            this.txtVideoPath.TabIndex = 0;
            this.txtVideoPath.Text = "C:\\Users\\admin\\Desktop\\a1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "处理文件路径:";
            // 
            // btnHandleVideo
            // 
            this.btnHandleVideo.Location = new System.Drawing.Point(557, 20);
            this.btnHandleVideo.Name = "btnHandleVideo";
            this.btnHandleVideo.Size = new System.Drawing.Size(75, 23);
            this.btnHandleVideo.TabIndex = 2;
            this.btnHandleVideo.Text = "处理";
            this.btnHandleVideo.UseVisualStyleBackColor = true;
            this.btnHandleVideo.Click += new System.EventHandler(this.btnHandleVideo_Click);
            // 
            // cboIsAutoCutVideo
            // 
            this.cboIsAutoCutVideo.AutoSize = true;
            this.cboIsAutoCutVideo.Location = new System.Drawing.Point(26, 60);
            this.cboIsAutoCutVideo.Name = "cboIsAutoCutVideo";
            this.cboIsAutoCutVideo.Size = new System.Drawing.Size(96, 16);
            this.cboIsAutoCutVideo.TabIndex = 3;
            this.cboIsAutoCutVideo.Text = "启用自动剪辑";
            this.cboIsAutoCutVideo.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "剪辑跳过开头时间(秒):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "剪辑去掉结尾时间(秒):";
            // 
            // txtCurVideoSencodStart
            // 
            this.txtCurVideoSencodStart.Location = new System.Drawing.Point(293, 58);
            this.txtCurVideoSencodStart.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtCurVideoSencodStart.Name = "txtCurVideoSencodStart";
            this.txtCurVideoSencodStart.Size = new System.Drawing.Size(75, 21);
            this.txtCurVideoSencodStart.TabIndex = 5;
            this.txtCurVideoSencodStart.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // txtCurVideoSencodEnd
            // 
            this.txtCurVideoSencodEnd.Location = new System.Drawing.Point(550, 58);
            this.txtCurVideoSencodEnd.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtCurVideoSencodEnd.Name = "txtCurVideoSencodEnd";
            this.txtCurVideoSencodEnd.Size = new System.Drawing.Size(75, 21);
            this.txtCurVideoSencodEnd.TabIndex = 6;
            this.txtCurVideoSencodEnd.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // cboVideoHeader
            // 
            this.cboVideoHeader.AutoSize = true;
            this.cboVideoHeader.Location = new System.Drawing.Point(21, 94);
            this.cboVideoHeader.Name = "cboVideoHeader";
            this.cboVideoHeader.Size = new System.Drawing.Size(72, 16);
            this.cboVideoHeader.TabIndex = 7;
            this.cboVideoHeader.Text = "添加片头";
            this.cboVideoHeader.UseVisualStyleBackColor = true;
            // 
            // cboVideoFloor
            // 
            this.cboVideoFloor.AutoSize = true;
            this.cboVideoFloor.Location = new System.Drawing.Point(103, 94);
            this.cboVideoFloor.Name = "cboVideoFloor";
            this.cboVideoFloor.Size = new System.Drawing.Size(72, 16);
            this.cboVideoFloor.TabIndex = 8;
            this.cboVideoFloor.Text = "添加片尾";
            this.cboVideoFloor.UseVisualStyleBackColor = true;
            // 
            // btnHandleTestUp
            // 
            this.btnHandleTestUp.Location = new System.Drawing.Point(28, 424);
            this.btnHandleTestUp.Name = "btnHandleTestUp";
            this.btnHandleTestUp.Size = new System.Drawing.Size(202, 23);
            this.btnHandleTestUp.TabIndex = 9;
            this.btnHandleTestUp.Text = "测试上传Yuotube";
            this.btnHandleTestUp.UseVisualStyleBackColor = true;
            this.btnHandleTestUp.Click += new System.EventHandler(this.btnHandleTestUp_Click);
            // 
            // cboDeleteResourceFile
            // 
            this.cboDeleteResourceFile.AutoSize = true;
            this.cboDeleteResourceFile.Location = new System.Drawing.Point(21, 116);
            this.cboDeleteResourceFile.Name = "cboDeleteResourceFile";
            this.cboDeleteResourceFile.Size = new System.Drawing.Size(132, 16);
            this.cboDeleteResourceFile.TabIndex = 10;
            this.cboDeleteResourceFile.Text = "处理完成删除原文件";
            this.cboDeleteResourceFile.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboDeleteResourceFile);
            this.Controls.Add(this.btnHandleTestUp);
            this.Controls.Add(this.cboVideoFloor);
            this.Controls.Add(this.cboVideoHeader);
            this.Controls.Add(this.txtCurVideoSencodEnd);
            this.Controls.Add(this.txtCurVideoSencodStart);
            this.Controls.Add(this.cboIsAutoCutVideo);
            this.Controls.Add(this.btnHandleVideo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVideoPath);
            this.Name = "MainForm";
            this.Text = "ffmpeg video hanle";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCurVideoSencodStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCurVideoSencodEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVideoPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHandleVideo;
        private System.Windows.Forms.CheckBox cboIsAutoCutVideo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtCurVideoSencodStart;
        private System.Windows.Forms.NumericUpDown txtCurVideoSencodEnd;
        private System.Windows.Forms.CheckBox cboVideoHeader;
        private System.Windows.Forms.CheckBox cboVideoFloor;
        private System.Windows.Forms.Button btnHandleTestUp;
        private System.Windows.Forms.CheckBox cboDeleteResourceFile;
    }
}

