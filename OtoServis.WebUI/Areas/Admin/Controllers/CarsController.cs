using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using OtoServis.WebUI.Utils;
using System.Drawing.Drawing2D;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
	[Area("Admin"), Authorize(Policy = "AdminPolicy")]
	public class CarsController : Controller
	{
		private readonly ICarService _serviceRepository;
		private readonly IServiceRepository<Brand> _brandRepository;

		public CarsController(IServiceRepository<Brand> brandRepository, ICarService serviceRepository)
		{
			_brandRepository = brandRepository;
			_serviceRepository = serviceRepository;
		}

		// GET: CarsController
		public async Task<ActionResult> Index()
		{
			var model = await _serviceRepository.CustomCarList();
			return View(model);
		}

		// GET: CarsController/Details/5
		public ActionResult Details(int id)
		{

			return View();
		}

		// GET: CarsController/Create
		public async Task<ActionResult> Create()
		{
			ViewBag.BrandId = new SelectList(await _brandRepository.GetAllAsync(), "Id", "Name");
			return View();
		}

		// POST: CarsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Vehicle cars, IFormFile? image1, IFormFile? image2, IFormFile? image3)
		{
			if (ModelState.IsValid)
			{
				try
				{
					cars.Image1 = await FileHelper.FileLoaderAsync(image1, "/img/Cars/");
					cars.Image2 = await FileHelper.FileLoaderAsync(image2, "/img/Cars/");
					cars.Image3 = await FileHelper.FileLoaderAsync(image3, "/img/Cars/");
					await _serviceRepository.AddAsync(cars);
					await _serviceRepository.SaveAsync();
					return RedirectToAction(nameof(Index));
				}
				catch
				{
					ModelState.AddModelError("", "Bir Hata Oluştu");
				}
			}
			ViewBag.BrandId = new SelectList(await _brandRepository.GetAllAsync(), "Id", "Name");
			return View(cars);

		}

		// GET: CarsController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			ViewBag.BrandId = new SelectList(await _brandRepository.GetAllAsync(), "Id", "Name");
			var model = await _serviceRepository.FindAsync(id);
			return View(model);
		}

		// POST: CarsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Vehicle cars, IFormFile? image1, IFormFile? image2, IFormFile? image3)
		{
			if (ModelState.IsValid)
			{
				try
				{
					if (image1 is not null)
						cars.Image1 = await FileHelper.FileLoaderAsync(image1, "/img/Cars/");

					if (image2 is not null)
						cars.Image2 = await FileHelper.FileLoaderAsync(image2, "/img/Cars/");

					if (image3 is not null)
						cars.Image3 = await FileHelper.FileLoaderAsync(image3, "/img/Cars/");


					_serviceRepository.Update(cars);
					await _serviceRepository.SaveAsync();
					return RedirectToAction(nameof(Index));
				}
				catch
				{
					ModelState.AddModelError("", "Bir Hata Oluştu");
				}
			}
			ViewBag.BrandId = new SelectList(await _brandRepository.GetAllAsync(), "Id", "Name");
			return View(cars);
		}

		// GET: CarsController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var model = await _serviceRepository.FindAsync(id);
			return View(model);
		}

		// POST: CarsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, Vehicle cars)
		{
			try
			{
				_serviceRepository.Delete(cars);
				await _serviceRepository.SaveAsync();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				ModelState.AddModelError("", "Bir Hata Oluştu");
			}
			return View(cars);
		}
	}
}
