using Api1DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api1Core.Extensions
{
    public static class EfCoreExtensions
    {
        public static void AddEFMysql(this IServiceCollection services, IConfiguration config)
        {
            var constring = config.GetConnectionString("MySql");
            services.AddDbContext<Api1DbContext>(x =>
            {
                x.UseMySql(constring, ServerVersion.AutoDetect(constring));
            });
        }
    }
}
