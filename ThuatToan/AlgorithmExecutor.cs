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
        /*public async static void InsertionSort(SortingVisualizationView view)
        {
            List<int> arr = view.listInt;
            int n = arr.Count;

            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;

                await view.Highlight(i);

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    view.Invalidate();
                    await Task.Delay(view.delayTime);

                    j--;
                }

                arr[j + 1] = key;
                view.Invalidate();
                await Task.Delay(view.delayTime);
            }
        }*/


    }
}
