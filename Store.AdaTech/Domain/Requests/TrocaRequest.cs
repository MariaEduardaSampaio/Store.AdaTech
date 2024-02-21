using Store.AdaTech.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Requests
{
    public class TrocaRequest
    {
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public List<int> IdProdutosAnteriores { get; set; }
        [Required]
        public List<int> IdProdutosAtuais { get; set; }
    }
}
