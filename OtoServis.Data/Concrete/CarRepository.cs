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
	public class CarRepository : Repository<Vehicle>, ICarRepository
	{
		public CarRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<List<Vehicle>> CustomCarList()
		{
			return await _dbSet.AsNoTracking().Include(x=>x.Brand).ToListAsync();
		}

		public async Task<List<Vehicle>> CustomCarList(Expression<Func<Vehicle, bool>> expression)
		{
			return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Brand).ToListAsync();
		}

		public async Task<Vehicle> GetCustomCar(int id)
		{
			return await _dbSet.AsNoTracking().Include(x => x.Brand).FirstOrDefaultAsync(c => c.Id == id);
		}

        public int GetMotoCount()
        {
			var value = _dbSet.Count();
			return value;
        }
    }
}
