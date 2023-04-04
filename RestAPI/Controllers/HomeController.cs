using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Utilities;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class HomeController : Controller
    {
        DBConnect connection = new DBConnect();

        [HttpGet]
        public string Test()
        {
            return "hi";
        }
    }
}
