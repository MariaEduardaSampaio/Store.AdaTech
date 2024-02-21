using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Entities
{
    public class Devolucao
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public List<Produto> Produtos { get; set; }
        [Required]
        public decimal Estorno { get; set; }
        [Required]
        public DateTime RealizadaEm { get; set; }
    }
}
