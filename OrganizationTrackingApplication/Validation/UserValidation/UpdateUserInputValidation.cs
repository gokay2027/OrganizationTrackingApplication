using FluentValidation;
using OrganizationTrackingApplicationApi.Model.User.UpdateUser;

namespace OrganizationTrackingApplicationApi.Validation.UserValidation
{
    public class UpdateUserInputValidation:AbstractValidator<UpdateUserModel>
    {
        public UpdateUserInputValidation()
        {
            RuleFor(a=>a.Id).NotEmpty().WithMessage("User Id Can not be empty");
            RuleFor(a=>a.Name).NotEmpty().WithMessage("Name Can not be empty");
            RuleFor(a=>a.Surname).NotEmpty().WithMessage("Surname Can not be empty");
            RuleFor(a=>a.Email).NotEmpty().WithMessage("Email Can not be empty");
            RuleFor(a=>a.Gender).NotEmpty().WithMessage("Gender Can not be empty");
        }

    }
}
