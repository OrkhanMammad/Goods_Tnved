using Goods_Tnved.Application.Repositories.GoodRepos;
using Goods_Tnved.Persistence.Concretes.GoodRepos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods_Tnved.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddScoped<IGoodReadRepository, GoodReadRepository>();
           

        }
    }
}
