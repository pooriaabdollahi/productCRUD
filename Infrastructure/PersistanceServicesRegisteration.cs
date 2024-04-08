using Application;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using static System.Net.Mime.MediaTypeNames;
namespace Infrastructure
{
    public static class PersistanceServicesRegisteration
    {
        public static void ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = "Server=localhost,1435;Database=master;User Id=sa;Password=Myp@ssword1;TrustServerCertificate=True;";

            services.AddDbContext<MyDBContext>(x => x.UseSqlServer(connectionString));
            services.AddTransient<IProductRepository,ProductRepository>();
            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                     ValidIssuer = "test.com",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("helloMySecretKeyThatIsLongEnaugh")),
                     ValidateIssuer = false,
                     ValidateAudience = false,
                    ValidateLifetime =true,

                    ValidateIssuerSigningKey = true
                };
            });
            services.AddAuthorization();
        }
    }
}
