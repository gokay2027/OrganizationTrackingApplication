using OrganizationTrackingApplicationApi.Model.BaseModel;

namespace OrganizationTrackingApplicationApi.GeminiAi.IOModelForAi
{
    public class AiContentOutputModel : BaseOutputModel
    {
        public string? AiContentMessage { get; set; }
    }
}