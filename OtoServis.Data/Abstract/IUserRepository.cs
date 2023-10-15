using OtoServis.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Abstract
{
    public interface IUserRepository:IRepository<User>
    {
        Task<List<User>> CustomUserList();
        Task<List<User>> CustomUserList(Expression<Func<User, bool>> expression);
        int GetUserCount();
    }
}
