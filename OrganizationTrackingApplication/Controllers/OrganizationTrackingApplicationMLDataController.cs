using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Application.DummyCommand;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;

namespace OrganizationTrackingApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationMLDataController : ControllerBase
    {
        private readonly IOrganizationTrackingApplicationQuery _query;
        private readonly IDummyCommand _dummyCommand;

        public OrganizationTrackingApplicationMLDataController(IOrganizationTrackingApplicationQuery query, IDummyCommand dummyCommand)
        {
            _query = query;
            _dummyCommand = dummyCommand;
        }

        [HttpGet]
        public IActionResult EventSuggestionDataForML()
        {
            return null;
        }

        [HttpPost]
        public async Task DummyData()
        {
            await _dummyCommand.AddDummyData();
        }
    }
}