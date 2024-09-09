using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hashemi2.Core.Entities
{
    public class Good
    {
        [Key]
        public int Id { get; set; }
        public string GoodName { get; set; }
        public string GoodNO { get; set; }
        public string SerialNO { get; set; }
        public string CurrentLocation { get; set; }
        public string Description { get; set; }


        public int StockId { get; set; }
        [ForeignKey("StockId")]
        public Stock GoodStock { get; set; }
    }
}
