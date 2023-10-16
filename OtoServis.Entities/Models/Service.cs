using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OtoServis.Entities.Models
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Servise Geliş Tarihi")]
        public DateTime ServiceArrivalDate { get; set; }
        [Display(Name = "Araç Problemi")]
        public string VehicleProblem { get; set; }
        [Display(Name = "Servis Ücreti")]
        public decimal ServicePrice { get; set; }
        [Display(Name = "Servis Çıkış Tarihi")]
        public DateTime ServiceOutDate { get; set; }

        public string? Transactions { get; set; } //Yapılan İşlemler
        [Display(Name = "Garanti Kapsamında Mı?")]
        public bool IsUnderWarranty { get; set; }
        [StringLength(15), Display(Name = "Araç Plaka"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string VehiclePlate { get; set; } //Araç Plaka
        [StringLength(50), Display(Name = "Araç Marka"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string VehicleBrand { get; set; }
        [StringLength(50), Display(Name = "Araç Model")]
        public string? VehicleModel { get; set; }
        [StringLength(50), Display(Name = "Araç Tipi")]
        public string? VehicleType { get; set; }
        [StringLength(50), Display(Name = "Şase")]
        public string? ChassisNo { get; set; } //Şase No
        [Required(ErrorMessage = "Bu Alan Boş bırakılamaz."), Display(Name = "Note")]
        public string Notes { get; set; }
    }
}
