using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN.Components
{
    public class Creator
    {
        public static int COLUMN_WIDTH = 10;
        public static int SPACING = 5;
        public static PictureBox CreateColumn(Rectangle parentBound, int value, int i, int max_element, int n)
        {
            PictureBox _component = new PictureBox();

            int m_padding = parentBound.Width - n * (COLUMN_WIDTH + SPACING);

            int relativeHeight = (int)( (float)value/max_element * parentBound.Height * 0.8f);
            _component.Size = new Size(COLUMN_WIDTH, relativeHeight);
            _component.Location = new Point(i * (COLUMN_WIDTH + SPACING) + m_padding/2, parentBound.Height - relativeHeight);
            _component.BackColor = Color.Blue;
            return _component;
        }
    }
}
