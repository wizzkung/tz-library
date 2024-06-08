using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace tz_lib24.Controllers
{
    public class IssuesController : Controller
    {
        private readonly libContext _libContext;

        public IssuesController(libContext lib)
        {
            _libContext = lib;
        }
        public async Task<IActionResult> Index()
        {
            var issued = await _libContext.Book_issues
               .Include(i => i.book)
               .Include(i => i.user)
               .Where(i => i.book.is_issued == true)
               .ToListAsync();

            if (issued != null && issued.Count > 0)
            {
                return View(issued);
            }
            else
            {
                return View("NotFound");
            }
        }


    }
}
