using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCSite.Models
{
    public class LoginViewModel
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Обязательный атрибут (Логин)")]
        [EmailAddress]
        [StringLength(30, MinimumLength = 10 ,ErrorMessage = "Недопустимая длина")]
        //[RegularExpression("^[a-zA-Z0-9]")]
        public string Login { get; set; }

        [Required]
        [StringLength(20)]
        [Compare("PasswordConfirm")]
        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
