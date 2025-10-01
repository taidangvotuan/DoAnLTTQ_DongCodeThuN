using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTTQ_DongCodeThuN
{
    class CodeThuatToan
    {
        public void heapSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Add("void heapify(int arr[], int n, int i)");
            list_Code.Items.Add("{");
            if (tang)
            {
                list_Code.Items.Add("	int max = i;");
                list_Code.Items.Add("	int l = i * 2 + 1;");
                list_Code.Items.Add("	int r = l + 1;");
                list_Code.Items.Add("	if (l < n && arr[l] > arr[max])");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		max = l;");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("	if (r < n && arr[r] > arr[max])");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		max = r;");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("	if (max != i)");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		swap(arr[i], arr[max]);");
                list_Code.Items.Add("		heapify(arr, n, max);");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("}");
            }
            else
            {
                list_Code.Items.Add("	int min = i;");
                list_Code.Items.Add("	int l = i * 2 + 1;");
                list_Code.Items.Add("	int r = l + 1;");
                list_Code.Items.Add("	if (l < n && arr[l] < arr[min])");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		min = l;");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("	if (r < n && arr[r] < arr[min])");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		min = r;");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("	if (min != i)");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		swap(arr[i], arr[min]);");
                list_Code.Items.Add("		heapify(arr, n, min);");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("}");
            }
            list_Code.Items.Add("");
            list_Code.Items.Add("void heapSort(int arr[], int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("	for (int i = n / 2 - 1; i >= 0; i--)");
            list_Code.Items.Add("		heapify(arr, n, i);");
            list_Code.Items.Add("	for (int j = n - 1; j > 0; j--)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		swap(arr[0], arr[j]);");
            list_Code.Items.Add("		heapify(arr, j, 0);");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("}");
        }
        public void mergeSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Add("void merge(int a[], int p, int t, int n)");
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
            list_Code.Items.Add("void mergeSort(int a[], int first, int end)");
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
        public void selectionSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Add("void selectionSort(int a[], int n)");
            list_Code.Items.Add("{");
            if (tang)
            {
                list_Code.Items.Add("	int min;");
                list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		min = i;");
                list_Code.Items.Add("		for (int j = i + 1; j < n; j++)");
                list_Code.Items.Add("			if (a[j] < a[min])");
                list_Code.Items.Add("				min = j;");
                list_Code.Items.Add("		if (min != i)");
                list_Code.Items.Add("			swap(a[i], a[min]);");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("}");
            }
            else
            {
                list_Code.Items.Add("	int max;");
                list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
                list_Code.Items.Add("	{");
                list_Code.Items.Add("		max = i;");
                list_Code.Items.Add("		for (int j = i + 1; j < n; j++)");
                list_Code.Items.Add("			if (a[j] > a[max])");
                list_Code.Items.Add("				max = j;");
                list_Code.Items.Add("		if (max != i)");
                list_Code.Items.Add("			swap(a[i], a[max]);");
                list_Code.Items.Add("	}");
                list_Code.Items.Add("}");
            }
        }

        public void bubbleSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Add("void bubbleSort(int a[], int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("	int i, j;");
            list_Code.Items.Add("	for (int i = 0; i < n - 1; i++)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		for (int j = 0; j < n - i - 1; j++)");
            if (tang)
            {
                list_Code.Items.Add("			if (a[j] > a[j + 1])");
            }
            else
            {
                list_Code.Items.Add("			if (a[j] < a[j + 1])");
            }
            list_Code.Items.Add("			{");
            list_Code.Items.Add("				swap(a[j], a[j + 1]);");
            list_Code.Items.Add("			}");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("}");
        }
        public void quicksort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Truyền code C quickSort
            list_Code.Items.Add("void quickSort(int a[], int low, int high)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("	if (low >= high)");
            list_Code.Items.Add("		return;");
            list_Code.Items.Add("	else");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		int pivot = a[high];");
            list_Code.Items.Add("		int right = high - 1;");
            list_Code.Items.Add("		int left = low;");
            list_Code.Items.Add("		while (true)");
            list_Code.Items.Add("		{");

            // Nếu là sắp xếp tăng
            if (tang)
            {
                list_Code.Items.Add("			while (a[left] < pivot && left <= right) left++;");
                list_Code.Items.Add("			while (a[right] > pivot && right >= left) right--;");
            }

            // Nếu là sắp xếp giảm
            else
            {
                list_Code.Items.Add("			while (a[left] > pivot && left <= right) left++;");
                list_Code.Items.Add("			while (a[right] < pivot && right >= left) right--;");
            }
            list_Code.Items.Add("			if (left >= right)");
            list_Code.Items.Add("				break;");
            list_Code.Items.Add("			swap(a[left], a[right]);");
            list_Code.Items.Add("			left++;");
            list_Code.Items.Add("			right--;");
            list_Code.Items.Add("		}");
            list_Code.Items.Add("		swap(a[left], a[high]);");
            list_Code.Items.Add("		quickSort(a, low, left - 1);");
            list_Code.Items.Add("		quickSort(a, left + 1, high);");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("}");
            /// Hàm swap
            list_Code.Items.Add("  void Swap(int &a,int &b)  {");
            list_Code.Items.Add("           int temp = a;");
            list_Code.Items.Add("            a = b;");
            list_Code.Items.Add("            b=temp;");
            list_Code.Items.Add(" }");
        }

        public void insertionSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Add("void insertionSort(int a[], int n)");
            list_Code.Items.Add("{");
            list_Code.Items.Add("	int j, x;");
            list_Code.Items.Add("	for (int i = 1; i < n; i++)");
            list_Code.Items.Add("	{");
            list_Code.Items.Add("		x = a[i];");
            list_Code.Items.Add("		j = i;");
            if (tang)
            {
                list_Code.Items.Add("		while (j > 0 && x < a[j - 1])");
            }
            else
            {
                list_Code.Items.Add("		while (j > 0 && x > a[j - 1])");
            }
            list_Code.Items.Add("		{");
            list_Code.Items.Add("			a[j] = a[j - 1];");
            list_Code.Items.Add("			j--;");
            list_Code.Items.Add("		}");
            list_Code.Items.Add("		a[j] = x;");
            list_Code.Items.Add("	}");
            list_Code.Items.Add("}");
        }
    }
}
