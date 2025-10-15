using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTTQ_DongCodeThuN
{
    // de de nhin hon, ong dat bien string roi bo het thuat toan vao
    // hoac dung File.ReadAllLines de doc file ben ngoai
    class CodeThuatToan
    {
        private void AddCodeToListBox(System.Windows.Forms.ListBox list, string code)
        {
            string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
                list.Items.Add(line);
        }

        public void HeapSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            // Hàm swap
            list_Code.Items.Clear(); // Xóa nội dung cũ

            string SwapFunc =
@"void Swap(int& a, int& b)
{
    int temp = a;
    a = b;
    b = temp;
}";

            string HeapifyTang =
@"void Heapify(int arr[], int n, int i)
{
    int max = i;
    int left = 2 * i + 1;
    int right = left + 1;
    if (left < n && arr[left] > arr[max])
        max = left;
    if (right < n && arr[right] > arr[max])
        max = right;
    if (max != i)
    {
        Swap(arr[i], arr[max]);
        Heapify(arr, n, max);
    }
}";

            string HeapifyGiam =
@"void Heapify(int arr[], int n, int i)
{
    int min = i;
    int left = 2 * i + 1;
    int right = left + 1;
    if (left < n && arr[left] < arr[min])
        min = left;
    if (right < n && arr[right] < arr[min])
        min = right;
    if (min != i)
    {
        Swap(arr[i], arr[min]);
        Heapify(arr, n, min);
    }
}";

            string HeapSortMain =
@"void HeapSort(int arr[], int n)
{
    for (int i = n / 2 - 1; i >= 0; i--)
        Heapify(arr, n, i);
    for (int j = n - 1; j > 0; j--)
    {
        Swap(arr[0], arr[j]);
        Heapify(arr, j, 0);
    }
}";
            // Hiển thị vào ListBox
            AddCodeToListBox(list_Code, SwapFunc);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, tang ? HeapifyTang : HeapifyGiam);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, HeapSortMain);
        }
        
        public void MergeSort(System.Windows.Forms.ListBox list_Code, Boolean tang)
        {
            list_Code.Items.Clear(); // Xóa nội dung cũ

            string MergeTang =
@"void Merge(int arr[], int left, int mid, int right)
{
    int n1 = mid - left + 1; // Số phần tử mảng con trái
    int n2 = right - mid;    // Số phần tử mảng con trái

    // Tạo mảng tạm
    int[] arrLeft = new int[n1];
    int[] arrRight = new int[n2];

    // Sao chép dữ liệu vào mảng tạm
    for (int i = 0; i < n1; i++)
        arrLeft[i] = arr[left + i];
    for (int j = 0; j < n2; j++)
        arrRight[j] = arr[mid + 1 + j];

    // Gộp 2 mảng tạm vào mảng chính
    int iLeft = 0;  // chỉ số mảng trái
    int iRight = 0;  // chỉ số mảng phải
    int k = left; // vị trí bắt đầu gộp

    while (iLeft < n1 && iRight < n2)
    {
        if (arrLeft[iLeft] <= arrRight[iRight])
        {
            arr[k] = arrLeft[iLeft];
            iLeft++;
        }
        else
        {
            arr[k] = arrRight[iRight];
            iRight++;
        }
        k++;
    }

    // Sao chép phần còn lại (nếu có)
    while (iLeft < n1)
    {
        arr[k] = arrLeft[iLeft];
        iLeft++;
        k++;
    }

    while (iRight < n2)
    {
        arr[k] = arrRight[iRight];
        iRight++;
        k++;
    }
}";

            string MergeGiam =
@"void Merge(int arr[], int left, int mid, int right)
{
    int n1 = mid - left + 1; // Số phần tử mảng con trái
    int n2 = right - mid;    // Số phần tử mảng con trái

    // Tạo mảng tạm
    int[] arrLeft = new int[n1];
    int[] arrRight = new int[n2];

    // Sao chép dữ liệu vào mảng tạm
    for (int i = 0; i < n1; i++)
        arrLeft[i] = arr[left + i];
    for (int j = 0; j < n2; j++)
        arrRight[j] = arr[mid + 1 + j];

    // Gộp 2 mảng tạm vào mảng chính
    int iLeft = 0;  // chỉ số mảng trái
    int iRight = 0;  // chỉ số mảng phải
    int k = left; // vị trí bắt đầu gộp

    while (iLeft < n1 && iRight < n2)
    {
        if (arrLeft[iLeft] >= arrRight[iRight])
        {
            arr[k] = arrLeft[iLeft];
            iLeft++;
        }
        else
        {
            arr[k] = arrRight[iRight];
            iRight++;
        }
        k++;
    }

    // Sao chép phần còn lại (nếu có)
    while (iLeft < n1)
    {
        arr[k] = arrLeft[iLeft];
        iLeft++;
        k++;
    }

    while (iRight < n2)
    {
        arr[k] = arrRight[iRight];
        iRight++;
        k++;
    }
}";

            string MergeSortMain =
@"void MergeSort(int arr[], int n)
{
    if (left < right)
    {
        int mid = (left + right) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
}";
            AddCodeToListBox(list_Code, tang ? MergeTang : MergeGiam);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, MergeSortMain);
        }

        public void InterchangeSort(System.Windows.Forms.ListBox list_Code, bool tang)
        {
            list_Code.Items.Clear();

            string SwapFunc =
@"void Swap(int& a, int& b)
{
    int temp = a;
    a = b;
    b = temp;
}";

            string CodeTang =
@"void InterchangeSort(int a[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = i + 1; j < n; j++)
            if (arr[i] > arr[j])
               Swap(arr[i], arr[j]);
    }
}";

            string CodeGiam =
