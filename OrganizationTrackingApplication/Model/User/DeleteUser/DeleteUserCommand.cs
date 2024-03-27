using MediatR;

namespace OrganizationTrackingApplicationApi.Model.User.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteUserOutputModel>
    {
        public DeleteUserInputModel InputModel { get; set; }
    }

    public class DeleteUserInputModel
    {
        public Guid Id { get; set; }
    }
}