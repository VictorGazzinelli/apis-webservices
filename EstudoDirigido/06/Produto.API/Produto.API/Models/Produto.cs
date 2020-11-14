namespace Produto.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }
        public bool EhAtivo { get; set; }
    }
}
