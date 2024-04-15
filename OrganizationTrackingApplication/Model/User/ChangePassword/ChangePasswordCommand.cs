using MediatR;

namespace OrganizationTrackingApplicationApi.Model.User.ChangePassword
{
    public class ChangePasswordCommand : IRequest<ChangePasswordOutputModel>
    {
        public ChangePasswordModel InputModel { get; set; }
    }

    public class ChangePasswordModel
    {
        public Guid Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}