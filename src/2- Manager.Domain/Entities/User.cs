using Manager.Core.Exceptions;
using Manager.Domain.Validators;

namespace Manager.Domain.Entities {

    public class User : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        //EF
        protected User() { }

        public User(string name, string email, string password) 
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if(!validation.IsValid){
                foreach(var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);
                
                throw new DomainException("Invalid User, please correct it!", _errors);
            }
            
            return true;
        }
    }
}