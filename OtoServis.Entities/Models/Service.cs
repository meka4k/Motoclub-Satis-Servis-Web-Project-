using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OtoServis.Entities.Models
{
    public class Service : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Service Arrival Date")]
        public DateTime ServiceArrivalDate { get; set; }
        [Display(Name = "Vehicle's Problem")]
        public string VehicleProblem { get; set; }
        [Display(Name = "Service Price")]
        public decimal ServicePrice { get; set; }
        [Display(Name = "Service Out Date")]
        public DateTime ServiceOutDate { get; set; }

        public string? Transactions { get; set; } //Yapılan İşlemler
        [Display(Name = "Is Under Warranty")]
        public bool IsUnderWarranty { get; set; }
        [StringLength(15), Display(Name = "Vehicle Plate"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string VehiclePlate { get; set; } //Araç Plaka
        [StringLength(50), Display(Name = "Vehicle Brand"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string VehicleBrand { get; set; }
        [StringLength(50)]
        public string? VehicleModel { get; set; }
        [StringLength(50)]
        public string? VehicleType { get; set; }
        [StringLength(50)]
        public string? ChassisNo { get; set; } //Şase No
        [Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Notes { get; set; }
    }
}
