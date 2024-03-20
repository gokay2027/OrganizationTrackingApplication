using Microsoft.AspNetCore.Mvc;

namespace OrganizationTrackingApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            return 5;
        }
    }
}
