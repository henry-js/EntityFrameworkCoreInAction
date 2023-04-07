using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Web.Pages_Books
{
    public class IndexModel : PageModel
    {
        private readonly BookApp.Data.BookDbContext _context;

        public IndexModel(BookApp.Data.BookDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Books != null)
            {
                Book = await _context.Books.Include(t => t.Tags).ToListAsync();
            }
        }
    }
}
