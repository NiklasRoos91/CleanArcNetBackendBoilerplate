using CleanArcNetBackendBoilerplate.Api.Extensions;
using CleanArcNetBackendBoilerplate.Application.Extensions;
using CleanArcNetBackendBoilerplate.Infrastructure.Extensions;

namespace CleanArcNetBackendBoilerplate.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();
            builder.Services.AddJwtAuthentication(builder.Configuration);
            builder.Services.AddSwaggerWithJwt();

            builder.Services.AddInfrastructure(builder.Configuration, useInMemory: false);
            builder.Services.AddApplication();


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
