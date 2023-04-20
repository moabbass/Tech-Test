using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Verto.Data;
using Verto.Models;
using Microsoft.AspNetCore.Http;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Verto.Controllers
{
    public class DetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment webHostEnvironment;
        

        public DetailsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Details
        public async Task<IActionResult> Index()
        {
              return _context.Detail != null ? 
                          View(await _context.Detail.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Detail'  is null.");
        }

        // GET: Details/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        // GET: Details/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,content,buttonName,pictureName")] Detail detail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        // GET: Details/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail.FindAsync(id);
            if (detail == null)
            {
                return NotFound();
            }
            return View(detail);
        }

        // POST: Details/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,content,buttonName,pictureName")] Detail detail)
        {
            if (id != detail.Id)
            {
                return NotFound();
            }
            detail =uploadImage(detail);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailExists(detail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(detail);
        }

        // GET: Details/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Detail == null)
            {
                return NotFound();
            }

            var detail = await _context.Detail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        public async Task<IActionResult> Redirecting(Detail detail)
        {
            if(detail == null)
            {
                return View();
            }
            return RedirectToAction(detail.Id.ToString(),"UpdateDetailPicture");
        }


        // POST: Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Detail == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Detail'  is null.");
            }
            var detail = await _context.Detail.FindAsync(id);
            if (detail != null)
            {
                _context.Detail.Remove(detail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailExists(int id)
        {
          return (_context.Detail?.Any(e => e.Id == id)).GetValueOrDefault();
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

        public ActionResult DetailPictureUpload(Detail detail)
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
                _context.Update(detail);
                 _context.SaveChanges();
                return RedirectToAction("Home");
            }
            
            return View();
        }
        


        private void uploadImage2()
        {
            //string strFolder = Server.MapPath("./");
            //string strFileName = this.test.PostedFile.FileName;
            //strFileName = Path.GetFileName(strFileName);
            //if (test.Value != "")
            //{
            //    // Create the folder if it does not exist.
            //    if (!Directory.Exists(strFolder))
            //    {
            //        Directory.CreateDirectory(strFolder);
            //    }
            //    // Save the uploaded file to the server.
            //    strFilePath = strFolder + strFileName;
            //    if (File.Exists(strFilePath))
            //    {
            //        lblUploadResult.Text = strFileName + " already exists on the server!";
            //    }
            //    else
            //    {
            //        oFile.PostedFile.SaveAs(strFilePath);
            //        lblUploadResult.Text = strFileName + " has been successfully uploaded.";
            //    }
            //}
            //else
            //{
            //    lblUploadResult.Text = "Click 'Browse' to select the file to upload.";
            //}
            //// Display the result of the upload.
            //frmConfirmation.Visible = true;
        }
    }
}
