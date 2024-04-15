using FluentValidation;
using OrganizationTrackingApplicationApi.Model.User.ChangePassword;

namespace OrganizationTrackingApplicationApi.Validation.UserValidation
{
    public class ChangePasswordValidation:AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordValidation()
        {
            RuleFor(a=>a.Id).NotEmpty().WithMessage("User id can not be empty");
            RuleFor(a=>a.OldPassword).NotEmpty().WithMessage("Old password can not be empty");
            RuleFor(a => a.NewPassword).NotEmpty().WithMessage("New password can not be empty");
        }
    }
}
