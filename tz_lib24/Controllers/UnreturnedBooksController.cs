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
    public class UnreturnedBooksController : Controller
    {
        private readonly libContext _context;

        public UnreturnedBooksController(libContext context)
        {
            _context = context;
        }

        // GET: UnreturnedBooks
        public async Task<IActionResult> Index()
        {
              return _context.UnreturnedBooks != null ? 
                          View(await _context.UnreturnedBooks.ToListAsync()) :
                          Problem("Entity set 'libContext.UnreturnedBooks'  is null.");
        }

        // GET: UnreturnedBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UnreturnedBooks == null)
            {
                return NotFound();
            }

            var unreturnedBooks = await _context.UnreturnedBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (unreturnedBooks == null)
            {
                return NotFound();
            }

            return View(unreturnedBooks);
        }

        // GET: UnreturnedBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnreturnedBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,book_id,user_id")] UnreturnedBooks unreturnedBooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unreturnedBooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unreturnedBooks);
        }

        // GET: UnreturnedBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UnreturnedBooks == null)
            {
                return NotFound();
            }

            var unreturnedBooks = await _context.UnreturnedBooks.FindAsync(id);
            if (unreturnedBooks == null)
            {
                return NotFound();
            }
            return View(unreturnedBooks);
        }

        // POST: UnreturnedBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,book_id,user_id")] UnreturnedBooks unreturnedBooks)
        {
            if (id != unreturnedBooks.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unreturnedBooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnreturnedBooksExists(unreturnedBooks.id))
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
            return View(unreturnedBooks);
        }

        // GET: UnreturnedBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UnreturnedBooks == null)
            {
                return NotFound();
            }

            var unreturnedBooks = await _context.UnreturnedBooks
                .FirstOrDefaultAsync(m => m.id == id);
            if (unreturnedBooks == null)
            {
                return NotFound();
            }

            return View(unreturnedBooks);
        }

        // POST: UnreturnedBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UnreturnedBooks == null)
            {
                return Problem("Entity set 'libContext.UnreturnedBooks'  is null.");
            }
            var unreturnedBooks = await _context.UnreturnedBooks.FindAsync(id);
            if (unreturnedBooks != null)
            {
                _context.UnreturnedBooks.Remove(unreturnedBooks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnreturnedBooksExists(int id)
        {
          return (_context.UnreturnedBooks?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
