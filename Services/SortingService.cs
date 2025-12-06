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
                Thread.Sleep(50);
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
            state.Binh_i_AnimationStepMax = 15;
            state.Binh_b_DangAnimation = true;

            // Chạy animation
            for (int step = 0; step <= state.Binh_i_AnimationStepMax; step++)
            {
                if (!state.is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!state.is_run) return;

                Thinh_v_KiemTraTamDung();

                state.Binh_i_AnimationStep = step;
                view.RefreshSortingPanel();

                int speed = state.toc_Do; // 1-15
                if (speed < 1) speed = 1;
                if (speed > 15) speed = 15;

                // Level 1  -> 200ms (chậm nhất)
                // Level 8  -> 50ms  (trung bình)
                // Level 15 -> 1ms   (nhanh nhất - gần như tức thời)
                int delay;
                if (speed <= 0)
                    delay = 200;
                else if (speed >= 15)
                    delay = 1;
                else
                    delay = 200 - (speed * 13); // Giảm 13ms mỗi level

                Thread.Sleep(delay);
                Application.DoEvents();
            }

            // Kết thúc animation
            state.Binh_b_DangAnimation = false;

            // Hoán vị giá trị
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            view.RefreshSortingPanel();
            Thinh_v_GhiBuoc(arr);
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

            view.RefreshSortingPanel();

            int speed = state.toc_Do;
            if (speed < 1) speed = 1;
            if (speed > 10) speed = 10;

            Thread.Sleep(20 * (11 - speed));

            Thinh_v_GhiBuoc(arr);
        }

        public void Tai_v_MergeTangDan(int[] arr, int left, int mid, int right)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

            int iL = 0, iR = 0, k = left;

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
        }

        public void Tai_v_MergeGiamDan(int[] arr, int left, int mid, int right)
        {
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

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
        }

        public void Tai_v_MergeSortTangDan(int[] arr, int left, int right)
        {
            if (left == 0 && right == arr.Length - 1) Thinh_v_BatDauLog(arr);
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortTangDan(arr, left, mid);
                if (!state.is_run) return;
                Tai_v_MergeSortTangDan(arr, mid + 1, right);
                if (!state.is_run) return;
                Tai_v_MergeTangDan(arr, left, mid, right);
            }
        }

        public void Tai_v_MergeSortGiamDan(int[] arr, int left, int right)
        {
            if (left == 0 && right == arr.Length - 1) Thinh_v_BatDauLog(arr);
            if (!state.is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!state.is_run) return;

            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortGiamDan(arr, left, mid);
                if (!state.is_run) return;
                Tai_v_MergeSortGiamDan(arr, mid + 1, right);
                if (!state.is_run) return;
                Tai_v_MergeGiamDan(arr, left, mid, right);
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
