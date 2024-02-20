using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Interfaces.Services;

namespace Store.AdaTech.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevolucaoController: Controller
    {
        private IDevolucaoService _service {  get; set; }
        public DevolucaoController(IDevolucaoService service)
        {
            _service = service;
        }
    }
}
