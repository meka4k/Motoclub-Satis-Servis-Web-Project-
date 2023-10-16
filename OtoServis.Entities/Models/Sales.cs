using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities.Models
{
    public class Sales : IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Araç")]
        public int VehicleId { get; set; }
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Satış Tarihi")]
        public DateTime DateOfSale { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
