using System;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN.Views.Interfaces
{
    public interface IMainView
    {
        // Events - View trigger khi có action
        event EventHandler NhapNgauNhienClicked;
        event EventHandler NhapBangTayClicked;
        event EventHandler ChayThuatToanClicked;
        event EventHandler TamDungThuatToanClicked;
        event EventHandler KetThucThuatToanClicked;
        event EventHandler ThuatToanChanged;
        event EventHandler TocDoChanged;
        event EventHandler KieuSapXepChanged;

        // Properties - Controller đọc/ghi
        int SoPhanTu { get; set; }
        int[] MangA { get; set; }
        string ThuatToanDaChon { get; }
        int TocDo { get; }
        bool TangDan { get; }

        // Methods - Controller gọi để cập nhật UI
        void VeLaiSortingPanel();
        void HienThiListBoxYTuong(string[] items);
        void HienThiListBoxCode(string[] items);
        void HienThiListBoxCacBuoc(string[] items);
        void ThemBuocVaoListBox(string buoc);
        void XoaListBoxCacBuoc();
        void MoCacNutLuaChonThuatToan();
        void MoCacNutDieuKhien();
        void KhoiChay();
        void KhoaChay();
        void HienThiThongBao(string message, string title, MessageBoxIcon icon);

        // Refresh UI
        void RefreshSortingPanel();
        void UpdateUI();
    }
}
     
