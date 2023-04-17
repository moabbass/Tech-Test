using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Verto.Data;
using Verto.Models;

namespace Verto.Controllers
{
    public class SpecialOffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpecialOffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SpecialOffers
        public async Task<IActionResult> Index()
        {
            //ViewData["SpecialOffers"] = _context.SpecialOffer != null ? View(await _context.SpecialOffer.ToListAsync()) : Problem("Entity set 'ApplicationDbContext.SpecialOffer'  is null.");

            //return View();
            return _context.SpecialOffer != null ? View(await _context.SpecialOffer.ToListAsync()) :Problem("Entity set 'ApplicationDbContext.SpecialOffer'  is null.");
        }

        // GET: SpecialOffers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.SpecialOffer == null)
            {
                return NotFound();
            }

            var specialOffer = await _context.SpecialOffer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (specialOffer == null)
            {
                return NotFound();
            }

            return View(specialOffer);
        }

        // GET: SpecialOffers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SpecialOffers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,type,offer")] SpecialOffer specialOffer)
        {
            if (ModelState.IsValid)
            {
                specialOffer.ID = Guid.NewGuid();
                _context.Add(specialOffer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialOffer);
        }

        // GET: SpecialOffers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.SpecialOffer == null)
            {
                return NotFound();
            }

            var specialOffer = await _context.SpecialOffer.FindAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }
            return View(specialOffer);
        }

        // POST: SpecialOffers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID,type,offer")] SpecialOffer specialOffer)
        {
            if (id != specialOffer.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialOffer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialOfferExists(specialOffer.ID))
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
            return View(specialOffer);
        }

        // GET: SpecialOffers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.SpecialOffer == null)
            {
                return NotFound();
            }

            var specialOffer = await _context.SpecialOffer
                .FirstOrDefaultAsync(m => m.ID == id);
            if (specialOffer == null)
            {
                return NotFound();
            }

            return View(specialOffer);
        }

        // POST: SpecialOffers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.SpecialOffer == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SpecialOffer'  is null.");
            }
            var specialOffer = await _context.SpecialOffer.FindAsync(id);
            if (specialOffer != null)
            {
                _context.SpecialOffer.Remove(specialOffer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialOfferExists(Guid id)
        {
          return (_context.SpecialOffer?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
