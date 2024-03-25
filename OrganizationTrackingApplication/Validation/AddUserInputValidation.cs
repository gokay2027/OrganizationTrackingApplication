using FluentValidation;
using OrganizationTrackingApplicationApi.Model.AddUser;

namespace OrganizationTrackingApplicationApi.Validation
{
    public class AddUserInputValidation:AbstractValidator<AddUserInputModel>
    {
        public AddUserInputValidation()
        {
            RuleFor(a=>a.Name).NotEmpty();
            RuleFor(a => a.Surname).NotEmpty();
            RuleFor(a => a.Email).NotEmpty();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.Gender).NotEmpty();
        }
    }
}
