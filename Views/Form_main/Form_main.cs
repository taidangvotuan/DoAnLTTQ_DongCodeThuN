using System;
using System.Reflection;
using System.Windows.Forms;
using DoAnLTTQ_DongCodeThuN.Views.Interfaces;
using DoAnLTTQ_DongCodeThuN.Controllers;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main : Form, IMainView
    {
        #region KHAI BÁO CONTROLLER VÀ BIẾN CŨ

        private MainController controller; // Controller MVC

        // GIỮ NGUYÊN CÁC BIẾN CŨ ĐỂ TƯƠNG THÍCH
        public static int[] a;
        public static int so_phan_tu;

        #endregion

        #region CONSTRUCTOR

        public Form_main()
        {
            InitializeComponent();

            // Khởi tạo Controller
            controller = new MainController(this);

            // Setup double-buffer
            typeof(Panel).InvokeMember(
                "DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, SortingPanelView, new object[] { true });

            // Vô hiệu hóa controls ban đầu
            TrackBar_ChinhTocDoThuatToan.Enabled = false;
            ButtonChayThuatToan.Enabled = false;
            ButtonTamDungThuatToan.Enabled = false;
            ButtonKetThucThuatToan.Enabled = false;
            ComboBox_ChonThuatToan.Enabled = false;
            RadioButton_GiamDan.Enabled = false;
            RadioButton_TangDan.Enabled = false;

            SortingPanelView.Paint += SortingPanelView_Paint;
        }

        #endregion

        #region IMPLEMENT IMainView - EVENTS
        public event EventHandler NhapNgauNhienClicked;
        public event EventHandler NhapBangTayClicked;
        public event EventHandler ChayThuatToanClicked;
        public event EventHandler TamDungThuatToanClicked;
        public event EventHandler KetThucThuatToanClicked;
        public event EventHandler ThuatToanChanged;
        public event EventHandler TocDoChanged;
        public event EventHandler KieuSapXepChanged;
        #endregion

        #region IMPLEMENT IMainView - PROPERTIES
        public int SoPhanTu
        {
            get => (int)NumericNhapSoPhanTu.Value;
            set => NumericNhapSoPhanTu.Value = value;
        }

        public int[] MangA
        {
            get => a;
            set
            {
                a = value;
                so_phan_tu = value?.Length ?? 0;
            }
        }

        public string ThuatToanDaChon => ComboBox_ChonThuatToan.SelectedItem?.ToString();
        public int TocDo => TrackBar_ChinhTocDoThuatToan.Value;
        public bool TangDan => RadioButton_TangDan.Checked;
        public bool GiamDan => RadioButton_GiamDan.Checked;

        #endregion

        #region IMPLEMENT IMainView - METHODS

        public void VeLaiSortingPanel()
        {
            SortingPanelView.Invalidate();
        }

        public void RefreshSortingPanel()
        {
            if (SortingPanelView.InvokeRequired)
                SortingPanelView.Invoke(new Action(() => SortingPanelView.Refresh()));
            else
                SortingPanelView.Refresh();
        }

        public void HienThiListBoxYTuong(string[] items)
        {
            ListBoxYTuong.Items.Clear();
            foreach (string item in items)
                ListBoxYTuong.Items.Add(item);
        }

        public void HienThiListBoxCode(string[] items)
        {
            ListBoxCodeC.Items.Clear();
            foreach (string item in items)
                ListBoxCodeC.Items.Add(item);
        }

        public void HienThiListBoxCacBuoc(string[] items)
        {
            ListBoxCacBuoc.Items.Clear();
            foreach (string item in items)
                ListBoxCacBuoc.Items.Add(item);
        }

        public void ThemBuocVaoListBox(string buoc)
        {
            if (ListBoxCacBuoc.InvokeRequired)
            {
                ListBoxCacBuoc.Invoke(new Action(() =>
                {
                    ListBoxCacBuoc.Items.Add(buoc);
                    ListBoxCacBuoc.TopIndex = ListBoxCacBuoc.Items.Count - 1;
                    ListBoxCacBuoc.Update();
                }));
            }
            else
            {
                ListBoxCacBuoc.Items.Add(buoc);
                ListBoxCacBuoc.TopIndex = ListBoxCacBuoc.Items.Count - 1;
                ListBoxCacBuoc.Update();
            }
        }

        public void XoaListBoxCacBuoc()
        {
            if (ListBoxCacBuoc.InvokeRequired)
                ListBoxCacBuoc.Invoke(new Action(() => ListBoxCacBuoc.Items.Clear()));
            else
                ListBoxCacBuoc.Items.Clear();
        }

        public void MoCacNutLuaChonThuatToan()
        {
            GroupBoxChonThuatToan.Enabled = true;
            ComboBox_ChonThuatToan.Enabled = true;
        }

        public void MoCacNutDieuKhien()
        {
            ButtonChayThuatToan.Enabled = true;
            ButtonTamDungThuatToan.Enabled = true;
            ButtonKetThucThuatToan.Enabled = true;
            TrackBar_ChinhTocDoThuatToan.Enabled = true;
        }

        public void KhoiChay()
        {
            ButtonNhapNgauNhien.Enabled = false;
            ButtonNhapBangTay.Enabled = false;
            ComboBox_ChonThuatToan.Enabled = false;
            RadioButton_TangDan.Enabled = false;
            RadioButton_GiamDan.Enabled = false;
            ButtonChayThuatToan.Enabled = false;
        }

        public void KhoaChay()
        {
            ButtonNhapNgauNhien.Enabled = true;
            ButtonNhapBangTay.Enabled = true;
            ComboBox_ChonThuatToan.Enabled = true;
            RadioButton_TangDan.Enabled = true;
            RadioButton_GiamDan.Enabled = true;
            KiemTraDieuKienChonThuatToan();
        }

        public void HienThiThongBao(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void UpdateUI()
        {
            Application.DoEvents();
        }

        #endregion

        #region UI EVENT HANDLERS - RAISE CONTROLLER EVENTS

        private void NhapNgauNhien(object sender, EventArgs e)
        {
            NhapNgauNhienClicked?.Invoke(this, e);
        }

        private void NhapBangTay(object sender, EventArgs e)
        {
            // Gọi FormNhapMang
            int soPhanTu = (int)NumericNhapSoPhanTu.Value;
            if (soPhanTu < 2 || soPhanTu > 50)
            {
                MessageBox.Show("Số phần tử phải từ 2 đến 20", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NumericNhapSoPhanTu.Value = 5;
                return;
            }

            FormNhapMang formNhap = new FormNhapMang();
            formNhap.SoPhanTu = soPhanTu;
            DialogResult result = formNhap.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Lấy mảng từ FormNhapMang
                int[] mangMoi = formNhap.Array;

                if (mangMoi != null && mangMoi.Length == soPhanTu)
                {
                    // Cập nhật vào state thông qua Controller
                    controller.State.a = mangMoi;
                    controller.State.so_phan_tu = soPhanTu;
                    controller.State.da_Tao_Mang = true;

                    // Cập nhật biến static cũ (để tương thích)
                    a = mangMoi;
                    so_phan_tu = soPhanTu;

                    // Vẽ lại
                    VeLaiSortingPanel();

                    // Mở các nút lựa chọn thuật toán
                    MoCacNutLuaChonThuatToan();

                    MessageBox.Show($"Đã nhập thành công {soPhanTu} phần tử!", "Thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi nhập mảng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region PRIVATE HELPER METHODS
        private void KiemTraDieuKienChonThuatToan()
        {
            bool daChonKieuSapXep = RadioButton_TangDan.Checked || RadioButton_GiamDan.Checked;
            bool daChonThuatToan = ComboBox_ChonThuatToan.SelectedIndex >= 0;

            if (daChonKieuSapXep && daChonThuatToan)
                MoCacNutDieuKhien();
            else
            {
                ButtonChayThuatToan.Enabled = false;
                ButtonTamDungThuatToan.Enabled = false;
                ButtonKetThucThuatToan.Enabled = false;
                TrackBar_ChinhTocDoThuatToan.Enabled = false;
            }
        }
        #endregion

        #region FORM EVENTS
        private void Form_Load(object sender, EventArgs e)
        {
            SortingPanelView.Paint += SortingPanelView_Paint;
        }
        #endregion

        public void VeLaiSortingPanelView()
        {
            VeLaiSortingPanel();
        }
    }
}