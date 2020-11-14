using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ModelProduto = Produto.API.Models.Produto;
using ModelProdutoPost = Produto.API.Models.ProdutoPost;

namespace Produto.API.Controllers
{
    [Produces("application/json")]
    [RequireHttps]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        static List<ModelProduto> DB = new List<ModelProduto>(new ModelProduto[]{
            new ModelProduto()
                { 
                    Id = 1,
                    Nome = "A",
                    Descricao = "A",
                    Categoria = "A",
                    Preco = 1.00,
                    EhAtivo = true
                },
            new ModelProduto()
                {
                    Id = 2,
                    Nome = "B",
                    Descricao = "B",
                    Categoria = "B",
                    Preco = 2.00,
                    EhAtivo = true
                },
            new ModelProduto()
                {
                    Id = 3,
                    Nome = "C",
                    Descricao = "C",
                    Categoria = "C",
                    Preco = 1.00,
                    EhAtivo = true
                },
        });

        /// <summary>
        /// Obtem todos os produtos ativos
        /// </summary>
        /// <remarks> Obtem todos os produtos ativos </remarks>
        [HttpGet]
        [Route("[controller]")]
        public IActionResult ListarTodosProdutosAtivos()
        {
            return Ok(new { ArrProduto = DB.Where(p => p.EhAtivo).ToArray() });
        }

        /// <summary>
        /// Obtem um produto dado o seu id
        /// </summary>
        /// <remarks> Obtem um produto dado o seu id </remarks>
        [HttpGet]
        [Route("[controller]/{id}")]
        public IActionResult ObterPorId([Required] int id)
        {
            ModelProduto Procurado = DB.FirstOrDefault(p => p.Id == id && p.EhAtivo);
            if (Procurado != null)
                return Ok(Procurado);
            else
                return BadRequest(new { Erro = $"Não foi encontrado um produto ativo com id {id}" });
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <remarks> Cria um produto </remarks>
        [HttpPost]
        [Route("[controller]")]
        public IActionResult Criar(ModelProdutoPost ProdutoProps)
        {
            int IdNovoProduto = DB.Select(p => p.Id).Max() + 1;
            ModelProduto NovoProduto = ProdutoProps.ConverterParaProduto();
            NovoProduto.Id = IdNovoProduto;
            DB.Add(NovoProduto);
            return Ok(NovoProduto);
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <remarks> Atualiza um produto </remarks>
        [HttpPut]
        [Route("[controller]/{id}")]
        public IActionResult Alterar([Required, FromRoute] int id, [FromBody] ModelProdutoPost ProdutoProps)
        {
            ModelProduto Procurado = DB.FirstOrDefault(p => p.Id == id && p.EhAtivo);
            if (Procurado != null)
            {
                DB.Where(p => p.Id == id && p.EhAtivo).ToList().ForEach(p =>
                {
                    p.Nome = ProdutoProps.Nome;
                    p.Descricao = ProdutoProps.Descricao;
                    p.Categoria = ProdutoProps.Categoria;
                    p.Preco = ProdutoProps.Preco;
                });
                return Ok(DB.FirstOrDefault(p => p.Id == id && p.EhAtivo));
            }
            else
                return BadRequest(new { Erro = $"Não foi encontrado um produto ativo com id {id}" });
        }

        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <remarks> Exclui um produto </remarks>
        [HttpDelete]
        [Route("[controller]/{id}")]
        public IActionResult Excluir([Required] int id)
        {
            ModelProduto Procurado = DB.FirstOrDefault(p => p.Id == id && p.EhAtivo);
            if (Procurado != null)
            {
                DB.Where(p => p.Id == id && p.EhAtivo).ToList().ForEach(p => p.EhAtivo = false);
                return Ok(DB.FirstOrDefault(p => p.Id == id));
            }
            else
                return BadRequest(new { Erro = $"Não foi encontrado um produto ativo com id {id}" });
        }
    }
}
