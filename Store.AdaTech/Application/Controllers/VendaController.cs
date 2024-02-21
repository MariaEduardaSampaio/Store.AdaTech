using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Entities;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Domain.Requests;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController: Controller
    {
        private IVendaService _service { get; set; }
        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [HttpPost("adicionarVenda", Name = "Adicionar Venda")]
        public IActionResult AdicionarVenda([FromBody] VendaRequest request)
        {
            try
            {
                var venda = _service.AdicionarVenda(request);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pegarVendaPorID", Name = "Pegar Venda Por ID")]
        public IActionResult PegarVendaPorID([FromQuery] int id)
        {
            try
            {
                var venda = _service.PegarVendaPorID(id);
                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listarVendas", Name = "Listar Vendas")]
        public IActionResult ListarVendas()
        {
            try
            {
                var vendas = _service.ListarVendas();
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listarVendasDoCliente", Name = "Listar Vendas Do Cliente")]
        public IActionResult ListarVendasDoCliente([FromQuery] string nomeCliente)
        {
            try
            {
                var vendas = _service.ListarVendasDoCliente(nomeCliente);
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("listarVendasPorValor", Name = "Listar Vendas Por Valor")]
        public IActionResult ListarVendasPorValor([FromQuery] decimal valor)
        {
            try
            {
                var vendas = _service.ListarVendasPorValor(valor);
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
