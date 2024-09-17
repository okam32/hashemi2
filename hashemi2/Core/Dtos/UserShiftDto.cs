using hashemi2.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace hashemi2.Core.Dtos
{
    public class UserShiftDto
    {
        public string UserName { get; set; }
        public int ShiftId { get; set; }
        public string ShiftDate { get; set; }
        
    }
}
