using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            TextBoxGiaTriMang.Focus();
        }

        int index = 0;

        /*private void btn_nhap_Click(object sender, EventArgs e)
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
                TextBoxChiSoMang.Text = "0";
                return;
            }
            if (index > Form1.so_phan_tu - 1 || index < 0)
            {
                MessageBox.Show("Không có phần tử thứ " + index);
                TextBoxChiSoMang.Text = "0";
                return;
            }

            try
            {
                value = Convert.ToInt32(TextBoxGiaTriMang.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                TextBoxGiaTriMang.Text = "0";
                return;
            }
            if (value < 0 || value > 99)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                TextBoxGiaTriMang.Text = "0";
                return;
            }
        }*/

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        #region KHU VỰC CÁC LABEL
        private void LabelDauBang_Click(object sender, EventArgs e)
        {

        }

        private void LabelA_Click(object sender, EventArgs e)
        {

        }

        private void LabelMoNgoac_Click(object sender, EventArgs e)
        {

        }

        private void LabelDongNgoac_Click(object sender, EventArgs e)
        {

        }
        #endregion

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
                TextBoxChiSoMang.Text = "0";
                return;
            }
            if (index > Form1.so_phan_tu - 1 || index < 0)
            {
                MessageBox.Show("Không có phần tử thứ " + index);
                TextBoxChiSoMang.Text = "0";
                return;
            }

            try
            {
                value = Convert.ToInt32(TextBoxGiaTriMang.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                TextBoxGiaTriMang.Text = "0";
                return;
            }
            if (value < 0 || value > 99)
            {
                MessageBox.Show("Giá trị nhập vào không hợp lệ!");
                kiemtra = false;
                TextBoxGiaTriMang.Text = "0";
                return;
            }

            if (kiemtra)
            {
                Form1.a[index] = value;
                Form1.node1[index].Text = value.ToString();
                // Đoạn này cho nó nhấp nháy 1 cái khi nhận giá trị
                Form1.node1[index].BackgroundImage = Properties.Resources.AnhPhanTuDangChon;
                Form1.node1[index].Refresh();
                Thread.Sleep(500);
                Form1.node1[index].BackgroundImage = Properties.Resources.AnhPhanTuMang;
                Form1.node1[index].Refresh();

                this.TextBoxGiaTriMang.Text = "0";
                this.TextBoxGiaTriMang.Focus();
                this.TextBoxChiSoMang.Text = (index + 1).ToString();
                this.TextBoxChiSoMang.SelectAll();
            }
            Close();
        }
        #endregion

        #region KHU VỰC CÁC TEXT BOX
        private void TextBoxChiSoMang_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxGiaTriMang_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
