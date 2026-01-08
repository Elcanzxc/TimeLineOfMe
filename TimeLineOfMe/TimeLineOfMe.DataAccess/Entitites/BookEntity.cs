

namespace TimeLineOfMe.DataAccess.Entitites;

public class BookEntity
{

    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Author { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime PublishedDate { get; set; }


   

}
