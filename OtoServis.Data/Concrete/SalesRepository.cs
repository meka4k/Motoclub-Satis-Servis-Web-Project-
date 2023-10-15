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
	public class SalesRepository : Repository<Sales>, ISalesRepository
	{
		public SalesRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<List<Sales>> CustomUserList()
		{
			return await _dbSet.AsNoTracking()
		.Include(x => x.Vehicle)
		.Include(x => x.Customer)
		.ToListAsync();
		}

		public async Task<List<Sales>> CustomUserList(Expression<Func<Sales, bool>> expression)
		{
			return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Vehicle).Include(x=>x.Customer).ToListAsync();
		}
	}
}
