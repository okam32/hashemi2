using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hashemi2.Core.Entities
{
    public class Request
    {
        [Key]
        public int ID { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public int GoodId { get; set; }
        [ForeignKey("GoodId")]
        public Good Good { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event Event { get; set; }
    }
}
