using gacha.Models;
using System.ComponentModel.DataAnnotations;

namespace gacha.ViewModels
{
    public class shipping_vm
    {
        //shipping表
        public int id { get; set; }

        //[Display(Name = "玩家")]
        //public virtual userInfo user { get; set; }
        //[Display(Name = "訂購人ID")]
        //public int userId { get; set; }

        //shippingDetail表
        //[Display(Name = "背包ID")]

        //public int bagId { get; set; }

        [Display(Name = "數量")]
        public int myquantity { get; set; }

        //gachaProduct
        [Display(Name = "商品名稱")]

        public string productName { get; set; }

        [Display(Name = "商品ID")]
        public int productId { get; set; }

    }
}
