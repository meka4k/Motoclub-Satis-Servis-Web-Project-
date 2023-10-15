using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
	[Area("Admin"), Authorize(Policy = "AdminPolicy")]
	public class SalesController : Controller
	{
		private readonly ISalesService _serviceRepository;
		private readonly ICarService _carServiceRepository;
		private readonly ICustomerService _customerServiceRepository;

		public SalesController(ISalesService serviceRepository, ICustomerService customerServiceRepository, ICarService carServiceRepository)
		{
			_serviceRepository = serviceRepository;
			_customerServiceRepository = customerServiceRepository;
			_carServiceRepository = carServiceRepository;
		}

		// GET: SalesController
		public async Task<ActionResult> Index()
		{
			var model = await _serviceRepository.CustomUserList();
			return View(model);
		}

		// GET: SalesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SalesController/Create
		public async Task<ActionResult> Create()
		{
			ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
			ViewBag.CustomerId = new SelectList(await _customerServiceRepository.GetAllAsync(), "Id", "Name");
			return View();
		}

		// POST: SalesController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Sales sales)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await _serviceRepository.AddAsync(sales);
					await _serviceRepository.SaveAsync();
					return RedirectToAction(nameof(Index));
				}
				catch
				{

				}
			}

			ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
			ViewBag.CustomerId = new SelectList(await _customerServiceRepository.GetAllAsync(), "Id", "Name");
			return View(sales);
		}

		// GET: SalesController/Edit/5
		public async Task<ActionResult> Edit(int id)
		{
			var model = await _serviceRepository.FindAsync(id);
			ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
			ViewBag.CustomerId = new SelectList(await _customerServiceRepository.GetAllAsync(), "Id", "Name");
			return View(model);
		}

		// POST: SalesController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit(int id, Sales sales)
		{
			if (ModelState.IsValid)
			{
				try
				{
					_serviceRepository.Update(sales);
					await _serviceRepository.SaveAsync();
					return RedirectToAction(nameof(Index));
				}
				catch
				{

				}
			}

			ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
			ViewBag.CustomerId = new SelectList(await _customerServiceRepository.GetAllAsync(), "Id", "Name");
			return View(sales);
		}

		// GET: SalesController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var model = await _serviceRepository.FindAsync(id);
			return View(model);
		}

		// POST: SalesController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Sales sales)
		{
			try
			{
				_serviceRepository.Delete(sales);
				_serviceRepository.Save();
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
