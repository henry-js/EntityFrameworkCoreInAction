using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookApp.Data;

namespace BookApp.Web.Pages_Books
{
    public class DeleteModel : PageModel
    {
        private readonly BookApp.Data.BookDbContext _context;

        public DeleteModel(BookApp.Data.BookDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);

            if (book != null)
            {
                Book = book;
                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
