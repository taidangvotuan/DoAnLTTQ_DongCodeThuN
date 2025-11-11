using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    // Dung nhet het tinh nang vao 1 file
    // Chia file ra de quan ly hon

    // Dung Form1 de tuong tac voi lop FormController
    public partial class Form_main : Form
    {
        #region KHAI BÁO BIẾN
        public Thread t1;
        public static Button[] node1;   // Biến minh họa mảng
        public static int so_phan_tu;   // Số phần tử của mảng
        public static Label[] chiSo;   // Chỉ số vị trí của mảng
        public static int[] a;         // Mảng a
        int toc_Do = 4;                  // Tốc độ, tối đa 10 cấp
        bool tang = true;     // Kiểu sắp xếp
        bool da_Tao_Mang = false;
        bool da_Tao_GT = false;
        bool kt_tam_dung = false;     //Biến kiểm tra tạm dừng
        bool sap_Xep_Tung_Buoc = true;        // Biến kiểm tra sắp xếp từng bước hay nhanh
        CodeThuatToan Code_CPP = new CodeThuatToan();       // Code C/C++ cho thuật toán
        YTuongThuatToan YTuong_CPP = new YTuongThuatToan();
        int i;    // Biến này dùng nhiều
        bool is_run = false;
        // Các biến thiết lập cho node
        int khoang_Cach;            // Khoảng cách hai node
        int kich_Thuoc;             // Kích thước node
        int co_Chu;                 // Cỡ chữ node
        int le_Node;                // Căn lề node
        int le_tren;                // Lề trên cho node
        #endregion

        FormController controller;
        public Form_main()
        {
            InitializeComponent();

            // Vô hiệu hóa các lable, button, checkbox, Radiobutton
            NutChinhTocDoThuatToan.Enabled = false;
            NutChayThuatToan.Enabled = false;
            NutTamDungThuatToan.Enabled = false;
            NutKetThucThuatToan.Enabled = false;

            controller = new FormController(this);
            ChonGiamDan.Enabled = false;
            ChonTangDan.Enabled = false;
        }

        public void ClearPanelMoPhong()
        {
            PanelMoPhong.Controls.Clear();
        }

        public void AddControlToPanel(Control c)
        {
            PanelMoPhong.Controls.Add(c);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region KHU VỰC CÁC LABEL
        private void Tai_v_LabelNhapSoPhanTu_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelChuThichSoPhanTu_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelNhapGiaTriMang_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelChonThuatToan_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelLoaiSapXep_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelTocDo_Click(object sender, EventArgs e)
        {

        }

        private void LabelMangA_Click(object sender, EventArgs e)
        {

        }

        private void LabelChiSo_Click(object sender, EventArgs e)
        {

        }

        private void LabelSoPhanTu_Click(object sender, EventArgs e)
        {

        }

        private void LabelKhoangGiaTriPhanTu_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC HÀM SẮP XẾP
        #region Heap Sort
        public void Tai_v_HeapifyTangDan(int[] arr, int n, int i)
        {
            int iLonNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = iTrai + 1;

            if (iTrai < n && arr[iTrai] > arr[iLonNhat])
                iLonNhat = iTrai;

            if (iPhai < n && arr[iPhai] > arr[iLonNhat])
                iLonNhat = iPhai;

            if (iLonNhat != i)
            {
                Tai_v_HoanVi(ref arr[i], ref arr[iLonNhat]);
                Tai_v_HeapifyTangDan(arr, n, iLonNhat);
            }
        }

        public void Tai_v_HeapifyGiamDan(int[] arr, int n, int i)
        {
            int iNhoNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = iTrai + 2;

            if (iTrai < n && arr[iTrai] < arr[iNhoNhat])
                iNhoNhat = iTrai;

            if (iPhai < n && arr[iPhai] < arr[iNhoNhat])
                iNhoNhat = iPhai;

            if (iNhoNhat != i)
            {
                Tai_v_HoanVi(ref arr[i], ref arr[iNhoNhat]);
                Tai_v_HeapifyGiamDan(arr, n, iNhoNhat);
            }
        }

        public void Tai_v_HeapSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Tai_v_HeapifyTangDan(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Tai_v_HoanVi(ref arr[0], ref arr[i]);
                Tai_v_HeapifyTangDan(arr, i, 0);
            }
        }

        public void Tai_v_HeapSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Tai_v_HeapifyGiamDan(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Tai_v_HoanVi(ref arr[0], ref arr[i]);
                Tai_v_HeapifyGiamDan(arr, i, 0);
            }
        }
        #endregion

        #region Insertion Sort
        public void Binh_v_InsertionSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public void Binh_v_InsertionSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        #region Selection Sort
        public void Binh_v_SelectionSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIdx])
                        minIdx = j;

                Tai_v_HoanVi(ref arr[minIdx], ref arr[i]);
            }
        }

        public void Binh_v_SelectionSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] > arr[maxIdx])
                        maxIdx = j;

                Tai_v_HoanVi(ref arr[maxIdx], ref arr[i]);
            }
        }
        #endregion

        #region Bubble Sort
        public void Thinh_v_BubbleSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                        Tai_v_HoanVi(ref arr[j], ref arr[j + 1]);
            }
        }

        public void Thinh_v_BubbleSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] < arr[j + 1])
                        Tai_v_HoanVi(ref arr[j], ref arr[j + 1]);
            }
        }
        #endregion

        #region Merge Sort
        public void Tai_v_MergeTangDan(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1; // số phần tử mảng con trái
            int n2 = right - mid;    // số phần tử mảng con phải

            // Tạo mảng tạm
            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            // Sao chép dữ liệu vào mảng tạm
            for (int i = 0; i < n1; i++)
                arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                arrRight[j] = arr[mid + 1 + j];

            // Gộp 2 mảng tạm vào mảng chính
            int iLeft = 0;  // chỉ số mảng trái
            int iRight = 0;  // chỉ số mảng phải
            int k = left; // vị trí bắt đầu gộp

            while (iLeft < n1 && iRight < n2)
            {
                if (arrLeft[iLeft] <= arrRight[iRight])
                {
                    arr[k] = arrLeft[iLeft];
                    iLeft++;
                }
                else
                {
                    arr[k] = arrRight[iRight];
                    iRight++;
                }
                k++;
            }

            // Sao chép phần còn lại (nếu có)
            while (iLeft < n1)
            {
                arr[k] = arrLeft[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                arr[k] = arrRight[iRight];
                iRight++;
                k++;
            }
        }

        public void Tai_v_MergeGiamDan(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1; // số phần tử mảng con trái
            int n2 = right - mid;    // số phần tử mảng con phải

            // Tạo mảng tạm
            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            // Sao chép dữ liệu vào mảng tạm
            for (int i = 0; i < n1; i++)
                arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++)
                arrRight[j] = arr[mid + 1 + j];

            // Gộp 2 mảng tạm vào mảng chính
            int iLeft = 0;  // chỉ số mảng trái
            int iRight = 0;  // chỉ số mảng phải
            int k = left; // vị trí bắt đầu gộp

            while (iLeft < n1 && iRight < n2)
            {
                if (arrLeft[iLeft] >= arrRight[iRight])
                {
                    arr[k] = arrLeft[iLeft];
                    iLeft++;
                }
                else
                {
                    arr[k] = arrRight[iRight];
                    iRight++;
                }
                k++;
            }

            // Sao chép phần còn lại (nếu có)
            while (iLeft < n1)
            {
                arr[k] = arrLeft[iLeft];
                iLeft++;
                k++;
            }

            while (iRight < n2)
            {
                arr[k] = arrRight[iRight];
                iRight++;
                k++;
            }
        }

        public void Tai_v_MergeSortTangDan(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortTangDan(arr, left, mid);
                Tai_v_MergeSortTangDan(arr, mid + 1, right);
                Tai_v_MergeTangDan(arr, left, mid, right);
            }
        }

        public void Tai_v_MergeSortGiamDan(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortGiamDan(arr, left, mid);
                Tai_v_MergeSortGiamDan(arr, mid + 1, right);
                Tai_v_MergeGiamDan(arr, left, mid, right);
            }
        }
        #endregion

        #region Interchange Sort
        public void Tai_v_InterchangeSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                        Tai_v_HoanVi(ref arr[i], ref arr[j]);
        }

        public void Tai_v_InterchangeSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] < arr[j])
                        Tai_v_HoanVi(ref arr[i], ref arr[j]);
        }
        #endregion

        #region Quick Sort
        public void Thinh_v_QuickSortTangDan(int[] arr, int iLeft, int iRight)
        {
            int i = iLeft;
            int j = iRight;
            int pivot = arr[(iLeft + iRight) / 2];

            while (i <= j)
            {
                while (arr[i] < pivot) i++;
                while (arr[j] > pivot) j--;

                if (i <= j)
                {
                    Tai_v_HoanVi(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }

            if (iLeft < j)
                Thinh_v_QuickSortTangDan(arr, iLeft, j);

            if (i < iRight)
                Thinh_v_QuickSortTangDan(arr, i, iRight);
        }

        public void Thinh_v_QuickSortGiamDan(int[] arr, int iLeft, int iRight)
        {
            int i = iLeft;
            int j = iRight;
            int pivot = arr[(iLeft + iRight) / 2];

            while (i <= j)
            {
                while (arr[i] > pivot) i++;
                while (arr[j] < pivot) j--;

                if (i <= j)
                {
                    Tai_v_HoanVi(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }

            if (iLeft < j)
                Thinh_v_QuickSortGiamDan(arr, iLeft, j);

            if (i < iRight)
                Thinh_v_QuickSortGiamDan(arr, i, iRight);
        }
        #endregion
        #endregion

        #region KHU VỰC CÁC PANEL

        private void PanelNen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelMoPhong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelThanhDieuKhien_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC LISTBOX
        private void Tai_v_ListBoxYTuong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_ListBoxCacBuoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_ListBoxCodeC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC GROUPBOX
        private void Tai_v_GroupBoxYTuong_Enter(object sender, EventArgs e)
        {

        }

        private void Tai_v_GroupBoxCacBuocThucHien_Enter(object sender, EventArgs e)
        {

        }

        private void Tai_v_GroupBoxChuongTrinhCPP_Enter(object sender, EventArgs e)
        {

        }

        private void Tai_v_GroupBoxKhoiTaoMang_Enter(object sender, EventArgs e)
        {

        }

        private void Tai_v_GroupBoxChonThuatToan_Enter(object sender, EventArgs e)
        {

        }

        private void Tai_v_GroupBoxDieuKhien_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC NÚT BẤM
        private void Tai_v_NutChayThuatToan_Click(object sender, EventArgs e)
        {
            controller.Start();
        }

        private void Tai_v_NutTamDungThuatToan_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutKetThucThuatToan_Click(object sender, EventArgs e)
        {

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

        private void Tai_v_NutChonThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThayDoiCodeKhiChonTangHoacGiam();
        }

        private void Tai_v_NutChinhTocDoThuatToan_Scroll(object sender, EventArgs e)
        {

        }

        private void Tai_v_ChonTangDan_CheckedChanged(object sender, EventArgs e)
        {
            if (ChonTangDan.Checked)
            {
                tang = true;
                ThayDoiCodeKhiChonTangHoacGiam();
            }
        }

        private void Tai_v_ChonGiamDan_CheckedChanged(object sender, EventArgs e)
        {
            if (ChonGiamDan.Checked)
            {
                tang = false;
                ThayDoiCodeKhiChonTangHoacGiam();
            }
        }

        private void Tai_v_ButtonHuongDan_Click(object sender, EventArgs e)
        {
            FormHuongDan f = new FormHuongDan();
            f.Show();
        }

        private void Tai_v_ButtonTacGia_Click(object sender, EventArgs e)
        {
            FormTacGia f = new FormTacGia();
            f.Show();
        }
        #endregion

        private void NumericNhapSoPhanTu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_ThanhDieuKhien_Paint(object sender, PaintEventArgs e)
        {

        }

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

        #region NHẬP DỮ LIỆU CHO MẢNG
        // Hàm nhập random
        private void Tai_v_NutNhapNgauNhien_Click(object sender, EventArgs e)
        {
            // Lấy số phần tử từ NumericUpDown
            so_phan_tu = (int)NumericNhapSoPhanTu.Value;

            // Kiểm tra điều kiện hợp lệ
            if (so_phan_tu < 2 || so_phan_tu > 12)
            {
                MessageBox.Show("Số phần tử phải nằm trong khoảng từ 2 đến 12!");
                NumericNhapSoPhanTu.Value = 5;
                so_phan_tu = 5;
                return;
            }

            // Dọn dẹp toàn bộ panel trước khi vẽ lại
            if (PanelMoPhong.Controls.Count > 0)
                PanelMoPhong.Controls.Clear();

            // Các thông số hiển thị
            int kc = 200;                // Tọa độ y cơ sở
            kich_Thuoc = 70;             // Kích thước mỗi ô
            co_Chu = 14;                 // Cỡ chữ trên nút
            khoang_Cach = 15;            // Khoảng cách giữa các nút
            Image img_nen = Properties.Resources.AnhPhanTuMang;

            // Tính lề trái để căn giữa hàng phần tử
            le_Node = (1185 - kich_Thuoc * so_phan_tu - khoang_Cach * (so_phan_tu - 1)) / 2;

            // Hiển thị tên mảng "A"
            Label lblTenMang = new Label();
            lblTenMang.Text = "A";
            lblTenMang.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTenMang.ForeColor = Color.Red;
            lblTenMang.AutoSize = true;
            lblTenMang.Location = new Point(le_Node - 60, kc + 50);
            PanelMoPhong.Controls.Add(lblTenMang);

            // Hiển thị chữ "Chỉ số"
            Label lblChiSo = new Label();
            lblChiSo.Text = "Chỉ số";
            lblChiSo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblChiSo.ForeColor = Color.Green;
            lblChiSo.AutoSize = true;
            lblChiSo.Location = new Point(le_Node - 90, kc + kich_Thuoc + 80);
            PanelMoPhong.Controls.Add(lblChiSo);

            // Khởi tạo mảng dữ liệu
            a = new int[so_phan_tu];
            node1 = new Button[so_phan_tu];
            chiSo = new Label[so_phan_tu];

            Random rd = new Random();

            for (int i = 0; i < so_phan_tu; i++)
            {
                // Sinh giá trị ngẫu nhiên
                a[i] = rd.Next(100);

                // Tạo button thể hiện phần tử
                node1[i] = new Button();
                node1[i].Text = a[i].ToString();
                node1[i].TextAlign = ContentAlignment.MiddleCenter;
                node1[i].Width = kich_Thuoc;
                node1[i].Height = kich_Thuoc;
                node1[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, kc + 30);
                node1[i].ForeColor = Color.Black;
                node1[i].Font = new Font("Arial", co_Chu, FontStyle.Bold);
                node1[i].FlatStyle = FlatStyle.Flat;
                node1[i].BackgroundImage = img_nen;
                node1[i].BackgroundImageLayout = ImageLayout.Stretch;
                node1[i].FlatAppearance.BorderSize = 0;
                PanelMoPhong.Controls.Add(node1[i]);

                // Tạo nhãn chỉ số dưới mỗi phần tử
                chiSo[i] = new Label();
                chiSo[i].TextAlign = ContentAlignment.MiddleCenter;
                chiSo[i].Text = i.ToString();
                chiSo[i].Width = kich_Thuoc;
                chiSo[i].Height = 25;
                chiSo[i].ForeColor = Color.Black;
                chiSo[i].Font = new Font("Arial", co_Chu - 2, FontStyle.Bold);
                chiSo[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, kc + kich_Thuoc + 82);
                PanelMoPhong.Controls.Add(chiSo[i]);

                // Hiển thị nhãn “Giá trị: X” bên dưới nút
                /*Label lblGiaTri = new Label();
                lblGiaTri.Text = $"Giá trị: {a[i]}";
                lblGiaTri.TextAlign = ContentAlignment.MiddleCenter;
                lblGiaTri.Width = kich_Thuoc;
                lblGiaTri.Height = 20;
                lblGiaTri.ForeColor = Color.Blue;
                lblGiaTri.Font = new Font("Arial", co_Chu - 3, FontStyle.Regular);
                lblGiaTri.Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, kc + kich_Thuoc + 90);
                PanelMoPhong.Controls.Add(lblGiaTri);*/
            }

            // 5️⃣ Kích hoạt các nút điều khiển
            da_Tao_Mang = true;
            NutNhapNgauNhien.Enabled = true;
            NutNhapBangTay.Enabled = true;
            NutChinhTocDoThuatToan.Enabled = true;
            NutChayThuatToan.Enabled = true;
            NutTamDungThuatToan.Enabled = true;
            NutKetThucThuatToan.Enabled = true;
            ChonGiamDan.Enabled = true;
            ChonTangDan.Enabled = true;
        }


        // Nhập dữ liệu bằng tay
        private void Tai_v_NutNhapBangTay_Click(object sender, EventArgs e)
        {
            so_phan_tu = (int)NumericNhapSoPhanTu.Value;
            if (so_phan_tu < 2 || so_phan_tu > 12)
            {
                MessageBox.Show(" Số phần tử phải nằm trong khoảng từ 2 đến 12");
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
        public void Tai_v_HoanVi(ref int a, ref int b)
        {
            int iTemp = a;
            a = b;
            b = iTemp;
        }

        // Hàm tạo một node simple, với text = !
        public Button create_node(Button node, String t)
        {
            node = new Button();
            node.Text = t;
            node.TextAlign = ContentAlignment.MiddleCenter;
            node.Width = kich_Thuoc;
            node.Height = kich_Thuoc;
            node.ForeColor = Color.Black;
            node.Font = new Font(this.Font, FontStyle.Bold);
            node.Font = new System.Drawing.Font("Arial", co_Chu, FontStyle.Bold);
            node.FlatStyle = FlatStyle.Flat;
            node.BackgroundImage = Properties.Resources.AnhPhanTuMang;
            node.BackgroundImageLayout = ImageLayout.Stretch;
            node.FlatAppearance.BorderSize = 0;
            return node;
        }

        // Hàm set màu node
        public void set_node_color(Control t, System.Drawing.Image img_nen)
        {
            t.BackgroundImage = img_nen;
            t.BackgroundImageLayout = ImageLayout.Stretch;
            t.Refresh();
        }

        // Hàm đổi giá trị của hai node
        public void swap_button(int t1, int t2)
        {

            Button Temp = node1[t1];
            node1[t1] = node1[t2];
            node1[t2] = Temp;
        }

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

        public void MoTatCaNutDieuKhien()
        {
            GroupBoxChonThuatToan.Enabled = true;
            ChonTangDan.Enabled = true;
            ChonGiamDan.Enabled = true;
            NutChonThuatToan.Enabled = true;
            NutChayThuatToan.Enabled = true;
            NutTamDungThuatToan.Enabled = true;
            NutKetThucThuatToan.Enabled = true;
            NutChinhTocDoThuatToan.Enabled = true;
        }

        public void XoaNoiDungPanelMoPhong()
        {
            PanelMoPhong.Controls.Clear();
        }

        public void ThemVaoPanelMoPhong(Control control)
        {
            PanelMoPhong.Controls.Add(control);
        }
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormController.OnUpdate?.Invoke();
        }

        private void SortingPanelView_Paint(object sender, PaintEventArgs e)
        {
            //Graphics graphics = e.Graphics;
            //Brush brush = new SolidBrush(Color.Blue);
            //graphics.FillRectangle(brush, new Rectangle(0, 0, 100, 100));
            //graphics.Clear(Color.White);
            //graphics.Dispose();
        }
    }
}