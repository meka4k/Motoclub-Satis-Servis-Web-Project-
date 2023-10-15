using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using System.Security.Claims;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IServiceRepository<User> _serviceRepository;
        private readonly IServiceRepository<Roles> _roleServiceRepository;

        public LoginController(IServiceRepository<User> serviceRepository, IServiceRepository<Roles> roleServiceRepository)
        {
            _serviceRepository = serviceRepository;
            _roleServiceRepository = roleServiceRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Admin/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            try
            {
                var account = _serviceRepository.Get(k => k.Email == email && k.Password == password && k.IsActive == true);
                if (account == null)
                {
                    TempData["Mesaj"] = "Giriş Başarısız!";

                }
                else
                {
                    var rol = _roleServiceRepository.Get(r => r.Id == account.RolesId);
                    var claims = new List<Claim>()
             {
                 new Claim(ClaimTypes.Name,account.Name),


             };
                    if (rol is not null)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, rol.Name));
                    }
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin");
                }

            }
            catch (Exception)
            {

                TempData["Mesaj"] = "Hata Oluştu!";
            }
            return View();
        }
    }
}
