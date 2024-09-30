using Microsoft.AspNetCore.Mvc;

namespace RealtyMarketApi.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Realty Api is work";
        }
    }
}
