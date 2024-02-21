using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevolucaoController : Controller
    {
        private IDevolucaoService _service { get; set; }
        public DevolucaoController(IDevolucaoService service)
        {
            _service = service;
        }

        [HttpPost("adicionarDevolucao", Name = "Adicionar Devolucao")]
        public IActionResult AdicionarDevolucao([FromBody] DevolucaoRequest request)
        {
            try
            {
                var devolucao = _service.AdicionarDevolucao(request);
                return Ok(devolucao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pegarDevolucaoPorID", Name = "Pegar Devolucao Por ID")]
        public IActionResult PegarDevolucaoPorID([FromQuery] int id)
        {
            try
            {
                var devolucao = _service.PegarDevolucaoPorID(id);
                return Ok(devolucao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listarDevolucoes", Name = "Listar Devolucoes")]
        public IActionResult ListarDevolucoes()
        {
            try
            {
                var devolucoes = _service.ListarDevolucoes();
                return Ok(devolucoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listarDevolucoesPorCliente", Name = "Listar Devolucoes Por Cliente")]
        public IActionResult ListarDevolucoesPorCliente([FromQuery] string nomeCliente)
        {
            try
            {
                var devolucoes = _service.ListarDevolucoesDoCliente(nomeCliente);
                return Ok(devolucoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listarDevolucoesPorValor", Name = "Listar Devolucoes Por Valor")]
        public IActionResult ListarDevolucoesPorValor([FromQuery] decimal valor)
        {
            try
            {
                var devolucoes = _service.ListarDevolucoesPorEstorno(valor);
                return Ok(devolucoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
