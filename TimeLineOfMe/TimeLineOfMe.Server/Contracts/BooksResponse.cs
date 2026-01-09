namespace TimeLineOfMe.Server.Contracts;

public record BooksResponse(
    Guid Id,
    string Title,
    string Author,
    string? Description,
    DateTime PublishedDate
);
