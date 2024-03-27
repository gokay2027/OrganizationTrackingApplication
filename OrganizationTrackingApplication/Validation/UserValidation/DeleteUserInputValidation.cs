using FluentValidation;
using OrganizationTrackingApplicationApi.Model.User.DeleteUser;

namespace OrganizationTrackingApplicationApi.Validation.UserValidation
{
    public class DeleteUserInputValidation : AbstractValidator<DeleteUserInputModel>
    {
        public DeleteUserInputValidation()
        {
            RuleFor(a => a.Id).NotEmpty().WithMessage("User id can not be empty");
        }
    }
}