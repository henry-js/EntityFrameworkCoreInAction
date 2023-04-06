using System.Collections;

namespace BookApp.Data;
public class Book
{
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    // ------------------------------------------------------
    // relationships
    public PriceOffer Promotion { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<BookAuthor> AuthorsLink { get; set; }
}

public class PriceOffer
{
    public int PriceOfferId { get; set; }
    public decimal NewPrice { get; set; }
    public string PromotionalText { get; set; }
    public int BookId { get; set; }
}

public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public byte Order { get; set; }

    // relationships
    public Book Book { get; set; }
    public Author Author { get; set; }
}

public class Author
{
    public int AuthorId { get; set; }
    public string name { get; set; }
    public ICollection<BookAuthor> BooksLink { get; set; }
}

public class Tag
{

    public string TagId { get; set; }

    // relationships
    public ICollection<Book> Books { get; set; }
}

public class Review
{
    public int ReviewId { get; set; }
    public string VoterName { get; set; }
    public int NumStars { get; set; }
    public string Comment { get; set; }

    // relationships
    public int BookId { get; set; }
}
