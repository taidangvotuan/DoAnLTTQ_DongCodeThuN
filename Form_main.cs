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
        #endregion

        public Form_main()
        {
            InitializeComponent();

            // Vô hiệu hóa các lable, button, checkbox, Radiobutton
            NutChinhTocDoThuatToan.Enabled = false;
            NutChayThuatToan.Enabled = false;
            NutTamDungThuatToan.Enabled = false;
            NutKetThucThuatToan.Enabled = false;

            FormController controller = new FormController(this);
            NutChonThuatToan.Enabled = false;
            ChonGiamDan.Enabled = false;
            ChonTangDan.Enabled = false;
            SortingPanelView.Paint += SortingPanelView_Paint;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            SortingPanelView.Paint += SortingPanelView_Paint;
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

        private void Tai_v_ThanhDieuKhien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SortingPanelView_Paint(object sender, PaintEventArgs e)
        {
            if (a == null || a.Length == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int n = a.Length;
            int panelWidth = SortingPanelView.Width;
            int panelHeight = SortingPanelView.Height;

            int barWidth = panelWidth / (n * 2);
            int maxVal = a.Max();
            int xStart = (panelWidth - n * barWidth * 2) / 2;

            Font font = new Font("Arial", 12, FontStyle.Bold);
            Brush barBrush = Brushes.Blue;
            Brush textBrush = Brushes.Black;

            for (int i = 0; i < n; i++)
            {
                float heightRatio = (float)a[i] / maxVal;
                int barHeight = (int)(heightRatio * (panelHeight - 100));

                int x = xStart + i * barWidth * 2;
                int y = panelHeight - barHeight - 50;

                g.FillRectangle(barBrush, x, y, barWidth, barHeight);

                string valueStr = a[i].ToString();
                SizeF textSize = g.MeasureString(valueStr, font);
                g.DrawString(valueStr, font, textBrush, x + (barWidth - textSize.Width) / 2, panelHeight - 40);
            }
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
            KiemTraDieuKienChonThuatToan();
            controller.Start();
        }

        private void Tai_v_NutTamDungThuatToan_Click(object sender, EventArgs e)
        {
            KiemTraDieuKienChonThuatToan();
        }

        private void Tai_v_NutKetThucThuatToan_Click(object sender, EventArgs e)
        {
            KiemTraDieuKienChonThuatToan();
        }

        private void Tai_v_NutChonThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NutChonThuatToan.SelectedIndex >= 0)
            {
                ChonTangDan.Enabled = true;
                ChonGiamDan.Enabled = true;
            }
            KiemTraDieuKienChonThuatToan();
            ThayDoiCodeKhiChonTangHoacGiam();
        }

        private void Tai_v_NutChinhTocDoThuatToan_Scroll(object sender, EventArgs e)
        {

        }

        private void Tai_v_ChonTangDan_CheckedChanged(object sender, EventArgs e)
        {
            KiemTraDieuKienChonThuatToan();
            
            if (ChonTangDan.Checked)
            {
                tang = true;
                ThayDoiCodeKhiChonTangHoacGiam();
            }
        }

        private void Tai_v_ChonGiamDan_CheckedChanged(object sender, EventArgs e)
        {
            KiemTraDieuKienChonThuatToan();
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

        #region KHU VỰC CÁC NÚT CHỨC NĂNG KHÁC
        private void NumericNhapSoPhanTu_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FormController.OnUpdate?.Invoke();
        }
        #endregion

        #region NHẬP DỮ LIỆU CHO MẢNG
        // Hàm nhập random
        private void Tai_v_NutNhapNgauNhien_Click(object sender, EventArgs e)
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
        private void Tai_v_NutNhapBangTay_Click(object sender, EventArgs e)
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
        public void Tai_v_HoanVi(ref int a, ref int b)
        {
            int iTemp = a;
            a = b;
            b = iTemp;
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

        #region CÁC HÀM CHỨC NĂNG ĐỂ TRUY CẬP PRIVATE
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