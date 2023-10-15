using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class UsersController : Controller
    {
        private readonly IUserService _serviceRepository;
        private readonly IServiceRepository<Roles> _roleServiceRepository;

        public UsersController(IUserService serviceRepository, IServiceRepository<Roles> roleServiceRepository)
        {
            _serviceRepository = serviceRepository;
            _roleServiceRepository = roleServiceRepository;
        }

        // GET: UsersController
        public async Task<ActionResult> Index()
        {
            var model = await _serviceRepository.CustomUserList();
            return View(model);
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsersController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.RolesId = new SelectList(await _roleServiceRepository.GetAllAsync(), "Id", "Name");
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceRepository.AddAsync(user);
                    await _serviceRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                }
            }

            ViewBag.RolesId = new SelectList(await _roleServiceRepository.GetAllAsync(), "Id", "Name");
            return View(user);
        }

        // GET: UsersController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _serviceRepository.FindAsync(id);
            ViewBag.RolesId = new SelectList(await _roleServiceRepository.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _serviceRepository.Update(user);
                    await _serviceRepository.SaveAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                }
            }

            ViewBag.RolesId = new SelectList(await _roleServiceRepository.GetAllAsync(), "Id", "Name");
            return View(user);
        }

        // GET: UsersController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model =await _serviceRepository.FindAsync(id);
            ViewBag.RolesId = new SelectList(await _roleServiceRepository.GetAllAsync(), "Id", "Name");
            return View(model);
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                _serviceRepository.Delete(user);
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
