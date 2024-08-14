using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class roleMetadata
    {
        [Display(Name = "管理ID")]
        [Required(ErrorMessage = "管理ID必填")]
        [Range(1, int.MaxValue, ErrorMessage = "管理ID必須大於或等於1")]
        public int id { get; set; }


        [Display(Name = "管理名稱")]
        [Required(ErrorMessage = "管理名稱必填")]
        [StringLength(20, ErrorMessage = " 最多20個字")]
        public string title { get; set; }
    }
}
