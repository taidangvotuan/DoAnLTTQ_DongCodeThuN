using System;
using System.Threading;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main
    {
        // Hàm dùng chung để xử lý tạm dừng / tiếp tục và nhận nút Kết thúc
        private void Binh_v_HandleTamDungVaKetThuc()
        {
            // Nếu đã yêu cầu dừng hẳn thì thôi
            if (!is_run) return;

            // Nếu đang tạm dừng thì giữ nguyên trạng thái, nhưng vẫn xử lý message để nút bấm hoạt động
            while (kt_tam_dung && is_run)
            {
                Application.DoEvents();
                Thread.Sleep(10);
            }

            // Dù có tạm dừng hay không, thi thoảng vẫn DoEvents để UI không bị đứng
            Application.DoEvents();
        }

        /*public void Tai_v_HoanVi(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }*/
        // Hàm hoán vị có hiệu ứng mô phỏng cột đang hoán vị (Bình)
        public void Binh_v_HoanViTheoViTri(int[] arr, int i, int j)
        {
            if (!is_run) return;

            // Ghi nhận 2 vị trí cần hoán đổi
            Binh_i_ViTriSwap1 = i;
            Binh_i_ViTriSwap2 = j;

            // Setup animation
            Binh_i_AnimationStep = 0;
            Binh_i_AnimationStepMax = 15;   // càng lớn animation càng mượt
            Binh_b_DangAnimation = true;

            // Chạy animation
            for (int step = 0; step <= Binh_i_AnimationStepMax; step++)
            {
                if (!is_run) return;

                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_i_AnimationStep = step;

                SortingPanelView.Invoke(new Action(() =>
                {
                    SortingPanelView.Refresh();
                }));

                // Tốc độ animation phụ thuộc TrackBar – luôn đọc speed mới nhất
                int speed = toc_Do;
                if (speed < 1) speed = 1;
                if (speed > 10) speed = 10;

                Thread.Sleep(10 * (11 - speed));
            }

            // Kết thúc animation
            Binh_b_DangAnimation = false;

            // --- Thực hiện hoán vị giá trị trong mảng ---
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            // Vẽ lại sau swap
            SortingPanelView.Invoke(new Action(() =>
            {
                SortingPanelView.Refresh();
            }));
        }

        #region Heap Sort
        public void Tai_v_HeapifyTangDan(int[] arr, int n, int i)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            int iLonNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = iTrai + 1;

            if (iTrai < n && arr[iTrai] > arr[iLonNhat])
                iLonNhat = iTrai;

            if (iPhai < n && arr[iPhai] > arr[iLonNhat])
                iLonNhat = iPhai;

            if (iLonNhat != i)
            {
                Binh_v_HoanViTheoViTri(arr, i, iLonNhat);
                if (!is_run) return;
                Tai_v_HeapifyTangDan(arr, n, iLonNhat);
            }
        }

        public void Tai_v_HeapifyGiamDan(int[] arr, int n, int i)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            int iNhoNhat = i;
            int iTrai = 2 * i + 1;
            int iPhai = iTrai + 2;

            if (iTrai < n && arr[iTrai] < arr[iNhoNhat])
                iNhoNhat = iTrai;

            if (iPhai < n && arr[iPhai] < arr[iNhoNhat])
                iNhoNhat = iPhai;

            if (iNhoNhat != i)
            {
                Binh_v_HoanViTheoViTri(arr, i, iNhoNhat);
                if (!is_run) return;
                Tai_v_HeapifyGiamDan(arr, n, iNhoNhat);
            }
        }

        public void Tai_v_HeapSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Tai_v_HeapifyTangDan(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_v_HoanViTheoViTri(arr, 0, i);

                if (!is_run) return;
                Tai_v_HeapifyTangDan(arr, i, 0);
            }
        }

        public void Tai_v_HeapSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Tai_v_HeapifyGiamDan(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_v_HoanViTheoViTri(arr, 0, i);

                if (!is_run) return;
                Tai_v_HeapifyGiamDan(arr, i, 0);
            }
        }
        #endregion

        #region Insertion Sort
        public void Binh_v_InsertionSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                int j = i;
                // Đẩy phần tử arr[i] dần về bên trái bằng các hoán vị kề nhau
                while (j > 0 && arr[j - 1] > arr[j])
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    Binh_v_HoanViTheoViTri(arr, j - 1, j); // có animation
                    j--;
                }
            }
        }

        public void Binh_v_InsertionSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                int j = i;
                while (j > 0 && arr[j - 1] < arr[j])
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    Binh_v_HoanViTheoViTri(arr, j - 1, j); // có animation
                    j--;
                }
            }
        }
        #endregion

        #region Selection Sort
        public void Binh_v_SelectionSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                if (minIdx != i)
                    Binh_v_HoanViTheoViTri(arr, minIdx, i);
            }
        }

        public void Binh_v_SelectionSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    if (arr[j] > arr[maxIdx])
                        maxIdx = j;
                }

                if (maxIdx != i)
                    Binh_v_HoanViTheoViTri(arr, maxIdx, i);
            }
        }
        #endregion

        #region Bubble Sort
        public void Thinh_v_BubbleSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    if (arr[j] > arr[j + 1])
                        Binh_v_HoanViTheoViTri(arr, j, j + 1);
                }
            }
        }

        public void Thinh_v_BubbleSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                for (int j = 0; j < n - i - 1; j++)
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    if (arr[j] < arr[j + 1])
                        Binh_v_HoanViTheoViTri(arr, j, j + 1);
                }
            }
        }
        #endregion

        #region Merge Sort
        // Hàm gán giá trị cho phần tử arr[index] kèm highlight + vẽ + delay (dùng cho Merge Sort)
        private void Binh_v_SetAndDrawMerge(int[] arr, int index, int value)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            // Gán giá trị mới vào mảng
            arr[index] = value;

            // Highlight cột đang ghi
            Binh_i_ViTriSwap1 = index;
            Binh_i_ViTriSwap2 = -1;
            Binh_b_DangAnimation = false; // không cần trượt ngang

            // Vẽ lại
            SortingPanelView.Invoke(new Action(() =>
            {
                SortingPanelView.Refresh();
            }));

            // Tạm dừng theo tốc độ TrackBar (tương tự các animation khác) – luôn đọc speed mới nhất
            int speed = toc_Do;
            if (speed < 1) speed = 1;
            if (speed > 10) speed = 10;

            Thread.Sleep(20 * (11 - speed));
        }

        public void Tai_v_MergeTangDan(int[] arr, int left, int mid, int right)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

            int iL = 0, iR = 0, k = left;

            while (iL < n1 && iR < n2)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

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
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrLeft[iL]);
                iL++;
                k++;
            }

            while (iR < n2)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrRight[iR]);
                iR++;
                k++;
            }
        }

        public void Tai_v_MergeGiamDan(int[] arr, int left, int mid, int right)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

            int iL = 0, iR = 0, k = left;

            while (iL < n1 && iR < n2)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

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
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrLeft[iL]);
                iL++;
                k++;
            }

            while (iR < n2)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                Binh_v_SetAndDrawMerge(arr, k, arrRight[iR]);
                iR++;
                k++;
            }
        }

        public void Tai_v_MergeSortTangDan(int[] arr, int left, int right)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortTangDan(arr, left, mid);
                if (!is_run) return;
                Tai_v_MergeSortTangDan(arr, mid + 1, right);
                if (!is_run) return;
                Tai_v_MergeTangDan(arr, left, mid, right);
            }
        }

        public void Tai_v_MergeSortGiamDan(int[] arr, int left, int right)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortGiamDan(arr, left, mid);
                if (!is_run) return;
                Tai_v_MergeSortGiamDan(arr, mid + 1, right);
                if (!is_run) return;
                Tai_v_MergeGiamDan(arr, left, mid, right);
            }
        }
        #endregion

        #region Interchange Sort
        public void Tai_v_InterchangeSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                for (int j = i + 1; j < n; j++)
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    if (arr[i] > arr[j])
                        Binh_v_HoanViTheoViTri(arr, i, j);
                }
            }
        }

        public void Tai_v_InterchangeSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                if (!is_run) return;
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                for (int j = i + 1; j < n; j++)
                {
                    if (!is_run) return;
                    Binh_v_HandleTamDungVaKetThuc();
                    if (!is_run) return;

                    if (arr[i] < arr[j])
                        Binh_v_HoanViTheoViTri(arr, i, j);
                }
            }
        }
        #endregion

        #region Quick Sort
        public void Thinh_v_QuickSortTangDan(int[] arr, int left, int right)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j && is_run)
            {
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                while (i <= right && arr[i] < pivot) i++;
                while (j >= left && arr[j] > pivot) j--;
                if (i <= j)
                {
                    if (i != j)
                        Binh_v_HoanViTheoViTri(arr, i, j);
                    i++; j--;
                }
            }

            if (!is_run) return;
            if (left < j) Thinh_v_QuickSortTangDan(arr, left, j);

            if (!is_run) return;
            if (i < right) Thinh_v_QuickSortTangDan(arr, i, right);
        }

        public void Thinh_v_QuickSortGiamDan(int[] arr, int left, int right)
        {
            if (!is_run) return;
            Binh_v_HandleTamDungVaKetThuc();
            if (!is_run) return;

            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j && is_run)
            {
                Binh_v_HandleTamDungVaKetThuc();
                if (!is_run) return;

                while (i <= right && arr[i] > pivot) i++;
                while (j >= left && arr[j] < pivot) j--;
                if (i <= j)
                {
                    if (i != j)
                        Binh_v_HoanViTheoViTri(arr, i, j);
                    i++; j--;
                }
            }

            if (!is_run) return;
            if (left < j) Thinh_v_QuickSortGiamDan(arr, left, j);

            if (!is_run) return;
            if (i < right) Thinh_v_QuickSortGiamDan(arr, i, right);
        }
        #endregion
    }
}
