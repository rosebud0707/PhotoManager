namespace PhotoManager
{
    partial class PhotoManager
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnFromOpen = new System.Windows.Forms.Button();
            this.txtSaveFrom = new System.Windows.Forms.TextBox();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.txtSaveTo = new System.Windows.Forms.TextBox();
            this.btnToOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnFromOpen
            // 
            this.btnFromOpen.Location = new System.Drawing.Point(422, 51);
            this.btnFromOpen.Name = "btnFromOpen";
            this.btnFromOpen.Size = new System.Drawing.Size(49, 23);
            this.btnFromOpen.TabIndex = 0;
            this.btnFromOpen.Text = "開く";
            this.btnFromOpen.UseVisualStyleBackColor = true;
            this.btnFromOpen.Click += new System.EventHandler(this.BtnFromOpen_Click);
            // 
            // txtSaveFrom
            // 
            this.txtSaveFrom.Location = new System.Drawing.Point(12, 51);
            this.txtSaveFrom.Name = "txtSaveFrom";
            this.txtSaveFrom.ReadOnly = true;
            this.txtSaveFrom.Size = new System.Drawing.Size(404, 23);
            this.txtSaveFrom.TabIndex = 1;
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Location = new System.Drawing.Point(12, 28);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(96, 15);
            this.lblInfo1.TabIndex = 2;
            this.lblInfo1.Text = "保存元 ディレクトリ";
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Location = new System.Drawing.Point(12, 94);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(96, 15);
            this.lblInfo2.TabIndex = 5;
            this.lblInfo2.Text = "保存先 ディレクトリ";
            // 
            // txtSaveTo
            // 
            this.txtSaveTo.Location = new System.Drawing.Point(12, 116);
            this.txtSaveTo.Name = "txtSaveTo";
            this.txtSaveTo.ReadOnly = true;
            this.txtSaveTo.Size = new System.Drawing.Size(404, 23);
            this.txtSaveTo.TabIndex = 4;
            // 
            // btnToOpen
            // 
            this.btnToOpen.Location = new System.Drawing.Point(422, 117);
            this.btnToOpen.Name = "btnToOpen";
            this.btnToOpen.Size = new System.Drawing.Size(49, 23);
            this.btnToOpen.TabIndex = 3;
            this.btnToOpen.Text = "開く";
            this.btnToOpen.UseVisualStyleBackColor = true;
            this.btnToOpen.Click += new System.EventHandler(this.BtnToOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(344, 196);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(61, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(411, 196);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "閉じる";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(12, 167);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(460, 23);
            this.pgBar.TabIndex = 8;
            // 
            // PhotoManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 229);
            this.ControlBox = false;
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.txtSaveTo);
            this.Controls.Add(this.btnToOpen);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.txtSaveFrom);
            this.Controls.Add(this.btnFromOpen);
            this.MaximumSize = new System.Drawing.Size(500, 268);
            this.MinimumSize = new System.Drawing.Size(500, 268);
            this.Name = "PhotoManager";
            this.Text = "PhotoManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private Button btnFromOpen;
        private TextBox txtSaveFrom;
        private Label lblInfo1;
        private Label lblInfo2;
        private TextBox txtSaveTo;
        private Button btnToOpen;
        private Button btnSave;
        private Button btnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar pgBar;
    }
}