using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo deve entre 3 e 60 caracteres")]
        [MinLength(300, ErrorMessage = "Esse campo deve entre 3 e 60 caracteres")]
        public string Title { get; set; }

    }
}
