using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace PatientRecord.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public IActionResult Index() => Ok("Project is running ");
    }
}
