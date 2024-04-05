using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.User.UpdateUser;
using OrganizationTrackingApplicationApi.Validation.UserValidation;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.UserCommand.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserOutputModel>
    {
        private readonly IGenericRepository<User> _userRepository;

        public UpdateUserCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserOutputModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validation = new UpdateUserInputValidation();

            var validationResult = validation.Validate(request.InputModel);

            if (validationResult.IsValid.Equals(false))
            {
                return new UpdateUserOutputModel()
                {
                    IsSuccess = false,
                    Message = validationResult.ToString(),
                };
            }

            try
            {
                var userToBeUpdated = await _userRepository.GetById(request.InputModel.Id);

                userToBeUpdated.Update(request.InputModel.Name, request.InputModel.Surname, request.InputModel.Email, request.InputModel.Gender);

                await _userRepository.Update(userToBeUpdated);

                return new UpdateUserOutputModel()
                {
                    IsSuccess = true,
                    Message = "User has been updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new UpdateUserOutputModel()
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}