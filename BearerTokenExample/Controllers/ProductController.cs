using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BearerTokenExample.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<string> Gets()
        {
            List<string> result = new List<string>()
            {
                "Kalem",
                "Bilgisayar",
                "Telefon",
                "Yazıcı",
                "Klavye",
                "Televizyon"
            };

            return result;
        }
    }
}
