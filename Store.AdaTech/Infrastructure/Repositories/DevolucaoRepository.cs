using Newtonsoft.Json;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;

namespace Store.AdaTech.Infrastructure.Repositories
{
    internal class DevolucaoRepository: IDevolucaoRepository
    {
        private static string? _repositoryJsonPath;
        public DevolucaoRepository()
        {
            string _jsonFileName = "Infrastructure\\Data\\devolucoes.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _repositoryJsonPath = Path.Combine(baseDirectory, _jsonFileName).Replace("bin\\Debug\\net8.0\\", "");
        }

        private static List<Devolucao>? PegarDados()
        {
            List<Devolucao>? devolucoes = new();

            if (File.Exists(_repositoryJsonPath))
            {
                string jsonData = File.ReadAllText(_repositoryJsonPath);
                devolucoes = JsonConvert.DeserializeObject<List<Devolucao>>(jsonData);
            }

            return devolucoes;
        }

        private static void SalvarDados(List<Devolucao> devolucoes)
        {
            if (File.Exists(_repositoryJsonPath))
            {
                string novoJsonData = JsonConvert.SerializeObject(devolucoes, Formatting.Indented);
                File.WriteAllText(_repositoryJsonPath, novoJsonData);
            }
        }

        public void AdicionarDevolucao(Devolucao devolucao)
        {
            var devolucoes = PegarDados();
            devolucoes.Add(devolucao);
            SalvarDados(devolucoes);
        }

        public IEnumerable<Devolucao>? ListarDevolucoes()
        {
            return PegarDados();
        }

        public IEnumerable<Devolucao>? ListarDevolucoesDoCliente(string nomeCliente)
        {
            return PegarDados().Where(devolucao => devolucao.NomeCliente == nomeCliente);
        }

        public IEnumerable<Devolucao>? ListarDevolucoesPorEstorno(decimal valor)
        {
            return PegarDados().Where(devolucao => devolucao.Estorno <= valor);
        }

        public Devolucao? PegarDevolucaoPorID(int id)
        {
            return PegarDados().FirstOrDefault(devolucao => devolucao.Id == id);
        }
    }
}