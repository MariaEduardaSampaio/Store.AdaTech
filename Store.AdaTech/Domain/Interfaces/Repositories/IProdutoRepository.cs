using Store.AdaTech.Domain.Entities;

namespace Store.AdaTech.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        public void AdicionarProduto(Produto produto);
        public Produto? PegarProdutoPorID(int id);
        public IEnumerable<Produto>? ListarProdutos();
        public IEnumerable<Produto>? ListarProdutosPorValor(decimal valor);
    }
}
