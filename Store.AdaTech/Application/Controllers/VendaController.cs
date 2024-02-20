using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Interfaces.Services;

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
    }
}
