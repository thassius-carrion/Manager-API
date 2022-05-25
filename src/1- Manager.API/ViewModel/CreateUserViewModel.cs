using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModel
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
