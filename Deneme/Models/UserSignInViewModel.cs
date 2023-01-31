using System.ComponentModel.DataAnnotations;

namespace Deneme.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez")]
        public string ?username1 { get; set; }

        [Required(ErrorMessage ="Şifre boş geçilemez")]
        public string ?password { get; set; }
    }
}
