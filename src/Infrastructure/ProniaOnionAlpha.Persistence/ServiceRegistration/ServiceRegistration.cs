using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnionAlpha.Application.Abstractions.Repositories;
using ProniaOnionAlpha.Application.Abstractions.Services;
using ProniaOnionAlpha.Persistence.Contexts;
using ProniaOnionAlpha.Persistence.Implementations.Repositories;
using ProniaOnionAlpha.Persistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionAlpha.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("default")));

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<JwtService>();

            return services;
        }
    }
}
