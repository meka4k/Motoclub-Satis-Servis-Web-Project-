using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using System.Drawing.Drawing2D;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
	[Area("Admin"),Authorize(Policy ="AdminPolicy")]
	public class BrandsController : Controller
	{
		private readonly IServiceRepository<Brand> _serviceRepository;

		public BrandsController(IServiceRepository<Brand> serviceRepository)
		{
			_serviceRepository = serviceRepository;
		}

		// GET: BrandsController
		public async Task<ActionResult> Index()
		{
			var model = await _serviceRepository.GetAllAsync();
			return View(model);
		}

		// GET: BrandsController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BrandsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BrandsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Brand brand)
		{
			try
			{
				await _serviceRepository.AddAsync(brand);
				await _serviceRepository.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ModelState.AddModelError("", "Bir Hata Oluştu");
			}
			return View(brand);
		}

		// GET: BrandsController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var model = await _serviceRepository.FindAsync(id);
			return View(model);
		}

		// POST: BrandsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Brand brand)
		{
			try
			{
				_serviceRepository.Update(brand);
				await _serviceRepository.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ModelState.AddModelError("", "Bir Hata Oluştu");
			}
			return View(brand);
		}

		// GET: BrandsController/Delete/5
		public async Task<ActionResult> Delete(int id)

		{
			var model = await _serviceRepository.FindAsync(id);
			return View(model);
		}

		// POST: BrandsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, Brand brand)
		{
			try
			{
				_serviceRepository.Delete(brand);
				await _serviceRepository.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ModelState.AddModelError("", "Bir Hata Oluştu");
			}
			return View(brand);
		}
	}
}
