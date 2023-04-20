using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Verto.Models;
using Verto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;


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


/*
        private readonly IWebHostEnvironment webHostEnvironment;

        public DetailsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
            webHostEnvironment = hostEnvironment;
        }

        private Detail uploadImage(Detail detail)
        {
            string uniqueFileName = null;

            if (detail.picture != null)
            {
                string imageUploadedFolder = Path.Combine(webHostEnvironment.WebRootPath, "UploadedImages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + detail.picture.FileName;
                string filePath = Path.Combine(imageUploadedFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    detail.picture.CopyTo(fileStream);
                }

                detail.pictureName = uniqueFileName;
            }
            return detail;
        }

*/
    }
}