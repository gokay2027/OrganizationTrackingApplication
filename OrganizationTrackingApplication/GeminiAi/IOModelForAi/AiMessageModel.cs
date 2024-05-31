using MediatR;

namespace OrganizationTrackingApplicationApi.GeminiAi.IOModelForAi
{
    public class AiMessageModel : IRequest<AiContentOutputModel>
    {
        public string? Message { get; set; }
    }
}