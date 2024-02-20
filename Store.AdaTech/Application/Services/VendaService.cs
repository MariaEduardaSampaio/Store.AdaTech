using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Services
{
    public class VendaService: IVendaService
    {
        private static int _contadorId = 0;

        public IVendaRepository _repository { get; set; }
        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }

        public Venda AdicionarVenda(VendaRequest request)
        {
            decimal valorTotal = 0;
            request.Produtos.ForEach(produto => valorTotal += produto.Preco);

            Venda venda = new()
            {
                Id = _contadorId++,
                NomeCliente = request.NomeCliente,
                Produtos = request.Produtos,
                RealizadaEm = DateTime.Now,
                ValorTotal = valorTotal
            };

            _repository.AdicionarVenda(venda);
            return venda;
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
