namespace DoAnLTTQ_DongCodeThuN.Models
{
    public class SortingState
    {
        public int[] a { get; set; }                    // Mảng dữ liệu
        public int so_phan_tu { get; set; }             // Số phần tử
        public int toc_Do { get; set; }                 // Tốc độ (1-10)
        public bool tang { get; set; }                  // true: tăng dần, false: giảm dần
        public bool da_Tao_Mang { get; set; }           // Đã tạo mảng chưa
        public bool kt_tam_dung { get; set; }           // Kiểm tra tạm dừng
        public bool is_run { get; set; }                // Đang chạy thuật toán

        // Biến animation
        public int Binh_i_ViTriSwap1 { get; set; }      // Vị trí swap 1
        public int Binh_i_ViTriSwap2 { get; set; }      // Vị trí swap 2
        public bool Binh_b_DangAnimation { get; set; }  // Đang animation
        public int Binh_i_AnimationStep { get; set; }   // Bước animation hiện tại
        public int Binh_i_AnimationStepMax { get; set; }// Số bước animation tối đa

        // Biến đếm bước
        public int Thinh_dem_buoc { get; set; }         // Đếm số bước

        public SortingState()
        {
            a = new int[0];
            so_phan_tu = 0;
            toc_Do = 4;
            tang = true;
            da_Tao_Mang = false;
            kt_tam_dung = false;
            is_run = false;

            Binh_i_ViTriSwap1 = -1;
            Binh_i_ViTriSwap2 = -1;
            Binh_b_DangAnimation = false;
            Binh_i_AnimationStep = 0;
            Binh_i_AnimationStepMax = 1;

            Thinh_dem_buoc = 0;
        }

        // Copy array để tránh thay đổi dữ liệu gốc
        public int[] GetArrayCopy()
        {
            if (a == null || a.Length == 0) return new int[0];

            int[] copy = new int[a.Length];
            System.Array.Copy(a, copy, a.Length);
            return copy;
        }

        // Reset trạng thái
        public void Reset()
        {
            kt_tam_dung = false;
            is_run = false;
            Binh_b_DangAnimation = false;
            Binh_i_ViTriSwap1 = -1;
            Binh_i_ViTriSwap2 = -1;
            Thinh_dem_buoc = 0;
        }
    }
}

