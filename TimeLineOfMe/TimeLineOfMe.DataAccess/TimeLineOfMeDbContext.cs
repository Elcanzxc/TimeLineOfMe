using Microsoft.EntityFrameworkCore;
using TimeLineOfMe.DataAccess.Entitites;

namespace TimeLineOfMe.DataAccess;

public class TimeLineOfMeDbContext : DbContext
{

    public TimeLineOfMeDbContext(DbContextOptions<TimeLineOfMeDbContext> options)
        : base(options)
    {

    }

    public DbSet<BookEntity> Books { get;set; }

}
