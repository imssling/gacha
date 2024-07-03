using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class userInfoMetaData
    {
        [Display(Name = "帳號ID")]
        public int id { get; set; }

        [Required(ErrorMessage = "使用者名稱必填")]
        [Display(Name = "名稱")]
        [StringLength(15)]
        public string userName { get; set; }


        [Display(Name = "手機號碼")]
        [StringLength(15)]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "電子郵件必填")]
        [Display(Name = "電子郵件")]
        [StringLength(200)]
        public string email { get; set; }
        [Required(ErrorMessage = "收貨地址必填")]
        [Display(Name = "收貨地址")]
        [StringLength(100)]
        public string address { get; set; }

        [Display(Name = "性別")]
        [StringLength(8)]
        public string gender { get; set; }

        [Display(Name = "驗證郵件")]
        public bool? emailConfirm { get; set; }
    }
}
