namespace Venda.API.Models
{
    public interface IProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
    }
}
