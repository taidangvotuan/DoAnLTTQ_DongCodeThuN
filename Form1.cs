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
        //Sửa hàm Heapify (sai ở chỗ iPhai = 2 * i + 1 thay vì iPhai = 2 * i + 2)
        public void Tai_v_Heapify(int[] arr, int n, int i)
        {
            int iLonNhat = i;        // gốc (cha)
            int iTrai = 2 * i + 1;   // con trái
            int iPhai = 2 * i + 2;   // con phải

            if (iTrai < n && arr[iTrai] > arr[iLonNhat])
                iLonNhat = iTrai;

            if (iPhai < n && arr[iPhai] > arr[iLonNhat])
                iLonNhat = iPhai;

            if (iLonNhat != i)
            {
                Tai_v_HoanVi(ref arr[i], ref arr[iLonNhat]);
                Tai_v_Heapify(arr, n, iLonNhat); // đệ quy để chắc chắn nhánh con cũng thành heap
            }
        }

        //Sửa hàm thuật toán HeapSort (nên build từ n/2 - 1 thay vì n/2)
        public void Tai_v_HeapSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Tai_v_Heapify(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
                Tai_v_HoanVi(ref arr[0], ref arr[i]);
                Tai_v_Heapify(arr, i, 0);
            }
        }

        public void Binh_v_InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        public void Binh_v_SelectionSort(int[] arr)
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
        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
