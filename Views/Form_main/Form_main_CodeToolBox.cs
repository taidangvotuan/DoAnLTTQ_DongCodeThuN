using System;
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
        private void PanelNen_Paint(object sender, PaintEventArgs e) { }

        private void PanelMoPhong_Paint(object sender, PaintEventArgs e) { }

        private void PanelThanhDieuKhien_Paint(object sender, PaintEventArgs e) { }

        private void Tai_v_ThanhDieuKhien_Paint(object sender, PaintEventArgs e) { }

        private void SortingPanelView_Paint(object sender, PaintEventArgs e)
        {
            /*if (a == null || a.Length == 0)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int n = a.Length;
            int panelWidth = SortingPanelView.Width;
            int panelHeight = SortingPanelView.Height;

            int barWidth = panelWidth / (n * 2);
            if (barWidth <= 0) barWidth = 1;
            int maxVal = a.Max();
            if (maxVal == 0) maxVal = 1;
            int xStart = (panelWidth - n * barWidth * 2) / 2;

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            {
                Brush barBrush = Brushes.Blue;
                Brush highlightBrush = Brushes.Red;
                Brush textBrush = Brushes.Black;

                float t = 0f;
                if (Binh_b_DangAnimation && Binh_i_AnimationStepMax > 0)
                {
                    t = (float)Binh_i_AnimationStep / (float)Binh_i_AnimationStepMax;
                    if (t < 0f) t = 0f;
                    if (t > 1f) t = 1f;
                }

                for (int i = 0; i < n; i++)
                {
                    float heightRatio = (float)a[i] / (float)maxVal;
                    int barHeight = (int)(heightRatio * (panelHeight - 100));

                    int baseX = xStart + i * barWidth * 2;
                    int x = baseX;

                    // Nếu đang animation thì nội suy vị trí 2 cột đang hoán vị (Bình)
                    if (Binh_b_DangAnimation && (i == Binh_i_ViTriSwap1 || i == Binh_i_ViTriSwap2))
                    {
                        int indexFrom, indexTo;

                        if (i == Binh_i_ViTriSwap1)
                        {
                            indexFrom = Binh_i_ViTriSwap1;
                            indexTo = Binh_i_ViTriSwap2;
                        }
                        else
                        {
                            indexFrom = Binh_i_ViTriSwap2;
                            indexTo = Binh_i_ViTriSwap1;
                        }

                        int fromX = xStart + indexFrom * barWidth * 2;
                        int toX = xStart + indexTo * barWidth * 2;

                        x = (int)(fromX + (toX - fromX) * t);
                    }

                    int y = panelHeight - barHeight - 50;

                    Brush brushToUse = barBrush;
                    if (i == Binh_i_ViTriSwap1 || i == Binh_i_ViTriSwap2)
                        brushToUse = highlightBrush;

                    g.FillRectangle(brushToUse, x, y, barWidth, barHeight);

                    string valueStr = a[i].ToString();
                    SizeF textSize = g.MeasureString(valueStr, font);
                    g.DrawString(
                        valueStr,
                        font,
                        textBrush,
                        x + (barWidth - textSize.Width) / 2,
                        panelHeight - 40);
                }
            }*/
            if (controller?.VisualService == null) return;

            controller.VisualService.DrawSortingPanel(
                e.Graphics,
                SortingPanelView.Width,
                SortingPanelView.Height
            );
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
            /*if (a == null || a.Length == 0)
            {
                MessageBox.Show("Bạn chưa khởi tạo mảng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (NutChonThuatToan.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn thuật toán!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ChonTangDan.Checked && !ChonGiamDan.Checked)
            {
                MessageBox.Show("Bạn chưa chọn kiểu sắp xếp!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            is_run = true;
            kt_tam_dung = false;
            Binh_b_DangAnimation = false;
            Binh_i_ViTriSwap1 = -1;
            Binh_i_ViTriSwap2 = -1;
            NutTamDungThuatToan.Text = "Tạm dừng";

            KhoiChay();

            string tenThuatToan = NutChonThuatToan.SelectedItem.ToString();

            if (tenThuatToan == "Bubble Sort")
            {
                if (tang) Thinh_v_BubbleSortTangDan(a);
                else Thinh_v_BubbleSortGiamDan(a);
            }
            else if (tenThuatToan == "Heap Sort")
            {
                if (tang) Tai_v_HeapSortTangDan(a);
                else Tai_v_HeapSortGiamDan(a);
            }
            else if (tenThuatToan == "Insertion Sort")
            {
                if (tang) Binh_v_InsertionSortTangDan(a);
                else Binh_v_InsertionSortGiamDan(a);
                VeLaiSortingPanelView();
            }
            else if (tenThuatToan == "Interchange Sort")
            {
                if (tang) Tai_v_InterchangeSortTangDan(a);
                else Tai_v_InterchangeSortGiamDan(a);
            }
            else if (tenThuatToan == "Merge Sort")
            {
                if (tang) Tai_v_MergeSortTangDan(a, 0, a.Length - 1);
                else Tai_v_MergeSortGiamDan(a, 0, a.Length - 1);
                VeLaiSortingPanelView();
            }
            else if (tenThuatToan == "Quick Sort")
            {
                if (tang) Thinh_v_QuickSortTangDan(a, 0, a.Length - 1);
                else Thinh_v_QuickSortGiamDan(a, 0, a.Length - 1);
            }
            else if (tenThuatToan == "Selection Sort")
            {
                if (tang) Binh_v_SelectionSortTangDan(a);
                else Binh_v_SelectionSortGiamDan(a);
            }

            is_run = false;
            kt_tam_dung = false;
            Binh_b_DangAnimation = false;
            Binh_i_ViTriSwap1 = -1;
            Binh_i_ViTriSwap2 = -1;
            NutTamDungThuatToan.Text = "Tạm dừng";

            VeLaiSortingPanelView();

            NutNhapNgauNhien.Enabled = true;
            NutNhapBangTay.Enabled = true;
            NutChonThuatToan.Enabled = true;
            ChonTangDan.Enabled = true;
            ChonGiamDan.Enabled = true;
            KiemTraDieuKienChonThuatToan();*/
            ChayThuatToanClicked?.Invoke(this, e);
        }

        private void Tai_v_NutTamDungThuatToan_Click(object sender, EventArgs e)
        {
            /*if (!is_run)
                return;

            kt_tam_dung = !kt_tam_dung;
            NutTamDungThuatToan.Text = kt_tam_dung ? "Tiếp tục" : "Tạm dừng";*/
            TamDungThuatToanClicked?.Invoke(this, e);
        }

        private void Tai_v_NutKetThucThuatToan_Click(object sender, EventArgs e)
        {
            /*if (!is_run)
                return;

            is_run = false;
            kt_tam_dung = false;
            Binh_b_DangAnimation = false;
            Binh_i_ViTriSwap1 = -1;
            Binh_i_ViTriSwap2 = -1;
            NutTamDungThuatToan.Text = "Tạm dừng";

            // Sắp xếp nhanh để ra kết quả cuối cùng
            if (a != null && a.Length > 0)
            {
                if (tang)
                    Array.Sort(a);
                else
                {
                    Array.Sort(a);
                    Array.Reverse(a);
                }
            }

            VeLaiSortingPanelView();

            // Mở lại các nút lựa chọn
            NutNhapNgauNhien.Enabled = true;
            NutNhapBangTay.Enabled = true;
            NutChonThuatToan.Enabled = true;
            ChonTangDan.Enabled = true;
            ChonGiamDan.Enabled = true;
            KiemTraDieuKienChonThuatToan();*/
            KetThucThuatToanClicked?.Invoke(this, e);
        }

        private void Tai_v_NutChonThuatToan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NutChonThuatToan.SelectedIndex >= 0)
            {
                ChonTangDan.Enabled = true;
                ChonGiamDan.Enabled = true;
            }
            ThuatToanChanged?.Invoke(this, e);
            KiemTraDieuKienChonThuatToan();
        }

        private void Tai_v_NutChinhTocDoThuatToan_Scroll(object sender, EventArgs e)
        {
            /*toc_Do = NutChinhTocDoThuatToan.Value;
            if (toc_Do < 1) toc_Do = 1;*/
            TocDoChanged?.Invoke(this, e);
        }

        private void Tai_v_ChonTangDan_CheckedChanged(object sender, EventArgs e)
        {
            /*KiemTraDieuKienChonThuatToan();

            if (ChonTangDan.Checked)
            {
                tang = true;
                ThayDoiCodeKhiChonTangHoacGiam();
            }*/
            if (ChonTangDan.Checked)
            {
                KieuSapXepChanged?.Invoke(this, e);
                KiemTraDieuKienChonThuatToan();
            }
        }

        private void Tai_v_ChonGiamDan_CheckedChanged(object sender, EventArgs e)
        {
            /*KiemTraDieuKienChonThuatToan();
            if (ChonGiamDan.Checked)
            {
                tang = false;
                ThayDoiCodeKhiChonTangHoacGiam();
            }*/
            if (ChonGiamDan.Checked)
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
