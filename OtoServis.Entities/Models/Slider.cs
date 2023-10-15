using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Models
{
    public class Slider:IEntity
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string? Title { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [StringLength(150)]
        public string Image { get; set; }
        public string? Link { get; set; }
    }
}
