using hashemi2.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace hashemi2.Core.Dtos
{
    public class UserShiftDto
    {
        public string UserName { get; set; }
        public string Personal1 { get; set; }
        public string Personal2 { get; set; }
        public string Personal3 { get; set; }
        public int ShiftId { get; set; }
        public string ShiftDate { get; set; }
        public List<ApplicationUser> MyUser { get; set; }

    }
}
