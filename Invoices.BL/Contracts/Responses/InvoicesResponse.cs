using Invoices.DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Invoices.BL.Contracts.Responses
{
    public class InvoicesResponse
    {
        //  public Header Header { get; set; }  
        public ResponseMessage ResponseMessage { get; set;}
        public Params Params { get; internal set; }

        public InvoicesResponse()
        {
            ResponseMessage = new ResponseMessage();
            Params = new Params();
        }
    }

    public class Params
    {
        public List<InvoicesTable> Invoices{ get; set; }
    }

    public class ResponseMessage
    {
        public string responseCode { get; set; } 
        public string TextMessage { get; set; } 
        public ResponseMessage()
        {
            responseCode = "";
            TextMessage = "";
        }    
    }
}
