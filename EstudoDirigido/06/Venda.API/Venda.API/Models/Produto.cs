namespace Venda.API.Models
{
    public class Produto : IProduto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }

    }
}
