using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public string Test()
        {
            return "hi";
        }
    }
}
