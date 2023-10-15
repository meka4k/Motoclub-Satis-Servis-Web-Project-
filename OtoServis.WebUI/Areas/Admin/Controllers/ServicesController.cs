using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ServicesController : Controller
    {
        private readonly IServiceRepository<OtoServis.Entities.Models.Service> _serviceRepository;

        public ServicesController(IServiceRepository<Entities.Models.Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: ServicesController
        public ActionResult Index()
        {
            var model = _serviceRepository.GetAll();
            return View(model);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OtoServis.Entities.Models.Service service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceRepository.AddAsync(service);
                    await _serviceRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir Hata Oluştu");
                }
            }
            return View(service);
        }

        // GET: ServicesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, OtoServis.Entities.Models.Service service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceRepository.Update(service);
                    await _serviceRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ModelState.AddModelError("", "Bir Hata Oluştu");
                }
            }
            return View(service);
        }

        // GET: ServicesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        // POST: ServicesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, OtoServis.Entities.Models.Service service)
        {
            try
            {
                _serviceRepository.Delete(service);
                await _serviceRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Bir Hata Oluştu");
            }
            return View(service);
        }
    }
}
