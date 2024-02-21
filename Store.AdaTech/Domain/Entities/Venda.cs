using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Entities
{
    public class Venda
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public List<Produto> Produtos { get; set; }
        [Required]
        public decimal ValorTotal {  get; set; }
        [Required]
        public DateTime RealizadaEm { get; set; }
    }
}
