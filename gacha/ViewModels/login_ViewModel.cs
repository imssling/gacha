using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class login_ViewModel
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(30)]
        public string account { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [StringLength(20)]
        public string password { get; set; }
    }
}
