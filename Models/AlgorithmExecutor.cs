using System;

namespace DoAnLTTQ_DongCodeThuN.ThuatToan
{
    //Chua cac thuat toan sap xep 
    public class Algorithm
    {
        public static void Swap(ref int a, ref int b)
        {
            (a, b) = (b, a);
        }

        #region BUBBLE SORT
        public static void BubbleSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (compareFunc(arr[j], arr[j + 1]))
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }
        #endregion

        #region QUICK SORT
        public static void QuickSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            QuickSort(arr, 0, arr.Length - 1, compareFunc);
        }

        public static void QuickSort(int[] arr, int left, int right, Func<int, int, bool> compareFunc)
        {
            if (left >= right) return;

            int pivotIndex = Partition(arr, left, right, compareFunc);

            QuickSort(arr, left, pivotIndex - 1, compareFunc);
            QuickSort(arr, pivotIndex + 1, right, compareFunc);
        }

        private static int Partition(int[] arr, int left, int right, Func<int, int, bool> compareFunc)
        {
            int pivot = arr[right];
            int low = left - 1;

            for (int i = left; i < right; i++)
            {
                if (!compareFunc(arr[i], pivot))
                {
                    low++;
                    Swap(ref arr[low], ref arr[i]);
                }
            }
            Swap(ref arr[low+1], ref arr[right]);
            return low + 1;
        }
        #endregion

        #region SELECTION SORT
        public static void SelectionSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!compareFunc(arr[j], arr[minIdx]))
                        minIdx = j;
                }
                if (minIdx != i)
                    Swap(ref arr[i], ref arr[minIdx]);
            }
        }        
        #endregion

        #region INTERCHANGE SORT
        public static void InterchangeSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (compareFunc(arr[i], arr[j]))
                        Swap(ref arr[i], ref arr[j]);
        }
        #endregion

        #region INSERTION SORT
        public static void InsertionSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && compareFunc(arr[j], key))
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        #region MERGE SORT
        private static void Merge(int[] left, int[] right, int[] array, Func<int, int, bool> compareFunc)
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (!compareFunc(left[i], right[j]))
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }

        public static void MergeSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            if (arr.Length <= 1)
                return;

            int middle = arr.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[arr.Length - middle];

            for (int i = 0; i < middle; i++)
                left[i] = arr[i];
            for (int i = middle; i < arr.Length; i++)
                right[i - middle] = arr[i];

            MergeSort(left, compareFunc);
            MergeSort(right, compareFunc);

            Merge(left, right, arr, compareFunc);
        }
        #endregion

        #region HEAP SORT
        public static void HeapSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(arr, n, i, compareFunc);

            for (int i = n - 1; i > 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, i, 0, compareFunc);
            }
        }

        private static void Heapify(int[] arr, int n, int i, Func<int, int, bool> compareFunc)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && compareFunc(arr[left], arr[largest]))
                largest = left;

            if (right < n && compareFunc(arr[right], arr[largest]))
                largest = right;

            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);
                Heapify(arr, n, largest, compareFunc);
            }
        }
        #endregion
    }
}
