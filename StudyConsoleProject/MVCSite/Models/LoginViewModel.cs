using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSite.Models
{
    public class LoginViewModel
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Обязательный атрибут (Логин)")]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
