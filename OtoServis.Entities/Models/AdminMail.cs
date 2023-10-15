using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Entities.Models
{
    public class AdminMail:IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string SenderMail { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
