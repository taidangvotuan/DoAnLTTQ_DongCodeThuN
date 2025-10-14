using System;
using System.Linq;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form1 : Form
    {
        private FormController controller;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller = new FormController(this);
            controller.sortingPanel = Controls.Find("SortingVisualizationView", true).First() as Panel;

        }

        #region KHU VỰC CÁC NÚT BẤM

        private void Tai_v_ChonTangDan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_ChonGiamDan_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutNhapNgauNhien_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutNhapBangTay_Click(object sender, EventArgs e)
        {

            Form2 f = new Form2();
            f.Show();
        }

        private void Tai_v_NutChinhTocDoThuatToan_Scroll(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutChonThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutChayThuatToan_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutTamDungThuatToan_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_NutKetThucThuatToan_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC LABEL
        private void Tai_v_LabelNhapSoPhanTu_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelNhapGiaTriMang_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelChuThichGiaTriMang_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelChuThichSoPhanTu_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelChonThuatToan_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelTocDo_Click(object sender, EventArgs e)
        {

        }

        private void Tai_v_LabelLoaiSapXep_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC TEXTBOX
        private void Tai_v_textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC GROUP BOX
        Random rand = new Random();
        int[] a = new int[100];
        private void OnCreateVisualizeChart(object sender, EventArgs e)
        {
            
            
            int n = rand.Next(10, 20);
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = rand.Next(1, 100);
            }
            controller.SetNeedToSortArray(a, n);
        }

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

        private void Tai_v_GroupBoxThanhDieuKhien_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region KHU VỰC NỀN
        private void Tai_v_Nen_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region KHU VỰC CÁC LISTBOX
        private void Tai_v_listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Tai_v_listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region CÁC HÀM CHỨC NĂNG
        public void Tai_v_HoanVi(ref int a, ref int b)
        {
            int iTemp = a;
            a = b;
            b = iTemp;
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
