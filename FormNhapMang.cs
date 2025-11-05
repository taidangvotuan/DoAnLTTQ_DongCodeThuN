using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class FormNhapMang : Form
    {
        int[] A = new int[12];  // Mảng tối đa 12 phần tử
        int n = 0;
        bool daNhap = false;
        int index = 0;

        public FormNhapMang()
        {
            InitializeComponent();
            //TextBoxGiaTriMang.Focus();
        }

        private void btn_nhap_Click(object sender, EventArgs e)
        {
            int value;
            Boolean kiemtra = true;
            string input = TextBoxChiSoMang.Text.Trim();


            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập dãy số cho mảng!", "Lỗi nhập");
                return;
            }

            // Tách theo dấu cách hoặc tab
            string[] parts = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Kiểm tra giới hạn phần tử
            if (parts.Length > 12)
            {
                MessageBox.Show("Mảng chỉ chứa tối đa 12 phần tử!", "Lỗi");
                return;
            }

            // Chuyển và kiểm tra từng giá trị
            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out A[i]) || A[i] < 0 || A[i] > 99)
                {
                    MessageBox.Show($"Giá trị thứ {i + 1} không hợp lệ! (phải trong 0–99)", "Lỗi");
                    return;
                }
            }

            n = parts.Length;
            daNhap = true;

            // Vẽ lại mảng
            //panel1.Invalidate();
            try
            {
                index = Convert.ToInt32(TextBoxChiSoMang.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị không hợp lệ!");
                TextBoxChiSoMang.Text = "0";
                return;
            }
            if (index > Form_main.so_phan_tu - 1 || index < 0)
            {
                MessageBox.Show("Không có phần tử thứ " + index);
                TextBoxChiSoMang.Text = "0";
                return;
            }

            try
            {
                //value = Convert.ToInt32(TextBoxGiaTriMang.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                //TextBoxGiaTriMang.Text = "0";
                return;
            }
            /*if (value < 0 || value > 99)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                //TextBoxGiaTriMang.Text = "0";
                return;
            }*/
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        #region KHU VỰC NÚT BẤM
        private void NutNhap_Click(object sender, EventArgs e)
        {
            int value;
            Boolean kiemtra = true;
            try
            {
                index = Convert.ToInt32(TextBoxChiSoMang.Text);
            }
            catch
            {
                MessageBox.Show("Chỉ số không hợp lệ!");
                //TextBoxChiSoMang.Text = "0";
                return;
            }
            if (index > Form_main.so_phan_tu - 1 || index < 0)
            {
                MessageBox.Show("Không có phần tử thứ " + index);
                //TextBoxChiSoMang.Text = "0";
                return;
            }

            try
            {
                //value = Convert.ToInt32(TextBoxGiaTriMang.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                //TextBoxGiaTriMang.Text = "0";
                return;
            }
            /*if (value < 0 || value > 99)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                //TextBoxGiaTriMang.Text = "0";
                return;
            }*/

            if (kiemtra)
            {
                //Form1.a[index] = value;
                //Form1.node1[index].Text = value.ToString();
                // Đoạn này cho nó nhấp nháy 1 cái khi nhận giá trị
                Form_main.node1[index].BackgroundImage = Properties.Resources.AnhPhanTuDangChon;
                Form_main.node1[index].Refresh();
                Thread.Sleep(500);
                Form_main.node1[index].BackgroundImage = Properties.Resources.AnhPhanTuMang;
                Form_main.node1[index].Refresh();

                //this.TextBoxGiaTriMang.Text = "0";
                //this.TextBoxGiaTriMang.Focus();
                //this.TextBoxChiSoMang.Text = (index + 1).ToString();
                //this.TextBoxChiSoMang.SelectAll();
            }
            Close();
        }
        #endregion

        #region KHU VỰC CÁC TEXT BOX
        private void TextBoxChiSoMang_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
