
using Lab2.Context;
using Lab2.Services.CourseServies;
using Lab2.Services.DepartmentService;
using Lab2.Services.StudentService;
using Microsoft.EntityFrameworkCore;

namespace Lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Company Context
            builder.Services.AddDbContext<CompanyContext>(option =>
            {
                option.UseSqlServer(builder.Configuration["ConnectionStrings:conn"]);
            });

            // Register Models Servises
            builder.Services.AddScoped<IStudentService, StudentService>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<ICourseServies, CourseServies>();

            // Ririster CORS Policy
            builder.Services.AddCors(CorsPolicy =>
            {
                CorsPolicy.AddPolicy("Development", (CorsOption) =>
                {
                    CorsOption.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                CorsPolicy.AddPolicy("Production", (CorsOption) =>
                {
                    CorsOption.WithOrigins("192.25.10.4").AllowAnyHeader().AllowAnyMethod();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            // Add CORS MW
            app.UseCors("Development");

            app.MapControllers();

            app.Run();
        }
    }
}
