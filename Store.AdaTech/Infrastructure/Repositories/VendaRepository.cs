using Newtonsoft.Json;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;

namespace Store.AdaTech.Infrastructure.Repositories
{
    public class VendaRepository: IVendaRepository
    {
        private static string? _repositoryJsonPath;
        public VendaRepository()
        {
            string _jsonFileName = "Infrastructure\\Data\\vendas.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _repositoryJsonPath = Path.Combine(baseDirectory, _jsonFileName).Replace("bin\\Debug\\net8.0\\", "");
        }

        private static List<Venda>? PegarDados()
        {
            List<Venda>? vendas = new();

            if (File.Exists(_repositoryJsonPath))
            {
                string jsonData = File.ReadAllText(_repositoryJsonPath);
                vendas = JsonConvert.DeserializeObject<List<Venda>>(jsonData);
            }

            return vendas;
        }

        private static void SalvarDados(List<Venda> vendas)
        {
            if (File.Exists(_repositoryJsonPath))
            {
                string novoJsonData = JsonConvert.SerializeObject(vendas, Formatting.Indented);
                File.WriteAllText(_repositoryJsonPath, novoJsonData);
            }
        }

        public void AdicionarVenda(Venda venda)
        {
            var vendas = PegarDados();
            vendas.Add(venda);
            SalvarDados(vendas);
        }

        public IEnumerable<Venda>? ListarVendas()
        {
            return PegarDados();
        }

        public IEnumerable<Venda>? ListarVendasDoCliente(string nomeCliente)
        {
            return PegarDados().Where(venda => venda.NomeCliente == nomeCliente);
        }

        public IEnumerable<Venda>? ListarVendasPorValor(decimal valor)
        {
            return PegarDados().Where(venda => venda.ValorTotal <= valor);
        }

        public Venda? PegarVendaPorID(int id)
        {
            return PegarDados().FirstOrDefault(venda => venda.Id == id);
        }
    }
}
