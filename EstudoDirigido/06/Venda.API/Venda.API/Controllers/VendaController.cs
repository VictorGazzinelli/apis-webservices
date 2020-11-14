using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Venda.API.Models;
using ModelVenda = Venda.API.Models.Venda;
using ModelVendaPost = Venda.API.Models.VendaPost;

namespace Venda.API.Controllers
{
    [Produces("application/json")]
    [RequireHttps]
    [ApiController]
    /// <summary>
    /// Vendas
    /// </summary>
    /// <remarks> Vendas </remarks>
    public class VendaController : ControllerBase
    {
        static Item[] ARRMOCKITEM = new Item[]
                {
                    new Item()
                    {
                        Quantidade = 1,
                        Produto = new Produto()
                        {
                            Id = 1,
                            Nome = "A",
                            Preco = 1.00,
                        }
                    },
                    new Item()
                    {
                        Quantidade = 2,
                        Produto = new Produto()
                        {
                            Id = 2,
                            Nome = "B",
                            Preco = 2.00,
                        }
                    },
                    new Item()
                    {
                        Quantidade = 3,
                        Produto = new Produto()
                        {
                            Id = 3,
                            Nome = "C",
                            Preco = 3.00,
                        }
                    }
                };

        static List<ModelVenda> DB = new List<ModelVenda>(new ModelVenda[] { 
            new ModelVenda()
            {
                Id = 1,
                ArrItens = ARRMOCKITEM,
                EhAtivo = true,
                ValorTotal = ARRMOCKITEM.Aggregate<Item, double>(0, (total, currentItem) => total += currentItem.Quantidade * currentItem.Produto.Preco),
            }
        });

        /// <summary>
        /// Obtem todos os vendas ativos
        /// </summary>
        /// <remarks> Obtem todos os vendas ativos </remarks>
        [HttpGet]
        [Route("[controller]")]
        public IActionResult ListarTodasVendasAtivas()
        {
            return Ok(new { ArrVenda = DB.Where(v => v.EhAtivo).ToArray() });
        }

        /// <summary>
        /// Obtem um venda dado o seu id
        /// </summary>
        /// <remarks> Obtem um venda dado o seu id </remarks>
        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult ObterPorId([Required] int id)
        {
            ModelVenda Procurado = DB.FirstOrDefault(v => v.Id == id && v.EhAtivo);
            if (Procurado != null)
                return Ok(Procurado);
            else
                return BadRequest(new { Erro = $"Não foi encontrado uma venda ativa com id {id}" });
        }

        /// <summary>
        /// Cria um venda
        /// </summary>
        /// <remarks> Cria um venda </remarks>
        [HttpPost]
        [Route("[controller]")]
        public IActionResult Criar(ModelVendaPost vendaProps)
        {
            int IdNovaVenda = DB.Select(v => v.Id).Max() + 1;
            ModelVenda NovaVenda = vendaProps.ConverterParaVenda();
            NovaVenda.Id = IdNovaVenda;
            DB.Add(NovaVenda);
            return Ok(NovaVenda);
        }

        /// <summary>
        /// Cancela uma venda
        /// </summary>
        /// <remarks> Cancela uma venda </remarks>
        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult Excluir([Required] int id)
        {
            ModelVenda Procurado = DB.FirstOrDefault(v => v.Id == id && v.EhAtivo);
            if (Procurado != null)
            {
                DB.Where(v => v.Id == id && v.EhAtivo).ToList().ForEach(v => v.EhAtivo = false);
                return Ok(DB.FirstOrDefault(v => v.Id == id));
            }
            else
                return BadRequest(new { Erro = $"Não foi encontrado uma venda ativa com id {id}" });
        }
    }
}
