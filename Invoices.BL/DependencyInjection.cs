using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Invoices.BL.Validation;
using Invoices.DL.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Invoices.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddScoped<IinvoicesService, InvoicesServices>();
            services.AddScoped<IinvoicesValidation, InvoicesRequestValidation>();
            services.AddScoped<IinvoicesService, InvoicesServices>();
          //  services.AddScoped<IInvoicesContext, InvoicesContext>();

            return services;
        }
    }
}
