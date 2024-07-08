using gacha.Models;
using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class gachaProductMetadata
    {
        [Display(Name = "商品ID")]
        public int id { get; set; }

        [Display(Name = "隸屬機台")]
        public int machineId { get; set; }

        [Display(Name = "隸屬機台")]
        public virtual gachaMachine machine { get; set; }

        [Display(Name = "商品名稱")]
        [Required(ErrorMessage = "商品名稱必填")]
        public string productName { get; set; }

        [Range(1, 5000)]
        [Display(Name = "庫存")]
        [Required(ErrorMessage = "庫存必填")]
        public int stock { get; set; }

        [Display(Name = "照片名稱")]
        //[Required(ErrorMessage = "照片名稱必填")]
        public string productPictureName { get; set; }

        [Display(Name = "創建時間")]
        public DateTime? createTime { get; set; }

    }
}
