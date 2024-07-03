using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class userInfoMetaData
    {
        [Display(Name = "帳號ID")]
        public int id { get; set; }

        [Display(Name = "名稱")]
        [Required(ErrorMessage = "使用者名稱必填")]
        [StringLength(15)]
        public string userName { get; set; }


        [Display(Name = "手機號碼")]
        [Required(ErrorMessage = "手機號碼必填")]
        [RegularExpression(@"09\d{8}$", ErrorMessage ="手機號碼格式錯誤,09XXX XXXXX")]
        [StringLength(10)]
        public string phoneNumber { get; set; }

        [Display(Name = "電子郵件")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "電子郵件格式錯誤")]
        [Required(ErrorMessage = "電子郵件必填")]
        [StringLength(200)]
        public string email { get; set; }

        [Display(Name = "收貨地址")]
        [Required(ErrorMessage = "收貨地址必填")]
        [StringLength(100)]
        public string address { get; set; }

        [Display(Name = "性別")]
        [Required(ErrorMessage = "性別必選")]
        [StringLength(8)]
        public string gender { get; set; }

        [Display(Name = "驗證郵件")]
        public bool? emailConfirm { get; set; }
    }
}
