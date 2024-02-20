using Store.AdaTech.Domain.Entities;

namespace Store.AdaTech.Domain.Interfaces.Repositories
{
    public interface IVendaRepository
    {
        public void AdicionarVenda(Venda venda);
        public Venda? PegarVendaPorID(int id);
        public IEnumerable<Venda>? ListarVendas();
        public IEnumerable<Venda>? ListarVendasDoCliente(string nomeCliente);
        public IEnumerable<Venda>? ListarVendasPorValor(decimal valor);
    }
}
