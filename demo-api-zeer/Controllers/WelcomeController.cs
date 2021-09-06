using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_api_zeer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public String Welcome()
        {
            return "Hello World! Welcome to the Demo Todo API.";
        }
    }
}
