using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrganizationTrackingApplicationApi.Application.DummyCommand;
using OrganizationTrackingApplicationApi.Application.Query.Abstract;
using OrganizationTrackingApplicationApi.GeminiAi.IOModelForAi;

namespace OrganizationTrackingApplicationApi.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrganizationTrackingApplicationMLDataController : ControllerBase
    {
        private readonly IOrganizationTrackingApplicationQuery _query;
        private readonly IDummyCommand _dummyCommand;
        private readonly IMediator _mediator;

        public OrganizationTrackingApplicationMLDataController(IOrganizationTrackingApplicationQuery query, IDummyCommand dummyCommand, IMediator mediator)
        {
            _query = query;
            _dummyCommand = dummyCommand;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> EventSuggestionDataForML()
        {
            await _query.SuggestEventDataForML();
            return Ok();
        }

        [HttpPost]
        public async Task DummyData()
        {
            await _dummyCommand.AddDummyData();
        }

        [HttpPost]
        public async Task<IActionResult> TalkAi([FromBody] AiMessageModel messageModel)
        {
            var result = await _mediator.Send(messageModel);
            return Ok(result);
        }
    }
}