using Microsoft.AspNetCore.Antiforgery;
using TransportWiseBackEnd.Controllers;

namespace TransportWiseBackEnd.Web.Host.Controllers
{
    public class AntiForgeryController : TransportWiseBackEndControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
