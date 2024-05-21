using Core.Extensions;
using Business.DI;
using Microsoft.Extensions.DependencyInjection;
using Core.Providers;
namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(opts => { opts.SuppressModelStateInvalidFilter = true; })
                .AddJsonOptions(opts => { opts.JsonSerializerOptions.PropertyNamingPolicy = null; });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddCore(builder.Configuration).AddCoreOperations(opts =>
            {
                opts.IsAddJwtHelper = true;
            });
            builder.Services.AddBusinessServices(builder.Configuration);
            builder.Services.AddHttpContextAccessor();
            builder.Logging.AddProvider(new CoreILoggerProvider(builder.Services.BuildServiceProvider(), builder.Configuration));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
