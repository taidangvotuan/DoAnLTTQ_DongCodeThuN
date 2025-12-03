using System;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DoAnLTTQ_DongCodeThuN
{
    public partial class FormNhapMang : Form
    {
        #region KHAI BÁO BIẾN
        public int SoPhanTu { get; set; }
        public int[] Array { get; private set; }

        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 99;

        // Label để hiển thị lỗi real-time
        private Label lblError;
        private Label lblStatus;
        #endregion

        public FormNhapMang()
        {
            InitializeComponent();
            InitializeValidation();
        }

        private void FormNhapMang_Load(object sender, EventArgs e)
        {
            // Hiển thị hướng dẫn
            UpdateStatus($"Nhập {SoPhanTu} số nguyên, mỗi số cách nhau bằng dấu cách. VD: 5 12 8 3 15");
            TextBoxNhapMang.Focus();
        }

        private void InitializeValidation()
        {
            // Tạo label hiển thị lỗi (nếu chưa có trong Designer)
            if (lblError == null)
            {
                lblError = new Label
                {
                    AutoSize = false,
                    ForeColor = Color.Red,
                    Font = new Font("Arial", 10F, FontStyle.Regular),
                    Location = new Point(16, 235),
                    Size = new Size(720, 30),
                    Text = ""
                };
                this.Controls.Add(lblError);
            }

            if (lblStatus == null)
            {
                lblStatus = new Label
                {
                    AutoSize = false,
                    ForeColor = Color.Blue,
                    Font = new Font("Arial", 9F, FontStyle.Italic),
                    Location = new Point(16, 265),
                    Size = new Size(720, 20),
                    Text = ""
                };
                this.Controls.Add(lblStatus);
            }
            // Subscribe to TextBox events
            TextBoxNhapMang.TextChanged += TextBoxNhapMang_TextChanged;
            TextBoxNhapMang.KeyPress += TextBoxNhapMang_KeyPress;

            // Load event
            this.Load += FormNhapMang_Load;
        }

        #region Real-time Validation
        private void TextBoxNhapMang_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép: số, space, backspace, delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
                ShowError("Chỉ được nhập số và dấu cách!");
            }
        }

        private void TextBoxNhapMang_TextChanged(object sender, EventArgs e)
        {
            // Clear error khi user typing
            if (!string.IsNullOrWhiteSpace(TextBoxNhapMang.Text))
                ClearError();

            // Validate real-time
            ValidateInput(showDetailedErrors: false);
        }

        private bool ValidateInput(bool showDetailedErrors)
        {
            string input = TextBoxNhapMang.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(input))
            {
                if (showDetailedErrors)
                    UpdateStatus($"Vui lòng nhập {SoPhanTu} số");
                return false;
            }

            // 2. Tách chuỗi
            string[] parts = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // 3. Kiểm tra số lượng
            if (parts.Length < SoPhanTu)
            {
                UpdateStatus($"Đã nhập {parts.Length}/{SoPhanTu} số");
                return false;
            }

            if (parts.Length > SoPhanTu)
            {
                if (showDetailedErrors)
                    ShowError($"Bạn đã nhập {parts.Length} số, chỉ cần {SoPhanTu} số!");
                return false;
            }

            // 4. Validate từng số
            for (int i = 0; i < parts.Length; i++)
            {
                // Kiểm tra format số
                if (!int.TryParse(parts[i], out int value))
                {
                    if (showDetailedErrors)
                        ShowError($"Giá trị '{parts[i]}' tại vị trí {i + 1} không phải là số hợp lệ!");
                    return false;
                }

                // Kiểm tra khoảng giá trị
                if (value < MIN_VALUE || value > MAX_VALUE)
                {
                    if (showDetailedErrors)
                        ShowError($"Số {value} tại vị trí {i + 1} nằm ngoài khoảng [{MIN_VALUE}..{MAX_VALUE}]!");
                    return false;
                }
            }

            // 5. Tất cả hợp lệ
            UpdateStatus($"Đã nhập đúng {parts.Length} số hợp lệ");
            return true;
        }
        #endregion

        #region Advanced Validation
        private ValidationResult ValidateInputDetailed()
        {
            var result = new ValidationResult { IsValid = true };
            string input = TextBoxNhapMang.Text.Trim();

            // 1. Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(input))
            {
                result.IsValid = false;
                result.ErrorMessage = "Vui lòng nhập dữ liệu!";
                return result;
            }

            // 2. Kiểm tra ký tự không hợp lệ
            if (Regex.IsMatch(input, @"[^\d\s]"))
            {
                result.IsValid = false;
                result.ErrorMessage = "Chỉ được nhập số và dấu cách!";
                var invalidChars = Regex.Matches(input, @"[^\d\s]").Cast<Match>().Select(m => m.Value).Distinct();
                result.ErrorMessage += $"\nKý tự không hợp lệ: {string.Join(", ", invalidChars)}";
                return result;
            }

            // 3. Kiểm tra nhiều dấu cách liên tiếp
            if (Regex.IsMatch(input, @"\s{2,}"))
                result.Warning = "Phát hiện nhiều dấu cách liên tiếp (sẽ tự động loại bỏ)";

            // 4. Tách và validate
            string[] parts = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // 5. Kiểm tra số lượng
            if (parts.Length < SoPhanTu)
            {
                result.IsValid = false;
                result.ErrorMessage = $"Thiếu {SoPhanTu - parts.Length} số! (Đã nhập {parts.Length}/{SoPhanTu})";
                result.ErrorMessage += $"Bạn PHẢI nhập CHÍNH XÁC {SoPhanTu} số, không được thiếu!";
                return result;
            }

            if (parts.Length > SoPhanTu)
            {
                result.IsValid = false;
                result.ErrorMessage = $"Thừa {parts.Length - SoPhanTu} số! (Chỉ cần {SoPhanTu} số)";
                result.ErrorMessage += $"Bạn PHẢI nhập CHÍNH XÁC {SoPhanTu} số, không được thừa!";
                return result;
            }

            // 6. Validate từng giá trị
            var invalidValues = new System.Collections.Generic.List<string>();
            var outOfRangeValues = new System.Collections.Generic.List<string>();

            for (int i = 0; i < parts.Length; i++)
            {
                if (!int.TryParse(parts[i], out int value))
                    invalidValues.Add($"'{parts[i]}' (vị trí {i + 1})");
                else if (value < MIN_VALUE || value > MAX_VALUE)
                    outOfRangeValues.Add($"{value} (vị trí {i + 1})");
                else
                    result.Values.Add(value);
            }

            if (invalidValues.Count > 0)
            {
                result.IsValid = false;
                result.ErrorMessage = "Các giá trị không hợp lệ:\n" + string.Join(", ", invalidValues);
                return result;
            }

            if (outOfRangeValues.Count > 0)
            {
                result.IsValid = false;
                result.ErrorMessage = $"Các số nằm ngoài khoảng [{MIN_VALUE}..{MAX_VALUE}]:\n" +
                    string.Join(", ", outOfRangeValues);
                return result;
            }

            // 7. Kiểm tra trùng lặp (warning only)
            var duplicates = result.Values
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => $"{g.Key} (xuất hiện {g.Count()} lần)");

            if (duplicates.Any())
                result.Warning = "Phát hiện giá trị trùng lặp: " + string.Join(", ", duplicates);

            return result;
        }
        #endregion

        #region Button Events
        private void NutNhap_Click(object sender, EventArgs e)
        {
            // Validate chi tiết
            var validationResult = ValidateInputDetailed();

            if (!validationResult.IsValid)
            {
                ShowError(validationResult.ErrorMessage);
                TextBoxNhapMang.Focus();
                TextBoxNhapMang.SelectAll();
                return;
            }

            // Hiển thị warning nếu có
            if (!string.IsNullOrEmpty(validationResult.Warning))
            {
                var result = MessageBox.Show(
                    validationResult.Warning + "\n\nBạn có muốn tiếp tục?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    TextBoxNhapMang.Focus();
                    return;
                }
            }

            // Hiển thị preview trước khi confirm
            string preview = string.Join(" → ", validationResult.Values);
            var confirmResult = MessageBox.Show(
                $"Mảng đã nhập:\n\n{preview}\n\nXác nhận sử dụng mảng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // CẬP NHẬT MẢNG VÀO Form_main
                Form_main.a = Array;
                Form_main.so_phan_tu = Array.Length;

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion

        #region Helper Methods
        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.ForeColor = Color.Red;
            SystemSounds.Beep.Play();
        }

        private void ClearError()
        {
            lblError.Text = "";
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
        }
        #endregion

        #region Validation Result Class

        private class ValidationResult
        {
            public bool IsValid { get; set; }
            public string ErrorMessage { get; set; }
            public string Warning { get; set; }
            public System.Collections.Generic.List<int> Values { get; set; }

            public ValidationResult()
            {
                Values = new System.Collections.Generic.List<int>();
            }
        }
        #endregion
    }
}