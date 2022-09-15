using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCorePractice.ViewModels.System.Users
{
    public class RegisterValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required")
                .MaximumLength(200).WithMessage("First name can not over 200 character");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required")
                .MaximumLength(200).WithMessage("Last name can not over 200 character");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").WithMessage("Invalid Email");
            RuleFor(x => x.Username).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at least 6 character");
            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.ConfirmPassword != request.Password)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}
