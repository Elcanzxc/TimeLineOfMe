using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeLineOfMe.Core.Models;
using TimeLineOfMe.DataAccess.Entitites;

namespace TimeLineOfMe.DataAccess.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
{
    public void Configure(EntityTypeBuilder<BookEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(Book.MAX_TITLE_LENGTH);

        builder.Property(x => x.Author)
            .IsRequired();

        builder.Property(x => x.Description);

        builder.Property(x => x.PublishedDate)
            .IsRequired();

        builder.ToTable(x => x.HasCheckConstraint("CK_Book_PublishedDate_NotFuture", "PublishedDate <= GETDATE()"));

    }
}
