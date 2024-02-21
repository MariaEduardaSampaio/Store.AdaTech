using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrocaController: Controller
    {
        private ITrocaService _service { get; set; }
        private ILogger<TrocaController> _logger { get; set; }
        public TrocaController(ITrocaService service, ILogger<TrocaController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpPost("adicionarTroca", Name = "Adicionar Troca")]
        public IActionResult AdicionarTroca([FromBody] TrocaRequest request)
        {
            try
            {
                var troca = _service.AdicionarTroca(request);
                return Ok(troca);
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("pegarTrocaPorID", Name = "Pegar Troca Por ID")]
        public IActionResult PegarTrocaPorID([FromQuery] int id)
        {
            try
            {
                var troca = _service.PegarTrocaPorID(id);
                return Ok(troca);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("listarTrocas", Name = "Listar Trocas")]
        public IActionResult ListarTrocas()
        {
            try
            {
                var trocas = _service.ListarTrocas();
                return Ok(trocas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("listarTrocasDoCliente", Name = "Listar Trocas Do Cliente")]
        public IActionResult ListarTrocasDoCliente([FromQuery] string nomeCliente)
        {
            try
            {
                var trocas = _service.ListarTrocasDoCliente(nomeCliente);
                return Ok(trocas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("listarTrocasPorValor", Name = "Listar Trocas Por Valor")]
        public IActionResult ListarTrocasPorValor([FromQuery] decimal valor)
        {
            try
            {
                var trocas = _service.ListarTrocasPorValor(valor);
                return Ok(trocas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}
