using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main : Form
    {
        #region KHAI BÁO BIẾN
        public Thread t1;
        public static Button[] node1;           // Biến minh họa mảng
        public static int so_phan_tu;           // Số phần tử của mảng
        public static Label[] chiSo;            // Chỉ số vị trí của mảng
        public static int[] a;                  // Mảng a
        int toc_Do = 4;                         // Tốc độ, tối đa 10 cấp
        bool tang = true;                       // Kiểu sắp xếp
        bool da_Tao_Mang = false;
        bool da_Tao_GT = false;
        bool kt_tam_dung = false;               // Biến kiểm tra tạm dừng
        bool sap_Xep_Tung_Buoc = true;          // Biến kiểm tra sắp xếp từng bước hay nhanh
        CodeThuatToan Code_CPP = new CodeThuatToan();       // Code C/C++ cho thuật toán
        YTuongThuatToan YTuong_CPP = new YTuongThuatToan();
        int i;                                  // Biến này dùng nhiều (biến chỉ số)
        bool is_run = false;                    // Cờ kiểm tra thuật toán còn chạy không
        FormController controller;              // Tạo controller để chạy thuật toán
        int Binh_i_ViTriSwap1 = -1;          // Vị trí cột thứ 1 đang hoán vị (Bình)
        int Binh_i_ViTriSwap2 = -1;          // Vị trí cột thứ 2 đang hoán vị (Bình)
        bool Binh_b_DangAnimation = false;   // Cờ cho biết đang chạy animation hoán vị (Bình)
        int Binh_i_AnimationStep = 0;        // Bước hiện tại của animation (Bình)
        int Binh_i_AnimationStepMax = 1;     // Số bước tối đa của animation (Bình)
        #endregion

        public Form_main()
        {
            InitializeComponent();
            controller = new FormController(this);

            // Bật double-buffer cho panel vẽ cột
            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, SortingPanelView, new object[] { true });

            // Vô hiệu hóa các lable, button, checkbox, Radiobutton
            NutChinhTocDoThuatToan.Enabled = false;
            NutChayThuatToan.Enabled = false;
            NutTamDungThuatToan.Enabled = false;
            NutKetThucThuatToan.Enabled = false;

            NutChonThuatToan.Enabled = false;
            ChonGiamDan.Enabled = false;
            ChonTangDan.Enabled = false;
            SortingPanelView.Paint += SortingPanelView_Paint;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SortingPanelView.Paint += SortingPanelView_Paint;
        }

        #region NHẬP DỮ LIỆU CHO MẢNG
        // Hàm nhập ngẫu nhiên
        private void NhapNgauNhien(object sender, EventArgs e)
        {
            // Lấy số phần tử từ NumericUpDown
            so_phan_tu = (int)NumericNhapSoPhanTu.Value;

            // Kiểm tra điều kiện hợp lệ
            if (so_phan_tu < 2 || so_phan_tu > 20)
            {
                MessageBox.Show("Số phần tử phải nằm trong khoảng từ 2 đến 20!");
                NumericNhapSoPhanTu.Value = 5;
                so_phan_tu = 5;
                return;
            }

            // Khởi tạo mảng dữ liệu
            a = new int[so_phan_tu];

            Random rd = new Random();
            for (int i = 0; i < so_phan_tu; i++)
                a[i] = rd.Next(100);

            // Yêu cầu SortingPanelView vẽ lại
            SortingPanelView.Invalidate(); // Sẽ gọi hàm SortingPanelView_Paint
            MoCacNutLuaChonThuatToan();
        }
 
        // Nhập dữ liệu bằng tay
        private void NhapBangTay(object sender, EventArgs e)
        {
            so_phan_tu = (int)NumericNhapSoPhanTu.Value;
            if (so_phan_tu < 2 || so_phan_tu > 20)
            {
                MessageBox.Show(" Số phần tử phải nằm trong khoảng từ 2 đến 20");
                da_Tao_Mang = false;
                NumericNhapSoPhanTu.Value = 5;   // Mặc định bằng 5 cho đẹp
                so_phan_tu = 5;
                return;
            }
            FormNhapMang f = new FormNhapMang();
            f.ShowDialog();
        }
        #endregion

        #region CÁC HÀM CHỨC NĂNG
        // Hàm reset giá trị của các node về 0;
        public void reset_node()
        {
            for (int i = 0; i < so_phan_tu; i++)
            {
                a[i] = 0;
                node1[i].Text = a[i].ToString();
            }
        }

        // Hàm xóa mảng đã tạo
        public void xoa_Mang(Button[] Node)
        {
            Application.DoEvents();
            this.Invoke((MethodInvoker)delegate
            {
                NutNhapBangTay.Enabled = false;
                NutNhapNgauNhien.Enabled = false;
                NutChayThuatToan.Enabled = false;
                if (da_Tao_Mang == true)
                {
                    for (i = 0; i < so_phan_tu; i++)
                    {
                        this.Controls.Remove(Node[i]);
                        this.Controls.Remove(chiSo[i]);
                    }
                    da_Tao_Mang = false;
                }
            });
        }

        private void ThayDoiCodeKhiChonTangHoacGiam()
        {
            ListBoxCodeC.Items.Clear();
            ListBoxYTuong.Items.Clear();
            string ChonThuatToan = NutChonThuatToan.SelectedItem.ToString();
            if (ChonThuatToan == "Selection Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.SelectionSort(ListBoxCodeC, tang);
                YTuong_CPP.SelectionSort(ListBoxYTuong);
            }

            if (ChonThuatToan == "Heap Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.HeapSort(ListBoxCodeC, tang);
                YTuong_CPP.HeapSort(ListBoxYTuong);
            }

            if (ChonThuatToan == "Bubble Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.BubbleSort(ListBoxCodeC, tang);
                YTuong_CPP.BubbleSort(ListBoxYTuong);
            }

            if (ChonThuatToan == "Quick Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.QuickSort(ListBoxCodeC, tang);
                YTuong_CPP.QuickSort(ListBoxYTuong);
            }

            if (ChonThuatToan == "Insertion Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.InsertionSort(ListBoxCodeC, tang);
                YTuong_CPP.InsertionSort(ListBoxYTuong);
            }

            if (ChonThuatToan == "Interchange Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.InterchangeSort(ListBoxCodeC, tang);
                YTuong_CPP.InterchangeSort(ListBoxYTuong);
            }

            if (ChonThuatToan == "Merge Sort" && (ChonTangDan.Checked || ChonGiamDan.Checked))
            {
                Code_CPP.MergeSort(ListBoxCodeC, tang);
                YTuong_CPP.MergeSort(ListBoxYTuong);
            }
        }

        private void KiemTraDieuKienChonThuatToan()
        {
            bool daChonKieuSapXep = ChonTangDan.Checked || ChonGiamDan.Checked;
            bool daChonThuatToan = NutChonThuatToan != null;

            if (daChonKieuSapXep && daChonThuatToan)
                MoCacNutDieuKhien();
            else
            {
                // KHÓA các nút điều khiển
                NutChayThuatToan.Enabled = false;
                NutTamDungThuatToan.Enabled = false;
                NutKetThucThuatToan.Enabled = false;
                NutChinhTocDoThuatToan.Enabled = false;
            }
        }

        #endregion

        #region CÁC HÀM CHỨC NĂNG ĐỂ TRUY CẬP THUỘC TÍNH/PHƯƠNG THỨC PRIVATE
        // Hàm vô hiệu hóa các nút khởi tạo khi ctrinh chạy
        public void KhoiChay()
        {
            NutNhapNgauNhien.Enabled = false;
            NutNhapBangTay.Enabled = false;
            NutChonThuatToan.Enabled = false;
            ChonTangDan.Enabled = false;
            ChonGiamDan.Enabled = false;
            NutChayThuatToan.Enabled = false;
        }

        // Hàm mở tất cả các nút lựa chọn thuật toán
        public void MoCacNutLuaChonThuatToan()
        {
            GroupBoxChonThuatToan.Enabled = true;
            NutChonThuatToan.Enabled = true;
        }

        // Hàm mở tất cả các nút điều khiển
        public void MoCacNutDieuKhien()
        {
            NutChayThuatToan.Enabled = true;
            NutTamDungThuatToan.Enabled = true;
            NutKetThucThuatToan.Enabled = true;
            NutChinhTocDoThuatToan.Enabled = true;
        }

        // Hàm vẽ lại cửa sổ sắp xếp (đối với nhập mảng bằng tay)
        public void VeLaiSortingPanelView()
        {
            SortingPanelView.Invalidate(); // gọi Paint
        }
        #endregion
    }
}