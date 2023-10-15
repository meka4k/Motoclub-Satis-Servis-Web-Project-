using OtoServis.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Abstract
{
	public interface ISalesRepository:IRepository<Sales>
	{
		Task<List<Sales>> CustomUserList();
		Task<List<Sales>> CustomUserList(Expression<Func<Sales, bool>> expression);
		
	}
}
