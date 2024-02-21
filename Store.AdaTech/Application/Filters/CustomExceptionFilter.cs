using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Store.AdaTech.Domain.Responses;

namespace Store.AdaTech.Application.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<CustomExceptionFilter> _logger; 

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceção.");

            context.HttpContext.Response.StatusCode = 400;
            var erroResult = new ErroResponse(context.Exception.Message, context.HttpContext.Response.StatusCode);
            var result = new JsonResult(erroResult);
            context.Result = result;
        }
    }
}