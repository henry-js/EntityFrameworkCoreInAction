using BookApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookApp.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly BookDbContext _dbContext;

    public IndexModel(ILogger<IndexModel> logger, BookDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }


    public void OnGet()
    {
        // var book = new Book()
        // {
        //     Description = "A new book: The Sequel",
        //     ImageUrl = "https://www.google.com",
        //     Price = 35.55M,
        //     PublishedOn = DateTime.UtcNow,
        //     Publisher = "Penguin Books",
        //     Title = "The Book 2",
        // };
        // var bookTags = new List<Tag>{
        //     new Tag { TagId = "Epic" },
        //     new Tag { TagId = "Fantasy" },
        //     new Tag { TagId = "Historical"},
        //     new Tag { TagId = "Autobiography"},
        //     new Tag { TagId = "Biography"},
        //     new Tag { TagId = "Young Adult"},
        //     new Tag { TagId = "Children"},
        //     };

        // if (_dbContext.Tags.FirstOrDefault() is null)
        // {
        //     _dbContext.Tags.AddRange(bookTags);
        //     _dbContext.SaveChanges();
        // }
        // var tags = _dbContext.Tags.ToList();
        // book.Tags = new List<Tag> { tags[2], tags[1] };
        // _dbContext.Books.Add(book);
        // _dbContext.SaveChanges();
    }
}
