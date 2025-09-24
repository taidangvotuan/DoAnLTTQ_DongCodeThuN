using DoAnLTTQ_DongCodeThuN.Components;
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
    internal class FormController
    {
        public Form mainForm;
        public Panel sortingPanel;

        public FormController(Form m_form) 
        {
            this.mainForm = m_form;
        }


        List<int> m_array = null;
        public void SetNeedToSortArray(int[] a, int n)
        {
            //if (persistanceArray == null)
            //    persistanceArray = new List<int>(n);

            m_array = new List<int>(n);
            m_array.Clear();
            for (int i = 0; i < n; i++)
            {
                m_array.Add(a[i]);
            }
            InitArrayView();
        }

        public void InitArrayView()
        {
            sortingPanel.Controls.Clear();
            int max = m_array.Max();
            for(int i = 0; i < m_array.Count; i++)
            {
                sortingPanel.Controls.Add(Creator.CreateColumn(sortingPanel.Bounds, m_array[i], i, max, m_array.Count));
            }
            //sortingPanel.Controls.Add();
        }


    }
}
