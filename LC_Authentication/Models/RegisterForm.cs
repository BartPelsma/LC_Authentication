using System.ComponentModel.DataAnnotations;

namespace LC_Authentication
{
    public class RegisterForm
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public virtual string Email { get; set; }
        [Required]
        public virtual string Password { get; set; }
    }
}
