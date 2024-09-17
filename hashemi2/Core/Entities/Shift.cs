using System.ComponentModel.DataAnnotations;

namespace hashemi2.Core.Entities
{
    public class Shift
    {
        [Key]
        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
