using Store.AdaTech.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.AdaTech.Domain.Requests
{
    public class DevolucaoRequest
    {
        [Required]
        [MinLength(3), MaxLength(60)]
        public string NomeCliente { get; set; }
        [Required]
        public List<int> IdProdutos { get; set; }
    }
}
