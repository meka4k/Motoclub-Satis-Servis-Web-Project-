using OtoServis.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Abstract
{
	public interface ICustomerRepository:IRepository<Customer>
	{
		Task<List<Customer>> CustomerCarList();
		Task<List<Customer>> CustomerCarList(Expression<Func<Customer, bool>> expression);
	}
}
