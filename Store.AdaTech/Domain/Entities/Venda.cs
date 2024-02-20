namespace Store.AdaTech.Domain.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal ValorTotal {  get; set; }
        public DateTime RealizadaEm { get; set; }
    }
}
