using System.Globalization;
using System.Text;

namespace TimeLineOfMe.Core.Models;

public class Book
{ 
    public const int MAX_TITLE_LENGTH = 250;

    public Guid Id { get; }

    public string Title { get;} = string.Empty;

    public string Author { get; } = string.Empty;

    public string? Description { get; }

    public DateTime PublishedDate { get; }



    private Book(Guid id, string title, string author, string? description, DateTime publishedDate)
    {
        Id = id;
        Title = title;
        Author = author;
        Description = description;
        PublishedDate = publishedDate;
    }


    public static (Book book,string error) Create(Guid id, string title, string author, string? description, string publishedDateStr)
    {

        StringBuilder errorBuilder = new();

        string format = "yyyy-MM-dd HH:mm:ss";

        bool success = DateTime.TryParseExact(
                publishedDateStr,
                format,
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None,
                out DateTime publishedDate);


        if (string.IsNullOrWhiteSpace(title))
            errorBuilder.AppendLine("Title cannot be empty.");

        if (title.Length > MAX_TITLE_LENGTH)
            errorBuilder.AppendLine($"Title cannot exceed {MAX_TITLE_LENGTH} characters.");

        if(string.IsNullOrWhiteSpace(author))
            errorBuilder.AppendLine("Author cannot be empty.");

        if (!success)
            errorBuilder.AppendLine($"Published date must be in the format {format}.");

        else if (publishedDate > DateTime.UtcNow)
            errorBuilder.AppendLine("Published date cannot be in the future.");




        var book = new Book(id, title, author, description, publishedDate);


        return (book, errorBuilder.ToString());

    }


    public static Book Create(Guid id, string title, string author, string? description, DateTime publishedDate) => new Book(id, title, author, description, publishedDate);

}
