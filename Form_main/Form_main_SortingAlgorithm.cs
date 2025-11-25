using System;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class Form_main
    {
        public void Tai_v_HoanVi(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
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
                Tai_v_HoanVi(ref arr[i], ref arr[iLonNhat]);
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
                Tai_v_HoanVi(ref arr[i], ref arr[iNhoNhat]);
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
                Tai_v_HoanVi(ref arr[0], ref arr[i]);
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
                Tai_v_HoanVi(ref arr[0], ref arr[i]);
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
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[minIdx])
                        minIdx = j;

                Tai_v_HoanVi(ref arr[minIdx], ref arr[i]);
            }
        }

        public void Binh_v_SelectionSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] > arr[maxIdx])
                        maxIdx = j;

                Tai_v_HoanVi(ref arr[maxIdx], ref arr[i]);
            }
        }
        #endregion

        #region Bubble Sort
        public void Thinh_v_BubbleSortTangDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                        Tai_v_HoanVi(ref arr[j], ref arr[j + 1]);
        }

        public void Thinh_v_BubbleSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] < arr[j + 1])
                        Tai_v_HoanVi(ref arr[j], ref arr[j + 1]);
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
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                        Tai_v_HoanVi(ref arr[i], ref arr[j]);
        }

        public void Tai_v_InterchangeSortGiamDan(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] < arr[j])
                        Tai_v_HoanVi(ref arr[i], ref arr[j]);
        }
        #endregion

        #region Quick Sort
        public void Thinh_v_QuickSortTangDan(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i] < pivot) i++;
                while (arr[j] > pivot) j--;
                if (i <= j)
                {
                    Tai_v_HoanVi(ref arr[i], ref arr[j]);
                    i++; j--;
                }
            }

            if (left < j) Thinh_v_QuickSortTangDan(arr, left, j);
            if (i < right) Thinh_v_QuickSortTangDan(arr, i, right);
        }

        public void Thinh_v_QuickSortGiamDan(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(left + right) / 2];

            while (i <= j)
            {
                while (arr[i] > pivot) i++;
                while (arr[j] < pivot) j--;
                if (i <= j)
                {
                    Tai_v_HoanVi(ref arr[i], ref arr[j]);
                    i++; j--;
                }
            }

            if (left < j) Thinh_v_QuickSortGiamDan(arr, left, j);
            if (i < right) Thinh_v_QuickSortGiamDan(arr, i, right);
        }
        #endregion
    }
}
