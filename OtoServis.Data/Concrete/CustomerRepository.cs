using Microsoft.EntityFrameworkCore;
using OtoServis.Data.Abstract;
using OtoServis.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Concrete
{

	public class CustomerRepository : Repository<Customer>, ICustomerRepository
	{
		public CustomerRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<List<Customer>> CustomerCarList()
		{
			return await _dbSet.AsNoTracking().Include(x => x.Vehicle).ToListAsync();
		}

		public async Task<List<Customer>> CustomerCarList(Expression<Func<Customer, bool>> expression)
		{
			return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Vehicle).ToListAsync();
		}
	}
}
