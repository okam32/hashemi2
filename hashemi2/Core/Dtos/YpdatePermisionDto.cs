using System.ComponentModel.DataAnnotations;

namespace hashemi2.Core.Dtos
{
    public class YpdatePermisionDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
    }
}
