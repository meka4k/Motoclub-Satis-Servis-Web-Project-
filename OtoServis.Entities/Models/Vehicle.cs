using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Models
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Brand Id"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public int BrandId { get; set; }
        [StringLength(50),Display(Name ="Renk"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş bırakılamaz."), Display(Name = "Fiyat")]
        public decimal Price { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        [Display(Name ="Model")]
        public string BrandName { get; set; }
        [StringLength(50), Display(Name = "Araç Tipi"), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
        public string VehicleType { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş bırakılamaz."), Display(Name = "Yıl")]
        public int Year { get; set; }
        [Display(Name = "Hala Satılık Mı?")]
        public bool IsItOnSale { get; set; }
        [Display(Name = "Ana Sayfa?")]
        public bool HomePage { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş bırakılamaz."), Display(Name = "Not")]
        public string Notes { get; set; }
        [StringLength(150),Display(Name ="Görsel")]
        public string? Image1 { get; set; }
        [StringLength(150), Display(Name = "Görsel 2")]
        public string? Image2 { get; set; }
        [StringLength(150), Display(Name = "Görsel 3")]
        public string? Image3 { get; set; }
        [Display(Name = "Marka")]
        public virtual Brand? Brand { get; set; }
    }
}
