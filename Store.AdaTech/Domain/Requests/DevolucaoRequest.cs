using Store.AdaTech.Domain.Entities;

namespace Store.AdaTech.Domain.Requests
{
    public class DevolucaoRequest
    {
        public string NomeCliente { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
