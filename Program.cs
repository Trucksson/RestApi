
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.EndPoints;

namespace RestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CVContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
               
            var app = builder.Build();

            // 
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            PersonEndpoints.RegisterEndpoints(app);
            UtbildningEndpoints.RegisterEndpoints(app);
            GitHubEndPoints.RegisterEndpoints(app);
            ArbetserfarenhetEndpoints.RegisterEndpoints(app);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.Run();
        }
    }
}
