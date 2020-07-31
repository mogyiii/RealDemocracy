using System.ComponentModel;
using Dec.Shared.DTOs;

namespace Dec.Web.Models
{
    public class RegisterModel
    {
        public UserDTO User { get; set; }

        // TODO localization
        [DisplayName("Password")]
        public string Password { get; set; }

        [DisplayName("Confirm password")]
        public string PasswordRe { get; set; }
    }
}
