using System.ComponentModel.DataAnnotations;

namespace LC_Authentication
{
    public class LoginForm
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
