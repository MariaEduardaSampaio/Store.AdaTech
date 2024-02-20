using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Services
{
    public class DevolucaoService: IDevolucaoService
    {
        private static int _contadorId = 0;
        private IDevolucaoRepository _repository { get; set; }
        public DevolucaoService(IDevolucaoRepository repository)
        {
            _repository = repository;
        }

        public Devolucao AdicionarDevolucao(DevolucaoRequest request)
        {
            decimal estorno = 0;
            request.Produtos.ForEach(produto => estorno += produto.Preco);

            Devolucao devolucao = new()
            {
                Id = _contadorId++,
                NomeCliente = request.NomeCliente,
                Produtos = request.Produtos,
                Estorno = estorno,
                RealizadaEm = DateTime.Now
            };

            _repository.AdicionarDevolucao(devolucao);
            return devolucao;
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
