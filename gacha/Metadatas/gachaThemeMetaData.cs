using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class gachaThemeMetaData
    {
        [Display(Name = "主題ID")]
        [Required(ErrorMessage = "主題ID必填")]
        public int id { get; set; }

        [Display(Name = "主題名稱")]
        [Required(ErrorMessage = "主題名稱必填")]
        public string themeName { get; set; }

        [Display(Name = "狀態")]
        [Required(ErrorMessage = "狀態必填")]
        public string status { get; set; }
    }
}
