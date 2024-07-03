using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class shippingMetaData
    {
        [Display(Name = "出貨ID")]
        [Required(ErrorMessage = "出貨ID必填")]
        
        public int id { get; set; }

        [Display(Name = "使用者ID")]
        [Required(ErrorMessage = "使用者ID必填")]
        public int userId { get; set; }

        [Display(Name = "出貨日期")]
        [Required(ErrorMessage = "出貨日期必填")]
        public DateTime? shippingDate { get; set; }


        [Display(Name = "出貨狀態")]
        [Required(ErrorMessage = "出貨狀態必填")]
        [StringLength(10)]
        public string shippingStatus { get; set; }
        [Display(Name = "配送地址")]
        [Required(ErrorMessage = "配送地址必填")]
        [StringLength(200)]
        public string shippingAddress { get; set; }
        [Display(Name = "聯絡電話")]
        [Required(ErrorMessage = "聯絡電話必填")]
        [StringLength(15)]
        public string contactPhone { get; set; }
        [Display(Name = "運送方式")]
        [Required(ErrorMessage = "運送方式必填")]
        [StringLength(10)]
        public string shippingMethod { get; set; }
        [Display(Name = "運費")]
        [Range(0,1000)]
        [Required(ErrorMessage = "運費必填,最低$0!")]
        public int shippingFee { get; set; }
    }
}
