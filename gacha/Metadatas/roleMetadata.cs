using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class roleMetadata
    {
        [Display(Name = "管理ID")]
        public int id { get; set; }
        [Display(Name = "管理名稱")]
        public string title { get; set; }
    }
}
