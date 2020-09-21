using Microsoft.AspNetCore.Antiforgery;
using CmsFeature.Controllers;

namespace CmsFeature.Web.Host.Controllers
{
    public class AntiForgeryController : CmsFeatureControllerBase
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
