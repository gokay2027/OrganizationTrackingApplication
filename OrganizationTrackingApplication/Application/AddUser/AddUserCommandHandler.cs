using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.AddUser;
using OrganizationTrackingApplicationApi.Validation;
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
            try
            {
                var validator = new AddUserInputValidation();
                var result = validator.Validate(request.InputModel);
                if (result.IsValid)
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
                        Message = "User Created Successfully"
                    };
                }
                else
                {
                    return new AddUserOutputModel
                    {
                        IsSuccess = false,
                        Message = "Error while creating user"
                    };
                }
            }
            catch (Exception ex)
            {
                return new AddUserOutputModel
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}