using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using OtoServis.WebUI.Models;
using System.Diagnostics;

namespace OtoServis.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceRepository<Slider> _serviceRepository;
        private readonly IServiceRepository<Contact> _contactServiceRepository;
        private readonly ICarService _carServiceRepository;

		public HomeController(IServiceRepository<Slider> serviceRepository, ICarService carServiceRepository, IServiceRepository<Contact> contactServiceRepository)
		{
			_serviceRepository = serviceRepository;
			_carServiceRepository = carServiceRepository;
			_contactServiceRepository = contactServiceRepository;
		}

		public async Task<IActionResult> Index()
        {
            var model = new HomepageViewModel()
            {
               
                Sliders = await _serviceRepository.GetAllAsync(),
                Vehicles = await _carServiceRepository.CustomCarList(x=>x.HomePage)
            };
           
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {

            return View();
        }
        [HttpPost]
		public async Task<IActionResult> Contact(Contact contact)
		{
            if (ModelState.IsValid)
            {
                try
                {
                    _contactServiceRepository.AddAsync(contact);
                    await _contactServiceRepository.SaveAsync();
					TempData["Message"] = "<div class='alert alert-success'>Mesajınız iletildi. En kısa sürede dönüş yapılacaktır.Teşekkürler...</div>";
					return RedirectToAction(nameof(Contact));
                }
                catch
                {
                    TempData["Message"] = "<div class='alert alert-danger'>Bir Hata Oluştu.</div>";
                    ModelState.AddModelError("", "Bir Hata Oluştu");
                }
            }

			return View(contact);
		}
		[Route("AccessDenied")]
        public IActionResult AccessDenied()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}