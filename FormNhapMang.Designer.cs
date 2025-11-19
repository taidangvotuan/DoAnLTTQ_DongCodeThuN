namespace DoAnLTTQ_DongCodeThuN
{
    partial class FormNhapMang
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
            this.TextBoxNhapMang = new System.Windows.Forms.TextBox();
            this.NutNhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxNhapMang
            // 
            this.TextBoxNhapMang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNhapMang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TextBoxNhapMang.Location = new System.Drawing.Point(16, 199);
            this.TextBoxNhapMang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxNhapMang.MaxLength = 59;
            this.TextBoxNhapMang.Name = "TextBoxNhapMang";
            this.TextBoxNhapMang.Size = new System.Drawing.Size(721, 30);
            this.TextBoxNhapMang.TabIndex = 4;
            this.TextBoxNhapMang.TextChanged += new System.EventHandler(this.TextBoxChiSoMang_TextChanged);
            // 
            // NutNhap
            // 
            this.NutNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NutNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.NutNhap.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NutNhap.ForeColor = System.Drawing.Color.Yellow;
            this.NutNhap.Location = new System.Drawing.Point(328, 249);
            this.NutNhap.Name = "NutNhap";
            this.NutNhap.Size = new System.Drawing.Size(112, 46);
            this.NutNhap.TabIndex = 7;
            this.NutNhap.Text = "Nhập";
            this.NutNhap.UseVisualStyleBackColor = false;
            this.NutNhap.Click += new System.EventHandler(this.NutNhap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(30, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(631, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "- Giá trị của mỗi phần tử trong mảng phải nằm trong khoảng từ 0 đến 99.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(11, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hãy nhập danh sách các giá trị của mảng:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Lưu ý:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(30, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(659, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "- Mỗi giá trị của các phần tử cách nhau bằng một dấu cách, ví dụ: 1 2 3 4 5.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // FormNhapMang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 374);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NutNhap);
            this.Controls.Add(this.TextBoxNhapMang);
            this.Name = "FormNhapMang";
            this.Text = "Nhập dữ liệu cho mảng";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxNhapMang;
        private System.Windows.Forms.Button NutNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}