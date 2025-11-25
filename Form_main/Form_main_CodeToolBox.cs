using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main
    {
        #region KHU VỰC CÁC LABEL
        private void Tai_v_LabelNhapSoPhanTu_Click(object sender, EventArgs e) { }
        private void Tai_v_LabelChuThichSoPhanTu_Click(object sender, EventArgs e) { }
        private void Tai_v_LabelNhapGiaTriMang_Click(object sender, EventArgs e) { }
        private void Tai_v_LabelChonThuatToan_Click(object sender, EventArgs e) { }
        private void Tai_v_LabelLoaiSapXep_Click(object sender, EventArgs e) { }
        private void Tai_v_LabelTocDo_Click(object sender, EventArgs e) { }
        // private void LabelMangA_Click(object sender, EventArgs e) { }
        // private void LabelChiSo_Click(object sender, EventArgs e) { }
        private void LabelSoPhanTu_Click(object sender, EventArgs e) { }
        private void LabelKhoangGiaTriPhanTu_Click(object sender, EventArgs e) { }
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
            controller.Create();
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
    }
}
