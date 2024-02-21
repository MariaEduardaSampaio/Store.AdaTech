using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Requests
{
    public class ProdutoRequest
    {
        [Required]
        [MinLength(3), MaxLength(60)]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public decimal Preco { get; set; }
    }
}
