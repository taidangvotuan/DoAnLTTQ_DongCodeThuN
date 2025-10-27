using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System;

namespace DoAnLTTQ_DongCodeThuN
{
    
    // Dung nhet het tinh nang vao 1 file
    // Chia file ra de quan ly hon
    
    // Dung Form1 de tuong tac voi lop FormController
    public partial class Form1 : Form
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
        public Form1()
        {
            InitializeComponent();

            // Vô hiệu hóa các lable, button, checkbox, Radiobutton
            NutNhapNgauNhien.Enabled = false;
            NutNhapBangTay.Enabled = false;
            NutChinhTocDoThuatToan.Enabled = false;
            NutChayThuatToan.Enabled = true;
            NutTamDungThuatToan.Enabled = false;
            NutKetThucThuatToan.Enabled = false;
            LabelChiSo.Visible = false;
            LabelMangA.Visible = false;

            controller = new FormController(this);
            ChonGiamDan.Enabled = false;
            ChonTangDan.Enabled = false;
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
        private void Tai_v_NutTao_Click(object sender, EventArgs e)
        {
            NumericNhapSoPhanTu.Focus();
            try
            {
                so_phan_tu = Convert.ToInt32(NumericNhapSoPhanTu.Value);
            }
            catch
            {
                MessageBox.Show("Số phần tử vừa nhập vào không hợp lệ!");
                NumericNhapSoPhanTu.Value = 5;
                return;
            }
            a = new int[so_phan_tu];
            Tai_v_TaoMang(150, Properties.Resources.AnhPhanTuMang);
            controller.Create();
        }

        private void Tai_v_NutNhapNgauNhien_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            for (int i = 0; i < so_phan_tu; i++)
            {
                a[i] = rd.Next(20);
                node1[i].Text = a[i].ToString();

            }

            // Mở các nút bấm
            ChonTangDan.Enabled = true;
            ChonGiamDan.Enabled = true;
            da_Tao_GT = true;
            NutChonThuatToan.Enabled = true;
        }

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

        }

        private void Tai_v_ButtonTacGia_Click(object sender, EventArgs e)
        {

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
                    LabelMangA.Visible = false;
                    LabelChiSo.Visible = false;
                }
            });
        }

        // Hàm tạo mảng
        public void Tai_v_TaoMang(int kc, System.Drawing.Image img_nen)
        {
            if (so_phan_tu < 2 || so_phan_tu > 12)
            {
                MessageBox.Show(" Số phần tử phải nằm trong khoảng từ 2 đến 12");
                da_Tao_Mang = false;
                NumericNhapSoPhanTu.Value = 5;   // Mặc định bằng 5 cho đẹp
                return;
            }

            // Tạo thuộc tính cho node
            kich_Thuoc = 70;
            co_Chu = 14;
            khoang_Cach = 15;

            // Tính lề trái để căn giữa hàng phần tử
            le_Node = (1185 - kich_Thuoc * so_phan_tu - khoang_Cach * (so_phan_tu - 1)) / 2;

            // Dọn dẹp phần tử cũ (nếu có)
            if (node1 != null)
            {
                foreach (Button btn in node1)
                    if (btn != null && PanelMoPhong.Controls.Contains(btn))
                        PanelMoPhong.Controls.Remove(btn);
            }

            if (chiSo != null)
            {
                foreach (Label lbl in chiSo)
                    if (lbl != null && PanelMoPhong.Controls.Contains(lbl))
                        PanelMoPhong.Controls.Remove(lbl);
            }

            // Khởi tạo mảng node
            node1 = new Button[so_phan_tu];
            chiSo = new Label[so_phan_tu];

            LabelChiSo.Visible = true;
            LabelMangA.Visible = true;

            for (int i = 0; i < so_phan_tu; i++)
            {
                node1[i] = new Button();
                node1[i].Text = a[i].ToString();
                node1[i].TextAlign = ContentAlignment.MiddleCenter;
                node1[i].Width = kich_Thuoc;
                node1[i].Height = kich_Thuoc;
                node1[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, kc + 30);
                node1[i].ForeColor = Color.Black;
                node1[i].Font = new Font(this.Font, FontStyle.Bold);
                node1[i].Font = new System.Drawing.Font("Arial", co_Chu, FontStyle.Bold);
                node1[i].FlatStyle = FlatStyle.Flat;
                node1[i].BackgroundImage = img_nen;
                node1[i].BackgroundImageLayout = ImageLayout.Stretch;
                node1[i].FlatAppearance.BorderSize = 0;
                PanelMoPhong.Controls.Add(node1[i]);

                // Tạo nhãn chỉ sổ
                chiSo[i] = new Label();
                chiSo[i].TextAlign = ContentAlignment.MiddleCenter;
                chiSo[i].Text = i.ToString();
                chiSo[i].Width = kich_Thuoc;
                chiSo[i].Height = kich_Thuoc;
                chiSo[i].ForeColor = Color.Black;

                chiSo[i].Location = new Point(le_Node + (kich_Thuoc + khoang_Cach) * i, 290 + khoang_Cach * 3);
                chiSo[i].Font = new System.Drawing.Font("Arial", co_Chu - 2, FontStyle.Bold);
                PanelMoPhong.Controls.Add(chiSo[i]);
            }
            da_Tao_Mang = true; //Xác nhận đã tạo mảng
            LabelChiSo.Visible = true;
            LabelMangA.Visible = true;
            NutNhapNgauNhien.Enabled = true;
            NutNhapBangTay.Enabled = true;
            NutChinhTocDoThuatToan.Enabled = true;
            NutChayThuatToan.Enabled = true;
            NutTamDungThuatToan.Enabled = true;
            NutKetThucThuatToan.Enabled = true;
            ChonGiamDan.Enabled = true;
            ChonTangDan.Enabled = true;
        }

        #region NHẬP DỮ LIỆU CHO MẢNG

        // Hàm nhập random
        private void btn_random_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            for (int i = 0; i < so_phan_tu; i++)
            {
                a[i] = rd.Next(100);
                node1[i].Text = a[i].ToString();
            }
        }

        // Nhập dữ liệu bằng tay
        private void Tai_v_NutNhapBangTay_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
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
            NutTao.Enabled = false;
            NutNhapNgauNhien.Enabled = false;
            NutNhapBangTay.Enabled = false;
            NutChonThuatToan.Enabled = false;
            ChonTangDan.Enabled = false;
            ChonGiamDan.Enabled = false;
            NutChayThuatToan.Enabled = false;
        }

        #region KHU VỰC CÁC HÀM SẮP XẾP
        public void Tai_v_Heapify(int[] arr, int n, int i)
        {
            int iLonNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = 2 * i + 1;
            if (iTrai < n && arr[iTrai] > arr[iLonNhat])
                iLonNhat = iTrai;
            if (iPhai < n && arr[iPhai] > arr[iLonNhat])
                iLonNhat = iPhai;
            if (iLonNhat != i)
            {
                Tai_v_HoanVi(ref arr[i], ref arr[iLonNhat]);
                Tai_v_Heapify(arr, n, iLonNhat);
            }
        }

        public void Tai_v_HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2; i >= 0; i--)
                Tai_v_Heapify(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Tai_v_HoanVi(ref arr[0], ref arr[i]);
                Tai_v_Heapify(arr, i, 0);
            }
        }
        #endregion
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