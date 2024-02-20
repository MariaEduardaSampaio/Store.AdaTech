using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Interfaces.Services;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrocaController: Controller
    {
        private ITrocaService _service { get; set; }
        public TrocaController(ITrocaService service)
        {
            _service = service;
        }
    }
}
