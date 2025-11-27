using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTTQ_DongCodeThuN.Components
{
    public class ViewConfig
    {
        public Rectangle parentBound;
        public int maxElement;
        public int numberOfElements;

        readonly int COLUMN_WIDTH = 10;
        readonly int SPACING = 5;

        public ViewConfig(Rectangle parentBound, int maxElement, int numberOfElements)
        {
            this.parentBound = parentBound;
            this.maxElement = maxElement;
            this.numberOfElements = numberOfElements;

            m_padding = parentBound.Width - numberOfElements * (COLUMN_WIDTH + SPACING);
        }


        int RelativeHeight(int value)
        {
            return (int)((float)value / maxElement * parentBound.Height * 0.8f);
        }

        int m_padding;
        public void CalculateBoundary(int index, int value, out int x, out int y, out int width, out int height)
        {
            int relativeHeight = RelativeHeight(value);
            height = relativeHeight;
            width = COLUMN_WIDTH;
            x = index * (COLUMN_WIDTH + SPACING) + m_padding / 2;
            y = parentBound.Height - relativeHeight;
        }

        public int CalculateXPosition(int index)
        {
            return index * (COLUMN_WIDTH + SPACING) + m_padding / 2;
        }
    }
}