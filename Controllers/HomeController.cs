using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Verto.Models;
using Verto.Data;
using Microsoft.EntityFrameworkCore;

namespace Verto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            //ViewData["Details"] = _context.Detail != null ? View(await _context.Detail.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.Detail'  is null.");
            //ViewData["Products"] = _context.Product != null ? View(await _context.Product.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            //ViewData["SpecialOffers"] = _context.SpecialOffer != null ? View(await _context.SpecialOffer.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.SpecialOffer'  is null.");

            ViewBag.Message = "Welcome to my demo!";
            ViewModel mymodel = new ViewModel();
            mymodel.details = (IEnumerable<Detail>)await _context.Detail.ToListAsync();
            mymodel.products = (IEnumerable<Product>)await _context.Product.ToListAsync();
            mymodel.specialOffers =(IEnumerable<SpecialOffer>) await _context.SpecialOffer.ToListAsync();

            return View(mymodel);            
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}