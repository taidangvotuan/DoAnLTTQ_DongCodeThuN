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


        List<int> persistanceArray = null;
        public void SetNeedToSortArray(int[] a, int n)
        {
            //if (persistanceArray == null)
            //    persistanceArray = new List<int>(n);

            persistanceArray = new List<int>(n);
            persistanceArray.Clear();
            for (int i = 0; i < n; i++)
            {
                persistanceArray.Add(a[i]);
            }
            InitArrayView();
        }

        public void InitArrayView()
        {
            sortingPanel.Controls.Clear();
            int max = persistanceArray.Max();
            for(int i = 0; i < persistanceArray.Count; i++)
            {
                sortingPanel.Controls.Add(Creator.CreateColumn(sortingPanel.Bounds, persistanceArray[i], i, max, persistanceArray.Count));
            }
            //sortingPanel.Controls.Add();
        }


    }
}
