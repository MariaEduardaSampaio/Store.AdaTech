using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Interfaces.Services;

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

    }
}
