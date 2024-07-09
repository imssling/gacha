using gacha.Models;
using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class activityTypeMetaData
    {
        [Display(Name = "活動類別ID")]
        public int id { get; set; }

        [Display(Name = "活動名稱")]
        [Required(ErrorMessage = "活動名稱必填")]
        public string name { get; set; }

        [Display(Name = "創建日期")]
        //[Required(ErrorMessage = "日期必填")]
        public DateTime? createdAt { get; set; }
    }
}
