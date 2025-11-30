using System;

namespace DoAnLTTQ_DongCodeThuN
{
    class YTuongThuatToan
    {
        private void AddIdeaToListBox(System.Windows.Forms.ListBox list, string code)
        {
            string[] lines = code.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (string line in lines)
                list.Items.Add(line);
        }

        public void HeapSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongHeapSort =
@"Thuật toán Heap Sort sắp xếp dựa trên ý tưởng là 
không gian cần sắp xếp đã được sắp xếp một phần và 
ta chỉ cần thêm giá trị mới vào không gian này sao 
cho không gian mới được sắp xếp.";
            AddIdeaToListBox(list_Idea, YTuongHeapSort);
            list_Idea.Items.Add("");
        }

        public void QuickSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongQuickSort =
@"- Thuật toán Quick Sort chia không gian cần sắp xếp
thành 2 không gian con là không gian con 1 và không
gian con 2. Không gian con 1 là không gian mà tất cả
các phần tử thuộc không gian này đều nhỏ hơn hoặc 
bằng tất cả các phần tử thuộc không gian con 2.
  + Nếu không gian con 1 có nhiều hơn 1 phần tử thì
sắp xếp không gian con này bằng thuật toán Quick 
Sort.
  + Nếu không gian con 2 có nhiều hơn 1 phần tử thì
sắp xếp không gian con này bằng thuật toán Quick 
Sort.";
            AddIdeaToListBox(list_Idea, YTuongQuickSort);
            list_Idea.Items.Add("");
        }

        public void MergeSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongMergeSort =
@"- Thuật toán Merge Sort chia không gian cần sắp xếp
thành 2 không gian con.
  + Nếu không gian con thứ nhất có nhiều hơn 1 phần
tử thì sắp xếp không gian con này bằng thuật toán
Merge Sort.
  + Nếu không gian con thứ hai có nhiều hơn 1 phần
tử thì sắp xếp không gian con này bằng thuật toán 
Merge Sort.
- Trộn 2 không gian con đã được sắp xếp lại với 
nhau.";
            AddIdeaToListBox(list_Idea, YTuongMergeSort);
            list_Idea.Items.Add("");
        }
        
        public void InterchangeSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongInterchangeSort =
@"Thuật toán Interchange Sort sẽ duyệt qua tất cả các 
cặp giá trị trong mảng và hoán vị hai giá trị trong 
một cặp nếu cặp giá trị đó là nghịch thế.";
            AddIdeaToListBox(list_Idea, YTuongInterchangeSort);
            list_Idea.Items.Add("");
        }

        public void SelectionSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongSelectionSort =
@"- Thuật toán Selection Sort sắp xếp bằng cách đưa 
các phần tử vào đúng vị trí của nó.";
            AddIdeaToListBox(list_Idea, YTuongSelectionSort);
            list_Idea.Items.Add("");
        }

        public void BubbleSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongBubbleSort =
@"- Ý tưởng của thuật toán Bubble Sort là nhẹ nổi lên
và nặng chìm xuống.
- Khái niệm nặng nhẹ là khái niệm trừu tượng.";
            AddIdeaToListBox(list_Idea, YTuongBubbleSort);
            list_Idea.Items.Add("");
        }

        public void InsertionSort(System.Windows.Forms.ListBox list_Idea)
        {
            string YTuongInsertionSort =
@"Thuật toán Insertion Sort sắp xếp dựa trên ý tưởng
là  không gian cần sắp xếp đã được sắp xếp một phần 
và ta chỉ cần thêm giá trị mới vào không gian này 
sao cho không gian mới được sắp xếp.";
            AddIdeaToListBox(list_Idea, YTuongInsertionSort);
            list_Idea.Items.Add("");
        }
    }
}
