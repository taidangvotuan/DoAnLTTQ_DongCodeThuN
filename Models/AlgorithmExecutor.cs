using DoAnLTTQ_DongCodeThuN.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        //public async static void BubbleSort(SortingVisualizationView view)
        //{
        //    List<int> arr = view.listInt;
        //    int n = arr.Count;

        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < n-1-i; j++)
        //        {
        //            await Task.Delay(view.delayTime);
        //            view.SetState(j, State.NOR);
        //            view.SetState(j+1, State.NOR);

        //            if (arr[j] > arr[j + 1])
        //            {
        //                await view.Swap(j, j + 1);                    
        //            }

        //            await Task.Delay(view.delayTime);
        //            view.SetState(j, State.NORMAL);
        //            view.SetState(j + 1, State.NORMAL);
        //        }
        //    }
        //}

        public static void BubbleSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            //List<int> arr = view.listInt;
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
        //public async static Task QuickSort(SortingVisualizationView view, int left, int right)
        //{
        //    if (left >= right) return;

        //    int pivotIndex = await Partition(view, left, right);

        //    await QuickSort(view, left, pivotIndex - 1);
        //    await QuickSort(view, pivotIndex + 1, right);
        //}

        //private async static Task<int> Partition(SortingVisualizationView view, int left, int right)
        //{
        //    List<int> arr = view.listInt;

        //    int pivot = arr[right];
        //    view.SetState(right, State.PIVOT);

        //    int low = left - 1;

        //    for (int i = left; i < right; i++)
        //    {
        //        view.SetState(i, State.NOR);
        //        await Task.Delay(view.delayTime);

        //        if (arr[i] < pivot)
        //        {
        //            low++;
        //            await view.Swap(i, low);
        //        }
        //        view.SetState(i, State.NORMAL);
        //    }

        //    await view.Swap(low + 1, right);
        //    view.SetState(right, State.NORMAL);

        //    return low + 1;
        //}
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
        //public async static void SelectionSort(SortingVisualizationView view)
        //{
        //    List<int> arr = view.listInt;
        //    int n = arr.Count;

        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        int minIdx = i;
        //        view.SetState(i, State.NOR);
        //        await Task.Delay(view.delayTime);

        //        for (int j = i + 1; j < n; j++)
        //        {
        //            view.SetState(j, State.NOR);
        //            await Task.Delay(view.delayTime);

        //            if (arr[j] < arr[minIdx])
        //            {
        //                if (minIdx != i)
        //                    view.SetState(minIdx, State.NORMAL);

        //                minIdx = j;
        //                view.SetState(minIdx, State.MIN);
        //            }
        //            else
        //                view.SetState(j, State.NORMAL);
        //        }

        //        if (minIdx != i)
        //            await view.Swap(i, minIdx);

        //        view.SetState(i, State.NORMAL);
        //        view.SetState(minIdx, State.NORMAL);
        //    }
        //}

        public static void SelectionSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (!compareFunc(arr[j], arr[minIdx]))
                    {
                        minIdx = j;
                    }
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
        //public async static void InsertionSort(SortingVisualizationView view)
        //{
        //    List<int> arr = view.listInt;
        //    int n = arr.Count;

        //    for (int i = 1; i < n; i++)
        //    {
        //        int j = i;

        //        // Đánh dấu phần tử đang xét
        //        view.SetState(i, State.NOR);
        //        await Task.Delay(view.delayTime);

        //        // Bắt đầu dịch sang trái
        //        while (j > 0 && arr[j] < arr[j - 1])
        //        {
        //            // Highlight 2 phần tử
        //            view.SetState(j, State.COMPARE);
        //            view.SetState(j - 1, State.COMPARE);
        //            await Task.Delay(view.delayTime);

        //            // Swap trực quan
        //            await view.Swap(j, j - 1);

        //            // Reset màu
        //            view.SetState(j, State.NORMAL);
        //            view.SetState(j - 1, State.NORMAL);

        //            j--;
        //        }

        //        // Reset chỉ số i sau khi xong
        //        view.SetState(i, State.NORMAL);
        //    }
        //}

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
        //public async static void MergeSort(SortingVisualizationView view)
        //{
        //    List<int> arr = view.listInt;
        //    await MergeSortRecursive(view, arr, 0, arr.Count - 1);
        //}

        //private static async Task MergeSortRecursive(SortingVisualizationView view, List<int> arr, int left, int right)
        //{
        //    if (left >= right)
        //        return;

        //    int mid = (left + right) / 2;

        //    // Chia nửa trái
        //    await MergeSortRecursive(view, arr, left, mid);

        //    // Chia nửa phải
        //    await MergeSortRecursive(view, arr, mid + 1, right);

        //    // Trộn lại
        //    await Merge(view, arr, left, mid, right);
        //}

        //private static async Task Merge(SortingVisualizationView view, List<int> arr, int left, int mid, int right)
        //{
        //    int i = left;
        //    int j = mid + 1;

        //    List<int> temp = new List<int>();

        //    // Highlight hai vùng đang merge
        //    for (int k = left; k <= right; k++)
        //    {
        //        view.SetState(k, State.NOR);
        //    }
        //    await Task.Delay(view.delayTime);

        //    // Merge bằng so sánh
        //    while (i <= mid && j <= right)
        //    {
        //        view.SetState(i, State.COMPARE);
        //        view.SetState(j, State.COMPARE);
        //        await Task.Delay(view.delayTime);

        //        if (arr[i] <= arr[j])
        //        {
        //            temp.Add(arr[i]);
        //            view.SetState(i, State.NORMAL);
        //            i++;
        //        }
        //        else
        //        {
        //            temp.Add(arr[j]);
        //            view.SetState(j, State.NORMAL);
        //            j++;
        //        }
        //    }

        //    // Thêm phần còn lại của nửa trái
        //    while (i <= mid)
        //    {
        //        temp.Add(arr[i]);
        //        i++;
        //    }

        //    // Thêm phần còn lại của nửa phải
        //    while (j <= right)
        //    {
        //        temp.Add(arr[j]);
        //        j++;
        //    }

        //    // Cập nhật vào arr + giao diện
        //    for (int k = 0; k < temp.Count; k++)
        //    {
        //        arr[left + k] = temp[k];
        //        view.SetValue(left + k, temp[k]);   // cập nhật trực quan
        //        await Task.Delay(view.delayTime);
        //    }

        //    // Reset trạng thái
        //    for (int k = left; k <= right; k++)
        //        view.SetState(k, State.NORMAL);
        //}
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
        //public async static void HeapSort(SortingVisualizationView view)
        //{
        //    List<int> arr = view.listInt;
        //    int n = arr.Count;

        //    // --- Xây dựng max-heap ---
        //    for (int i = n / 2 - 1; i >= 0; i--)
        //        await Heapify(view, arr, n, i);

        //    // --- Trích dần từng phần tử khỏi heap ---
        //    for (int i = n - 1; i > 0; i--)
        //    {
        //        // Highlight root và phần tử cuối
        //        view.SetState(0, State.COMPARE);
        //        view.SetState(i, State.COMPARE);
        //        await Task.Delay(view.delayTime);

        //        // Hoán đổi root với phần tử cuối
        //        await view.Swap(0, i);

        //        // Reset màu
        //        view.SetState(0, State.NORMAL);
        //        view.SetState(i, State.NORMAL);

        //        // Gọi heapify lên heap rút gọn
        //        await Heapify(view, arr, i, 0);
        //    }
        //}

        //private static async Task Heapify(SortingVisualizationView view, List<int> arr, int n, int i)
        //{
        //    int largest = i;
        //    int left = 2 * i + 1;
        //    int right = 2 * i + 2;

        //    // So sánh với con trái
        //    if (left < n && arr[left] > arr[largest])
        //        largest = left;

        //    // So sánh với con phải
        //    if (right < n && arr[right] > arr[largest])
        //        largest = right;

        //    // Nếu cần đổi chỗ
        //    if (largest != i)
        //    {
        //        // Highlight
        //        view.SetState(i, State.COMPARE);
        //        view.SetState(largest, State.COMPARE);
        //        await Task.Delay(view.delayTime);

        //        await view.Swap(i, largest);

        //        // Reset màu
        //        view.SetState(i, State.NORMAL);
        //        view.SetState(largest, State.NORMAL);

        //        // Đệ quy tiếp tục hiệu chỉnh
        //        await Heapify(view, arr, n, largest);
        //    }
        //}

        public static void HeapSort(int[] arr, Func<int, int, bool> compareFunc)
        {
            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i, compareFunc);
            }

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
            {
                largest = left;
            }

            if (right < n && compareFunc(arr[right], arr[largest]))
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);

                Heapify(arr, n, largest, compareFunc);
            }
        }
        #endregion
    }
}
