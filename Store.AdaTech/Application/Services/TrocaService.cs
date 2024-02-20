using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Services
{
    public class TrocaService: ITrocaService
    {
        private static int _contadorId = 0;

        public ITrocaRepository _repository { get; set; }
        public TrocaService(ITrocaRepository repository)
        {
            _repository = repository;
        }

        public Troca AdicionarTroca(TrocaRequest request)
        {
            decimal valorTotalProdutosAtuais = 0, valorTotalProdutosAnteriores = 0;
            request.ProdutosAtuais.ForEach(produto => valorTotalProdutosAtuais += produto.Preco);
            request.ProdutosAnteriores.ForEach(produto => valorTotalProdutosAnteriores += produto.Preco);

            Troca troca = new()
            {
                Id = _contadorId++,
                NomeCliente = request.NomeCliente,
                ProdutosAnteriores = request.ProdutosAnteriores,
                ProdutosAtuais = request.ProdutosAtuais,
                RealizadaEm = DateTime.Now,
                Diferenca = valorTotalProdutosAtuais - valorTotalProdutosAnteriores,
                ValorTotal = valorTotalProdutosAtuais
            };

            _repository.AdicionarTroca(troca);
            return troca;
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
