namespace ceramictile.v3
{
    partial class ImageControlSettingDlg
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
            this.rb_ZoomOut = new System.Windows.Forms.RadioButton();
            this.rb_ZoomIn = new System.Windows.Forms.RadioButton();
            this.rb_Moving = new System.Windows.Forms.RadioButton();
            this.rb_Full = new System.Windows.Forms.RadioButton();
            this.cb_isLoadingBuffer = new System.Windows.Forms.CheckBox();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rb_ZoomOut
            // 
            this.rb_ZoomOut.AutoSize = true;
            this.rb_ZoomOut.Location = new System.Drawing.Point(86, 59);
            this.rb_ZoomOut.Name = "rb_ZoomOut";
            this.rb_ZoomOut.Size = new System.Drawing.Size(47, 16);
            this.rb_ZoomOut.TabIndex = 0;
            this.rb_ZoomOut.TabStop = true;
            this.rb_ZoomOut.Text = "放大";
            this.rb_ZoomOut.UseVisualStyleBackColor = true;
            this.rb_ZoomOut.CheckedChanged += new System.EventHandler(this.rb_ZoomOut_CheckedChanged);
            // 
            // rb_ZoomIn
            // 
            this.rb_ZoomIn.AutoSize = true;
            this.rb_ZoomIn.Location = new System.Drawing.Point(86, 97);
            this.rb_ZoomIn.Name = "rb_ZoomIn";
            this.rb_ZoomIn.Size = new System.Drawing.Size(47, 16);
            this.rb_ZoomIn.TabIndex = 1;
            this.rb_ZoomIn.TabStop = true;
            this.rb_ZoomIn.Text = "缩小";
            this.rb_ZoomIn.UseVisualStyleBackColor = true;
            this.rb_ZoomIn.CheckedChanged += new System.EventHandler(this.rb_ZoomIn_CheckedChanged);
            // 
            // rb_Moving
            // 
            this.rb_Moving.AutoSize = true;
            this.rb_Moving.Location = new System.Drawing.Point(86, 135);
            this.rb_Moving.Name = "rb_Moving";
            this.rb_Moving.Size = new System.Drawing.Size(47, 16);
            this.rb_Moving.TabIndex = 2;
            this.rb_Moving.TabStop = true;
            this.rb_Moving.Text = "平移";
            this.rb_Moving.UseVisualStyleBackColor = true;
            this.rb_Moving.CheckedChanged += new System.EventHandler(this.rb_Moving_CheckedChanged);
            // 
            // rb_Full
            // 
            this.rb_Full.AutoSize = true;
            this.rb_Full.Location = new System.Drawing.Point(86, 173);
            this.rb_Full.Name = "rb_Full";
            this.rb_Full.Size = new System.Drawing.Size(47, 16);
            this.rb_Full.TabIndex = 3;
            this.rb_Full.TabStop = true;
            this.rb_Full.Text = "全图";
            this.rb_Full.UseVisualStyleBackColor = true;
            this.rb_Full.CheckedChanged += new System.EventHandler(this.rb_Full_CheckedChanged);
            // 
            // cb_isLoadingBuffer
            // 
            this.cb_isLoadingBuffer.AutoSize = true;
            this.cb_isLoadingBuffer.Location = new System.Drawing.Point(86, 211);
            this.cb_isLoadingBuffer.Name = "cb_isLoadingBuffer";
            this.cb_isLoadingBuffer.Size = new System.Drawing.Size(96, 16);
            this.cb_isLoadingBuffer.TabIndex = 4;
            this.cb_isLoadingBuffer.Text = "是否缓冲加载";
            this.cb_isLoadingBuffer.UseVisualStyleBackColor = true;
            this.cb_isLoadingBuffer.CheckedChanged += new System.EventHandler(this.cb_isLoadingBuffer_CheckedChanged);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Confirm.Location = new System.Drawing.Point(68, 296);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 5;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(207, 295);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // ImageControlSettingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 402);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.cb_isLoadingBuffer);
            this.Controls.Add(this.rb_Full);
            this.Controls.Add(this.rb_Moving);
            this.Controls.Add(this.rb_ZoomIn);
            this.Controls.Add(this.rb_ZoomOut);
            this.Name = "ImageControlSettingDlg";
            this.Text = "图像显示参数控制";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_ZoomOut;
        private System.Windows.Forms.RadioButton rb_ZoomIn;
        private System.Windows.Forms.RadioButton rb_Moving;
        private System.Windows.Forms.RadioButton rb_Full;
        private System.Windows.Forms.CheckBox cb_isLoadingBuffer;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_Cancel;
    }
}