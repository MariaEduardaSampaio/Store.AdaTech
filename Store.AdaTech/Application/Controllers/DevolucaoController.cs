using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Application.Filters;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevolucaoController : Controller
    {
        private IDevolucaoService _service { get; set; }
        private ILogger<DevolucaoController> _logger { get; set; }
        public DevolucaoController(IDevolucaoService service, ILogger<DevolucaoController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("testarExcecaoELog", Name = "Testar Exceção e Log")]
        public IActionResult? TestarExcecaoELog([FromQuery] bool erro)
        {
            try
            {
                if (erro)
                    throw new ArgumentException("Lança erro para teste.");
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
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
                _logger.LogError(ex.Message);
                return BadRequest();
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
                _logger.LogError(ex.Message);
                return BadRequest();
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
                _logger.LogError(ex.Message);
                return BadRequest();
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
                _logger.LogError(ex.Message);
                return BadRequest();
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
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
