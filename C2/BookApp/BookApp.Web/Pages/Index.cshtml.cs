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
        var book = new Book()
        {
            Description = "A new book: The Sequel",
            ImageUrl = "https://www.google.com",
            Price = 35.55M,
            PublishedOn = DateTime.UtcNow,
            Publisher = "Penguin Books",
            Title = "The Book 2",
        };
        var tags = _dbContext.Tags.Where(x => x.TagId == "Epic").FirstOrDefault();
        var bookTags = tags?.Books.ToList();
        _dbContext.SaveChanges();
    }
}
