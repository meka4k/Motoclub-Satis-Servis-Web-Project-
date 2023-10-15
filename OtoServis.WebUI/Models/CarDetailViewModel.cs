using OtoServis.Entities.Models;

namespace OtoServis.WebUI.Models
{
    public class CarDetailViewModel
    {
        public Vehicle Vehicle{ get; set; }
        public Customer? Customer{ get; set; }
    }
}
