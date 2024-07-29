using gacha.Models;
using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class adminMetadata
    {
        [Display(Name = "帳號")]
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(30, ErrorMessage = "帳號長度不能超過 30 個字元")]
        public string account { get; set; }

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string name { get; set; }

        [Display(Name = "權限")]
        [Required(ErrorMessage = "權限必填")]
        public int roleId { get; set; }

        [Display(Name = "信箱")]
        [Required(ErrorMessage = "信箱必填")]

        public string email { get; set; }

        [Display(Name = "手機")]
        [Required(ErrorMessage = "手機必填")]
        public string phoneNumber { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼必填")]
        public string password { get; set; }
    }
}
