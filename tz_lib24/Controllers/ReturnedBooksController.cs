using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tz_lib24.Models;

namespace tz_lib24.Controllers
{
    public class ReturnedBooksController : Controller
    {
        private readonly libContext _context;

        public ReturnedBooksController(libContext context)
        {
            _context = context;
        }

        // GET: ReturnedBooks
        public async Task<IActionResult> Index()
        {
              return _context.ReturnedBooks != null ? 
                          View(await _context.ReturnedBooks.ToListAsync()) :
                          Problem("Entity set 'libContext.ReturnedBooks'  is null.");
        }

        // GET: ReturnedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ReturnedBooks == null)
            {
                return NotFound();
            }

            var returnedBooks = await _context.ReturnedBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (returnedBooks == null)
            {
                return NotFound();
            }

            return View(returnedBooks);
        }

        // GET: ReturnedBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReturnedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,book_id,user_id,date_issued,due_date")] ReturnedBooks returnedBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(returnedBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(returnedBooks);
        }

        // GET: ReturnedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ReturnedBooks == null)
            {
                return NotFound();
            }

            var returnedBooks = await _context.ReturnedBooks.FindAsync(id);
            if (returnedBooks == null)
            {
                return NotFound();
            }
            return View(returnedBooks);
        }

        // POST: ReturnedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,book_id,user_id,date_issued,due_date")] ReturnedBooks returnedBooks)
        {
            if (id != returnedBooks.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(returnedBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnedBooksExists(returnedBooks.id))
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
            return View(returnedBooks);
        }

        // GET: ReturnedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ReturnedBooks == null)
            {
                return NotFound();
            }

            var returnedBooks = await _context.ReturnedBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (returnedBooks == null)
            {
                return NotFound();
            }

            return View(returnedBooks);
        }

        // POST: ReturnedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ReturnedBooks == null)
            {
                return Problem("Entity set 'libContext.ReturnedBooks'  is null.");
            }
            var returnedBooks = await _context.ReturnedBooks.FindAsync(id);
            if (returnedBooks != null)
            {
                _context.ReturnedBooks.Remove(returnedBooks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnedBooksExists(int id)
        {
          return (_context.ReturnedBooks?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
