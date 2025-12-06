using System;

namespace DoAnLTTQ_DongCodeThuN
{
    partial class Form_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ListBoxYTuong = new System.Windows.Forms.ListBox();
            this.ListBoxCodeC = new System.Windows.Forms.ListBox();
            this.GroupBoxChuongTrinhCPP = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonHuongDan = new System.Windows.Forms.Button();
            this.PanelNen = new System.Windows.Forms.Panel();
            this.ButtonTacGia = new System.Windows.Forms.Button();
            this.ListBoxCacBuoc = new System.Windows.Forms.ListBox();
            this.GroupBoxCacBuocThucHien = new System.Windows.Forms.GroupBox();
            this.ThanhDieuKhien = new System.Windows.Forms.Panel();
            this.GroupBoxYTuong = new System.Windows.Forms.GroupBox();
            this.GroupBoxChonThuatToan = new System.Windows.Forms.GroupBox();
            this.LabelChonThuatToan = new System.Windows.Forms.Label();
            this.LabelLoaiSapXep = new System.Windows.Forms.Label();
            this.RadioButton_TangDan = new System.Windows.Forms.RadioButton();
            this.ComboBox_ChonThuatToan = new System.Windows.Forms.ComboBox();
            this.RadioButton_GiamDan = new System.Windows.Forms.RadioButton();
            this.GroupBoxDieuKhien = new System.Windows.Forms.GroupBox();
            this.ButtonKetThucThuatToan = new System.Windows.Forms.Button();
            this.ButtonTamDungThuatToan = new System.Windows.Forms.Button();
            this.ButtonChayThuatToan = new System.Windows.Forms.Button();
            this.TrackBar_ChinhTocDoThuatToan = new System.Windows.Forms.TrackBar();
            this.LabelTocDo = new System.Windows.Forms.Label();
            this.GroupBoxKhoiTaoMang = new System.Windows.Forms.GroupBox();
            this.LabelKhoangGiaTriPhanTu = new System.Windows.Forms.Label();
            this.LabelSoPhanTu = new System.Windows.Forms.Label();
            this.NumericNhapSoPhanTu = new System.Windows.Forms.NumericUpDown();
            this.ButtonNhapNgauNhien = new System.Windows.Forms.Button();
            this.LabelNhapGiaTriMang = new System.Windows.Forms.Label();
            this.ButtonNhapBangTay = new System.Windows.Forms.Button();
            this.PanelMoPhong = new System.Windows.Forms.Panel();
            this.SortingPanelView = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.GroupBoxChuongTrinhCPP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelNen.SuspendLayout();
            this.GroupBoxCacBuocThucHien.SuspendLayout();
            this.ThanhDieuKhien.SuspendLayout();
            this.GroupBoxYTuong.SuspendLayout();
            this.GroupBoxChonThuatToan.SuspendLayout();
            this.GroupBoxDieuKhien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar_ChinhTocDoThuatToan)).BeginInit();
            this.GroupBoxKhoiTaoMang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericNhapSoPhanTu)).BeginInit();
            this.PanelMoPhong.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxYTuong
            // 
            this.ListBoxYTuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ListBoxYTuong.FormattingEnabled = true;
            this.ListBoxYTuong.IntegralHeight = false;
            this.ListBoxYTuong.ItemHeight = 28;
            this.ListBoxYTuong.Location = new System.Drawing.Point(2, 18);
            this.ListBoxYTuong.Name = "ListBoxYTuong";
            this.ListBoxYTuong.Size = new System.Drawing.Size(373, 202);
            this.ListBoxYTuong.TabIndex = 18;
            this.ListBoxYTuong.SelectedIndexChanged += new System.EventHandler(this.Tai_v_ListBoxYTuong_SelectedIndexChanged);
            // 
            // ListBoxCodeC
            // 
            this.ListBoxCodeC.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ListBoxCodeC.FormattingEnabled = true;
            this.ListBoxCodeC.IntegralHeight = false;
            this.ListBoxCodeC.ItemHeight = 18;
            this.ListBoxCodeC.Location = new System.Drawing.Point(2, 18);
            this.ListBoxCodeC.Name = "ListBoxCodeC";
            this.ListBoxCodeC.Size = new System.Drawing.Size(439, 202);
            this.ListBoxCodeC.TabIndex = 20;
            this.ListBoxCodeC.SelectedIndexChanged += new System.EventHandler(this.Tai_v_ListBoxCodeC_SelectedIndexChanged);
            // 
            // GroupBoxChuongTrinhCPP
            // 
            this.GroupBoxChuongTrinhCPP.BackColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBoxChuongTrinhCPP.Controls.Add(this.ListBoxCodeC);
            this.GroupBoxChuongTrinhCPP.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBoxChuongTrinhCPP.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBoxChuongTrinhCPP.Location = new System.Drawing.Point(985, 544);
            this.GroupBoxChuongTrinhCPP.Name = "GroupBoxChuongTrinhCPP";
            this.GroupBoxChuongTrinhCPP.Size = new System.Drawing.Size(447, 222);
            this.GroupBoxChuongTrinhCPP.TabIndex = 15;
            this.GroupBoxChuongTrinhCPP.TabStop = false;
            this.GroupBoxChuongTrinhCPP.Text = "Code C/C++";
            this.GroupBoxChuongTrinhCPP.Enter += new System.EventHandler(this.Tai_v_GroupBoxChuongTrinhCPP_Enter);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(240, 576);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1186, 183);
            this.panel3.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.pictureBox1.Image = global::DoAnLTTQ_DongCodeThuN.Properties.Resources.AnhUIT;
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(236, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(238, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // ButtonHuongDan
            // 
            this.ButtonHuongDan.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonHuongDan.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonHuongDan.FlatAppearance.BorderSize = 0;
            this.ButtonHuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonHuongDan.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonHuongDan.Location = new System.Drawing.Point(0, 188);
            this.ButtonHuongDan.Name = "ButtonHuongDan";
            this.ButtonHuongDan.Size = new System.Drawing.Size(240, 65);
            this.ButtonHuongDan.TabIndex = 22;
            this.ButtonHuongDan.Text = "Hướng dẫn sử dụng";
            this.ButtonHuongDan.UseVisualStyleBackColor = false;
            this.ButtonHuongDan.Click += new System.EventHandler(this.Tai_v_ButtonHuongDan_Click);
            // 
            // PanelNen
            // 
            this.PanelNen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PanelNen.BackColor = System.Drawing.Color.CornflowerBlue;
            this.PanelNen.Controls.Add(this.panel3);
            this.PanelNen.Controls.Add(this.pictureBox1);
            this.PanelNen.Controls.Add(this.label1);
            this.PanelNen.Controls.Add(this.ButtonTacGia);
            this.PanelNen.Controls.Add(this.ButtonHuongDan);
            this.PanelNen.Location = new System.Drawing.Point(3, 3);
            this.PanelNen.Name = "PanelNen";
            this.PanelNen.Size = new System.Drawing.Size(240, 765);
            this.PanelNen.TabIndex = 21;
            this.PanelNen.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelNen_Paint);
            // 
            // ButtonTacGia
            // 
            this.ButtonTacGia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ButtonTacGia.BackColor = System.Drawing.Color.Gainsboro;
            this.ButtonTacGia.FlatAppearance.BorderSize = 0;
            this.ButtonTacGia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonTacGia.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTacGia.Location = new System.Drawing.Point(0, 251);
            this.ButtonTacGia.Name = "ButtonTacGia";
            this.ButtonTacGia.Size = new System.Drawing.Size(240, 65);
            this.ButtonTacGia.TabIndex = 23;
            this.ButtonTacGia.Text = "Về tác giả";
            this.ButtonTacGia.UseVisualStyleBackColor = false;
            this.ButtonTacGia.Click += new System.EventHandler(this.Tai_v_ButtonTacGia_Click);
            // 
            // ListBoxCacBuoc
            // 
            this.ListBoxCacBuoc.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ListBoxCacBuoc.FormattingEnabled = true;
            this.ListBoxCacBuoc.HorizontalScrollbar = true;
            this.ListBoxCacBuoc.IntegralHeight = false;
            this.ListBoxCacBuoc.ItemHeight = 28;
            this.ListBoxCacBuoc.Location = new System.Drawing.Point(1, 18);
            this.ListBoxCacBuoc.Name = "ListBoxCacBuoc";
            this.ListBoxCacBuoc.Size = new System.Drawing.Size(358, 202);
            this.ListBoxCacBuoc.TabIndex = 19;
            this.ListBoxCacBuoc.SelectedIndexChanged += new System.EventHandler(this.Tai_v_ListBoxCacBuoc_SelectedIndexChanged);
            // 
            // GroupBoxCacBuocThucHien
            // 
            this.GroupBoxCacBuocThucHien.BackColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBoxCacBuocThucHien.Controls.Add(this.ListBoxCacBuoc);
            this.GroupBoxCacBuocThucHien.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBoxCacBuocThucHien.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBoxCacBuocThucHien.Location = new System.Drawing.Point(622, 544);
            this.GroupBoxCacBuocThucHien.Name = "GroupBoxCacBuocThucHien";
            this.GroupBoxCacBuocThucHien.Size = new System.Drawing.Size(364, 222);
            this.GroupBoxCacBuocThucHien.TabIndex = 20;
            this.GroupBoxCacBuocThucHien.TabStop = false;
            this.GroupBoxCacBuocThucHien.Text = "Các bước thực hiện";
            this.GroupBoxCacBuocThucHien.Enter += new System.EventHandler(this.Tai_v_GroupBoxCacBuocThucHien_Enter);
            // 
            // ThanhDieuKhien
            // 
            this.ThanhDieuKhien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ThanhDieuKhien.Controls.Add(this.GroupBoxCacBuocThucHien);
            this.ThanhDieuKhien.Controls.Add(this.PanelNen);
            this.ThanhDieuKhien.Controls.Add(this.GroupBoxChuongTrinhCPP);
            this.ThanhDieuKhien.Controls.Add(this.GroupBoxYTuong);
            this.ThanhDieuKhien.Controls.Add(this.GroupBoxChonThuatToan);
            this.ThanhDieuKhien.Controls.Add(this.GroupBoxDieuKhien);
            this.ThanhDieuKhien.Controls.Add(this.GroupBoxKhoiTaoMang);
            this.ThanhDieuKhien.Controls.Add(this.PanelMoPhong);
            this.ThanhDieuKhien.Location = new System.Drawing.Point(-5, -3);
            this.ThanhDieuKhien.Name = "ThanhDieuKhien";
            this.ThanhDieuKhien.Size = new System.Drawing.Size(1432, 768);
            this.ThanhDieuKhien.TabIndex = 23;
            this.ThanhDieuKhien.Paint += new System.Windows.Forms.PaintEventHandler(this.Tai_v_ThanhDieuKhien_Paint);
            // 
            // GroupBoxYTuong
            // 
            this.GroupBoxYTuong.BackColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBoxYTuong.Controls.Add(this.ListBoxYTuong);
            this.GroupBoxYTuong.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBoxYTuong.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBoxYTuong.Location = new System.Drawing.Point(243, 544);
            this.GroupBoxYTuong.Name = "GroupBoxYTuong";
            this.GroupBoxYTuong.Size = new System.Drawing.Size(381, 222);
            this.GroupBoxYTuong.TabIndex = 14;
            this.GroupBoxYTuong.TabStop = false;
            this.GroupBoxYTuong.Text = "Ý tưởng";
            this.GroupBoxYTuong.Enter += new System.EventHandler(this.Tai_v_GroupBoxYTuong_Enter);
            // 
            // GroupBoxChonThuatToan
            // 
            this.GroupBoxChonThuatToan.BackColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBoxChonThuatToan.Controls.Add(this.LabelChonThuatToan);
            this.GroupBoxChonThuatToan.Controls.Add(this.LabelLoaiSapXep);
            this.GroupBoxChonThuatToan.Controls.Add(this.RadioButton_TangDan);
            this.GroupBoxChonThuatToan.Controls.Add(this.ComboBox_ChonThuatToan);
            this.GroupBoxChonThuatToan.Controls.Add(this.RadioButton_GiamDan);
            this.GroupBoxChonThuatToan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBoxChonThuatToan.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBoxChonThuatToan.Location = new System.Drawing.Point(546, 3);
            this.GroupBoxChonThuatToan.Name = "GroupBoxChonThuatToan";
            this.GroupBoxChonThuatToan.Size = new System.Drawing.Size(340, 116);
            this.GroupBoxChonThuatToan.TabIndex = 19;
            this.GroupBoxChonThuatToan.TabStop = false;
            this.GroupBoxChonThuatToan.Text = "Lựa chọn thuật toán";
            this.GroupBoxChonThuatToan.Enter += new System.EventHandler(this.Tai_v_GroupBoxChonThuatToan_Enter);
            // 
            // LabelChonThuatToan
            // 
            this.LabelChonThuatToan.AutoSize = true;
            this.LabelChonThuatToan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LabelChonThuatToan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelChonThuatToan.Location = new System.Drawing.Point(6, 40);
            this.LabelChonThuatToan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelChonThuatToan.Name = "LabelChonThuatToan";
            this.LabelChonThuatToan.Size = new System.Drawing.Size(143, 19);
            this.LabelChonThuatToan.TabIndex = 10;
            this.LabelChonThuatToan.Text = "Chọn thuật toán:";
            this.LabelChonThuatToan.Click += new System.EventHandler(this.Tai_v_LabelChonThuatToan_Click);
            // 
            // LabelLoaiSapXep
            // 
            this.LabelLoaiSapXep.AutoSize = true;
            this.LabelLoaiSapXep.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LabelLoaiSapXep.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelLoaiSapXep.Location = new System.Drawing.Point(6, 65);
            this.LabelLoaiSapXep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelLoaiSapXep.Name = "LabelLoaiSapXep";
            this.LabelLoaiSapXep.Size = new System.Drawing.Size(114, 19);
            this.LabelLoaiSapXep.TabIndex = 16;
            this.LabelLoaiSapXep.Text = "Loại sắp xếp:";
            this.LabelLoaiSapXep.Click += new System.EventHandler(this.Tai_v_LabelLoaiSapXep_Click);
            // 
            // RadioButton_TangDan
            // 
            this.RadioButton_TangDan.AutoSize = true;
            this.RadioButton_TangDan.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton_TangDan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.RadioButton_TangDan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RadioButton_TangDan.Location = new System.Drawing.Point(135, 64);
            this.RadioButton_TangDan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioButton_TangDan.Name = "RadioButton_TangDan";
            this.RadioButton_TangDan.Size = new System.Drawing.Size(103, 23);
            this.RadioButton_TangDan.TabIndex = 1;
            this.RadioButton_TangDan.TabStop = true;
            this.RadioButton_TangDan.Text = "Tăng dần";
            this.RadioButton_TangDan.UseVisualStyleBackColor = false;
            this.RadioButton_TangDan.CheckedChanged += new System.EventHandler(this.Tai_v_ChonTangDan_CheckedChanged);
            // 
            // ComboBox_ChonThuatToan
            // 
            this.ComboBox_ChonThuatToan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ComboBox_ChonThuatToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox_ChonThuatToan.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ComboBox_ChonThuatToan.ForeColor = System.Drawing.Color.Black;
            this.ComboBox_ChonThuatToan.FormattingEnabled = true;
            this.ComboBox_ChonThuatToan.Items.AddRange(new object[] {
            "Bubble Sort",
            "Heap Sort",
            "Insertion Sort",
            "Interchange Sort",
            "Merge Sort",
            "Quick Sort",
            "Selection Sort"});
            this.ComboBox_ChonThuatToan.Location = new System.Drawing.Point(135, 38);
            this.ComboBox_ChonThuatToan.Name = "ComboBox_ChonThuatToan";
            this.ComboBox_ChonThuatToan.Size = new System.Drawing.Size(188, 29);
            this.ComboBox_ChonThuatToan.TabIndex = 12;
            this.ComboBox_ChonThuatToan.SelectedIndexChanged += new System.EventHandler(this.Tai_v_NutChonThuatToan_SelectedIndexChanged);
            // 
            // RadioButton_GiamDan
            // 
            this.RadioButton_GiamDan.AutoSize = true;
            this.RadioButton_GiamDan.BackColor = System.Drawing.Color.Transparent;
            this.RadioButton_GiamDan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.RadioButton_GiamDan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RadioButton_GiamDan.Location = new System.Drawing.Point(231, 64);
            this.RadioButton_GiamDan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RadioButton_GiamDan.Name = "RadioButton_GiamDan";
            this.RadioButton_GiamDan.Size = new System.Drawing.Size(104, 23);
            this.RadioButton_GiamDan.TabIndex = 2;
            this.RadioButton_GiamDan.TabStop = true;
            this.RadioButton_GiamDan.Text = "Giảm dần";
            this.RadioButton_GiamDan.UseVisualStyleBackColor = false;
            this.RadioButton_GiamDan.CheckedChanged += new System.EventHandler(this.Tai_v_ChonGiamDan_CheckedChanged);
            // 
            // GroupBoxDieuKhien
            // 
            this.GroupBoxDieuKhien.BackColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBoxDieuKhien.Controls.Add(this.ButtonKetThucThuatToan);
            this.GroupBoxDieuKhien.Controls.Add(this.ButtonTamDungThuatToan);
            this.GroupBoxDieuKhien.Controls.Add(this.ButtonChayThuatToan);
            this.GroupBoxDieuKhien.Controls.Add(this.TrackBar_ChinhTocDoThuatToan);
            this.GroupBoxDieuKhien.Controls.Add(this.LabelTocDo);
            this.GroupBoxDieuKhien.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBoxDieuKhien.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBoxDieuKhien.Location = new System.Drawing.Point(885, 3);
            this.GroupBoxDieuKhien.Name = "GroupBoxDieuKhien";
            this.GroupBoxDieuKhien.Size = new System.Drawing.Size(544, 116);
            this.GroupBoxDieuKhien.TabIndex = 20;
            this.GroupBoxDieuKhien.TabStop = false;
            this.GroupBoxDieuKhien.Text = "Thanh điều khiển";
            this.GroupBoxDieuKhien.Enter += new System.EventHandler(this.Tai_v_GroupBoxDieuKhien_Enter);
            // 
            // ButtonKetThucThuatToan
            // 
            this.ButtonKetThucThuatToan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonKetThucThuatToan.FlatAppearance.BorderSize = 0;
            this.ButtonKetThucThuatToan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonKetThucThuatToan.ForeColor = System.Drawing.Color.Black;
            this.ButtonKetThucThuatToan.Location = new System.Drawing.Point(367, 68);
            this.ButtonKetThucThuatToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonKetThucThuatToan.Name = "ButtonKetThucThuatToan";
            this.ButtonKetThucThuatToan.Size = new System.Drawing.Size(165, 32);
            this.ButtonKetThucThuatToan.TabIndex = 19;
            this.ButtonKetThucThuatToan.Text = "Kết thúc";
            this.ButtonKetThucThuatToan.UseVisualStyleBackColor = false;
            this.ButtonKetThucThuatToan.Click += new System.EventHandler(this.Tai_v_NutKetThucThuatToan_Click);
            // 
            // ButtonTamDungThuatToan
            // 
            this.ButtonTamDungThuatToan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ButtonTamDungThuatToan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonTamDungThuatToan.FlatAppearance.BorderSize = 0;
            this.ButtonTamDungThuatToan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonTamDungThuatToan.ForeColor = System.Drawing.Color.Black;
            this.ButtonTamDungThuatToan.Location = new System.Drawing.Point(192, 68);
            this.ButtonTamDungThuatToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonTamDungThuatToan.Name = "ButtonTamDungThuatToan";
            this.ButtonTamDungThuatToan.Size = new System.Drawing.Size(165, 32);
            this.ButtonTamDungThuatToan.TabIndex = 18;
            this.ButtonTamDungThuatToan.Text = "Tạm dừng";
            this.ButtonTamDungThuatToan.UseVisualStyleBackColor = false;
            this.ButtonTamDungThuatToan.Click += new System.EventHandler(this.Tai_v_NutTamDungThuatToan_Click);
            // 
            // ButtonChayThuatToan
            // 
            this.ButtonChayThuatToan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonChayThuatToan.FlatAppearance.BorderSize = 0;
            this.ButtonChayThuatToan.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonChayThuatToan.ForeColor = System.Drawing.Color.Black;
            this.ButtonChayThuatToan.Location = new System.Drawing.Point(15, 68);
            this.ButtonChayThuatToan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonChayThuatToan.Name = "ButtonChayThuatToan";
            this.ButtonChayThuatToan.Size = new System.Drawing.Size(165, 32);
            this.ButtonChayThuatToan.TabIndex = 17;
            this.ButtonChayThuatToan.Text = "Chạy";
            this.ButtonChayThuatToan.UseVisualStyleBackColor = false;
            this.ButtonChayThuatToan.Click += new System.EventHandler(this.Tai_v_NutChayThuatToan_Click);
            // 
            // TrackBar_ChinhTocDoThuatToan
            // 
            this.TrackBar_ChinhTocDoThuatToan.Location = new System.Drawing.Point(67, 33);
            this.TrackBar_ChinhTocDoThuatToan.Maximum = 15;
            this.TrackBar_ChinhTocDoThuatToan.Name = "TrackBar_ChinhTocDoThuatToan";
            this.TrackBar_ChinhTocDoThuatToan.Size = new System.Drawing.Size(471, 56);
            this.TrackBar_ChinhTocDoThuatToan.TabIndex = 15;
            this.TrackBar_ChinhTocDoThuatToan.Scroll += new System.EventHandler(this.Tai_v_NutChinhTocDoThuatToan_Scroll);
            // 
            // LabelTocDo
            // 
            this.LabelTocDo.AutoSize = true;
            this.LabelTocDo.BackColor = System.Drawing.Color.Transparent;
            this.LabelTocDo.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LabelTocDo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelTocDo.Location = new System.Drawing.Point(13, 35);
            this.LabelTocDo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelTocDo.Name = "LabelTocDo";
            this.LabelTocDo.Size = new System.Drawing.Size(69, 19);
            this.LabelTocDo.TabIndex = 13;
            this.LabelTocDo.Text = "Tốc độ:";
            this.LabelTocDo.Click += new System.EventHandler(this.Tai_v_LabelTocDo_Click);
            // 
            // GroupBoxKhoiTaoMang
            // 
            this.GroupBoxKhoiTaoMang.BackColor = System.Drawing.Color.CornflowerBlue;
            this.GroupBoxKhoiTaoMang.Controls.Add(this.LabelKhoangGiaTriPhanTu);
            this.GroupBoxKhoiTaoMang.Controls.Add(this.LabelSoPhanTu);
            this.GroupBoxKhoiTaoMang.Controls.Add(this.NumericNhapSoPhanTu);
            this.GroupBoxKhoiTaoMang.Controls.Add(this.ButtonNhapNgauNhien);
            this.GroupBoxKhoiTaoMang.Controls.Add(this.LabelNhapGiaTriMang);
            this.GroupBoxKhoiTaoMang.Controls.Add(this.ButtonNhapBangTay);
            this.GroupBoxKhoiTaoMang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.GroupBoxKhoiTaoMang.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBoxKhoiTaoMang.Location = new System.Drawing.Point(243, 3);
            this.GroupBoxKhoiTaoMang.Name = "GroupBoxKhoiTaoMang";
            this.GroupBoxKhoiTaoMang.Size = new System.Drawing.Size(304, 116);
            this.GroupBoxKhoiTaoMang.TabIndex = 18;
            this.GroupBoxKhoiTaoMang.TabStop = false;
            this.GroupBoxKhoiTaoMang.Text = "Khởi tạo mảng";
            this.GroupBoxKhoiTaoMang.Enter += new System.EventHandler(this.Tai_v_GroupBoxKhoiTaoMang_Enter);
            // 
            // LabelKhoangGiaTriPhanTu
            // 
            this.LabelKhoangGiaTriPhanTu.AutoSize = true;
            this.LabelKhoangGiaTriPhanTu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LabelKhoangGiaTriPhanTu.ForeColor = System.Drawing.Color.Transparent;
            this.LabelKhoangGiaTriPhanTu.Location = new System.Drawing.Point(47, 37);
            this.LabelKhoangGiaTriPhanTu.Name = "LabelKhoangGiaTriPhanTu";
            this.LabelKhoangGiaTriPhanTu.Size = new System.Drawing.Size(155, 19);
            this.LabelKhoangGiaTriPhanTu.TabIndex = 26;
            this.LabelKhoangGiaTriPhanTu.Text = "(Giá trị từ 2 đến 45)";
            this.LabelKhoangGiaTriPhanTu.Click += new System.EventHandler(this.LabelKhoangGiaTriPhanTu_Click);
            // 
            // LabelSoPhanTu
            // 
            this.LabelSoPhanTu.AutoSize = true;
            this.LabelSoPhanTu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LabelSoPhanTu.ForeColor = System.Drawing.Color.Transparent;
            this.LabelSoPhanTu.Location = new System.Drawing.Point(9, 20);
            this.LabelSoPhanTu.Name = "LabelSoPhanTu";
            this.LabelSoPhanTu.Size = new System.Drawing.Size(228, 19);
            this.LabelSoPhanTu.TabIndex = 25;
            this.LabelSoPhanTu.Text = "Nhập số phần tử của mảng:";
            this.LabelSoPhanTu.Click += new System.EventHandler(this.LabelSoPhanTu_Click);
            // 
            // NumericNhapSoPhanTu
            // 
            this.NumericNhapSoPhanTu.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.NumericNhapSoPhanTu.Location = new System.Drawing.Point(208, 19);
            this.NumericNhapSoPhanTu.Name = "NumericNhapSoPhanTu";
            this.NumericNhapSoPhanTu.Size = new System.Drawing.Size(80, 27);
            this.NumericNhapSoPhanTu.TabIndex = 24;
            this.NumericNhapSoPhanTu.ValueChanged += new System.EventHandler(this.NumericNhapSoPhanTu_ValueChanged);
            // 
            // ButtonNhapNgauNhien
            // 
            this.ButtonNhapNgauNhien.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNhapNgauNhien.FlatAppearance.BorderSize = 0;
            this.ButtonNhapNgauNhien.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonNhapNgauNhien.ForeColor = System.Drawing.Color.Black;
            this.ButtonNhapNgauNhien.Location = new System.Drawing.Point(11, 78);
            this.ButtonNhapNgauNhien.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonNhapNgauNhien.Name = "ButtonNhapNgauNhien";
            this.ButtonNhapNgauNhien.Size = new System.Drawing.Size(138, 32);
            this.ButtonNhapNgauNhien.TabIndex = 4;
            this.ButtonNhapNgauNhien.Text = "Ngẫu nhiên";
            this.ButtonNhapNgauNhien.UseVisualStyleBackColor = false;
            this.ButtonNhapNgauNhien.Click += new System.EventHandler(this.NhapNgauNhien);
            // 
            // LabelNhapGiaTriMang
            // 
            this.LabelNhapGiaTriMang.AutoSize = true;
            this.LabelNhapGiaTriMang.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.LabelNhapGiaTriMang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LabelNhapGiaTriMang.Location = new System.Drawing.Point(7, 59);
            this.LabelNhapGiaTriMang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelNhapGiaTriMang.Name = "LabelNhapGiaTriMang";
            this.LabelNhapGiaTriMang.Size = new System.Drawing.Size(176, 19);
            this.LabelNhapGiaTriMang.TabIndex = 7;
            this.LabelNhapGiaTriMang.Text = "Tạo giá trị cho mảng:";
            this.LabelNhapGiaTriMang.Click += new System.EventHandler(this.Tai_v_LabelNhapGiaTriMang_Click);
            // 
            // ButtonNhapBangTay
            // 
            this.ButtonNhapBangTay.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ButtonNhapBangTay.FlatAppearance.BorderSize = 0;
            this.ButtonNhapBangTay.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.ButtonNhapBangTay.ForeColor = System.Drawing.Color.Black;
            this.ButtonNhapBangTay.Location = new System.Drawing.Point(155, 78);
            this.ButtonNhapBangTay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButtonNhapBangTay.Name = "ButtonNhapBangTay";
            this.ButtonNhapBangTay.Size = new System.Drawing.Size(138, 32);
            this.ButtonNhapBangTay.TabIndex = 5;
            this.ButtonNhapBangTay.Text = "Bằng tay";
            this.ButtonNhapBangTay.UseVisualStyleBackColor = false;
            this.ButtonNhapBangTay.Click += new System.EventHandler(this.NhapBangTay);
            // 
            // PanelMoPhong
            // 
            this.PanelMoPhong.Controls.Add(this.SortingPanelView);
            this.PanelMoPhong.Location = new System.Drawing.Point(243, 119);
            this.PanelMoPhong.Name = "PanelMoPhong";
            this.PanelMoPhong.Size = new System.Drawing.Size(1185, 422);
            this.PanelMoPhong.TabIndex = 22;
            this.PanelMoPhong.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMoPhong_Paint);
            // 
            // SortingPanelView
            // 
            this.SortingPanelView.Location = new System.Drawing.Point(2, 0);
            this.SortingPanelView.Name = "SortingPanelView";
            this.SortingPanelView.Size = new System.Drawing.Size(1187, 422);
            this.SortingPanelView.TabIndex = 2;
            this.SortingPanelView.Paint += new System.Windows.Forms.PaintEventHandler(this.SortingPanelView_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 763);
            this.Controls.Add(this.ThanhDieuKhien);
            this.Font = new System.Drawing.Font("SVN-Gilroy XBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 51);
            this.Name = "Form_main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Mô phỏng thuật toán";
            this.Load += new System.EventHandler(this.Form_Load);
            this.GroupBoxChuongTrinhCPP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelNen.ResumeLayout(false);
            this.GroupBoxCacBuocThucHien.ResumeLayout(false);
            this.ThanhDieuKhien.ResumeLayout(false);
            this.GroupBoxYTuong.ResumeLayout(false);
            this.GroupBoxChonThuatToan.ResumeLayout(false);
            this.GroupBoxChonThuatToan.PerformLayout();
            this.GroupBoxDieuKhien.ResumeLayout(false);
            this.GroupBoxDieuKhien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBar_ChinhTocDoThuatToan)).EndInit();
            this.GroupBoxKhoiTaoMang.ResumeLayout(false);
            this.GroupBoxKhoiTaoMang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericNhapSoPhanTu)).EndInit();
            this.PanelMoPhong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        #endregion
        private System.Windows.Forms.ListBox ListBoxYTuong;
        private System.Windows.Forms.ListBox ListBoxCodeC;
        private System.Windows.Forms.GroupBox GroupBoxChuongTrinhCPP;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonHuongDan;
        private System.Windows.Forms.Panel PanelNen;
        private System.Windows.Forms.Button ButtonTacGia;
        private System.Windows.Forms.ListBox ListBoxCacBuoc;
        private System.Windows.Forms.GroupBox GroupBoxCacBuocThucHien;
        private System.Windows.Forms.Panel ThanhDieuKhien;
        private System.Windows.Forms.ComboBox ComboBox_ChonThuatToan;
        private System.Windows.Forms.Label LabelChonThuatToan;
        private System.Windows.Forms.GroupBox GroupBoxYTuong;
        private System.Windows.Forms.Label LabelLoaiSapXep;
        private System.Windows.Forms.Label LabelTocDo;
        private System.Windows.Forms.Button ButtonNhapBangTay;
        private System.Windows.Forms.Label LabelNhapGiaTriMang;
        private System.Windows.Forms.RadioButton RadioButton_GiamDan;
        private System.Windows.Forms.RadioButton RadioButton_TangDan;
        private System.Windows.Forms.GroupBox GroupBoxChonThuatToan;
        private System.Windows.Forms.GroupBox GroupBoxDieuKhien;
        private System.Windows.Forms.Button ButtonKetThucThuatToan;
        private System.Windows.Forms.Button ButtonTamDungThuatToan;
        private System.Windows.Forms.Button ButtonChayThuatToan;
        private System.Windows.Forms.TrackBar TrackBar_ChinhTocDoThuatToan;
        private System.Windows.Forms.GroupBox GroupBoxKhoiTaoMang;
        private System.Windows.Forms.Panel PanelMoPhong;
        private System.Windows.Forms.Panel SortingPanelView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ButtonNhapNgauNhien;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label LabelSoPhanTu;
        private System.Windows.Forms.NumericUpDown NumericNhapSoPhanTu;
        private System.Windows.Forms.Label LabelKhoangGiaTriPhanTu;
    }
}
