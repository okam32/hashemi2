using hashemi2.Core.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hashemi2.Core.Entities
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public string StockName { get; set; }
        public string StockOwnerUserName { get; set; }
        public List<Good> Goods { get; set; }

        
    }
}
