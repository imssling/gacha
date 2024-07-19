using gacha.Models;
using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class adminMetadata
    {
        [Display(Name = "管理員ID")]
        public int id { get; set; }

        [Display(Name = "帳號")]
        [Required(ErrorMessage = "帳號必填")]
        [StringLength(10)]
        public string account { get; set; }

        [Display(Name = "角色ID")]
        public int roleId { get; set; }

        [Display(Name = "信箱")]
        public string email { get; set; }

        [Display(Name = "連絡電話")]
        public string phoneNumber { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼必填")]
        [StringLength(10)]
        public string password { get; set; }

        [Display(Name = "角色")]
        public virtual role role { get; set; }

    }
}
