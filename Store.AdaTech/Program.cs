
using Store.AdaTech.Application.Filters;
using Store.AdaTech.Application.Middlewares;
using Store.AdaTech.Application.Services;
using Store.AdaTech.Domain.Interfaces.Repositories;
using Store.AdaTech.Domain.Interfaces.Services;
using Store.AdaTech.Infrastructure.Repositories;

namespace Store.AdaTech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("localhost",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:5500", "https://localhost:7217");
                    });
            });
 
            // adicionar repositorios
            builder.Services.AddSingleton<IDevolucaoRepository, DevolucaoRepository>();
            builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
            builder.Services.AddSingleton<ITrocaRepository, TrocaRepository>();
            builder.Services.AddSingleton<IVendaRepository, VendaRepository>();

            // adicionar services
            builder.Services.AddSingleton<IDevolucaoService, DevolucaoService>();
            builder.Services.AddSingleton<IProdutoService, ProdutoService>();
            builder.Services.AddSingleton<ITrocaService, TrocaService>();
            builder.Services.AddSingleton<IVendaService, VendaService>();

            // adicionar controllers
            builder.Services.AddControllers(options =>
                options.Filters.Add<CustomExceptionFilter>()
            );


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("localhost");
            }

            // adicionar middlewares
            app.UseMiddleware<LoggingMiddleware>();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
