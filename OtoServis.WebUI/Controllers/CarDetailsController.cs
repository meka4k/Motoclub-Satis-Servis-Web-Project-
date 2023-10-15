using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Data.Abstract;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using OtoServis.WebUI.Models;
using System.Security.Claims;

namespace OtoServis.WebUI.Controllers
{
	public class CarDetailsController : Controller
	{
		private readonly ICarService _serviceRepository;
        private readonly IUserService _userServiceRepository;
        private readonly IServiceRepository<Customer> _customerServiceRepository;

        public CarDetailsController(ICarService serviceRepository, IServiceRepository<Customer> customerServiceRepository, IUserService userServiceRepository)
        {
            _serviceRepository = serviceRepository;
            _customerServiceRepository = customerServiceRepository;
            _userServiceRepository = userServiceRepository;
        }

        public async Task<IActionResult> Index(int? id)
		{
			if (id == null)
				return NotFound();
			
			var car = await _serviceRepository.GetCustomCar(id.Value);
			if (car == null)
				return NotFound();

			var model = new CarDetailViewModel();
			model.Vehicle = car;

			if(User.Identity.IsAuthenticated)
			{
                var email = User.FindFirst(ClaimTypes.Email)?.Value;
                var uguid = User.FindFirst(ClaimTypes.UserData)?.Value;
                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uguid))
                {
                    var user = _userServiceRepository.Get(x => x.Email == email && x.UserGuid.ToString() == uguid);
                    if (user is not null)
                    {
						model.Customer = new Customer
						{
							Name = user.Name,
							Surname = user.Surname,
							Email=user.Email,
							Phone=user.Phone,
							
						};
                    }
                }
            }
			return View(model);
		}

		//[Route("Tum-Araclarimiz")]
		public async Task<IActionResult> List()
		{
            ViewBag.countMotor = _serviceRepository.GetCount();
            var model = await _serviceRepository.CustomCarList(x=>x.IsItOnSale);
			return View(model);
		}

        public async Task<IActionResult> Search(string q)
        {
            var model = await _serviceRepository.CustomCarList(x => x.IsItOnSale && x.Brand.Name.Contains(q) || x.VehicleType.Contains(q) || x.BrandName.Contains(q));
            return View(model);
        }

		[HttpPost]
		public async Task<IActionResult> Musteri(Customer customer)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await _customerServiceRepository.AddAsync(customer);
					await _customerServiceRepository.SaveAsync();
					TempData["Message"] = "<div class='alert alert-success'>Talebiniz alınmıştır. En kısa sürede dönüş yapılacaktır. Teşekkürler...</div>";
					return Redirect("Index/"+customer.VehicleId);
					
				}
				catch
				{
					TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu.</div>";
					ModelState.AddModelError("", "Bir Hata Oluştu");
				}
				
			}
			return View();
		}
	}
}
