namespace Store.AdaTech.Domain.Entities
{
    public class Devolucao
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal Estorno { get; set; }
        public DateTime RealizadaEm { get; set; }
    }
}
