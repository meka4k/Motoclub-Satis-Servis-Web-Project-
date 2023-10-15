using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class RolesController : Controller
    {
        private readonly IServiceRepository<Roles> _serviceRepository;

        public RolesController(IServiceRepository<Roles> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: RolesController
        public async Task<ActionResult> Index()
        {
            var model = await _serviceRepository.GetAllAsync();
            return View(model);
        }


        // GET: RolesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RolesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Roles roles)
        {
            try
            {
                _serviceRepository.Add(roles);
                _serviceRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        // POST: RolesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Roles roles)
        {
            try
            {
                _serviceRepository.Update(roles);
                _serviceRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RolesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        // POST: RolesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Roles roles)
        {
            try
            {
                _serviceRepository.Delete(roles);
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
