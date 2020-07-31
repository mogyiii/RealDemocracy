using FluentValidation;
using Dec.Web.Models;

namespace Dec.Web.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail is required!")
                .EmailAddress().WithMessage("Format is incorrect!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required!");
        }
    }
}
