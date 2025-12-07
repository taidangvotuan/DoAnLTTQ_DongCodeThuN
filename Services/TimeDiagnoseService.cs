using DoAnLTTQ_DongCodeThuN.ThuatToan;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTTQ_DongCodeThuN.Services
{
    public static class TimeDiagnoseService
    {
        public static double TimeDiagnose(Action action)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            action.Invoke();

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            return ts.TotalMilliseconds;
        }

        public static double ChayMoPhongThuatToan(int[] arr, string thuattoan, bool tang)
        {

            Func<int, int, bool> compareFunc = (x, y) =>
            {
                return tang ? (x > y) : (x < y);
            };

            int[] copy_arr = new int[arr.Length];
            Array.Copy(arr, copy_arr, arr.Length);

            return TimeDiagnose(() =>
            {
                switch (thuattoan)
                {
                    case "Bubble Sort":
                        Algorithm.BubbleSort(copy_arr, compareFunc);
                        break;
                    case "Selection Sort":
                        Algorithm.SelectionSort(copy_arr, compareFunc);
                        break;
                    case "Insertion Sort":
                        Algorithm.InsertionSort(copy_arr, compareFunc);
                        break;
                    case "Heap Sort":
                        Algorithm.HeapSort(copy_arr, compareFunc);
                        break;
                    case "Interchange Sort":
                        Algorithm.InterchangeSort(copy_arr, compareFunc);
                        break;
                    case "Merge Sort":
                        Algorithm.MergeSort(copy_arr, compareFunc);
                        break;
                    case "Quick Sort":
                        Algorithm.QuickSort(copy_arr, compareFunc);
                        break;
                    default:
                        break;
                }
            });
        }
    }
}
