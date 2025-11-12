using DoAnLTTQ_DongCodeThuN.Components;
using DoAnLTTQ_DongCodeThuN.ThuatToan;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public class FormController
    {
        public Form mainForm;
        public Panel sortingPanel;

        public static Action OnUpdate;

        public FormController(Form m_form) 
        {
            this.mainForm = m_form;
            // "SortingPanelView" la ten cua panel dung de the hien thuat toan sap xep
            // DUNG DOI TEN CUA PANEL NAY
            sortingPanel = mainForm.Controls.Find("SortingPanelView", true).First() as Panel;
            //OnUpdate += Update;
        }
        public void SetSpeed(float speed) { }


        List<int> m_array = null;
        public void SetNeedToSortArray(int[] a, int n)
        {
            m_array = new List<int>(n);
            m_array.Clear();
            for (int i = 0; i < n; i++)
            {
                m_array.Add(a[i]);
            }
            //Create();
        }

        SortingVisualizationView visualizationView;
        public void Create()
        {
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int n = rnd.Next(6, 8);
            int[] a = new int[n+1];
            for(int i = 0; i < n; i++)
                a[i] = rnd.Next(1, 16);
            
            SetNeedToSortArray(a, n);
            visualizationView = new SortingVisualizationView(m_array, sortingPanel);
        }

        public void Start()
        {
            AlgorithmExecutor.BubbleSort(visualizationView);
        }
    }
}
