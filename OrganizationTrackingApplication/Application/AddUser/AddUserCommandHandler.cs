using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.AddUser;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, AddUserOutputModel>
    {
        private readonly IGenericRepository<User> _userRepository;

        public AddUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AddUserOutputModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(request.Name,request.Surname,request.Email,request.Password,request.Gender);

            _userRepository.Insert(user);
            

            return new AddUserOutputModel
            {
                IsSuccess = true,
                Message = "user Added"
            };
        }
    }
}
