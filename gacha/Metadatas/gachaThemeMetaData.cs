using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class gachaThemeMetaData
    {
        [Display(Name = "主題ID")]
        public int id { get; set; }

        [Display(Name = "主題名稱")]
        public string themeName { get; set; }
    }
}
