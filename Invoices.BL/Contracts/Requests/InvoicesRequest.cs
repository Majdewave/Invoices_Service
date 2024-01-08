using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoices.BL.Contracts.Responses;
using Invoices.DL.Model;

namespace Invoices.BL.Contracts.Requests
{
    public class InvoicesRequest
    {

        [Required]
        public string Id { get; set; }
        public string Status { get; set; }
        public int? Amount { get; set; }

        public InvoicesRequest()
        {
            Id= string.Empty;
            Status = string.Empty;  
            Amount = 0; 
        }

    }
}
