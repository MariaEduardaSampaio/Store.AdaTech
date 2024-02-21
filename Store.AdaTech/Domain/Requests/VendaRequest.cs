using Store.AdaTech.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Requests
{
    public class VendaRequest
    {
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public List<int> IdProdutos { get; set; }
    }
}
