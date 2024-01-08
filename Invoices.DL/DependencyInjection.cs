using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Invoices.DL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration Configuration)
        {
            if(services is null || Configuration is null)
            {
                throw new ArgumentException(nameof(Configuration) + "or" + nameof(services));

                return services;
            }

            return services;
        }
    }
}
