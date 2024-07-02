//using gacha.Models;
using System.ComponentModel.DataAnnotations;


namespace gacha.Metadatas
{
    public class trackingListMetaData
    {
       
        public int userId { get; set; }

        public int gachaMachineId { get; set; }

        public DateTime? trackingDate { get; set; }

        public string noteStatus { get; set; }

        
    }
}
