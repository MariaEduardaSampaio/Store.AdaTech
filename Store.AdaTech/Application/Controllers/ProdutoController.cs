using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private IProdutoService _service { get; set; }
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpPost("adicionarProduto", Name = "Adicionar Produto")]
        public IActionResult AdicionarProduto([FromBody] ProdutoRequest request)
        {
            try
            {
                var produto = _service.AdicionarProduto(request);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pegarProdutoPorID", Name = "Pegar Produto Por ID")]
        public IActionResult PegarProdutoPorID([FromQuery] int id)
        {
            try
            {
                var produto = _service.PegarProdutoPorID(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("listarProdutos", Name = "Listar Produtos")]
        public IActionResult ListarProdutos()
        {
            try
            {
                var produtos = _service.ListarProdutos();
                return Ok(produtos);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("listarProdutosPorValor", Name = "Listar Produtos Por Valor")]
        public IActionResult ListarProdutosPorValor([FromQuery] decimal valor)
        {
            try
            {
                var produtos = _service.ListarProdutosPorValor(valor);
                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
