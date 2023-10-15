using System.ComponentModel.DataAnnotations;

namespace OtoServis.WebUI.Models
{
    public class CustomerLoginViewModel
    {
        [StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Email { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Password { get; set; }
    }
}
