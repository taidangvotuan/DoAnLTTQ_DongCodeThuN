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
        #region KHAI BÁO BIẾN
        int[] A = new int[20];  // Mảng tối đa 20 phần tử
        int n = 0;
        bool daNhap = false;
        int index = 0;
        #endregion

        public FormNhapMang()
        {
            InitializeComponent();
            //TextBoxGiaTriMang.Focus();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

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
                MessageBox.Show($"Bạn đã nhập quá số phần tử (Tối đa {nMain} phần tử)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            Form mainForm = Application.OpenForms["Form_main"];
            if (mainForm is Form_main fMain)
            {
                fMain.VeLaiSortingPanelView();
                fMain.MoCacNutLuaChonThuatToan();
            }
            this.Close();
        }

        #region KHU VỰC CÁC TEXT BOX
        private void TextBoxChiSoMang_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC LABEL
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
        #endregion
    }
}