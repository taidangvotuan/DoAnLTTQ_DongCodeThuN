using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTTQ_DongCodeThuN
{
    class CodeThuatToan
    {
        public void HeapSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Hàm swap
            list_Code.Items.Add("void Swap(int& a, int& b)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    int temp = a;");
            list_Code.Items.Add("    a = b;");
            list_Code.Items.Add("    b = temp;");
            list_Code.Items.Add("}");

            list_Code.Items.Add("void Heapify(int arr[], int n, int i)");
            list_Code.Items.Add("{");
            if (tang)
            {
                list_Code.Items.Add("    int max = i;");
                list_Code.Items.Add("    int left = 2 * i + 1;");
                list_Code.Items.Add("    int right = left + 1;");
                list_Code.Items.Add("    if (left < n && arr[left] > arr[max])");
                list_Code.Items.Add("        max = left;");
                list_Code.Items.Add("    if (right < n && arr[right] > arr[max])");
                list_Code.Items.Add("        max = right;");
                list_Code.Items.Add("    if (max != i)");
                list_Code.Items.Add("    {");
                list_Code.Items.Add("        Swap(arr[i], arr[max]);");
                list_Code.Items.Add("        Heapify(arr, n, max);");
                list_Code.Items.Add("    }");
                list_Code.Items.Add("}");
            }
            else
            {
                list_Code.Items.Add("   int min = i;");
                list_Code.Items.Add("   int left = i * 2 + 1;");
                list_Code.Items.Add("	int right = left + 1;");
                list_Code.Items.Add("	if (left < n && arr[left] < arr[min])");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		min = left;");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("	if (right < n && arr[right] < arr[min])");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		min = right;");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("	if (min != i)");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		Swap(arr[i], arr[min]);");
                list_Code.Items.Add("		Heapify(arr, n, min);");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("}");
            }
            list_Code.Items.Add("");
            list_Code.Items.Add("void HeapSort(int arr[], int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    for (int i = n / 2 - 1; i >= 0; i--)");
            list_Code.Items.Add("        Heapify(arr, n, i);");
            list_Code.Items.Add("    for (int j = n - 1; j > 0; j--)");
            list_Code.Items.Add("    {");
            list_Code.Items.Add("        Swap(arr[0], arr[j]);");
            list_Code.Items.Add("        Heapify(arr, j, 0);");
            list_Code.Items.Add("    }");
            list_Code.Items.Add("}");
        }
        public void MergeSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Add("void Merge(int a[], int p, int t, int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("	int n1 = t - p + 1;");
            list_Code.Items.Add("	int n2 = n - t;");
            list_Code.Items.Add("	int left[n1]; int right[n2];");
            list_Code.Items.Add("");
            list_Code.Items.Add("	for (int x = 0; x < n1; x++) left[x] = a[p + x];");
            list_Code.Items.Add("");
            list_Code.Items.Add("	for (int y = 0; y < n2; y++) right[y] = a[t + 1 + y];");
            list_Code.Items.Add("");
            list_Code.Items.Add("	int i = 0, j = 0;");
            list_Code.Items.Add("	int k = p;");
            list_Code.Items.Add("");
            list_Code.Items.Add("	while (i < n1 && j < n2)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		if (left[i] >= right[j])");
            list_Code.Items.Add("		{");
            list_Code.Items.Add("			a[k] = right[j];");
            list_Code.Items.Add("			j++;");
            list_Code.Items.Add("		}");
            list_Code.Items.Add("		else");
            list_Code.Items.Add("		{");
            list_Code.Items.Add("			a[k] = left[i];");
            list_Code.Items.Add("			i++;");
            list_Code.Items.Add("		}");
            list_Code.Items.Add("     	}");
            list_Code.Items.Add("		k++;");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("");
            list_Code.Items.Add("	while (j < n2)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		a[k] = right[j];");
            list_Code.Items.Add("		k++;");
            list_Code.Items.Add("		j++;");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("");
            list_Code.Items.Add("	while (i < n1)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		a[k] = left[i];");
            list_Code.Items.Add("		k++;");
            list_Code.Items.Add("		i++;");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("}");
            list_Code.Items.Add("");
            list_Code.Items.Add("void MergeSort(int a[], int first, int end)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("	int t;");
            list_Code.Items.Add("	if (first < end)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		t = (first + end) / 2;");
            list_Code.Items.Add("		mergeSort(a, first, t);");
            list_Code.Items.Add("		mergeSort(a, t + 1, end);");
            list_Code.Items.Add("		merge(a, first, t, end);");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("	else");
            list_Code.Items.Add("		return;");
            list_Code.Items.Add("}");
            if (tang)
            {

            }
            else
            {

            }
        }
        public void SelectionSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Hàm swap
            list_Code.Items.Add("void Swap(int& a, int& b)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    int temp = a;");
            list_Code.Items.Add("    a = b;");
            list_Code.Items.Add("    b = temp;");
            list_Code.Items.Add("}");

            list_Code.Items.Add("void SelectionSort(int a[], int n)");
            list_Code.Items.Add("{");
            if (tang)
            {
                list_Code.Items.Add("    int min;");
                list_Code.Items.Add("    for (int i = 0; i < n - 1; i++)");
                list_Code.Items.Add("    {");
                list_Code.Items.Add("        min = i;");
                list_Code.Items.Add("        for (int j = i + 1; j < n; j++)");
                list_Code.Items.Add("            if (a[j] < a[min])");
                list_Code.Items.Add("                min = j;");
                list_Code.Items.Add("        if (min != i)");
                list_Code.Items.Add("            Swap(a[i], a[min]);");
                list_Code.Items.Add("    }");
                list_Code.Items.Add("}");
            }
            else
            {
                list_Code.Items.Add("    int max;");
                list_Code.Items.Add("    for (int i = 0; i < n - 1; i++)");
                list_Code.Items.Add("    {");
                list_Code.Items.Add("        max = i;");
                list_Code.Items.Add("        for (int j = i + 1; j < n; j++)");
                list_Code.Items.Add("            if (a[j] > a[max])");
                list_Code.Items.Add("                max = j;");
                list_Code.Items.Add("        if (max != i)");
                list_Code.Items.Add("            Swap(a[i], a[max]);");
                list_Code.Items.Add("    }");
                list_Code.Items.Add("}");
            }
        }

        public void BubbleSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Hàm Swap
            list_Code.Items.Add("void Swap(int& a, int& b)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    int temp = a;");
            list_Code.Items.Add("    a = b;");
            list_Code.Items.Add("    b = temp;");
            list_Code.Items.Add("}");

            list_Code.Items.Add("void BubbleSort(int arr[], int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    for (int i = 0; i < n - 1; i++)");
            list_Code.Items.Add("    {");
            list_Code.Items.Add("        for (int j = 0; j < n - i - 1; j++)");
            if (tang)
            {
                list_Code.Items.Add("            if (arr[j] > arr[j + 1])");
            }
            else
            {
                list_Code.Items.Add("            if (arr[j] < arr[j + 1])");
            }
            list_Code.Items.Add("                Swap(arr[j], arr[j + 1]);");
            list_Code.Items.Add("    }");
            list_Code.Items.Add("}");
        }
        public void QuickSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Hàm swap
            list_Code.Items.Add("void Swap(int& a, int& b)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    int temp = a;");
            list_Code.Items.Add("    a = b;");
            list_Code.Items.Add("    b = temp;");
            list_Code.Items.Add("}");

            // Truyền code C QuickSort
            list_Code.Items.Add("void QuickSort(int a[], int left, int right)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    int i = left, j = right;");
            list_Code.Items.Add("    int pivot = a[(left + right) / 2];");
            list_Code.Items.Add("    while (i <= j)");
            list_Code.Items.Add("    {");

            // Nếu là sắp xếp tăng
            if (tang)
            {
                list_Code.Items.Add("        while (a[i] < pivot) i++");
                list_Code.Items.Add("        while (a[j] > pivot) j--;");
            }

            // Nếu là sắp xếp giảm
            else
            {
                list_Code.Items.Add("        while (a[i] > pivot) i++");
                list_Code.Items.Add("        while (a[j] < pivot) j--;");
            }
            list_Code.Items.Add("        if (i <= j)");
            list_Code.Items.Add("        {");
            list_Code.Items.Add("           Swap(a[i], a[j]);");
            list_Code.Items.Add("           i++;");
            list_Code.Items.Add("           j--;");
            list_Code.Items.Add("        }");
            list_Code.Items.Add("    }");
            list_Code.Items.Add("    if (left < j)");
            list_Code.Items.Add("       QuickSort(a, left, j);");
            list_Code.Items.Add("    if (i < right)");
            list_Code.Items.Add("       QuickSort(a, i, right);");
            list_Code.Items.Add("}");
        }

        public void InsertionSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Hàm swap
            list_Code.Items.Add("void Swap(int& a, int& b)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    int temp = a;");
            list_Code.Items.Add("    a = b;");
            list_Code.Items.Add("    b = temp;");
            list_Code.Items.Add("}");

            list_Code.Items.Add("void InsertionSort(int arr[], int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("    for (int i = 1; i < n; i++)");
            list_Code.Items.Add("    {");
            list_Code.Items.Add("        int key = arr[i];");
            list_Code.Items.Add("        int j = i - 1;");
            if (tang)
            {
                list_Code.Items.Add("        while (j >= 0 && arr[j] > key)");
            }
            else
            {
                list_Code.Items.Add("        while (j >= 0 && arr[j] < key)");
            }
            list_Code.Items.Add("        {");
            list_Code.Items.Add("            arr[j + 1] = arr[j];");
            list_Code.Items.Add("            j--;");
            list_Code.Items.Add("        }");
            list_Code.Items.Add("        arr[j + 1] = key;");
            list_Code.Items.Add("    }");
            list_Code.Items.Add("}");
        }
    }
}
