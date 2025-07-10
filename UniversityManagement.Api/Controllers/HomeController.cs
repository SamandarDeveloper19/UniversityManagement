using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace UniversityManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            "Hi there";
    }
}
