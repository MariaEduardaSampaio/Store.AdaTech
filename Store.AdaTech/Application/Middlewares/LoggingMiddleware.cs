namespace Store.AdaTech.Application.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            var metodo = context.Request.Method;
            var nomeRota = "Nome da rota não definido";

            if (endpoint?.Metadata.GetMetadata<EndpointNameMetadata>() is EndpointNameMetadata endpointNameMetadata)
                nomeRota = endpointNameMetadata.EndpointName;

            _logger.LogInformation($"Início da solicitação: [{metodo}] {nomeRota}");

            await _next(context);

            _logger.LogInformation($"Fim da solicitação: [{metodo}]: {nomeRota}");
        }
    }
}
