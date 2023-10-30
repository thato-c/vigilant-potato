using LicenceService.Data;
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
    }
}
