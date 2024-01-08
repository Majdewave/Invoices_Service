using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController 
    {
        public ILogger Log { get; set; }

        public BaseController()
        {
            //this.Log = log4net.LogManager.GetLogger(typeof(MyLogger));
            //var name = this.GetType.Name;
            //name = name.Replace("Controller", "");
        }
    }
}
