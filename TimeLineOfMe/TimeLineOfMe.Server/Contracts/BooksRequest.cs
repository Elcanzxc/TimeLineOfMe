namespace TimeLineOfMe.Server.Contracts;

public record BooksRequest(
    string Title,
    string Author,
    string? Description,
    string PublishedDate
);
