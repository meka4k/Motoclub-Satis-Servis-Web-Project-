using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities.Models
{
    public class Sales : IEntity
    {
        public int Id { get; set; }
        [Display(Name ="Vehicle")]
        public int VehicleId { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Date of Sale")]
        public DateTime DateOfSale { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
