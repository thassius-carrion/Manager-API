using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators {

    public class UserValidator : AbstractValidator<User>{

        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Entity can not be empty.")

                .NotNull()
                .WithMessage("Entity can not be null.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name can not be null.")

                .NotEmpty()
                .WithMessage("Name can not be empty.")

                .MinimumLength(3)
                .WithMessage("Name must have at least 3 characters.")

                .MaximumLength(80)
                .WithMessage("Name must have maximum of 80 characters.");
            
            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email can not be null.")

                .NotEmpty()
                .WithMessage("Email can not be empty.")

                .MinimumLength(10)
                .WithMessage("Email must have at least 10 characters.")

                .MaximumLength(180)
                .WithMessage("Email must have maximum of 180 characters.")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("Email invalid.");
            
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password can not be null.")

                .NotEmpty()
                .WithMessage("Password can not be empty.")

                .MinimumLength(6)
                .WithMessage("Password must have at least 6 characters.")

                .MaximumLength(30)
                .WithMessage("Password must have maximum of 30 characters.");
             
        }

    }
}