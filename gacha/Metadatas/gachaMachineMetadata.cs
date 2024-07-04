﻿using gacha.Models;
using System.ComponentModel.DataAnnotations;

namespace gacha.Metadatas
{
    public class gachaMachineMetadata
    {
        [Display(Name = "機台ID")]
        public int id { get; set; }

        [Display(Name = "主題名稱")]
        public int themeId { get; set; }

        [Display(Name = "機台名稱")]
        [Required(ErrorMessage = "機台名稱必填")]
        public string? machineName { get; set; }

        [Display(Name = "機台詳細資訊")]
        public string? machineDescription { get; set; }

        [Display(Name = "相片名稱")]
        public string? machinePictureName { get; set; }

        [Display(Name = "創建時間")]
        public DateTime? createTime { get; set; }

        [Range(1, 5000, ErrorMessage = "範圍為1-5000")]
        [Display(Name = "價錢")]
        [Required(ErrorMessage = "價錢必填")]
        public int price { get; set; }

        [Display(Name = "主題")]
        public virtual gachaTheme theme { get; set; }

        [Display(Name = "啟用")]
        public bool status { get; set; }
    }
}
