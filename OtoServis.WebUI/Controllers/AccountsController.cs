using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using OtoServis.WebUI.Models;
using System.Security.Claims;

namespace OtoServis.WebUI.Controllers
{
	public class AccountsController : Controller
	{
		private readonly IUserService _serviceRepository;
		private readonly IServiceRepository<Roles> _roleServiceRepository;

		public AccountsController(IUserService serviceRepository, IServiceRepository<Roles> roleServiceRepository)
		{
			_serviceRepository = serviceRepository;
			_roleServiceRepository = roleServiceRepository;
		}

		[Authorize(Policy = "CustomerPolicy")]
		public IActionResult Index()
		{
			var email = User.FindFirst(ClaimTypes.Email)?.Value;
			var uguid = User.FindFirst(ClaimTypes.UserData)?.Value;
			if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uguid))
			{
				var user = _serviceRepository.Get(x => x.Email == email && x.UserGuid.ToString() == uguid);
				if (user is not null)
				{
					return View(user);
				}
			}
			return NotFound();
		}

		public async Task<IActionResult> UserUpdate(User user)
		{
			try
			{
				var email = User.FindFirst(ClaimTypes.Email)?.Value;
				var uguid = User.FindFirst(ClaimTypes.UserData)?.Value;
				if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(uguid))
				{
					var userList = _serviceRepository.Get(x => x.Email == email && x.UserGuid.ToString() == uguid);
					if (user is not null)
					{
						userList.Name = user.Name;
						userList.Email = user.Email;
						userList.Surname = user.Surname;
						userList.Password = user.Password;
						userList.Phone = user.Phone;
						userList.IsActive = user.IsActive;
						userList.CreatedDate = user.CreatedDate;
						userList.UserGuid = user.UserGuid;

						_serviceRepository.Update(userList);
						_serviceRepository.SaveAsync();
					}
				}
			}
			catch (Exception)
			{

				ModelState.AddModelError("", "Bir Hata Oluştu!");
			}
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(User user)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var rol = await _roleServiceRepository.GetAsync(x => x.Name == "Customer");
					
					if (rol == null)
					{
						ModelState.AddModelError("", "İşlem Başarısız");
						return View();
					}
					user.IsActive = true;
					user.RolesId = rol.Id;
					


					await _serviceRepository.AddAsync(user);
					await _serviceRepository.SaveAsync();
					return RedirectToAction("Login");
				}
				catch
				{
					ModelState.AddModelError("", "Bir Hata Meydana Geldi!");
				}

			}
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(CustomerLoginViewModel customerLoginView)
		{
			try
			{
				var account = _serviceRepository.Get(k => k.Email == customerLoginView.Email && k.Password == customerLoginView.Password && k.IsActive == true);
				if (account == null)
				{
					ModelState.AddModelError("", "Giriş Başarısız!");

				}
				else
				{
					var rol = _roleServiceRepository.Get(r => r.Id == account.RolesId);
					var claims = new List<Claim>()
			 {
				 new Claim(ClaimTypes.Name,account.Name),
				 new Claim(ClaimTypes.Email,account.Email),
				 new Claim(ClaimTypes.UserData,account.UserGuid.ToString())


			 };
					if (rol is not null)
					{
						claims.Add(new Claim(ClaimTypes.Role, rol.Name));
					}
					var userIdentity = new ClaimsIdentity(claims, "Login");
					ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
					await HttpContext.SignInAsync(principal);
					if (rol.Name == "Admin")
					{
						return Redirect("/Admin");
					}
					return Redirect("/Home");
				}

			}
			catch (Exception)
			{

				ModelState.AddModelError("", "Hata Meydana Geldi!");
			}
			return View();
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync();
			return Redirect("/");
		}

	}
}
