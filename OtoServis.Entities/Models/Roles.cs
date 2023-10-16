using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace OtoServis.Entities.Models
{
    public class Roles : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Rol"),Required(ErrorMessage ="Bu Alan Boş Bırakılamaz."),StringLength(50)]
        public string Name { get; set; }
    }
}
