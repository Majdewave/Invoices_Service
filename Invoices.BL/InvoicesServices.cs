using Azure;
using Invoices.BL.Contracts.Requests;
using Invoices.BL.Contracts.Responses;
using Invoices.BL.Enums;
using Invoices.DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Params = Invoices.BL.Contracts.Responses.Params;

namespace Invoices.BL
{
    public class InvoicesServices : IinvoicesService
    {
        private InvoicesResponse response;
        private readonly IConfiguration _conf;
        private readonly InvoicesContext _invoicesContext;
        public InvoicesServices(IConfiguration configuration, InvoicesContext invoicesContext)
        {
            _conf = configuration;
            _invoicesContext = invoicesContext;
        }
        public async Task<InvoicesResponse> GetInvoices(InvoicesRequest request)
        {
            try
            {
                response = new InvoicesResponse();

                if (!string.IsNullOrWhiteSpace(request?.Id))
                {
                    var invoice = await _invoicesContext.InvoicesTables.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (invoice is not null)  // return the spicific invoices by id.
                    {
                        DateTime date = DateTime.Now;
                        response.Params.Invoices = new List<InvoicesTable>
                        {
                            invoice
                        };
                        response.ResponseMessage.responseCode = ((int)LogCode.success).ToString();
                        response.ResponseMessage.TextMessage = (LogCode.success).ToString();
                    }
                    else // didn't find the spicific id
                    {
                        response.ResponseMessage.responseCode = ((int)LogCode.error_id_is_not__found).ToString();
                        response.ResponseMessage.TextMessage = (LogCode.error_id_is_not__found).ToString();
                    }
                }
                else // if Id Field is Empty , return all invoices 
                {
                    var invoices = await _invoicesContext.InvoicesTables.ToListAsync();
                    response.Params.Invoices = invoices;
                    response.ResponseMessage.responseCode = ((int)LogCode.success).ToString();
                    response.ResponseMessage.TextMessage = (LogCode.success).ToString();

                }
                return response;
            }
            catch (Exception ex)
            {
                var res = new InvoicesResponse();
                res.ResponseMessage.responseCode = ((int)LogCode.Failure).ToString();
                res.ResponseMessage.TextMessage = $"InvoicesGet Response method Error. ex : {ex}";
            }
            return response;
        }

        public async Task<InvoicesResponse> SetInvoices(InvoicesRequest? request)
        {
            response = new InvoicesResponse();
            try
            {
                var req = new InvoicesTable();
                if(request.Id.Length <=9)  // 
                {
                    req.Id = request.Id;
                    req.Status = request.Status;
                    req.Amount = request.Amount;
                    req.Date = DateTime.Now;
                }
 

                object value = await _invoicesContext.InvoicesTables.AddAsync(req);
                _invoicesContext.SaveChanges();

                response.ResponseMessage.responseCode = ((int)LogCode.success).ToString();
                response.ResponseMessage.TextMessage = (LogCode.success).ToString();
            }
            catch (Exception ex)
            {
                var res = new InvoicesResponse();
                res.ResponseMessage.responseCode = ((int)LogCode.Failure).ToString();
                res.ResponseMessage.TextMessage = $"InvoicesGet Response method Error. ex : {ex}";
            }
            return response;
        }


        public async Task<InvoicesResponse> UpdateInvoices(InvoicesRequest request)
        {
            try
            {
                response = new InvoicesResponse();
                var req = new InvoicesTable();

                if (!string.IsNullOrWhiteSpace(request?.Id))
                {
                    var invoice = await _invoicesContext.InvoicesTables.FirstOrDefaultAsync(s => s.Id == request.Id);
                    if (invoice is not null)  // id is exist, we can update the item
                    {
                        invoice.Status = request.Status;
                        invoice.Amount = request.Amount;
                        invoice.Date = DateTime.Now;

                      //  object value = await _invoicesContext.InvoicesTables.AddAsync(req);
                        await _invoicesContext.SaveChangesAsync();

                        response.ResponseMessage.responseCode = ((int)LogCode.success).ToString();
                        response.ResponseMessage.TextMessage = (LogCode.success).ToString();
                    }
                    else // didn't find the spicific id
                    {
                        response.ResponseMessage.responseCode = ((int)LogCode.error_id_is_not__found).ToString();
                        response.ResponseMessage.TextMessage = (LogCode.error_id_is_not__found).ToString();
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                var res = new InvoicesResponse();
                res.ResponseMessage.responseCode = ((int)LogCode.Failure).ToString();
                res.ResponseMessage.TextMessage = $"InvoicesGet Response method Error. ex : {ex}";
            }
            return response;
        }


    }
}
