namespace DoAnLTTQ_DongCodeThuN
{
    partial class FormHuongDan
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("SVN-Gilroy", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 30;
            this.listBox1.Items.AddRange(new object[] {
            "Để tạo mảng: Bạn có thể lựa chọn nhập mảng ngẫu nhiên hoặc bằng tay:",
            "- Tạo mảng ngẫu nhiên: Người dùng chỉ cần nhập số phần tử, sau đó nhấn nút \"Ngẫu " +
                "nhiên\" để tạo mảng giá trị các phần tử ",
            "trong mảng với các con số ngẫu nhiên.",
            "- Tạo mảng bằng tay: ",
            "   + Người dùng nhập số phần tử.",
            "   + Nhấn nút \"Bằng tay\", lúc này sẽ hiện cửa sổ để nhập giá trị các phần tử.",
            "   + Bạn sẽ nhập lần lượt các giá trị của các phần tử trong mảng, mỗi giá trị của" +
                " phần tử cách nhau bằng dấu cách.",
            "   + Sau khi nhập xong, bạn nhấn nút \"Nhập\", lúc này các phần tử của mảng sẽ hiện" +
                " giá trị và thứ tự tương ứng với thứ tự giá trị ",
            "bạn đã nhập trong mảng."});
            this.listBox1.Location = new System.Drawing.Point(2, 1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1420, 754);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // FormHuongDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1422, 763);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormHuongDan";
            this.Text = "Hướng dẫn sử dụng";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
    }
}