using Newtonsoft.Json;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Repositories;

namespace Store.AdaTech.Infrastructure.Repositories
{
    public class ProdutoRepository: IProdutoRepository
    {
        private static string? _repositoryJsonPath;
        public ProdutoRepository()
        {
            string _jsonFileName = "Data\\produtos.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _repositoryJsonPath = Path.Combine(baseDirectory, _jsonFileName).Replace("bin\\Debug\\net8.0", "");
        }

        private static List<Produto>? PegarDados()
        {
            List<Produto>? produtos = new();

            if (File.Exists(_repositoryJsonPath))
            {
                string jsonData = File.ReadAllText(_repositoryJsonPath);
                produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonData);
            }

            return produtos;
        }

        private static void SalvarDados(List<Produto> produtos)
        {
            if (File.Exists(_repositoryJsonPath))
            {
                string novoJsonData = JsonConvert.SerializeObject(produtos, Formatting.Indented);
                File.WriteAllText(_repositoryJsonPath, novoJsonData);
            }
        }

        public void AdicionarProduto(Produto produto)
        {
            var produtos = PegarDados();
            produtos.Add(produto);
            SalvarDados(produtos);
        }

        public IEnumerable<Produto>? ListarProdutos()
        {
            return PegarDados();
        }

        public IEnumerable<Produto>? ListarProdutosPorValor(decimal valor)
        {
            return PegarDados().Where(produto => produto.Preco >= valor);
        }

        public Produto? PegarProdutoPorID(int id)
        {
            return PegarDados().FirstOrDefault(produto => produto.Id == id);
        }
    }
}
