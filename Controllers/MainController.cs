using DoAnLTTQ_DongCodeThuN.Models;
using DoAnLTTQ_DongCodeThuN.Services;
using DoAnLTTQ_DongCodeThuN.Views.Interfaces;
using System;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN.Controllers
{
    public class MainController
    {
        private readonly IMainView view;
        private readonly SortingState state;
        private readonly SortingService sortingService;
        private readonly VisualizationService visualService;
        private readonly DataGeneratorService dataService;
        private readonly CodeThuatToan codeCPP;
        private readonly YTuongThuatToan ytuongCPP;

        public MainController(IMainView view)
        {
            this.view = view;
            this.state = new SortingState();
            this.visualService = new VisualizationService(state);
            this.sortingService = new SortingService(view, state, visualService);
            this.dataService = new DataGeneratorService();
            this.codeCPP = new CodeThuatToan();
            this.ytuongCPP = new YTuongThuatToan();

            // Subscribe to view events
            WireUpEvents();
        }

        // Cho phép truy cập state từ View (để vẽ)
        public SortingState State => state;
        public VisualizationService VisualService => visualService;

        #region WIRE UP EVENTS

        private void WireUpEvents()
        {
            view.NhapNgauNhienClicked += OnNhapNgauNhien;
            view.NhapBangTayClicked += OnNhapBangTay;
            view.ChayThuatToanClicked += OnChayThuatToan;
            view.TamDungThuatToanClicked += OnTamDungThuatToan;
            view.KetThucThuatToanClicked += OnKetThucThuatToan;
            view.ThuatToanChanged += OnThuatToanChanged;
            view.TocDoChanged += OnTocDoChanged;
            view.KieuSapXepChanged += OnKieuSapXepChanged;
        }

        #endregion

        #region EVENT HANDLERS

        private void OnNhapNgauNhien(object sender, EventArgs e)
        {
            try
            {
                int soPhanTu = view.SoPhanTu;

                if (soPhanTu < 2 || soPhanTu > 20)
                {
                    view.HienThiThongBao("Số phần tử phải từ 2 đến 20!", "Lỗi",
                        MessageBoxIcon.Warning);
                    return;
                }

                state.so_phan_tu = soPhanTu;
                state.a = dataService.GenerateRandomArray(soPhanTu);
                state.da_Tao_Mang = true;

                view.MangA = state.a;
                view.VeLaiSortingPanel();
                view.MoCacNutLuaChonThuatToan();
            }
            catch (Exception ex)
            {
                view.HienThiThongBao(ex.Message, "Lỗi", MessageBoxIcon.Error);
            }
        }

        private void OnNhapBangTay(object sender, EventArgs e)
        {
            int soPhanTu = view.SoPhanTu;

            if (soPhanTu < 2 || soPhanTu > 20)
            {
                view.HienThiThongBao("Số phần tử phải từ 2 đến 20!", "Lỗi",
                    MessageBoxIcon.Warning);
                return;
            }

            state.so_phan_tu = soPhanTu;

            // FormNhapMang sẽ tự cập nhật Form_main.a
            // Sau khi FormNhapMang đóng, View sẽ gọi VeLaiSortingPanel
        }

        private void OnChayThuatToan(object sender, EventArgs e)
        {
            if (state.a == null || state.a.Length == 0)
            {
                view.HienThiThongBao("Bạn chưa khởi tạo mảng!", "Thông báo",
                    MessageBoxIcon.Warning);
                return;
            }

            string thuatToan = view.ThuatToanDaChon;
            if (string.IsNullOrEmpty(thuatToan))
            {
                view.HienThiThongBao("Bạn chưa chọn thuật toán!", "Thông báo",
                    MessageBoxIcon.Warning);
                return;
            }

            if (!view.TangDan && !view.TangDan) // Kiểm tra có chọn kiểu sắp xếp
            {
                view.HienThiThongBao("Bạn chưa chọn kiểu sắp xếp!", "Thông báo",
                    MessageBoxIcon.Warning);
                return;
            }

            // Cập nhật state
            state.is_run = true;
            state.kt_tam_dung = false;
            state.tang = view.TangDan;
            state.toc_Do = view.TocDo;
            visualService.ResetHighlight();

            view.KhoiChay();

            // Chạy thuật toán
            RunSelectedAlgorithm(thuatToan, state.tang);

            // Kết thúc
            state.Reset();
            view.KhoaChay();
            view.VeLaiSortingPanel();
        }

        private void OnTamDungThuatToan(object sender, EventArgs e)
        {
            if (!state.is_run) return;
            state.kt_tam_dung = !state.kt_tam_dung;
        }

        private void OnKetThucThuatToan(object sender, EventArgs e)
        {
            if (!state.is_run) return;

            state.is_run = false;
            state.kt_tam_dung = false;
            visualService.ResetHighlight();

            // Sắp xếp nhanh để ra kết quả
            if (state.a != null && state.a.Length > 0)
            {
                if (state.tang)
                    Array.Sort(state.a);
                else
                {
                    Array.Sort(state.a);
                    Array.Reverse(state.a);
                }
            }

            view.VeLaiSortingPanel();
            view.KhoaChay();
        }

        private void OnThuatToanChanged(object sender, EventArgs e)
        {
            UpdateCodeAndIdea();
        }

        private void OnTocDoChanged(object sender, EventArgs e)
        {
            state.toc_Do = view.TocDo;
        }

        private void OnKieuSapXepChanged(object sender, EventArgs e)
        {
            state.tang = view.TangDan;
            UpdateCodeAndIdea();
        }

        #endregion

        #region PRIVATE METHODS

        private void RunSelectedAlgorithm(string tenThuatToan, bool tang)
        {
            switch (tenThuatToan)
            {
                case "Bubble Sort":
                    if (tang) sortingService.Thinh_v_BubbleSortTangDan(state.a);
                    else sortingService.Thinh_v_BubbleSortGiamDan(state.a);
                    break;

                case "Selection Sort":
                    if (tang) sortingService.Binh_v_SelectionSortTangDan(state.a);
                    else sortingService.Binh_v_SelectionSortGiamDan(state.a);
                    break;

                case "Insertion Sort":
                    if (tang) sortingService.Binh_v_InsertionSortTangDan(state.a);
                    else sortingService.Binh_v_InsertionSortGiamDan(state.a);
                    break;

                case "Heap Sort":
                    if (tang) sortingService.Tai_v_HeapSortTangDan(state.a);
                    else sortingService.Tai_v_HeapSortGiamDan(state.a);
                    break;

                case "Interchange Sort":
                    if (tang) sortingService.Tai_v_InterchangeSortTangDan(state.a);
                    else sortingService.Tai_v_InterchangeSortGiamDan(state.a);
                    break;

                case "Merge Sort":
                    if (tang) sortingService.Tai_v_MergeSortTangDan(state.a, 0, state.a.Length - 1);
                    else sortingService.Tai_v_MergeSortGiamDan(state.a, 0, state.a.Length - 1);
                    break;

                case "Quick Sort":
                    if (tang) sortingService.Thinh_v_QuickSortTangDan(state.a, 0, state.a.Length - 1);
                    else sortingService.Thinh_v_QuickSortGiamDan(state.a, 0, state.a.Length - 1);
                    break;
            }
        }

        private void UpdateCodeAndIdea()
        {
            string thuatToan = view.ThuatToanDaChon;
            if (string.IsNullOrEmpty(thuatToan)) return;

            bool tang = view.TangDan;

            // Tạo ListBox tạm để lấy items
            ListBox tempCode = new ListBox();
            ListBox tempIdea = new ListBox();

            switch (thuatToan)
            {
                case "Bubble Sort":
                    codeCPP.BubbleSort(tempCode, tang);
                    ytuongCPP.BubbleSort(tempIdea);
                    break;
                case "Selection Sort":
                    codeCPP.SelectionSort(tempCode, tang);
                    ytuongCPP.SelectionSort(tempIdea);
                    break;
                case "Insertion Sort":
                    codeCPP.InsertionSort(tempCode, tang);
                    ytuongCPP.InsertionSort(tempIdea);
                    break;
                case "Heap Sort":
                    codeCPP.HeapSort(tempCode, tang);
                    ytuongCPP.HeapSort(tempIdea);
                    break;
                case "Interchange Sort":
                    codeCPP.InterchangeSort(tempCode, tang);
                    ytuongCPP.InterchangeSort(tempIdea);
                    break;
                case "Merge Sort":
                    codeCPP.MergeSort(tempCode, tang);
                    ytuongCPP.MergeSort(tempIdea);
                    break;
                case "Quick Sort":
                    codeCPP.QuickSort(tempCode, tang);
                    ytuongCPP.QuickSort(tempIdea);
                    break;
            }

            // Convert ListBox items to string array
            string[] codeItems = new string[tempCode.Items.Count];
            string[] ideaItems = new string[tempIdea.Items.Count];

            for (int i = 0; i < tempCode.Items.Count; i++)
                codeItems[i] = tempCode.Items[i].ToString();

            for (int i = 0; i < tempIdea.Items.Count; i++)
                ideaItems[i] = tempIdea.Items[i].ToString();

            view.HienThiListBoxCode(codeItems);
            view.HienThiListBoxYTuong(ideaItems);
        }
        #endregion
    }
}