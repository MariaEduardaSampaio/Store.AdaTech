using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private static int _contadorId;

        public IProdutoRepository _repository { get; set; }
        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
            _contadorId = _repository.ListarProdutos()?.Any() == true ? _repository.ListarProdutos().Last().Id + 1 : 0;
        }

        public Produto AdicionarProduto(ProdutoRequest request)
        {
            Produto produto = new()
            {
                Id = _contadorId++,
                Nome = request.Nome,
                Descricao = request.Descricao,
                Preco = request.Preco
            };

            _repository.AdicionarProduto(produto);
            return produto;
        }

        public Produto? PegarProdutoPorID(int id)
        {
            return _repository.PegarProdutoPorID(id);
        }

        public IEnumerable<Produto>? ListarProdutos()
        {
            return _repository.ListarProdutos();
        }

        public IEnumerable<Produto>? ListarProdutosPorValor(decimal valor)
        {
            return _repository.ListarProdutosPorValor(valor);
        }
    }
}
