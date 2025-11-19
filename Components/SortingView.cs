using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN.Components
{
    //public class ViewConfig
    //{
    //public class ViewConfig
    //{
    //    public Rectangle parentBound;
    //    public int maxElement;
    //    public int numberOfElements;


    //    readonly int COLUMN_WIDTH = 10;
    //    readonly int SPACING = 5;
    //    public ViewConfig(Rectangle parentBound, int maxElement, int numberOfElements)
    //    {
    //        this.parentBound = parentBound;
    //        this.maxElement = maxElement;
    //        this.numberOfElements = numberOfElements;

    //        m_padding = parentBound.Width - numberOfElements * (COLUMN_WIDTH + SPACING);
    //    }


    //    int RelativeHeight(int value)
    //    {
    //        return  (int)((float)value / maxElement * parentBound.Height * 0.8f);
    //    }

    //    int m_padding;
    //    public void CalculateBoundary(int index, int value, out int x, out int y, out int width, out int height)
    //    {
    //        int relativeHeight = RelativeHeight(value);
    //        height = relativeHeight;
    //        width = COLUMN_WIDTH;
    //        x = index * (COLUMN_WIDTH + SPACING) + m_padding / 2;
    //        y = parentBound.Height - relativeHeight;
    //        //Console.WriteLine(x + " " + y+" "+width+" "+height);
    //    }

    //    public int CalculateXPosition(int index)
    //    {
    //        return index * (COLUMN_WIDTH + SPACING) + m_padding / 2;
    //    }
    //}
    //}

    public class SortingVisualizationView
    {
        Panel mainView;
        public int delayTime = 200;

        public List<int> listInt;
        List<ColumnNode> nodes;
        public SortingVisualizationView(List<int> arr, Panel sortingPanel)
        {
            listInt = new List<int>(arr);
            mainView = sortingPanel;
            nodes = new List<ColumnNode>();
            InitArrayView();

            //AAA();
        }

        // ----test-------
        //void ThreadApproach()
        //{
        //    while (mainView.Location.X < 270)
        //    {
        //        mainView.Invoke((MethodInvoker)delegate
        //        {
        //            mainView.Location = new Point(mainView.Location.X + 1 * speed, mainView.Location.Y);
        //        });
        //        Thread.Sleep(10);
        //    }            
        //}
        //async void TaskApproach()
        //{
        //    while(true)
        //    {
        //        mainView.Location = new Point(mainView.Location.X + 1, mainView.Location.Y);
        //        await Task.Delay(10);
        //    }
        //}

        //async void AAA()
        //{
        //    Console.WriteLine("lololololahhahaha");
        //    await Swap(0, 2);
        //    await Task.Delay(1000);
        //    await Swap(0, 2);
        //}

        ViewConfig config;
        public void InitArrayView()
        {
            ClearView();
            int max = listInt.Max();
            config = new ViewConfig(mainView.Bounds, max, listInt.Count);
            for (int i = 0; i < listInt.Count; i++)
            {
                ColumnNode node = new ColumnNode(config, i, listInt[i]);
                mainView.Controls.Add(node.GetVisualElement());
                node.CreateElement();
                nodes.Add(node);
            }
        }

        void ClearView()
        {
            mainView.Controls.Clear();
            nodes.Clear();
        }

        public Action OnSwapComplete;
        // su dung task de thuc hien swap animation
        // DUNG DUNG VAO CO GI HOI TUI
        public async Task Swap(int index_1, int index_2)
        {
            if (index_1 == index_2)
                return;
            nodes[index_1].SetState(State.SELECTED);
            nodes[index_2].SetState(State.SELECTED);

            // thay doi vi tri 2 phan tu truc quan tren man hinh
            // su dung task cua 
            //Console.WriteLine("lol");
            await Task.Delay(1000);
            int pos_x_1 = config.CalculateXPosition(index_1);
            int pos_x_2 = config.CalculateXPosition(index_2);
            await Task.WhenAll(nodes[index_1].MoveTo(pos_x_2), nodes[index_2].MoveTo(pos_x_1));
            //await nodes[index_1].MoveTo(pos_x_2);
            //await nodes[index_2].MoveTo(pos_x_1);

            // thay doi vi tri 2 phan tu trong mang
            (listInt[index_1], listInt[index_2]) = (listInt[index_2], listInt[index_1]);
            (nodes[index_1], nodes[index_2]) = (nodes[index_2], nodes[index_1]);
            nodes[index_1].SetIndex(index_2);
            nodes[index_2].SetIndex(index_1);


            nodes[index_1].SetState(State.NORMAL);
            nodes[index_2].SetState(State.NORMAL);
            OnSwapComplete?.Invoke(); // action invoke khi swap 2 phan tu

        }

        // chinh trang thai cho phan tu
        public void SetState(int index, State state)
        {
            nodes[index]?.SetState(state);
        }

        public async Task SetState(List<int> arr, int i, int j)
        {
            // Hoán vị
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;

            // Gọi invalidate/redraw
            //this.Invalidate();

            await Task.Delay(delayTime); // Delay để thấy animation
        }
    }
}
