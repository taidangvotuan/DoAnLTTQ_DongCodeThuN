namespace DoAnLTTQ_DongCodeThuN
{
    partial class FormNhapNgauNhien
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.NutNhap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.numericUpDown1.Location = new System.Drawing.Point(317, 58);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 30);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(44, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập số phần tử của mảng:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NutNhap
            // 
            this.NutNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NutNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.NutNhap.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NutNhap.ForeColor = System.Drawing.Color.Yellow;
            this.NutNhap.Location = new System.Drawing.Point(175, 90);
            this.NutNhap.Name = "NutNhap";
            this.NutNhap.Size = new System.Drawing.Size(112, 46);
            this.NutNhap.TabIndex = 8;
            this.NutNhap.Text = "Nhập";
            this.NutNhap.UseVisualStyleBackColor = false;
            this.NutNhap.Click += new System.EventHandler(this.NutNhap_Click);
            // 
            // FormNhapNgauNhien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 168);
            this.Controls.Add(this.NutNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Name = "FormNhapNgauNhien";
            this.Text = "Tạo mảng ngẫu nhiên";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button NutNhap;
    }
}