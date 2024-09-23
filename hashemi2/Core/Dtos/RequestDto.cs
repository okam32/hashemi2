using hashemi2.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace hashemi2.Core.Dtos
{
    public class RequestDto
    {
        public string UserId { get; set; }
      
        public int GoodId { get; set; }
        
        public int EventId { get; set; }
        
    }
}
