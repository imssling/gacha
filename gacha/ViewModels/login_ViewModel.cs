using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class login_ViewModel
    {
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(10)]
        [Display(Name = "帳號")]
        public string account { get; set; }

        [Required(ErrorMessage = "密碼必填")]
        [Display(Name = "密碼")]
        public string password { get; set; }
    }
}
