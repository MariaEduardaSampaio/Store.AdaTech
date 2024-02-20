using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Domain.Interfaces.Services
{
    public interface IDevolucaoService
    {
        public Devolucao AdicionarDevolucao(DevolucaoRequest devolucao);
        public Devolucao? PegarDevolucaoPorID(int id);
        public IEnumerable<Devolucao>? ListarDevolucoes();
        public IEnumerable<Devolucao>? ListarDevolucoesDoCliente(string nomeCliente);
        public IEnumerable<Devolucao>? ListarDevolucoesPorEstorno(decimal valor);
    }
}
