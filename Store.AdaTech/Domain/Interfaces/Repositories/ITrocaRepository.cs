using Store.AdaTech.Domain.Entities;

namespace Store.AdaTech.Domain.Interfaces.Repositories
{
    public interface ITrocaRepository
    {
        public void AdicionarTroca(Troca troca);
        public Troca? PegarTrocaPorID(int id);
        public IEnumerable<Troca>? ListarTrocas();
        public IEnumerable<Troca>? ListarTrocasDoCliente(string nomeCliente);
        public IEnumerable<Troca>? ListarTrocasPorValor(decimal valor);
    }
}
