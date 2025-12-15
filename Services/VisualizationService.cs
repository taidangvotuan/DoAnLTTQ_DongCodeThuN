using DoAnLTTQ_DongCodeThuN.Models;
using System;
using System.Drawing;
using System.Linq;

namespace DoAnLTTQ_DongCodeThuN.Services
{
    public class VisualizationService
    {
        private readonly SortingState state;

        public VisualizationService(SortingState state)
        {
            this.state = state;
        }

        // Vẽ các cột sắp xếp (Vẽ node)
        public void DrawSortingPanel(Graphics g, int panelWidth, int panelHeight)
        {
            if (state.a == null || state.a.Length == 0)
                return;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            int n = state.a.Length;
            int barWidth = panelWidth / (n * 2);
            if (barWidth <= 0) barWidth = 1;

            int maxVal = state.a.Max();
            if (maxVal == 0) maxVal = 1;

            int xStart = (panelWidth - n * barWidth * 2) / 2;

            using (Font font = new Font("Arial", 12, FontStyle.Bold))
            {
                // Định nghĩa các màu
                Brush normalBrush = Brushes.Blue;           // Màu mặc định
                Brush swapBrush = Brushes.Red;              // Màu đỏ - đang hoán vị
                Brush divideBrush = Brushes.Purple;         // Màu tím - đang chia (Merge Sort)
                Brush mergingBrush = Brushes.LimeGreen;     // Màu xanh lá - đang trộn (Merge Sort)
                Brush completedBrush = Brushes.Green;       // Màu xanh đậm - hoàn thành
                Brush textBrush = Brushes.Black;

                // Tính toán animation progress
                float t = 0f;
                if (state.Binh_b_DangAnimation && state.Binh_i_AnimationStepMax > 0)
                {
                    t = (float)state.Binh_i_AnimationStep / (float)state.Binh_i_AnimationStepMax;
                    t = Math.Min(Math.Max(t, 0f), 1f);
                }

                // Vẽ từng cột
                for (int i = 0; i < n; i++)
                {
                    float heightRatio = (float)state.a[i] / (float)maxVal;
                    int barHeight = (int)(heightRatio * (panelHeight - 100));

                    int baseX = xStart + i * barWidth * 2;
                    int x = baseX;

                    // Nếu đang animation thì nội suy vị trí
                    if (state.Binh_b_DangAnimation &&
                        (i == state.Binh_i_ViTriSwap1 || i == state.Binh_i_ViTriSwap2))
                    {
                        int indexFrom, indexTo;

                        if (i == state.Binh_i_ViTriSwap1)
                        {
                            indexFrom = state.Binh_i_ViTriSwap1;
                            indexTo = state.Binh_i_ViTriSwap2;
                        }
                        else
                        {
                            indexFrom = state.Binh_i_ViTriSwap2;
                            indexTo = state.Binh_i_ViTriSwap1;
                        }

                        int fromX = xStart + indexFrom * barWidth * 2;
                        int toX = xStart + indexTo * barWidth * 2;

                        x = (int)(fromX + (toX - fromX) * t);
                    }
                    int y = panelHeight - barHeight - 50;

                    // Chọn màu
                    Brush brushToUse = normalBrush;
                    if (state.Binh_b_DangAnimation)
                    {
                        // Đang animation hoán vị
                        if (i == state.Binh_i_ViTriSwap1 || i == state.Binh_i_ViTriSwap2)
                            brushToUse = swapBrush;
                    }
                    else if (i == state.Binh_i_ViTriSwap1)
                    {
                        // Highlight đặc biệt cho Merge Sort
                        // Dùng AnimationStep để phân biệt giai đoạn:
                        // 0 = Đang chia (Tím)
                        // 1 = Đang trộn (Xanh lá)
                        // 2 = Đang xét vùng (Cam)

                        if (state.Binh_i_AnimationStep == 0)
                            brushToUse = divideBrush;       // Tím - đang chia
                        else if (state.Binh_i_AnimationStep == 1)
                            brushToUse = mergingBrush;      // Xanh lá - đang trộn
                        else if (state.Binh_i_AnimationStep == 2)
                            brushToUse = Brushes.Orange;      // Cam - đang xét
                        else
                            brushToUse = swapBrush;         // Đỏ - hoán vị thông thường
                    }
                    else if (i == state.Binh_i_ViTriSwap2)
                        brushToUse = swapBrush;

                    // Vẽ cột
                    g.FillRectangle(brushToUse, x, y, barWidth, barHeight);

                    // Vẽ giá trị
                    string valueStr = state.a[i].ToString();
                    SizeF textSize = g.MeasureString(valueStr, font);
                    g.DrawString(valueStr, font, textBrush, x + (barWidth - textSize.Width) / 2, panelHeight - 40);
                }
            }
        }

        // Reset highlight - không highlight cột nào
        public void ResetHighlight()
        {
            state.Binh_i_ViTriSwap1 = -1;
            state.Binh_i_ViTriSwap2 = -1;
            state.Binh_b_DangAnimation = false;
            state.Binh_i_AnimationStep = 0;
        }

        // Highlight 2 cột
        public void HighlightColumns(int index1, int index2)
        {
            state.Binh_i_ViTriSwap1 = index1;
            state.Binh_i_ViTriSwap2 = index2;
        }

        // Highlight 1 cột với màu đặc biệt (cho Merge Sort)
        public void HighlightColumnWithState(int index, int colorState)
        {
            state.Binh_i_ViTriSwap1 = index;
            state.Binh_i_ViTriSwap2 = -1;
            state.Binh_i_AnimationStep = colorState; // 0=Cam, 1=Xanh lá, 2=Vàng
        }
    }
}
