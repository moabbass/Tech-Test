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
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task< IActionResult> Index()
        {           
            List<Detail> details = await _context.Detail.ToListAsync();
            List<Product> products = await _context.Product.ToListAsync();
            List<SpecialOffer> specialOffers = await _context.SpecialOffer.ToListAsync();
            var tupelModel = new Tuple<List<Detail>, List<Product>, List<SpecialOffer>>(details, products, specialOffers);
            return View(tupelModel);            
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