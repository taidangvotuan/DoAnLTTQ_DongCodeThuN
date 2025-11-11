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
            string input = TextBoxNhapMang.Text.Trim();


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
                index = Convert.ToInt32(TextBoxNhapMang.Text);
            }
            catch
            {
                MessageBox.Show("Giá trị không hợp lệ!");
                TextBoxNhapMang.Text = "0";
                return;
            }
            if (index > Form_main.so_phan_tu - 1 || index < 0)
            {
                MessageBox.Show("Không có phần tử thứ " + index);
                TextBoxNhapMang.Text = "0";
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
            string input = TextBoxNhapMang.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập dãy số cho mảng!", "Lỗi nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tách theo dấu cách hoặc tab
            string[] parts = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            int nMain = Form_main.so_phan_tu;  // số phần tử đã chọn ở Form_main
            int soNhap = parts.Length;

            if (soNhap > nMain)
            {
                MessageBox.Show($"Bạn đã nhập quá số phần tử ({nMain})!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Gán giá trị đã nhập
            for (int i = 0; i < soNhap; i++)
            {
                if (!int.TryParse(parts[i], out A[i]) || A[i] < 0 || A[i] > 99)
                {
                    MessageBox.Show($"Giá trị thứ {i + 1} không hợp lệ (phải nằm trong 0–99)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Gán phần còn lại bằng 0 nếu chưa nhập đủ
            for (int i = soNhap; i < nMain; i++)
                A[i] = 0;

            n = nMain;

            // Hiển thị mảng ra màn hình (cho người dùng xem lại)
            string ketQua = string.Join(" ", A.Take(n));
            MessageBox.Show($"Mảng sau khi nhập là:\n{ketQua}", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // --- Gán mảng này sang Form_main để hiển thị ---
            Form_main.a = new int[nMain];
            for (int i = 0; i < nMain; i++)
                Form_main.a[i] = A[i];

            // Tạo node hiển thị (như hình bạn gửi)
            Form_main.node1 = new Button[nMain];
            Form_main.chiSo = new Label[nMain];

            Image img_nen = DoAnLTTQ_DongCodeThuN.Properties.Resources.AnhPhanTuMang;
            int kc = 200;
            int kich_Thuoc = 70;
            int co_Chu = 14;
            int khoang_Cach = 15;
            int le_Node = (1185 - kich_Thuoc * nMain - khoang_Cach * (nMain - 1)) / 2;

            // --- Gán mảng này sang Form_main để hiển thị ---
            Form_main.a = new int[nMain];
            for (int i = 0; i < nMain; i++)
                Form_main.a[i] = A[i];

            // Tạo node hiển thị (như hình bạn gửi)
            Form_main.node1 = new Button[nMain];
            Form_main.chiSo = new Label[nMain];

            // Xóa phần cũ
            Form mainForm = Application.OpenForms["Form_main"];
            if (mainForm is Form_main fMain)
            {
                if (fMain != null)
                    fMain.XoaNoiDungPanelMoPhong();

                // Hiển thị chữ "A" (tên mảng)
                Label lblTenMang = new Label();
                lblTenMang.Text = "A";
                lblTenMang.Font = new Font("Arial", 20, FontStyle.Bold);
                lblTenMang.ForeColor = Color.Red;
                lblTenMang.AutoSize = true;
                lblTenMang.Location = new Point(le_Node - 60, kc + 50);
                fMain.ThemVaoPanelMoPhong(lblTenMang);

                // Hiển thị chữ "Chỉ số"
                Label lblChiSo = new Label();
                lblChiSo.Text = "Chỉ số";
                lblChiSo.Font = new Font("Arial", 16, FontStyle.Bold);
                lblChiSo.ForeColor = Color.Green;
                lblChiSo.AutoSize = true;
                lblChiSo.Location = new Point(le_Node - 90, 290 + khoang_Cach * 4);
                fMain.ThemVaoPanelMoPhong(lblChiSo);

                for (int i = 0; i < nMain; i++)
                {
                    // Nút giá trị
                    Button btn = new Button();
                    btn.Text = A[i].ToString();
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.Width = kich_Thuoc;
                    btn.Height = kich_Thuoc;
                    btn.Font = new Font("Arial", co_Chu, FontStyle.Bold);
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackgroundImage = img_nen;
                    btn.BackgroundImageLayout = ImageLayout.Stretch;
                    btn.Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, kc + 30);

                    // Label chỉ số
                    Label lbl = new Label();
                    lbl.Text = i.ToString();
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    lbl.Width = kich_Thuoc;
                    lbl.Height = kich_Thuoc;
                    lbl.Font = new Font("Arial", co_Chu - 2, FontStyle.Bold);
                    lbl.Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 290 + khoang_Cach * 3);

                    fMain.ThemVaoPanelMoPhong(btn);
                    fMain.ThemVaoPanelMoPhong(lbl);
                    fMain.MoTatCaNutDieuKhien();

                    Form_main.node1[i] = btn;
                    Form_main.chiSo[i] = lbl;
                }
            }

            this.Close();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
