using DoAnLTTQ_DongCodeThuN.Models;
using DoAnLTTQ_DongCodeThuN.Views.Interfaces;
using System.Threading;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN.Services
{
    public class SortingService
    {
        private readonly IMainView view;
        private readonly SortingState state;
        private readonly VisualizationService visualService;

        // Class helper để lưu trạng thái trước merge
        private class MergeState
        {
            public int[] ArrayBefore { get; set; }
            public int Left { get; set; }
            public int Right { get; set; }
        }

        public SortingService(IMainView view, SortingState state, VisualizationService visualService)
        {
            this.view = view;
            this.state = state;
            this.visualService = visualService;
        }

        #region HÀM DÙNG CHUNG
        // Hàm kiểm tra tạm dừng
        public void Thinh_v_KiemTraTamDung()
        {
            while (state.kt_tam_dung && state.is_run)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }
        }

        // Hàm reset và in log ban đầu
        public void Thinh_v_BatDauLog(int[] arr)
        {
            state.Thinh_dem_buoc = 0;
            view.XoaListBoxCacBuoc();
            string chuoiMang = string.Join("  ", arr);
            view.ThemBuocVaoListBox($"Dãy chưa sắp : {chuoiMang}");
        }

        // Ghi bước với màu sắc cho vị trí hoán vị
        public void Thinh_v_GhiBuocCoMau(int[] arr, int viTri1, int viTri2)
        {
            state.Thinh_dem_buoc++;
            string chuoiMang = string.Join("  ", arr);
            string noiDung = $"Bước {state.Thinh_dem_buoc} : {chuoiMang}";
            view.ThemBuocVaoListBoxCoMau(noiDung, viTri1, viTri2);
            Application.DoEvents();
        }

        // Hàm ghi lại các bước hoán vị
        public void Thinh_v_GhiBuoc(int[] arr)
        {
            state.Thinh_dem_buoc++;
            string chuoiMang = string.Join("  ", arr);
            string noiDung = $"Bước {state.Thinh_dem_buoc} : {chuoiMang}";
            view.ThemBuocVaoListBox(noiDung);
            Application.DoEvents();
        }

        // Hàm xử lý tạm dừng và kết thúc
        private void Binh_v_HandleTamDungVaKetThuc()
        {
            if (!state.is_run) return;

            while (state.kt_tam_dung && state.is_run)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }
            Application.DoEvents();
        }

        // Hàm hoán vị có animation
        public void Binh_v_HoanViTheoViTri(int[] arr, int i, int j)
        {
            if (!state.is_run) return;

            // Ghi nhận 2 vị trí hoán đổi
            state.Binh_i_ViTriSwap1 = i;
            state.Binh_i_ViTriSwap2 = j;

            // Setup animation
            state.Binh_i_AnimationStep = 0;
            state.Binh_i_AnimationStepMax = 750; // 750ms / swap
            state.Binh_b_DangAnimation = true;

            // Chạy animation
            for (int step = 0; step <= state.Binh_i_AnimationStepMax; )
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                Thinh_v_KiemTraTamDung();

                int speed = state.toc_Do; // 1-15
                if (speed < 1) speed = 1;
                if (speed > 15) speed = 15;

                step += 10 * speed;

                state.Binh_i_AnimationStep = step;
                view.RefreshSortingPanel();
                Thread.Sleep(10);
                Application.DoEvents();
            }

            // Kết thúc animation
            state.Binh_b_DangAnimation = false;

            // Hoán vị giá trị
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            view.RefreshSortingPanel();
            Thinh_v_GhiBuocCoMau(arr, i, j);
        }
        #endregion

        #region BUBBLE SORT
        public void Thinh_v_BubbleSortTangDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;
                    Thinh_v_KiemTraTamDung();

                    if (arr[j] > arr[j + 1])
                        Binh_v_HoanViTheoViTri(arr, j, j + 1);
                }
            }
        }

        public void Thinh_v_BubbleSortGiamDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;
                    Thinh_v_KiemTraTamDung();

                    if (arr[j] < arr[j + 1])
                        Binh_v_HoanViTheoViTri(arr, j, j + 1);
                }
            }
        }
        #endregion

        #region SELECTION SORT
        public void Binh_v_SelectionSortTangDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;
                    Thinh_v_KiemTraTamDung();

                    if (arr[j] < arr[minIdx]) minIdx = j;  
                }

                if (minIdx != i)
                    Binh_v_HoanViTheoViTri(arr, minIdx, i);
            }
        }

        public void Binh_v_SelectionSortGiamDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;
                    Thinh_v_KiemTraTamDung();

                    if (arr[j] > arr[maxIdx]) maxIdx = j;
                }

                if (maxIdx != i)
                    Binh_v_HoanViTheoViTri(arr, maxIdx, i);
            }
        }
        #endregion

        #region INSERTION SORT
        public void Binh_v_InsertionSortTangDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                int j = i;
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;

                    Binh_v_HoanViTheoViTri(arr, j - 1, j);
                    j--;
                }
            }
        }

        public void Binh_v_InsertionSortGiamDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                int j = i;
                while (j > 0 && arr[j - 1] < arr[j])
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;

                    Binh_v_HoanViTheoViTri(arr, j - 1, j);
                    j--;
                }
            }
        }
        #endregion

        #region HEAP SORT
        public void Tai_v_HeapifyTangDan(int[] arr, int n, int i)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;
            Thinh_v_KiemTraTamDung();

            int iLonNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = iTrai + 1;

            if (iTrai < n && arr[iTrai] > arr[iLonNhat]) iLonNhat = iTrai;
            if (iPhai < n && arr[iPhai] > arr[iLonNhat]) iLonNhat = iPhai;

            if (iLonNhat != i)
            {
                Binh_v_HoanViTheoViTri(arr, i, iLonNhat);
                if (!state.is_run) return;
                Tai_v_HeapifyTangDan(arr, n, iLonNhat);
            }
        }

        public void Tai_v_HeapifyGiamDan(int[] arr, int n, int i)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;
            Thinh_v_KiemTraTamDung();

            int iNhoNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = iTrai + 1;

            if (iTrai < n && arr[iTrai] < arr[iNhoNhat]) iNhoNhat = iTrai;
            if (iPhai < n && arr[iPhai] < arr[iNhoNhat]) iNhoNhat = iPhai;

            if (iNhoNhat != i)
            {
                Binh_v_HoanViTheoViTri(arr, i, iNhoNhat);
                if (!state.is_run) return;
                Tai_v_HeapifyGiamDan(arr, n, iNhoNhat);
            }
        }

        public void Tai_v_HeapSortTangDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                Tai_v_HeapifyTangDan(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                Binh_v_HoanViTheoViTri(arr, 0, i);

                if (!state.is_run) return;
                Tai_v_HeapifyTangDan(arr, i, 0);
            }
        }

        public void Tai_v_HeapSortGiamDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                Tai_v_HeapifyGiamDan(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                Binh_v_HoanViTheoViTri(arr, 0, i);

                if (!state.is_run) return;
                Tai_v_HeapifyGiamDan(arr, i, 0);
            }
        }
        #endregion

        #region INTERCHANGE SORT
        public void Tai_v_InterchangeSortTangDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                for (int j = i + 1; j < n; j++)
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;
                    Thinh_v_KiemTraTamDung();

                    if (arr[i] > arr[j])
                        Binh_v_HoanViTheoViTri(arr, i, j);
                }
            }
        }

        public void Tai_v_InterchangeSortGiamDan(int[] arr)
        {
            Thinh_v_BatDauLog(arr);
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                for (int j = i + 1; j < n; j++)
                {
                    if (!state.is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!state.is_run) return;
                    Thinh_v_KiemTraTamDung();

                    if (arr[i] < arr[j])
                        Binh_v_HoanViTheoViTri(arr, i, j);
                }
            }
        }
        #endregion

        #region MERGE SORT
        // Hàm gán giá trị cho phần tử - GIỮ NGUYÊN TÊN
        private void Binh_v_SetAndDrawMerge(int[] arr, int index, int value)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            arr[index] = value;

            state.Binh_i_ViTriSwap1 = index;
            state.Binh_i_ViTriSwap2 = -1;
            state.Binh_b_DangAnimation = false;

            // Màu xanh lá - đang merge (gán giá trị)
            state.Binh_i_AnimationStep = 1;

            view.RefreshSortingPanel();

            int speed = state.toc_Do;
            if (speed < 1) speed = 1;
            if (speed > 10) speed = 10;

            Thread.Sleep(50 * (11 - speed));
        }

        // Log với màu và thông tin chi tiết
        private void LogMergeStep(int[] arrayBefore, int[] arrayAfter, int left, int right)
        {
            if (!state.is_run) return;

            var changedInfo = new System.Collections.Generic.List<int>();

            for (int i = left; i <= right; i++)
                if (arrayBefore[i] != arrayAfter[i])
                    changedInfo.Add(i);

            if (changedInfo.Count > 0)
            {
                state.Thinh_dem_buoc++;
                string chuoiMang = string.Join("  ", arrayAfter);
                string noiDung = $"Bước {state.Thinh_dem_buoc} - KẾT QUẢ [{left}..{right}]: {chuoiMang}";

                // Truyền thêm left, right
                view.ThemBuocVaoListBoxCoNhieuMau(noiDung, changedInfo.ToArray(), left, right);
            }
            else
            {
                state.Thinh_dem_buoc++;
                string chuoiMang = string.Join("  ", arrayAfter);
                view.ThemBuocVaoListBox($"Bước {state.Thinh_dem_buoc} - [{left}..{right}]: {chuoiMang} (không đổi)");
            }
        }

        public void Tai_v_MergeTangDan(int[] arr, int left, int mid, int right)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            // Lưu trạng thái mảng trước khi merge
            int[] arrayBefore = new int[arr.Length];
            System.Array.Copy(arr, arrayBefore, arr.Length);

            view.ThemBuocVaoListBox($"Trộn [{left}..{mid}] và [{mid + 1}..{right}]");

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

            // Highlight vùng đang merge với màu cam
            for (int i = left; i <= right; i++)
            {
                state.Binh_i_ViTriSwap1 = i;
                state.Binh_i_AnimationStep = 0; // Màu cam - chuẩn bị
                view.RefreshSortingPanel();
            }
            Thread.Sleep(300); // Dừng lại để quan sát

            int iL = 0, iR = 0, k = left;

            // Trộn hai mảng
            while (iL < n1 && iR < n2)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                if (arrLeft[iL] <= arrRight[iR])
                {
                    Binh_v_SetAndDrawMerge(arr, k, arrLeft[iL]);
                    iL++;
                }
                else
                {
                    Binh_v_SetAndDrawMerge(arr, k, arrRight[iR]);
                    iR++;
                }
                k++;
            }

            // Copy phần còn lại
            while (iL < n1)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrLeft[iL]);
                iL++;
                k++;
            }

            while (iR < n2)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrRight[iR]);
                iR++;
                k++;
            }
            // Log kết quả với highlight các vị trí đã merge
            LogMergeStep(arrayBefore, arr, left, right);

            // Highlight vùng đã merge xong với màu xanh lá
            for (int i = left; i <= right; i++)
            {
                state.Binh_i_ViTriSwap1 = i;
                state.Binh_i_AnimationStep = 1; // Màu xanh lá - hoàn thành
                view.RefreshSortingPanel();
            }
            Thread.Sleep(400); // Dừng lại để quan sát
        }

        public void Tai_v_MergeGiamDan(int[] arr, int left, int mid, int right)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            // Lưu trạng thái mảng trước khi merge
            int[] arrayBefore = new int[arr.Length];
            System.Array.Copy(arr, arrayBefore, arr.Length);

            // Log bắt đầu merge
            view.ThemBuocVaoListBox($"Trộn [{left}..{mid}] và [{mid + 1}..{right}]");

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];
            
            // Highlight vùng đang merge với màu cam
            for (int i = left; i <= right; i++)
            {
                state.Binh_i_ViTriSwap1 = i;
                state.Binh_i_AnimationStep = 0; // Màu cam - chuẩn bị
                view.RefreshSortingPanel();
            }
            Thread.Sleep(300); // Dừng lại để quan sát

            int iL = 0, iR = 0, k = left;

            while (iL < n1 && iR < n2)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                if (arrLeft[iL] >= arrRight[iR])
                {
                    Binh_v_SetAndDrawMerge(arr, k, arrLeft[iL]);
                    iL++;
                }
                else
                {
                    Binh_v_SetAndDrawMerge(arr, k, arrRight[iR]);
                    iR++;
                }
                k++;
            }

            while (iL < n1)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrLeft[iL]);
                iL++;
                k++;
            }

            while (iR < n2)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrRight[iR]);
                iR++;
                k++;
            }

            // Log kết quả
            LogMergeStep(arrayBefore, arr, left, right);

            // Highlight vùng đã merge xong với màu xanh lá
            for (int i = left; i <= right; i++)
            {
                state.Binh_i_ViTriSwap1 = i;
                state.Binh_i_AnimationStep = 1; // Màu xanh lá - hoàn thành
                view.RefreshSortingPanel();
            }
            Thread.Sleep(400); // Dừng lại để quan sát
        }

        public void Tai_v_MergeSortTangDan(int[] arr, int left, int right)
        {
            if (left == 0 && right == arr.Length - 1)
            {
                Thinh_v_BatDauLog(arr);
                view.ThemBuocVaoListBox("------------------------");
                view.ThemBuocVaoListBox("BẮT ĐẦU MERGE SORT");
                view.ThemBuocVaoListBox("------------------------");
            }
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            if (left < right)
            {
                int mid = (left + right) / 2;
                // Log chia mảng
                view.ThemBuocVaoListBox($"CHIA: [{left}..{right}] → [{left}..{mid}] và [{mid + 1}..{right}]");

                // Highlight vùng đang chia với màu vàng
                for (int i = left; i <= right; i++)
                {
                    state.Binh_i_ViTriSwap1 = i;
                    state.Binh_i_AnimationStep = 2; // Màu vàng - đang chia
                    view.RefreshSortingPanel();
                }
                Thread.Sleep(350);

                // Đệ quy chia mảng
                Tai_v_MergeSortTangDan(arr, left, mid);
                if (!state.is_run) return;
                Tai_v_MergeSortTangDan(arr, mid + 1, right);
                if (!state.is_run) return;

                // Trộn mảng
                Tai_v_MergeTangDan(arr, left, mid, right);
            }
            if (left == 0 && right == arr.Length - 1)
            {
                view.ThemBuocVaoListBox("------------------------");
                view.ThemBuocVaoListBox("HOÀN THÀNH MERGE SORT!");
                view.ThemBuocVaoListBox("------------------------");
            }
        }

        public void Tai_v_MergeSortGiamDan(int[] arr, int left, int right)
        {
            if (left == 0 && right == arr.Length - 1)
            {
                Thinh_v_BatDauLog(arr);
                view.ThemBuocVaoListBox("------------------------");
                view.ThemBuocVaoListBox("BẮT ĐẦU MERGE SORT");
                view.ThemBuocVaoListBox("------------------------");
            }
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            if (left < right)
            {
                int mid = (left + right) / 2;
                // Log chia mảng
                view.ThemBuocVaoListBox($"CHIA: [{left}..{right}] → [{left}..{mid}] và [{mid + 1}..{right}]");

                // Highlight vùng đang chia với màu vàng
                for (int i = left; i <= right; i++)
                {
                    state.Binh_i_ViTriSwap1 = i;
                    state.Binh_i_AnimationStep = 2; // Màu vàng - đang chia
                    view.RefreshSortingPanel();
                }
                Thread.Sleep(400);

                Tai_v_MergeSortGiamDan(arr, left, mid);
                if (!state.is_run) return;
                Tai_v_MergeSortGiamDan(arr, mid + 1, right);
                if (!state.is_run) return;
                Tai_v_MergeGiamDan(arr, left, mid, right);
            }
            if (left == 0 && right == arr.Length - 1)
            {
                view.ThemBuocVaoListBox("------------------------");
                view.ThemBuocVaoListBox("HOÀN THÀNH MERGE SORT!");
                view.ThemBuocVaoListBox("------------------------");
            }
        }
        #endregion

        #region QUICK SORT
        public void Thinh_v_QuickSortTangDan(int[] arr, int left, int right)
        {
            if (left == 0 && right == arr.Length - 1) Thinh_v_BatDauLog(arr);

            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;
            Thinh_v_KiemTraTamDung();

            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j && state.is_run)
            {
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                while (i <= right && arr[i] < pivot) i++;
                while (j >= left && arr[j] > pivot) j--;
                if (i <= j)
                {
                    if (i != j)
                        Binh_v_HoanViTheoViTri(arr, i, j);
                    i++; j--;
                }
            }

            if (!state.is_run) return;
            if (left < j) Thinh_v_QuickSortTangDan(arr, left, j);

            if (!state.is_run) return;
            if (i < right) Thinh_v_QuickSortTangDan(arr, i, right);
        }

        public void Thinh_v_QuickSortGiamDan(int[] arr, int left, int right)
        {
            if (left == 0 && right == arr.Length - 1) Thinh_v_BatDauLog(arr);

            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;
            Thinh_v_KiemTraTamDung();

            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j && state.is_run)
            {
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;
                Thinh_v_KiemTraTamDung();

                while (i <= right && arr[i] > pivot) i++;
                while (j >= left && arr[j] < pivot) j--;
                if (i <= j)
                {
                    if (i != j)
                        Binh_v_HoanViTheoViTri(arr, i, j);
                    i++; j--;
                }
            }

            if (!state.is_run) return;
            if (left < j) Thinh_v_QuickSortGiamDan(arr, left, j);

            if (!state.is_run) return;
            if (i < right) Thinh_v_QuickSortGiamDan(arr, i, right);
        }
        #endregion
    }
}
