namespace SuperSimple.Auth.Manager
{
    using FluentValidation;
    using System.Collections.Generic;

    public class SignupModel
    {
        public string Email         { get; set; }
        public string Secret        { get; set; }
        public string ConfirmSecret { get; set; }
        public List<Error> Errors   { get; set; }
    }

    public class SignupValidator : AbstractValidator<SignupModel>
    {
        public SignupValidator()
        {
            RuleFor(signup => signup.Email).NotEmpty();
            RuleFor(signup => signup.Email).EmailAddress();
            RuleFor(signup => signup.Secret).NotEmpty();
            RuleFor(signup => signup.ConfirmSecret).Must((signup, confirmSecret) => 
                confirmSecret == signup.Secret).WithMessage("Passwords do not match.");
        }
    }
}

