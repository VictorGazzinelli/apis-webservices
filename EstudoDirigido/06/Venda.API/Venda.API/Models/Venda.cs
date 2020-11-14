using System.Linq;

namespace Venda.API.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public Item [] ArrItens { get; set; }
        public bool EhAtivo { get; set; }

        //public Venda(int Id, Item[] ArrItens, bool EhAtivo)
        //{
        //    this.Id = Id;
        //    this.ArrItens = ArrItens;
        //    this.EhAtivo = EhAtivo;
        //    this.ValorTotal = ArrItens.Aggregate<Item, double>(0, (total, currentItem) => total += currentItem.Quantidade * currentItem.Produto.Preco);
        //}
    }
}
