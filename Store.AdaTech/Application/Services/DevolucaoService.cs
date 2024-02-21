using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Services
{
    public class DevolucaoService : IDevolucaoService
    {
        private IDevolucaoRepository _repository { get; set; }
        private IProdutoRepository _produtoRepository { get; set; }
        private static int _contadorId;
        public DevolucaoService(IDevolucaoRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _contadorId = _repository.ListarDevolucoes()?.Any() == true ? _repository.ListarDevolucoes().Last().Id + 1 : 0;
        }

        public Devolucao AdicionarDevolucao(DevolucaoRequest request)
        {
            decimal estorno = 0;
            var produtos = ValidarListaDeProdutos(request.IdProdutos);
            produtos.ForEach(produto => estorno += produto.Preco);

            Devolucao devolucao = new()
            {
                Id = _contadorId++,
                NomeCliente = request.NomeCliente,
                Produtos = produtos,
                Estorno = estorno,
                RealizadaEm = DateTime.Now
            };

            _repository.AdicionarDevolucao(devolucao);
            return devolucao;
        }

        public List<Produto> ValidarListaDeProdutos(List<int> idProdutos)
        {
            List<Produto> produtos = new();

            foreach (var idProduto in idProdutos)
            {
                var produto = _produtoRepository.PegarProdutoPorID(idProduto);
                if (produto is not null)
                    produtos.Add(produto);
                else
                    throw new ArgumentException("Não existe um produto com este ID.");
            }

            return produtos;
        }

        public Devolucao? PegarDevolucaoPorID(int id)
        {
            return _repository.PegarDevolucaoPorID(id);
        }

        public IEnumerable<Devolucao>? ListarDevolucoes()
        {
            return _repository.ListarDevolucoes();
        }

        public IEnumerable<Devolucao>? ListarDevolucoesDoCliente(string nomeCliente)
        {
            return _repository.ListarDevolucoesDoCliente(nomeCliente);
        }

        public IEnumerable<Devolucao>? ListarDevolucoesPorEstorno(decimal valor)
        {
            return _repository.ListarDevolucoesPorEstorno(valor);
        }
    }
}
