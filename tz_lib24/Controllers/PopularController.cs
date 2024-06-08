using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tz_lib24.Controllers
{
    public class PopularController : Controller
    {
        private readonly libContext libContext;
        public PopularController(libContext lib)
        {
            libContext = lib;

        }
        public async Task<IActionResult> Index()
        {
            var popular = await libContext.Book_issues
                .GroupBy(b => b.book_id).Select(g => new { id = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count).FirstOrDefaultAsync();
            if (popular != null)
            {
                var book = await libContext.Books.FindAsync(popular.id);
                return View(book);
            }
            else
            {
                return View("Notfound");            }


        }

    }
}
