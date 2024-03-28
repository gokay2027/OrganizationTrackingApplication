using MediatR;

namespace OrganizationTrackingApplicationApi.Model.User.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserOutputModel>
    {
        public AddUserInputModel InputModel { get; set; }
    }

    public class AddUserInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
    }
}