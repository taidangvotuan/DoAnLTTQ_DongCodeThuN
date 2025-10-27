namespace DoAnLTTQ_DongCodeThuN
{
    partial class Form2
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
            this.TextBoxChiSoMang = new System.Windows.Forms.TextBox();
            this.NutNhap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxChiSoMang
            // 
            this.TextBoxChiSoMang.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxChiSoMang.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.TextBoxChiSoMang.Location = new System.Drawing.Point(0, 173);
            this.TextBoxChiSoMang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TextBoxChiSoMang.MaxLength = 59;
            this.TextBoxChiSoMang.Name = "TextBoxChiSoMang";
            this.TextBoxChiSoMang.Size = new System.Drawing.Size(644, 30);
            this.TextBoxChiSoMang.TabIndex = 4;
            this.TextBoxChiSoMang.TextChanged += new System.EventHandler(this.TextBoxChiSoMang_TextChanged);
            // 
            // NutNhap
            // 
            this.NutNhap.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NutNhap.BackColor = System.Drawing.Color.DodgerBlue;
            this.NutNhap.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NutNhap.ForeColor = System.Drawing.Color.Yellow;
            this.NutNhap.Location = new System.Drawing.Point(276, 223);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(11, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(542, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "(Giá trị của mỗi phần tử trong mảng phải nằm trong khoảng từ 0 đến 99)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(11, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(324, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hãy nhập danh sách các giá trị của mảng ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 374);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NutNhap);
            this.Controls.Add(this.TextBoxChiSoMang);
            this.Name = "Form2";
            this.Text = "Nhập dữ liệu cho mảng";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox TextBoxChiSoMang;
        private System.Windows.Forms.Button NutNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}