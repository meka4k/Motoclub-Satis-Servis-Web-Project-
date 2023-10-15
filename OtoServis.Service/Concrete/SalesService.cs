using OtoServis.Data;
using OtoServis.Data.Concrete;
using OtoServis.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Service.Concrete
{
	public class SalesService : SalesRepository, ISalesService
	{
		public SalesService(AppDbContext context) : base(context)
		{
		}
	}
}
