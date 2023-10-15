using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Ad"),StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Name { get; set; }
        [Display(Name = "Soyad"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Surname { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Email { get; set; }
        [Display(Name = "Telefon"), StringLength(20), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [Display(Name = "Şifre"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        [Display(Name = "Created Date"), ScaffoldColumn(true)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [Display(Name = "User Role"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public int RolesId { get; set; }
        [Display(Name = "User Role")]
        public virtual Roles? Roles { get; set; }

        public Guid UserGuid { get; set; } = Guid.NewGuid();
    }
}
