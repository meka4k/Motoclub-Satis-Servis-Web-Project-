using OtoServis.Data;
using OtoServis.Data.Concrete;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Service.Concrete
{
    public class ServiceRepository<T> : Repository<T>, IServiceRepository<T> where T : class, IEntity, new()
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }


	}
}
