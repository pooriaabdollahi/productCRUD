using Application;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class PersistanceServicesRegisteration
    {
        public static void ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "Server=localhost,1435;Database=master;User Id=sa;Password=Myp@ssword1;TrustServerCertificate=True;";

            services.AddDbContext<MyDBContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<IProductRepository,ProductRepository>();
        }
    }
}
