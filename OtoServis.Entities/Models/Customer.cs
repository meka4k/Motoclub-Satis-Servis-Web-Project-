using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OtoServis.Entities.Models
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Adı"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş Bırakılamaz.")]
        public string Name { get; set; }
        [Display(Name = "Soyadı"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş Bırakılamaz.")]
        public string Surname { get; set; }
        [Display(Name = "Tc Numarası")]
        public string? IdentityNo { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Adres"), StringLength(250)]
        public string? Address { get; set; }
        [Display(Name = "Telefon"), StringLength(20)]
        public string? Phone { get; set; }
        [Display(Name = "Not"), StringLength(250)]
        public string? Notes { get; set; }
        [Display(Name = "Talep Edilen Araç")]
        public virtual Vehicle? Vehicle { get; set; }
    }
}
