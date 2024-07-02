using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{

    public class permissionMetaData
    {
        [Display(Name = "權限ID")]
        
        public int id { get; set; }

        [Display(Name = "權限功能名稱")]
        [Required(ErrorMessage = "權限功能名稱必填")]
        public string permissionDesc { get; set; }
    }
}
