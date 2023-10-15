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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<User>> CustomUserList()
        {
            return await _dbSet.AsNoTracking().Include(x => x.Roles).ToListAsync();
        }

        public async Task<List<User>> CustomUserList(Expression<Func<User, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().Include(x => x.Roles).ToListAsync();
        }

        public int GetUserCount()
        {
            return _dbSet.Count();
        }
    }
}
