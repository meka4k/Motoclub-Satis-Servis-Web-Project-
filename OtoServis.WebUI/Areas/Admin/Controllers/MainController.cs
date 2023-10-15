using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class MainController : Controller
    {
        private readonly ICarService _carServiceRepository;
        private readonly IUserService _userService;
        private readonly IServiceRepository<Brand> _brandService;
        private readonly IServiceRepository<Sales> _salesService;

        public MainController(ICarService carServiceRepository, IUserService userService, IServiceRepository<Brand> brandService, IServiceRepository<Sales> salesService)
        {
            _carServiceRepository = carServiceRepository;
            _userService = userService;
            _brandService = brandService;
            _salesService = salesService;
        }

        public IActionResult Index()
        {
            ViewBag.cycleCount = _carServiceRepository.GetMotoCount();
            ViewBag.userCount = _userService.GetUserCount();
            ViewBag.brandCount = _brandService.GetCount();
            ViewBag.saleCount = _salesService.GetCount();
            return View();
        }
    }
}
