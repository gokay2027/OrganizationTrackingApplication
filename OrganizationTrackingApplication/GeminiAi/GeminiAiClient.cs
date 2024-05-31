using MediatR;
using Mscc.GenerativeAI;
using OrganizationTrackingApplicationApi.GeminiAi.IOModelForAi;

namespace OrganizationTrackingApplicationApi.GeminiAi
{
    public class GeminiAiClient : IRequestHandler<AiMessageModel, AiContentOutputModel>
    {
        private GoogleAI googleAI { get; set; }

        public GeminiAiClient()
        {
            this.googleAI = new GoogleAI(apiKey: "AIzaSyC1PdMXYBeFfsceaOoc41av3NgNadqI4KA");
        }

        public async Task<AiContentOutputModel> Handle(AiMessageModel request, CancellationToken cancellationToken)
        {
            var model = googleAI.GenerativeModel("gemini-1.5-pro");
            var resultData = model.GenerateContent(request.Message).Result;

            var outputModel = new AiContentOutputModel
            {
                AiContentMessage = resultData.Text,
                IsSuccess = true,
                Message = "Ai Responsed Successfully"
            };

            return outputModel;
        }
    }
}