using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class admin_ViewModel
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(30, ErrorMessage =" 最多30個字")]
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
        public string title { get; set; }


        [Display(Name = "信箱")]
        [Required(ErrorMessage = "信箱必填")]
        [StringLength(50, ErrorMessage = " 最長50個字")]
        public string email { get; set; }

        [Display(Name = "電話")]
        [Required(ErrorMessage = "電話必填")]
        [StringLength(20, ErrorMessage = " 最長20個字")]
        public string phoneNumber { get; set; }


        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string password { get; set; }
    }
}
