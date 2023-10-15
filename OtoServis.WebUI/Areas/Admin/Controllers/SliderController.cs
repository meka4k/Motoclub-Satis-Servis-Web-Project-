using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtoServis.Entities.Models;
using OtoServis.Service.Abstract;
using OtoServis.WebUI.Utils;

namespace OtoServis.WebUI.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Policy = "AdminPolicy")]
    public class SliderController : Controller
    {
        private readonly IServiceRepository<Slider> _serviceRepository;

        public SliderController(IServiceRepository<Slider> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        // GET: SliderController
        public async Task<ActionResult> Index()
        {
            var model = await _serviceRepository.GetAllAsync();
            return View(model);
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Slider slider, IFormFile? image)
        {
            try
            {
                slider.Image = await FileHelper.FileLoaderAsync(image, "/Img/Slider/");
                await _serviceRepository.AddAsync(slider);
                await _serviceRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _serviceRepository.FindAsync(id);
            return View(data);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Slider slider, IFormFile? image)
        {
            try
            {
                if (image is not null)
                    slider.Image = await FileHelper.FileLoaderAsync(image, "/Img/Slider/");
                _serviceRepository.Update(slider);
                await _serviceRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _serviceRepository.FindAsync(id);
            return View(data);
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Slider slider)
        {
            try
            {

                _serviceRepository.Delete(slider);
                await _serviceRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
