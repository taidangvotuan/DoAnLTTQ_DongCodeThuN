using System;

namespace DoAnLTTQ_DongCodeThuN.Services
{
    public class DataGeneratorService
    {
        private readonly Random random;

        public DataGeneratorService()
        {
            random = new Random();
        }

        // Sinh mảng ngẫu nhiên
        public int[] GenerateRandomArray(int size)
        {
            if (size < 2 || size > 45)
                throw new ArgumentException("Số phần tử phải từ 2 đến 45");

            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
                arr[i] = random.Next(100); // Giá trị từ 0-99

            return arr;
        }

        // Validate mảng nhập bằng tay
        public bool ValidateManualArray(int[] arr)
        {
            if (arr == null || arr.Length < 2 || arr.Length > 45)
                return false;

            foreach (int val in arr)
            {
                if (val < 0 || val > 99)
                    return false;
            }
            return true;
        }

        // Parse string thành mảng
        public int[] ParseArrayFromString(string input, int expectedSize)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Chuỗi nhập rỗng");

            string[] parts = input.Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                throw new ArgumentException("Phải có ít nhất 2 số");

            if (parts.Length > expectedSize)
                throw new ArgumentException($"Bạn đã nhập quá {expectedSize} phần tử");

            int[] arr = new int[expectedSize];

            for (int i = 0; i < parts.Length; i++)
                if (!int.TryParse(parts[i], out arr[i]) || arr[i] < 0 || arr[i] > 99)
                    throw new ArgumentException($"Giá trị thứ {i + 1} không hợp lệ (0-99)");

            // Gán phần còn lại = 0
            for (int i = parts.Length; i < expectedSize; i++)
                arr[i] = 0;
            return arr;
        }
    }
}
