using MediatR;

namespace OrganizationTrackingApplicationApi.Model.AddUser
{
    public class AddUserCommand : IRequest<AddUserOutputModel>
    {
        public AddUserInputModel InputModel { get; set; }
    }

    public class AddUserInputModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
    }
}