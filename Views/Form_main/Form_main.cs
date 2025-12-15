using DoAnLTTQ_DongCodeThuN.Controllers;
using DoAnLTTQ_DongCodeThuN.Views.Interfaces;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

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
            typeof(Panel).InvokeMember("DoubleBuffered",
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

            // Set ListBoxCacBuoc to OwnerDraw để tùy chỉnh màu sắc
            ListBoxCacBuoc.DrawMode = DrawMode.OwnerDrawFixed;
            ListBoxCacBuoc.DrawItem += ListBoxCacBuoc_DrawItem;
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
        public event EventHandler NhapFileClicked;
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

        // Thêm bước với thông tin vị trí hoán vị để highlight màu
        public void ThemBuocVaoListBoxCoMau(string buoc, int viTri1, int viTri2)
        {
            if (ListBoxCacBuoc.InvokeRequired)
            {
                ListBoxCacBuoc.Invoke(new Action(() =>
                {
                    // Lưu thông tin vị trí hoán vị vào Tag
                    var item = new ListBoxItem { Text = buoc, SwapPos1 = viTri1, SwapPos2 = viTri2 };
                    ListBoxCacBuoc.Items.Add(item);
                    ListBoxCacBuoc.TopIndex = ListBoxCacBuoc.Items.Count - 1;
                    ListBoxCacBuoc.Update();
                }));
            }
            else
            {
                var item = new ListBoxItem { Text = buoc, SwapPos1 = viTri1, SwapPos2 = viTri2 };
                ListBoxCacBuoc.Items.Add(item);
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

        public void SetRuntimeLabelUI(double t)
        {
            runtimeLabel.Text = $"Runtime : {t}ms";
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
            // Tối đa là 45 phần tử thôi nha, chư hơn nữa là khó nhìn lắm
            // Gọi FormNhapMang
            int soPhanTu = (int)NumericNhapSoPhanTu.Value;
            if (soPhanTu < 2 || soPhanTu > 45)
            {
                MessageBox.Show("Số phần tử phải từ 2 đến 45", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Có lỗi khi nhập mảng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NhapFileText(object sender, EventArgs e)
        {
            NhapFileClicked?.Invoke(this, e);
        }
        #endregion

        #region CUSTOM DRAWING FOR LISTBOX
        private void ListBoxCacBuoc_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            var item = ListBoxCacBuoc.Items[e.Index];
            string text;
            int swapPos1 = -1, swapPos2 = -1;

            if (item is ListBoxItem listBoxItem)
            {
                text = listBoxItem.Text;
                swapPos1 = listBoxItem.SwapPos1;
                swapPos2 = listBoxItem.SwapPos2;
            }
            else
            {
                text = item.ToString();
            }

            // Xác định màu sắc và font dựa trên nội dung
            Font drawFont = e.Font;
            Brush textBrush = Brushes.Black;

            // Kiểm tra các từ khóa đặc biệt để tô màu
            if (text.Contains("BẮT ĐẦU MERGE SORT") || text.Contains("HOÀN THÀNH MERGE SORT"))
            {
                // Header màu xanh dương đậm, in đậm
                textBrush = Brushes.DarkBlue;
                drawFont = new Font(e.Font, FontStyle.Bold);
            }
            else if (text.StartsWith("CHIA:"))
            {
                // Dòng chia màu cam/vàng
                textBrush = Brushes.DarkOrange;
                drawFont = new Font(e.Font, FontStyle.Bold);
            }
            else if (text.StartsWith("BẮT ĐẦU TRỘN:"))
            {
                // Dòng bắt đầu trộn màu xanh lá
                textBrush = Brushes.Green;
                drawFont = new Font(e.Font, FontStyle.Bold);
            }
            else if (text.StartsWith("HOÀN THÀNH:"))
            {
                // Dòng hoàn thành màu xanh lá đậm
                textBrush = Brushes.DarkGreen;
                drawFont = new Font(e.Font, FontStyle.Bold);
            }
            else if (text.StartsWith("---"))
            {
                // Đường kẻ phân cách màu xám
                textBrush = Brushes.Gray;
            }
            else if (swapPos1 >= 0 && swapPos2 >= 0)
            {
                // Các bước thông thường với highlight màu đỏ
                DrawHighlightedText(e.Graphics, text, e.Bounds, swapPos1, swapPos2);
                e.DrawFocusRectangle();
                return;
            }

            // Vẽ text với màu sắc đã chọn
            e.Graphics.DrawString(text, drawFont, textBrush, e.Bounds);

            // Cleanup font nếu đã tạo mới
            if (drawFont != e.Font)
                drawFont.Dispose();

            e.DrawFocusRectangle();
        }

        private void DrawHighlightedText(Graphics g, string text, Rectangle bounds, int pos1, int pos2)
        {
            // Parse text để tìm các số và vị trí của chúng
            string[] parts = text.Split(new[] { ":" }, StringSplitOptions.None);
            if (parts.Length < 2)
            {
                g.DrawString(text, ListBoxCacBuoc.Font, Brushes.Black, bounds);
                return;
            }

            string prefix = parts[0] + ": ";
            string numbers = parts[1].Trim();
            string[] nums = numbers.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);

            float x = bounds.X;
            float y = bounds.Y;

            // Vẽ prefix
            g.DrawString(prefix, ListBoxCacBuoc.Font, Brushes.Black, x, y);
            SizeF prefixSize = g.MeasureString(prefix, ListBoxCacBuoc.Font);
            x += prefixSize.Width;

            // Vẽ từng số với màu sắc phù hợp
            for (int i = 0; i < nums.Length; i++)
            {
                Brush brush = Brushes.Black;

                if (i == pos1 || i == pos2)
                    brush = Brushes.Red; // Highlight số đang hoán vị

                g.DrawString(nums[i], ListBoxCacBuoc.Font, brush, x, y);
                SizeF numSize = g.MeasureString(nums[i] + "  ", ListBoxCacBuoc.Font);
                x += numSize.Width;
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

        #region LISTBOX ITEM CLASS
        private class ListBoxItem
        {
            public string Text { get; set; }
            public int SwapPos1 { get; set; } = -1;
            public int SwapPos2 { get; set; } = -1;

            public override string ToString()
            {
                return Text;
            }
        }
        #endregion


        private void Form_Load(object sender, EventArgs e)
        {
            SortingPanelView.Paint += SortingPanelView_Paint;
        }

        public void VeLaiSortingPanelView()
        {
            VeLaiSortingPanel();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            string code = string.Empty;
            foreach (var item in ListBoxCodeC.Items)
            {
                // Do something with each item
                string itemText = item.ToString();
                code += itemText + '\n';
            }
            Clipboard.SetText(code);
        }
    }
}