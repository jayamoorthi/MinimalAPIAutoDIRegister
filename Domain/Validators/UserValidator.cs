using Domain.ModelDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class UserValidator :AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("First Name is required");

            RuleFor(user => user.LastName).Must(x => !string.IsNullOrWhiteSpace(x)).WithMessage("Last Name is required");

            RuleFor(user => user.Email).EmailAddress().WithMessage("Enter valid email address");


        }
    }
}
