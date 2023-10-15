using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OtoServis.Entities.Models
{
	public class Contact:IEntity
	{
        public int Id { get; set; }
		[Display(Name = "Ad ve Soyad"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
		public string Name { get; set; }
		[Display(Name = "Email"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
		public string Email { get; set; }
		[Display(Name = "Başlık"), StringLength(50), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
		public string Title { get; set; }
		[Display(Name = "Mesaj"), StringLength(500), Required(ErrorMessage = "Bu Alan Boş bırakılamaz.")]
		public string Message { get; set; }
    }
}
