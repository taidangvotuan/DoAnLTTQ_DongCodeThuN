using System;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main
    {
        #region KHU VỰC CÁC PANEL
        private void PanelNen_Paint(object sender, PaintEventArgs e) { }
        private void PanelMoPhong_Paint(object sender, PaintEventArgs e) { }
        private void PanelThanhDieuKhien_Paint(object sender, PaintEventArgs e) { }
        private void Tai_v_ThanhDieuKhien_Paint(object sender, PaintEventArgs e) { }
        private void SortingPanelView_Paint(object sender, PaintEventArgs e)
        { 
            if (controller?.VisualService == null) return;
            controller.VisualService.DrawSortingPanel(e.Graphics, SortingPanelView.Width, SortingPanelView.Height);
        }
        #endregion

        #region KHU VỰC CÁC NÚT BẤM
        private void Tai_v_NutChayThuatToan_Click(object sender, EventArgs e)
        {
            ChayThuatToanClicked?.Invoke(this, e);
        }

        private void Tai_v_NutTamDungThuatToan_Click(object sender, EventArgs e)
        {
            TamDungThuatToanClicked?.Invoke(this, e);
        }

        private void Tai_v_NutKetThucThuatToan_Click(object sender, EventArgs e)
        {
            KetThucThuatToanClicked?.Invoke(this, e);
        }

        private void Tai_v_NutChonThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBox_ChonThuatToan.SelectedIndex >= 0)
            {
                RadioButton_TangDan.Enabled = true;
                RadioButton_GiamDan.Enabled = true;
            }
            ThuatToanChanged?.Invoke(this, e);
            KiemTraDieuKienChonThuatToan();
        }

        private void Tai_v_NutChinhTocDoThuatToan_Scroll(object sender, EventArgs e)
        {
            TocDoChanged?.Invoke(this, e);
        }

        private void Tai_v_ChonTangDan_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_TangDan.Checked)
            {
                KieuSapXepChanged?.Invoke(this, e);
                KiemTraDieuKienChonThuatToan();
            }
        }

        private void Tai_v_ChonGiamDan_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton_GiamDan.Checked)
            {
                KieuSapXepChanged?.Invoke(this, e);
                KiemTraDieuKienChonThuatToan();
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

        #endregion

        #region KHU VỰC CÁC NÚT CHỨC NĂNG KHÁC
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //FormController.OnUpdate?.Invoke();
        }
        #endregion
    }
}
