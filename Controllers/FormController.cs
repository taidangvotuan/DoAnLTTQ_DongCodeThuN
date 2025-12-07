using DoAnLTTQ_DongCodeThuN.Components;
using DoAnLTTQ_DongCodeThuN.ThuatToan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    /// <summary>
    /// Controller quản lý visualization của thuật toán sắp xếp (Legacy component)
    /// Tích hợp với AlgorithmExecutor để chạy các thuật toán
    /// </summary>
    //public class FormController
    //{
    //    #region FIELDS
    //    public Form mainForm;
    //    public Panel sortingPanel;
    //    public static Action OnUpdate;

    //    private List<int> m_array = null;
    //    private SortingVisualizationView visualizationView;
    //    private readonly Random random;
    //    #endregion

    //    #region CONSTRUCTOR
    //    /// <summary>
    //    /// Khởi tạo FormController với form chính
    //    /// </summary>
    //    /// <param name="m_form">Form chứa panel visualization</param>
    //    /// <exception cref="ArgumentNullException">Nếu form null</exception>
    //    /// <exception cref="InvalidOperationException">Nếu không tìm thấy SortingPanelView</exception>
    //    public FormController(Form m_form)
    //    {
    //        if (m_form == null)
    //            throw new ArgumentNullException(nameof(m_form), "Main form không được null");

    //        this.mainForm = m_form;
    //        this.random = new Random();

    //        // "SortingPanelView" la ten cua panel dung de the hien thuat toan sap xep
    //        // DUNG DOI TEN CUA PANEL NAY
    //        var panels = mainForm.Controls.Find("SortingPanelView", true);
    //        if (panels == null || panels.Length == 0)
    //            throw new InvalidOperationException($"Không tìm thấy panel SortingPanelView trong form");

    //        sortingPanel = panels.First() as Panel;

    //        if (sortingPanel == null)
    //            throw new InvalidOperationException($"SortingPanelView không phải là Panel");

    //        //OnUpdate += Update;
    //    }
    //    #endregion

    //    #region SPEED CONTROL
    //    /// <summary>
    //    /// Thiết lập tốc độ animation
    //    /// </summary>
    //    public void SetSpeed(int level)
    //    {
    //        if (level < 1 || level > 15)
    //            throw new ArgumentOutOfRangeException(nameof(level), "Tốc độ phải từ 1 đến 15");

    //        if (visualizationView != null)
    //        {
    //            // ===== CÔNG THỨC TỐC ĐỘ MỚI =====
    //            // Level 1  -> 200ms (chậm nhất)
    //            // Level 8  -> 50ms  (trung bình)
    //            // Level 15 -> 1ms   (nhanh nhất)

    //            int delay;
    //            if (level <= 0)
    //                delay = 200;
    //            else if (level >= 15)
    //                delay = 1; // Cực nhanh
    //            else
    //                delay = 200 - (level * 13); // Giảm 13ms mỗi level

    //            visualizationView.delayTime = delay;
    //        }
    //    }

    //    /// <summary>
    //    /// Thiết lập tốc độ với giá trị float (tương thích code cũ)
    //    /// </summary>
    //    public void SetSpeedFloat(float speed)
    //    {
    //        if (speed < 0.1f || speed > 15.0f)
    //            throw new ArgumentOutOfRangeException(nameof(speed),
    //                "Tốc độ phải từ 0.1 đến 15.0");

    //        // Convert float speed sang level integer
    //        int level = (int)Math.Round(speed);
    //        if (level < 1) level = 1;
    //        if (level > 15) level = 15;

    //        SetSpeed(level);
    //    }

    //    /// <summary>
    //    /// Lấy mức tốc độ hiện tại (1-15)
    //    /// </summary>
    //    public int GetSpeedLevel()
    //    {
    //        if (visualizationView == null) return 8; // Default: trung bình

    //        // Tính ngược level từ delayTime
    //        int delay = visualizationView.delayTime;

    //        // Công thức ngược: level = (200 - delay) / 13
    //        int level = (200 - delay) / 13;

    //        // Clamp về range 1-15
    //        if (level < 1) return 1;
    //        if (level > 15) return 15;
    //        return level;
    //    }

    //    /// <summary>
    //    /// Lấy delay time hiện tại (ms)
    //    /// </summary>
    //    public int GetDelayTime()
    //    {
    //        return visualizationView?.delayTime ?? 100;
    //    }

    //    /// <summary>
    //    /// Lấy mô tả tốc độ
    //    /// </summary>
    //    public string GetSpeedDescription()
    //    {
    //        int level = GetSpeedLevel();

    //        if (level <= 3) return "Rất chậm";
    //        if (level <= 6) return "Chậm";
    //        if (level <= 9) return "Trung bình";
    //        if (level <= 12) return "Nhanh";
    //        return "Rất nhanh";
    //    }
    //    #endregion

    //    #region ARRAY MANAGEMENT
    //    /// <summary>
    //    /// Thiết lập mảng cần sắp xếp
    //    /// </summary>
    //    /// <param name="a">Mảng đầu vào</param>
    //    /// <param name="n">Số phần tử</param>
    //    /// <exception cref="ArgumentNullException">Nếu mảng null</exception>
    //    /// <exception cref="ArgumentOutOfRangeException">Nếu n không hợp lệ</exception>
    //    public void SetNeedToSortArray(int[] a, int n)
    //    {
    //        if (a == null)
    //            throw new ArgumentNullException(nameof(a), "Mảng không được null");
    //        if (n < 0 || n > a.Length)
    //            throw new ArgumentOutOfRangeException(nameof(n), $"Số phần tử phải từ 0 đến {a.Length}");

    //        // Khởi tạo list với capacity
    //        m_array = new List<int>(n);
    //        m_array.Clear();

    //        // Copy n phần tử đầu tiên
    //        for (int i = 0; i < n; i++)
    //            m_array.Add(a[i]);
    //        //Create();
    //    }

    //    /// <summary>
    //    /// Lấy mảng hiện tại
    //    /// </summary>
    //    /// <returns>Copy của mảng hoặc null nếu chưa khởi tạo</returns>
    //    public int[] GetCurrentArray()
    //    {
    //        return m_array?.ToArray();
    //    }

    //    /// <summary>
    //    /// Kiểm tra đã có mảng chưa
    //    /// </summary>
    //    public bool HasArray()
    //    {
    //        return m_array != null && m_array.Count > 0;
    //    }
    //    #endregion

    //    #region VISUALIZATION CREATION
    //    public void Create()
    //    {
    //        Random rnd = new Random((int)DateTime.Now.Ticks);
    //        int n = rnd.Next(1, 45);
    //        int[] a = new int[n + 1];

    //        for (int i = 0; i < n; i++)
    //            a[i] = rnd.Next(0, 100);

    //        SetNeedToSortArray(a, n);
    //        visualizationView = new SortingVisualizationView(m_array, sortingPanel);
    //    }

    //    /// <summary>
    //    /// Tạo mảng với tham số tùy chỉnh
    //    /// </summary>
    //    /// <param name="elementCount">Số phần tử</param>
    //    /// <param name="minValue">Giá trị nhỏ nhất</param>
    //    /// <param name="maxValue">Giá trị lớn nhất</param>
    //    public void CreateCustom(int elementCount, int minValue, int maxValue)
    //    {
    //        if (elementCount < 2 || elementCount > 45)
    //            throw new ArgumentOutOfRangeException(nameof(elementCount), "Số phần tử phải từ 2 đến 45");
    //        if (minValue >= maxValue)
    //            throw new ArgumentException("minValue phải nhỏ hơn maxValue");

    //        int[] a = new int[elementCount];
    //        for (int i = 0; i < elementCount; i++)
    //            a[i] = random.Next(minValue, maxValue);

    //        SetNeedToSortArray(a, elementCount);
    //        visualizationView = new SortingVisualizationView(m_array, sortingPanel);
    //    }

    //    /// <summary>
    //    /// Tạo visualization từ mảng có sẵn
    //    /// </summary>
    //    /// <param name="array">Mảng cần visualize</param>
    //    public void CreateFromArray(int[] array)
    //    {
    //        if (array == null || array.Length == 0)
    //            throw new ArgumentException("Mảng không được null hoặc rỗng", nameof(array));

    //        SetNeedToSortArray(array, array.Length);
    //        visualizationView = new SortingVisualizationView(m_array, sortingPanel);
    //    }
    //    #endregion

    //    #region ALGORITHM EXECUTION
    //    /// <summary>
    //    /// Bắt đầu chạy thuật toán Bubble Sort (default)
    //    /// </summary>
    //    /// <exception cref="InvalidOperationException">Nếu chưa khởi tạo visualization</exception>
    //    public void Start()
    //    {
    //        if (visualizationView == null)
    //            throw new InvalidOperationException("Chưa khởi tạo visualization. Gọi Create() trước khi Start()");
    //        AlgorithmExecutor.BubbleSort(visualizationView);
    //    }

    //    /// <summary>
    //    /// Chạy thuật toán theo tên
    //    /// </summary>
    //    public async Task StartByName(string name)
    //    {
    //        if (visualizationView == null)
    //            throw new InvalidOperationException("Chưa khởi tạo");
    //        if (string.IsNullOrWhiteSpace(name))
    //            throw new ArgumentException("Tên thuật toán rỗng");

    //        switch (name.ToLower().Replace(" ", ""))
    //        {
    //            case "bubblesort":
    //                AlgorithmExecutor.BubbleSort(visualizationView);
    //                break;
    //            case "quicksort":
    //                await AlgorithmExecutor.QuickSort(visualizationView, 0, visualizationView.listInt.Count - 1);
    //                break;
    //            case "selectionsort":
    //                AlgorithmExecutor.SelectionSort(visualizationView);
    //                break;
    //            case "insertionsort":
    //                AlgorithmExecutor.InsertionSort(visualizationView);
    //                break;
    //            case "mergesort":
    //                AlgorithmExecutor.MergeSort(visualizationView);
    //                break;
    //            case "heapsort":
    //                AlgorithmExecutor.HeapSort(visualizationView);
    //                break;
    //            case "interchangesort":
    //                AlgorithmExecutor.InterchangeSort(visualizationView);
    //                break;
    //            default:
    //                throw new ArgumentException($"Thuật toán '{name}' không hỗ trợ");
    //        }
    //    }

    //    // Shortcut methods
    //    public void StartBubbleSort() => AlgorithmExecutor.BubbleSort(visualizationView);
    //    public async Task StartQuickSort() => await AlgorithmExecutor.QuickSort(visualizationView, 0, visualizationView.listInt.Count - 1);
    //    public void StartSelectionSort() => AlgorithmExecutor.SelectionSort(visualizationView);
    //    public void StartInsertionSort() => AlgorithmExecutor.InsertionSort(visualizationView);
    //    public void StartMergeSort() => AlgorithmExecutor.MergeSort(visualizationView);
    //    public void StartHeapSort() => AlgorithmExecutor.HeapSort(visualizationView);
    //    public void StartInterchangeSort() => AlgorithmExecutor.InterchangeSort(visualizationView);
    //    #endregion

    //    #region STATE & UTILITIES
    //    public void Stop()
    //    {
    //        visualizationView = null;
    //        m_array?.Clear();
    //    }

    //    public bool IsReady()
    //    {
    //        return visualizationView != null && m_array != null && m_array.Count > 0;
    //    }

    //    public string GetStatus()
    //    {
    //        if (!HasArray()) return "Chưa khởi tạo";
    //        return $"Array: {m_array.Count} | View: {(visualizationView != null ? "OK" : "NULL")}";
    //    }

    //    public static string[] GetAlgorithms()
    //    {
    //        return new[] { "Bubble Sort", "Quick Sort", "Selection Sort",
    //                      "Insertion Sort", "Merge Sort", "Heap Sort", "Interchange Sort" };
    //    }

    //    public void Dispose()
    //    {
    //        Stop();
    //        OnUpdate = null;
    //        sortingPanel = null;
    //        mainForm = null;
    //    }
    //    #endregion
    //}
}
