using DoAnLTTQ_DongCodeThuN.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTTQ_DongCodeThuN.ThuatToan
{
    //Chua cac thuat toan sap xep 
    public class AlgorithmExecutor
    {
        #region BUBBLE SORT
        public async static void BubbleSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            int n = arr.Count;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-1-i; j++)
                {
                    await Task.Delay(500);
                    view.SetState(j, State.NOR);
                    view.SetState(j+1, State.NOR);

                    if (arr[j] > arr[j + 1])
                    {
                        await view.Swap(j, j + 1);                    
                    }

                    await Task.Delay(500);
                    view.SetState(j, State.NORMAL);
                    view.SetState(j + 1, State.NORMAL);
                }
            }
        }
        #endregion

        #region QUICK SORT
        public async static Task QuickSort(SortingVisualizationView view, int left, int right)
        {
            if (left >= right) return;

            int pivotIndex = await Partition(view, left, right);

            await QuickSort(view, left, pivotIndex - 1);
            await QuickSort(view, pivotIndex + 1, right);
        }

        private async static Task<int> Partition(SortingVisualizationView view, int left, int right)
        {
            List<int> arr = view.listInt;

            int pivot = arr[right];
            view.SetState(right, State.PIVOT);

            int low = left - 1;

            for (int i = left; i < right; i++)
            {
                view.SetState(i, State.NOR);
                await Task.Delay(500);

                if (arr[i] < pivot)
                {
                    low++;
                    await view.Swap(i, low);
                }
                view.SetState(i, State.NORMAL);
            }

            await view.Swap(low + 1, right);
            view.SetState(right, State.NORMAL);

            return low + 1;
        }
        #endregion

        #region SELECTION SORT
        public async static void SelectionSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            int n = arr.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                view.SetState(i, State.NOR);
                await Task.Delay(300);

                for (int j = i + 1; j < n; j++)
                {
                    view.SetState(j, State.NOR);
                    await Task.Delay(300);

                    if (arr[j] < arr[minIdx])
                    {
                        if (minIdx != i)
                            view.SetState(minIdx, State.NORMAL);

                        minIdx = j;
                        view.SetState(minIdx, State.MIN);
                    }
                    else
                        view.SetState(j, State.NORMAL);
                }

                if (minIdx != i)
                    await view.Swap(i, minIdx);

                view.SetState(i, State.NORMAL);
                view.SetState(minIdx, State.NORMAL);
            }
        }
        #endregion

        #region INTERCHANGE SORT
        public async static void InterchangeSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            int n = arr.Count;

            for (int i = 0; i < n - 1; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] > arr[j])
                        await view.SetState(arr, i, j);
        }
        #endregion

        // Con nhung thuat toan con lai thi co gang viet thuat toan mo phong sap xep
        #region INSERTION SORT
        public async static void InsertionSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            int n = arr.Count;

            for (int i = 1; i < n; i++)
            {
                int j = i;

                // Đánh dấu phần tử đang xét
                view.SetState(i, State.NOR);
                await Task.Delay(view.delayTime);

                // Bắt đầu dịch sang trái
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    // Highlight 2 phần tử
                    view.SetState(j, State.COMPARE);
                    view.SetState(j - 1, State.COMPARE);
                    await Task.Delay(view.delayTime);

                    // Swap trực quan
                    await view.Swap(j, j - 1);

                    // Reset màu
                    view.SetState(j, State.NORMAL);
                    view.SetState(j - 1, State.NORMAL);

                    j--;
                }

                // Reset chỉ số i sau khi xong
                view.SetState(i, State.NORMAL);
            }
        }
        #endregion

        #region MERGE SORT
        public async static void MergeSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            await MergeSortRecursive(view, arr, 0, arr.Count - 1);
        }

        private static async Task MergeSortRecursive(SortingVisualizationView view, List<int> arr, int left, int right)
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            // Chia nửa trái
            await MergeSortRecursive(view, arr, left, mid);

            // Chia nửa phải
            await MergeSortRecursive(view, arr, mid + 1, right);

            // Trộn lại
            await Merge(view, arr, left, mid, right);
        }

        private static async Task Merge(SortingVisualizationView view, List<int> arr, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;

            List<int> temp = new List<int>();

            // Highlight hai vùng đang merge
            for (int k = left; k <= right; k++)
            {
                view.SetState(k, State.NOR);
            }
            await Task.Delay(view.delayTime);

            // Merge bằng so sánh
            while (i <= mid && j <= right)
            {
                view.SetState(i, State.COMPARE);
                view.SetState(j, State.COMPARE);
                await Task.Delay(view.delayTime);

                if (arr[i] <= arr[j])
                {
                    temp.Add(arr[i]);
                    view.SetState(i, State.NORMAL);
                    i++;
                }
                else
                {
                    temp.Add(arr[j]);
                    view.SetState(j, State.NORMAL);
                    j++;
                }
            }

            // Thêm phần còn lại của nửa trái
            while (i <= mid)
            {
                temp.Add(arr[i]);
                i++;
            }

            // Thêm phần còn lại của nửa phải
            while (j <= right)
            {
                temp.Add(arr[j]);
                j++;
            }

            // Cập nhật vào arr + giao diện
            for (int k = 0; k < temp.Count; k++)
            {
                arr[left + k] = temp[k];
                view.SetValue(left + k, temp[k]);   // cập nhật trực quan
                await Task.Delay(view.delayTime);
            }

            // Reset trạng thái
            for (int k = left; k <= right; k++)
                view.SetState(k, State.NORMAL);
        }

        #endregion

        #region HEAP SORT
        public async static void HeapSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            int n = arr.Count;

            // --- Xây dựng max-heap ---
            for (int i = n / 2 - 1; i >= 0; i--)
                await Heapify(view, arr, n, i);

            // --- Trích dần từng phần tử khỏi heap ---
            for (int i = n - 1; i > 0; i--)
            {
                // Highlight root và phần tử cuối
                view.SetState(0, State.COMPARE);
                view.SetState(i, State.COMPARE);
                await Task.Delay(view.delayTime);

                // Hoán đổi root với phần tử cuối
                await view.Swap(0, i);

                // Reset màu
                view.SetState(0, State.NORMAL);
                view.SetState(i, State.NORMAL);

                // Gọi heapify lên heap rút gọn
                await Heapify(view, arr, i, 0);
            }
        }

        private static async Task Heapify(SortingVisualizationView view, List<int> arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // So sánh với con trái
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // So sánh với con phải
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // Nếu cần đổi chỗ
            if (largest != i)
            {
                // Highlight
                view.SetState(i, State.COMPARE);
                view.SetState(largest, State.COMPARE);
                await Task.Delay(view.delayTime);

                await view.Swap(i, largest);

                // Reset màu
                view.SetState(i, State.NORMAL);
                view.SetState(largest, State.NORMAL);

                // Đệ quy tiếp tục hiệu chỉnh
                await Heapify(view, arr, n, largest);
            }
        }
        #endregion
    }
}