@"void InterchangeSort(int a[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = i + 1; j < n; j++)
            if (arr[i] < arr[j])
               Swap(arr[i], arr[j]);
    }
}";
            AddCodeToListBox(list_Code, SwapFunc);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, tang ? CodeTang : CodeGiam);
        }

        public void SelectionSort(System.Windows.Forms.ListBox list_Code, bool tang)
        {
            list_Code.Items.Clear();

            string SwapFunc =
@"void Swap(int& a, int& b)
{
    int temp = a;
    a = b;
    b = temp;
}";

            string CodeTang =
@"void SelectionSort(int a[], int n)
{
    int min;
    for (int i = 0; i < n - 1; i++)
    {
        min = i;
        for (int j = i + 1; j < n; j++)
            if (a[j] < a[min])
                min = j;
        if (min != i)
            Swap(a[i], a[min]);
    }
}";

            string CodeGiam =
@"void SelectionSort(int a[], int n)
{
    int max;
    for (int i = 0; i < n - 1; i++)
    {
        max = i;
        for (int j = i + 1; j < n; j++)
            if (a[j] > a[max])
                max = j;
        if (max != i)
            Swap(a[i], a[max]);
    }
}";
            AddCodeToListBox(list_Code, SwapFunc);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, tang ? CodeTang : CodeGiam);
        }

        public void BubbleSort(System.Windows.Forms.ListBox list_Code, bool tang)
        {
            list_Code.Items.Clear();

            string SwapFunc =
@"void Swap(int& a, int& b)
{
    int temp = a;
    a = b;
    b = temp;
}";

            string CodeTang =
@"void BubbleSort(int arr[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
            if (arr[j] > arr[j + 1])
                Swap(arr[j], arr[j + 1]);
    }
}";

            string CodeGiam =
@"void BubbleSort(int arr[], int n)
{
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
            if (arr[j] < arr[j + 1])
                Swap(arr[j], arr[j + 1]);
    }
}";
            AddCodeToListBox(list_Code, SwapFunc);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, tang ? CodeTang : CodeGiam);
        }

        public void QuickSort(System.Windows.Forms.ListBox list_Code, bool tang)
        {
            list_Code.Items.Clear();

            string SwapFunc =
@"void Swap(int& a, int& b)
{
    int temp = a;
    a = b;
    b = temp;
}";

            string codeTang =
@"void QuickSort(int a[], int left, int right)
{
    int i = left, j = right;
    int pivot = a[(left + right) / 2];
    while (i <= j)
    {
        while (a[i] < pivot) i++;
        while (a[j] > pivot) j--;
        if (i <= j)
        {
            Swap(a[i], a[j]);
            i++;
            j--;
        }
    }
    if (left < j)
        QuickSort(a, left, j);
    if (i < right)
        QuickSort(a, i, right);
}";

            string codeGiam =
@"void QuickSort(int a[], int left, int right)
{
    int i = left, j = right;
    int pivot = a[(left + right) / 2];
    while (i <= j)
    {
        while (a[i] > pivot) i++;
        while (a[j] < pivot) j--;
        if (i <= j)
        {
            Swap(a[i], a[j]);
            i++;
            j--;
        }
    }
    if (left < j)
        QuickSort(a, left, j);
    if (i < right)
        QuickSort(a, i, right);
}";
            AddCodeToListBox(list_Code, SwapFunc);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, tang ? codeTang : codeGiam);
        }

        public void InsertionSort(System.Windows.Forms.ListBox list_Code, bool tang)
        {
            list_Code.Items.Clear();

            string SwapFunc =
@"void Swap(int& a, int& b)
{
    int temp = a;
    a = b;
    b = temp;
}";

            string CodeTang =
@"void InsertionSort(int arr[], int n)
{
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
}";

            string CodeGiam =
@"void InsertionSort(int arr[], int n)
{
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
}";
            AddCodeToListBox(list_Code, SwapFunc);
            list_Code.Items.Add("");
            AddCodeToListBox(list_Code, tang ? CodeTang : CodeGiam);
        }
    }
}
