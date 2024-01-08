using Microsoft.AspNetCore.Mvc;

using Invoices.BL.Contracts.Requests;
using Invoices.BL.Validation;
using System.Runtime.CompilerServices;
using Invoices.BL.Enums;
using Invoices.BL.Contracts.Responses;
using Invoices.BL;

namespace Invoices.API.Controllers
{
    public class InvoicesController : ControllerBase
    {
        private readonly IinvoicesValidation _InvoicesRequestValidation;
        private readonly IinvoicesService _invoicesService;


        public InvoicesController(/*IinvoicesValidation  validation,*/ IinvoicesService invoicesService)
        {
            // _InvoicesRequestValidation = validation;
            _invoicesService = invoicesService;

        }
        InvoicesResponse response = new InvoicesResponse();


        [HttpPost("GetInvoices")]
        public async Task<ActionResult> GetInvoices([FromBody] InvoicesRequest? req)
        {
            if(req == null || req == null)
            {
                return BadRequest("Request is Invalid.");
            }

            try
            {
                response = await _invoicesService.GetInvoices(req);
            }
            catch (Exception ex)
            {
                var res = new InvoicesResponse();
                res.ResponseMessage.responseCode = ((int)LogCode.Failure).ToString();
                res.ResponseMessage.TextMessage = $"InvoicesGet Response method Error. ex : {ex}";
            }
            return Ok(response);
        }

        [HttpPost("SetInvoices")]
        public async Task<ActionResult> SetInvoices([FromBody] InvoicesRequest? req)
        {
            if (req == null)
            {
                return BadRequest("Request is Invalid.");
            }

            try
            {
                response = await _invoicesService.SetInvoices(req);
            }
            catch (Exception ex)
            {
                var res = new InvoicesResponse();
                res.ResponseMessage.responseCode = ((int)LogCode.Failure).ToString();
                res.ResponseMessage.TextMessage = $"InvoicesGet Response method Error. ex : {ex}";
            }
            return Ok(response);
        }

        [HttpPut("UpdateInvoices")]
        public async Task<ActionResult> UpdateInvoices([FromBody] InvoicesRequest? req)
        {
            if (req == null || req == null)
            {
                return BadRequest("Request is Invalid.");
            }

            try
            {
                response = await _invoicesService.UpdateInvoices(req);
            }
            catch (Exception ex)
            {
                var res = new InvoicesResponse();
                res.ResponseMessage.responseCode = ((int)LogCode.Failure).ToString();
                res.ResponseMessage.TextMessage = $"InvoicesGet Response method Error. ex : {ex}";
            }
            return Ok(response);
        }

    }
}
