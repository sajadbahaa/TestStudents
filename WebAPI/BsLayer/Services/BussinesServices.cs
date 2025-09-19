using BsLayer.maaper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsLayer.Services
{
    static  public class BussinesServices
    {
        public static IServiceCollection addBussinesServices(this IServiceCollection services) 
        {
            services.AddScoped<TransactionService>();
            services.AddScoped<AppMappingProfile>();
            services.AddScoped<SpecilizationsService>();
            services.AddScoped<ItemsService>();
            services.AddScoped<CourseService>();
            return services;
        }
    }
}
