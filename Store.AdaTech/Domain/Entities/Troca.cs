using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Entities
{
    public class Troca
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public List<Produto> ProdutosAnteriores { get; set; }
        [Required]
        public List<Produto> ProdutosAtuais { get; set; }
        [Required]
        public decimal ValorTotal { get; set; }
        [Required]
        public decimal Diferenca { get; set; }
        [Required]
        public DateTime RealizadaEm { get; set; }
    }
}
