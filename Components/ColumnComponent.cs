using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN.Components
{

    public enum State
    {
        NORMAL,
        SELECTED,
        NOR
    }


    public class ColumnNode
    {
        PictureBox _element;
        ViewConfig config;

        int index;
        int value;
        public ColumnNode(ViewConfig config, int index, int value) 
        { 
            this.config = config;
            this.index = index;
            this.value = value;
            _element = new PictureBox();
        }


        public void CreateElement()
        {
            config.CalculateBoundary(index, value, out int x, out int y, out int width, out int height);
            _element.Size = new Size(width, height);
            _element.Location = new Point(x, y);
            SetState(State.NORMAL);
        }

        public PictureBox GetVisualElement() => _element;
        public void SetIndex(int index) => this.index= index;

        // thay doi mau sac dua vao trang thai cua node khi dang sap xep
        public void SetState(State state)
        {
            switch(state)
            {
                case State.NORMAL:
                    _element.BackColor = Color.Blue; 
                    break;
                case State.SELECTED:
                    _element.BackColor = Color.Red;
                    break;
                default:
                    _element.BackColor = Color.Black;
                    break;
            }
        }

        public async Task MoveTo(int pos)
        {
            int direction = pos - _element.Location.X;
            if (direction == 0)
                return;
            direction = direction > 0 ? 1 : -1;
            while(Math.Abs(pos - _element.Location.X) > 2)
            {
                // linear movement
                // co the dung cac ham de cho animation muot hon
                _element.Location = new Point(_element.Location.X + 1 * direction , _element.Location.Y);
                await Task.Delay(10);
            }
            _element.Location = new Point(pos, _element.Location.Y);
        }
    }
}
