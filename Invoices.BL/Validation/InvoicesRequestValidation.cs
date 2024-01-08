using Invoices.BL.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.BL.Validation
{
    public class InvoicesRequestValidation : IinvoicesValidation
    {
        public async Task<Tuple<string, string>> GetInvoicesValidation(InvoicesRequest request)
        {
            string rc = "0";
            string message = "Error ";
            await Task.Run(async () =>
            {
                if ((request.Id).ToString().Length < 9)
                {
                    rc = "100";
                    message += "_ID";
                }
            });
            var response = new Tuple<string, string>(rc, message);
            return response;
        }
    }
}
