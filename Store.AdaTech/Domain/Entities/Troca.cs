namespace Store.AdaTech.Domain.Entities
{
    public class Troca
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public List<Produto> ProdutosAnteriores { get; set; }
        public List<Produto> ProdutosAtuais { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Diferenca { get; set; }
        public DateTime RealizadaEm { get; set; }
    }
}
