using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hashemi2.Core.Entities
{
    public class UserShift
    {
        [Key]
        public int UserShiftId { get; set; }
        public string UserName { get; set; }
        public string Personal1 {  get; set; }
        public string Personal2 {  get; set; }
        public string Personal3 { get; set; }
        public int ShiftId { get; set; }
        public string ShiftDate { get; set; }
        [ForeignKey("ShiftId")]
        public Shift USerShift { get; set; }
    }
}
