using Invoices.BL.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.BL.Validation
{
    public interface IinvoicesValidation
    {
        Task<Tuple<string, string>> GetInvoicesValidation(InvoicesRequest req);
       // Task<Tuple<string, string>> SetInvoicesValidation(InvoicesResponse req);
    }
}
