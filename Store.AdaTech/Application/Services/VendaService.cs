using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;
using Store.AdaTech.Infrastructure.Repositories;

namespace Store.AdaTech.Application.Services
{
    public class VendaService: IVendaService
    {
        private static int _contadorId;

        public IVendaRepository _repository { get; set; }
        public IProdutoRepository _produtoRepository { get; set; }
        public VendaService(IVendaRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _produtoRepository = produtoRepository;
            _contadorId = _repository.ListarVendas()?.Any() == true ? _repository.ListarVendas().Last().Id + 1 : 0;
        }

        public Venda AdicionarVenda(VendaRequest request)
        {
            decimal valorTotal = 0;
            var produtos = ValidarListaDeProdutos(request.IdProdutos);
            produtos.ForEach(produto => valorTotal += produto.Preco);

            Venda venda = new()
            {
                Id = _contadorId++,
                NomeCliente = request.NomeCliente,
                Produtos = produtos,
                RealizadaEm = DateTime.Now,
                ValorTotal = valorTotal
            };

            _repository.AdicionarVenda(venda);
            return venda;
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

        public Venda? PegarVendaPorID(int id)
        {
            return _repository.PegarVendaPorID(id);
        }

        public IEnumerable<Venda>? ListarVendas()
        {
            return _repository.ListarVendas();
        }

        public IEnumerable<Venda>? ListarVendasDoCliente(string nomeCliente)
        {
            return _repository.ListarVendasDoCliente(nomeCliente);
        }

        public IEnumerable<Venda>? ListarVendasPorValor(decimal valor)
        {
            return _repository.ListarVendasPorValor(valor);
        }
    }
}
