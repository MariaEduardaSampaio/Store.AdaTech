using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Domain.Interfaces.Services
{
    public interface IVendaService
    {
        public Venda AdicionarVenda(VendaRequest venda);
        public Venda? PegarVendaPorID(int id);
        public IEnumerable<Venda>? ListarVendas();
        public IEnumerable<Venda>? ListarVendasDoCliente(string nomeCliente);
        public IEnumerable<Venda>? ListarVendasPorValor(decimal valor);
    }
}
