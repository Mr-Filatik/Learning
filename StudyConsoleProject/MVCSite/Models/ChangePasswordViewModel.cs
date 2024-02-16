using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSite.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string OldPassword { get; set; }

        [Required]
        public string NewPassword { get; set; }
    }
}
