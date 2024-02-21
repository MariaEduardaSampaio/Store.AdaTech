using Newtonsoft.Json;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;

namespace Store.AdaTech.Infrastructure.Repositories
{
    public class TrocaRepository: ITrocaRepository
    {
        private static string? _repositoryJsonPath;
        public TrocaRepository()
        {
            string _jsonFileName = "Infrastructure\\Data\\trocas.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _repositoryJsonPath = Path.Combine(baseDirectory, _jsonFileName).Replace("bin\\Debug\\net8.0\\", "");
        }

        private static List<Troca>? PegarDados()
        {
            List<Troca>? trocas = new();

            if (File.Exists(_repositoryJsonPath))
            {
                string jsonData = File.ReadAllText(_repositoryJsonPath);
                trocas = JsonConvert.DeserializeObject<List<Troca>>(jsonData);
            }

            return trocas;
        }

        private static void SalvarDados(List<Troca> trocas)
        {
            if (File.Exists(_repositoryJsonPath))
            {
                string novoJsonData = JsonConvert.SerializeObject(trocas, Formatting.Indented);
                File.WriteAllText(_repositoryJsonPath, novoJsonData);
            }
        }

        public void AdicionarTroca(Troca troca)
        {
            var trocas = PegarDados();            
            trocas.Add(troca);
            SalvarDados(trocas);
        }

        public IEnumerable<Troca>? ListarTrocas()
        {
            return PegarDados();
        }

        public IEnumerable<Troca>? ListarTrocasDoCliente(string nomeCliente)
        {
            return PegarDados().Where(troca => troca.NomeCliente == nomeCliente);
        }

        public IEnumerable<Troca>? ListarTrocasPorValor(decimal valor)
        {
            return PegarDados().Where(troca => troca.ValorTotal <= valor);
        }

        public Troca? PegarTrocaPorID(int id)
        {
            return PegarDados().FirstOrDefault(troca => troca.Id == id);
        }
    }
}
