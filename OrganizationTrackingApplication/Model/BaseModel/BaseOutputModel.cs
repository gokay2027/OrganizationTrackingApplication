namespace OrganizationTrackingApplicationApi.Model.BaseModel
{
    /// <summary>
    /// This class is used for commands and single variable returner queries
    /// </summary>
    public class BaseOutputModel
    {
        public string Message { get; set; }

        public bool IsSuccess { get; set; }
    }
}