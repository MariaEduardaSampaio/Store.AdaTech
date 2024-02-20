using Store.AdaTech.Domain.Entities;

namespace Store.AdaTech.Domain.Requests
{
    public class TrocaRequest
    {
        public string NomeCliente { get; set; }
        public List<Produto> ProdutosAnteriores { get; set; }
        public List<Produto> ProdutosAtuais { get; set; }
    }
}
