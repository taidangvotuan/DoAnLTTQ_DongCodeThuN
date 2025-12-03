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
            NutChinhTocDoThuatToan.Enabled = false;
            NutChayThuatToan.Enabled = false;
            NutTamDungThuatToan.Enabled = false;
            NutKetThucThuatToan.Enabled = false;
            NutChonThuatToan.Enabled = false;
            ChonGiamDan.Enabled = false;
            ChonTangDan.Enabled = false;

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

        public string ThuatToanDaChon => NutChonThuatToan.SelectedItem?.ToString();

        public int TocDo => NutChinhTocDoThuatToan.Value;

        public bool TangDan => ChonTangDan.Checked;

        #endregion

        #region IMPLEMENT IMainView - METHODS

        public void VeLaiSortingPanel()
        {
            SortingPanelView.Invalidate();
        }

        public void RefreshSortingPanel()
        {
            if (SortingPanelView.InvokeRequired)
            {
                SortingPanelView.Invoke(new Action(() => SortingPanelView.Refresh()));
            }
            else
            {
                SortingPanelView.Refresh();
            }
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
            {
                ListBoxCacBuoc.Invoke(new Action(() => ListBoxCacBuoc.Items.Clear()));
            }
            else
            {
                ListBoxCacBuoc.Items.Clear();
            }
        }

        public void MoCacNutLuaChonThuatToan()
        {
            GroupBoxChonThuatToan.Enabled = true;
            NutChonThuatToan.Enabled = true;
        }

        public void MoCacNutDieuKhien()
        {
            NutChayThuatToan.Enabled = true;
            NutTamDungThuatToan.Enabled = true;
            NutKetThucThuatToan.Enabled = true;
            NutChinhTocDoThuatToan.Enabled = true;
        }

        public void KhoiChay()
        {
            NutNhapNgauNhien.Enabled = false;
            NutNhapBangTay.Enabled = false;
            NutChonThuatToan.Enabled = false;
            ChonTangDan.Enabled = false;
            ChonGiamDan.Enabled = false;
            NutChayThuatToan.Enabled = false;
        }

        public void KhoaChay()
        {
            NutNhapNgauNhien.Enabled = true;
            NutNhapBangTay.Enabled = true;
            NutChonThuatToan.Enabled = true;
            ChonTangDan.Enabled = true;
            ChonGiamDan.Enabled = true;
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
            so_phan_tu = (int)NumericNhapSoPhanTu.Value;
            if (so_phan_tu < 2 || so_phan_tu > 20)
            {
                MessageBox.Show("Số phần tử phải từ 2 đến 20");
                NumericNhapSoPhanTu.Value = 5;
                so_phan_tu = 5;
                return;
            }

            FormNhapMang f = new FormNhapMang();
            f.ShowDialog();

            // Sau khi đóng, a đã được cập nhật
            MoCacNutLuaChonThuatToan();
        }
        #endregion

        #region PRIVATE HELPER METHODS
        private void KiemTraDieuKienChonThuatToan()
        {
            bool daChonKieuSapXep = ChonTangDan.Checked || ChonGiamDan.Checked;
            bool daChonThuatToan = NutChonThuatToan.SelectedIndex >= 0;

            if (daChonKieuSapXep && daChonThuatToan)
                MoCacNutDieuKhien();
            else
            {
                NutChayThuatToan.Enabled = false;
                NutTamDungThuatToan.Enabled = false;
                NutKetThucThuatToan.Enabled = false;
                NutChinhTocDoThuatToan.Enabled = false;
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