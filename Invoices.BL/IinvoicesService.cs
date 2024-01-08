using Invoices.BL.Contracts.Requests;
using Invoices.BL.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.BL
{
    public interface IinvoicesService
    {
        Task<InvoicesResponse> GetInvoices(InvoicesRequest req);
        Task<InvoicesResponse> SetInvoices(InvoicesRequest req);
        Task<InvoicesResponse> UpdateInvoices(InvoicesRequest req);
    }
}
