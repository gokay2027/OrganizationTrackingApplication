using MediatR;

namespace OrganizationTrackingApplicationApi.Model.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserOutputModel>
    {
        public UpdateUserModel InputModel { get; set; }
    }

    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
    }
}