using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Domain.Interfaces.Services
{
    public interface ITrocaService
    {
        public Troca AdicionarTroca(TrocaRequest troca);
        public Troca? PegarTrocaPorID(int id);
        public IEnumerable<Troca>? ListarTrocas();
        public IEnumerable<Troca>? ListarTrocasDoCliente(string nomeCliente);
        public IEnumerable<Troca>? ListarTrocasPorValor(decimal valor);
    }
}
