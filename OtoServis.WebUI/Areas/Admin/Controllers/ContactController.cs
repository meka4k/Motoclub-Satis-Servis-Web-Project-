using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class ContactController : Controller
    {
        private readonly IServiceRepository<Contact> _serviceRepository;

        public ContactController(IServiceRepository<Contact> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }


        public IActionResult Index()
        {
            var model = _serviceRepository.GetAll();
            return View(model);
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            return View(model);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Contact contact)
        {
            try
            {
                _serviceRepository.Delete(contact);
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
