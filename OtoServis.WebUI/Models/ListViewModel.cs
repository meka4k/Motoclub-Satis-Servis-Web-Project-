using OtoServis.Entities.Models;

namespace OtoServis.WebUI.Models
{
    public class ListViewModel
    {
        public IEnumerable<Vehicle> Vehicles { get; set; }
        public bool IsDescending { get; set; }
    }

}
