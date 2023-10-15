using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Models
{
    public class Brand : IEntity
    {
        public int Id { get; set; }
        [StringLength(50), Required(ErrorMessage = "Bu Alan Boş Bırakılamaz.")]
        public string Name { get; set; }

    }
}
