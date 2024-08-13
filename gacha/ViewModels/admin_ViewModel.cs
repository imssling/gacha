using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class admin_ViewModel
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(30, ErrorMessage = " 最多30個字")]
        public string account { get; set; }

        [Display(Name = "名稱")]
        [Required(ErrorMessage = "名稱必填")]
        [StringLength(10, ErrorMessage = " 最多10個字")]
        public string name { get; set; }


        [Display(Name = "角色ID")]
        [Required(ErrorMessage = "角色ID必選")]
        public int roleId { get; set; }

        [Display(Name = "角色稱號")]
        //[Required(ErrorMessage = "角色稱號必選")]
        public string? title { get; set; }


        [Display(Name = "信箱")]
        [Required(ErrorMessage = "信箱必填")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "請輸入有效的電子郵件地址")]
        [StringLength(50, ErrorMessage = " 最長50個字")]
        public string email { get; set; }

        [Display(Name = "電話")]
        [Required(ErrorMessage = "電話必填")]
        [RegularExpression(@"^09\d{8}$", ErrorMessage = "請輸入有效的台灣手機號碼，格式為09開頭的十位數字")]
        [StringLength(10, ErrorMessage = "請輸入有效的台灣手機號碼，格式為09開頭的十位數字")]
        public string phoneNumber { get; set; }


        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$",
            ErrorMessage = "密碼必須至少6個字符長, 且包含數字和特殊字符")]
        public string password { get; set; }


        [Display(Name = "確認密碼")]
        [Required(ErrorMessage = "確認密碼必填")]
        [Compare("password", ErrorMessage = "新密碼和確認密碼不同")]
        public string confirmPassword { get; set; }
    }
}
