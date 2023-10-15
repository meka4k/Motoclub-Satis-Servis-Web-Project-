using OtoServis.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OtoServis.Data.Abstract
{
	public interface ICarRepository:IRepository<Vehicle> 
	{
		Task<List<Vehicle>> CustomCarList();
		Task<Vehicle> GetCustomCar(int id);
		int GetMotoCount();

		Task<List<Vehicle>> CustomCarList(Expression<Func<Vehicle, bool>> expression);
	}
}
