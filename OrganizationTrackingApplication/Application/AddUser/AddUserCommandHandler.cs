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
            var user = new User(request.InputModel.Name,
                request.InputModel.Surname,
                request.InputModel.Email,
                request.InputModel.Password,
                request.InputModel.Gender);

            await _userRepository.Insert(user);

            return new AddUserOutputModel
            {
                IsSuccess = true,
                Message = "user Added"
            };
        }
    }
}