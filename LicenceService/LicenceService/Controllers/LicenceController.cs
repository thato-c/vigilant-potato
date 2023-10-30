using LicenceService.Data;
using LicenceService.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LicenceService.Controllers
{
    public class LicenceController : Controller
    {
        private readonly LicenceContext _context;

        public LicenceController(LicenceContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Retrieve a list of licences from the database
            var licences = await _context.Licences.ToListAsync();

            if (licences.Count == 0)
            {
                ViewBag.Message = "No Licences Registered";
                return View();
            }

            return View(licences);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LicenceViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the ViewModel to Licence entity
                var Licence = new Models.Licence
                {
                    Name = model.Name,
                    Description = model.Description,
                    Cost = model.Cost,
                    ValidityMonths = model.ValidityMonths
                };

                // Add and save the new licence to the database
                _context.Licences.Add(Licence);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
