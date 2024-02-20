using Store.AdaTech.Domain.Entities;

namespace Store.AdaTech.Domain.Interfaces.Repositories
{
    public interface IDevolucaoRepository
    {
        public void AdicionarDevolucao(Devolucao devolucao);
        public Devolucao? PegarDevolucaoPorID(int id);
        public IEnumerable<Devolucao>? ListarDevolucoes();
        public IEnumerable<Devolucao>? ListarDevolucoesDoCliente(string nomeCliente);
        public IEnumerable<Devolucao>? ListarDevolucoesPorEstorno(decimal valor);
    }
}
