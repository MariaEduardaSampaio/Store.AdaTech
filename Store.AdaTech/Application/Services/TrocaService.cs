using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;
using Store.AdaTech.Infrastructure.Repositories;

namespace Store.AdaTech.Application.Services
{
    public class TrocaService: ITrocaService
    {
        private static int _contadorId = 0;

        public ITrocaRepository _repository { get; set; }
        private IProdutoRepository _produtoRepository { get; set; }

        public TrocaService(ITrocaRepository repository, IProdutoRepository produtoRepository)
        {
            _repository = repository;
            _contadorId = _repository.ListarTrocas()?.Any() == true ? _repository.ListarTrocas().Last().Id + 1 : 0;
            _produtoRepository = produtoRepository;
        }

        public Troca AdicionarTroca(TrocaRequest request)
        {
            decimal valorTotalProdutosAtuais = 0, valorTotalProdutosAnteriores = 0;
            var produtosAnteriores = ValidarListaDeProdutos(request.IdProdutosAnteriores);
            var produtosAtuais = ValidarListaDeProdutos(request.IdProdutosAtuais);
            produtosAtuais.ForEach(produto => valorTotalProdutosAtuais += produto.Preco);
            produtosAnteriores.ForEach(produto => valorTotalProdutosAnteriores += produto.Preco);

            var diferenca = valorTotalProdutosAtuais - valorTotalProdutosAnteriores;
            if (diferenca < 0)
                throw new ArgumentException("Só é possível trocar produtos por uma compra de valor igual ou maior que o total anterior.");

            Troca troca = new()
            {
                Id = _contadorId++,
                NomeCliente = request.NomeCliente,
                ProdutosAnteriores = produtosAnteriores,
                ProdutosAtuais = produtosAtuais,
                RealizadaEm = DateTime.Now,
                Diferenca = diferenca,
                ValorTotal = valorTotalProdutosAtuais
            };

            _repository.AdicionarTroca(troca);
            return troca;
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

        public Troca? PegarTrocaPorID(int id)
        {
            return _repository.PegarTrocaPorID(id);
        }

        public IEnumerable<Troca>? ListarTrocas()
        {
            return _repository.ListarTrocas();
        }

        public IEnumerable<Troca>? ListarTrocasDoCliente(string nomeCliente)
        {
            return _repository.ListarTrocasDoCliente(nomeCliente);
        }

        public IEnumerable<Troca>? ListarTrocasPorValor(decimal valor)
        {
            return _repository.ListarTrocasPorValor(valor);
        }
    }
}
