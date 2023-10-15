using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _serviceRepository;
        private readonly IServiceRepository<Vehicle> _carServiceRepository;

        public CustomersController(IServiceRepository<Vehicle> carServiceRepository, ICustomerService serviceRepository)
        {
            _carServiceRepository = carServiceRepository;
            _serviceRepository = serviceRepository;
        }

        // GET: CustomersController
        public async Task<ActionResult>Index()
        {
            var model =await _serviceRepository.CustomerCarList();
            return View(model);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomersController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceRepository.AddAsync(customer);
                    await _serviceRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
					ModelState.AddModelError("", "Bir Hata Oluştu");
				}
            }

            ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
            return View(customer);
        }

        // GET: CustomersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
            return View(model);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceRepository.Update(customer);
                    await _serviceRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                }
            }

            ViewBag.VehicleId = new SelectList(await _carServiceRepository.GetAllAsync(), "Id", "BrandName");
            return View(customer);
        }

        // GET: CustomersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                _serviceRepository.Delete(customer);
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
