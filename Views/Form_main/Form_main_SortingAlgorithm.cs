using System;
using System.Threading;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main
    {
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

                Binh_i_AnimationStep = step;

                SortingPanelView.Invoke(new Action(() =>
                {
                    SortingPanelView.Refresh();
                }));

                Thread.Sleep(10 * (11 - toc_Do)); // tốc độ animation phụ thuộc TrackBar
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
                Tai_v_HeapifyTangDan(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
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
                Tai_v_HeapifyGiamDan(arr, n, i);

            for (int i = n - 1; i >= 0; i--)
            {
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
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        public void Binh_v_InsertionSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
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

                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIdx])
                        minIdx = j;

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

                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] > arr[maxIdx])
                        maxIdx = j;

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
                for (int j = 0; j < n - i - 1; j++)
                {
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
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (!is_run) return;

                    if (arr[j] < arr[j + 1])
                    Binh_v_HoanViTheoViTri(arr, j, j + 1);
                }
            }
        }
        #endregion

        #region Merge Sort
        public void Tai_v_MergeTangDan(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

            int iL = 0, iR = 0, k = left;

            while (iL < n1 && iR < n2)
                arr[k++] = (arrLeft[iL] <= arrRight[iR]) ? arrLeft[iL++] : arrRight[iR++];

            while (iL < n1) arr[k++] = arrLeft[iL++];
            while (iR < n2) arr[k++] = arrRight[iR++];
        }

        public void Tai_v_MergeGiamDan(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrLeft = new int[n1];
            int[] arrRight = new int[n2];

            for (int i = 0; i < n1; i++) arrLeft[i] = arr[left + i];
            for (int j = 0; j < n2; j++) arrRight[j] = arr[mid + 1 + j];

            int iL = 0, iR = 0, k = left;

            while (iL < n1 && iR < n2)
                arr[k++] = (arrLeft[iL] >= arrRight[iR]) ? arrLeft[iL++] : arrRight[iR++];

            while (iL < n1) arr[k++] = arrLeft[iL++];
            while (iR < n2) arr[k++] = arrRight[iR++];
        }

        public void Tai_v_MergeSortTangDan(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortTangDan(arr, left, mid);
                Tai_v_MergeSortTangDan(arr, mid + 1, right);
                Tai_v_MergeTangDan(arr, left, mid, right);
            }
        }

        public void Tai_v_MergeSortGiamDan(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                Tai_v_MergeSortGiamDan(arr, left, mid);
                Tai_v_MergeSortGiamDan(arr, mid + 1, right);
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
                for (int j = i + 1; j < n; j++)
                {
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
                for (int j = i + 1; j < n; j++)
                {
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

            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j && is_run)
            {
                while (i <= right && arr[i] < pivot) i++;
                while (j >= left && arr[j] > pivot) j--;
                if (i != j)
                    Binh_v_HoanViTheoViTri(arr, i, j);
                i++; j--;
            }

            if (!is_run) return;
            if (left < j) Thinh_v_QuickSortTangDan(arr, left, j);

            if (!is_run) return;
            if (i < right) Thinh_v_QuickSortTangDan(arr, i, right);
        }

        public void Thinh_v_QuickSortGiamDan(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j && is_run)
            {
                while (i <= right && arr[i] > pivot) i++;
                while (j >= left && arr[j] < pivot) j--;
                if (i != j)
                    Binh_v_HoanViTheoViTri(arr, i, j);
                i++; j--;
            }

            if (!is_run) return;
            if (left < j) Thinh_v_QuickSortGiamDan(arr, left, j);

            if (!is_run) return;
            if (i < right) Thinh_v_QuickSortGiamDan(arr, i, right);
        }
        #endregion
    }
}
