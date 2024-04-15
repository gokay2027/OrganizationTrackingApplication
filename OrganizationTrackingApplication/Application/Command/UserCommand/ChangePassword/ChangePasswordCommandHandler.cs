using Entities.Domain;
using MediatR;
using OrganizationTrackingApplicationApi.Model.User.ChangePassword;
using OrganizationTrackingApplicationApi.Validation.UserValidation;
using OrganizationTrackingApplicationData.GenericRepository.Abstract;

namespace OrganizationTrackingApplicationApi.Application.Command.UserCommand.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordOutputModel>
    {
        private readonly IGenericRepository<User> _userRepository;

        public ChangePasswordCommandHandler(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ChangePasswordOutputModel> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var validation = new ChangePasswordValidation();
            var validationResult = validation.Validate(request.InputModel);

            if (validationResult.IsValid.Equals(false))
            {
                return new ChangePasswordOutputModel
                {
                    IsSuccess = false,
                    Message = validationResult.ToString()
                };
            }

            try
            {
                var userToChangePassword = await _userRepository.GetById(request.InputModel.Id);
                var oldValidPassword = userToChangePassword.ChangePassword(request.InputModel.OldPassword, request.InputModel.NewPassword);

                if (oldValidPassword.Equals(false))
                {
                    return new ChangePasswordOutputModel
                    {
                        IsSuccess = false,
                        Message = "Password you entered is not matched to your current password"
                    };
                }

                return new ChangePasswordOutputModel
                {
                    IsSuccess = true,
                    Message = "Password has been changed successfully"
                };
            }
            catch (Exception ex)
            {
                return new ChangePasswordOutputModel
                {
                    IsSuccess = false,
                    Message = ex.InnerException.Message
                };
            }
        }
    }
}