using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class User
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve possuir até 20 caractere")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir acima de 3 caractere")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve possuir até 20 caractere")]
        [MinLength(3, ErrorMessage = "Este campo deve possuir acima de 3 caractere")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
