namespace Produto.API.Models
{
    public class ProdutoPost
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public double Preco { get; set; }

        public Produto ConverterParaProduto()
        {
            return new Produto()
            {
                Nome = this.Nome,
                Descricao = this.Descricao,
                Categoria = this.Categoria,
                Preco = this.Preco,
                EhAtivo = true,
            };
        }

    }
}
