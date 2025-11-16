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
    }
}
