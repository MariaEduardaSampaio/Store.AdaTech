using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        public Produto AdicionarProduto(ProdutoRequest produto);
        public Produto? PegarProdutoPorID(int id);
        public IEnumerable<Produto>? ListarProdutos();
        public IEnumerable<Produto>? ListarProdutosPorValor(decimal valor);
    }
}
