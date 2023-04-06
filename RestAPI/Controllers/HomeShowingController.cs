using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Utilities;
using HomeLibrary;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class HomeShowingController : Controller
    {
        DBConnect connection = new DBConnect();
    }
}
