using System.Linq;

namespace Venda.API.Models
{
    public class VendaPost
    {
        public Item[] ArrItens { get; set; }

        public Venda ConverterParaVenda()
        {
            return new Venda()
            {
                ArrItens = this.ArrItens,
                ValorTotal = this.ArrItens.Aggregate<Item, double>(0, (total, currentItem) => total += currentItem.Quantidade * currentItem.Produto.Preco),
                EhAtivo = true,
            };
        }

    }
}
