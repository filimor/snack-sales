using System.ComponentModel.DataAnnotations;

namespace SnackSales.ViewModels
{
    public class LoginViewModel
    {
        [Required] [Display(Name = "Usuário")] public string Username { get; set; }

        [Required]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}