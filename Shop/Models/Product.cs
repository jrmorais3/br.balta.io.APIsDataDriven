using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Esse campo deve entre 3 e 60 caracteres")]
        [MinLength(300, ErrorMessage = "Esse campo deve entre 3 e 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Esse campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "o preço deve ser maior que zero")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida")]
        public int categoryId { get; set; }

        public Category category { get; set; }
    }
}
