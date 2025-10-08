using CMS.Domain.Entity.Comments;
using CMS.Domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace CMS.Presistence.EF;

public class CMSDbContext:DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }

    public CMSDbContext(DbContextOptions<CMSDbContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CMSDbContext).Assembly);

        modelBuilder.Entity<User>().Property(p => p.Id).ValueGeneratedNever();
        modelBuilder.Entity<Comment>(builder =>
        {
            builder.OwnsOne(c => c.content);
        });

        //SEQUENCE
        modelBuilder.HasSequence<long>("SQ_Hilo_User").StartsAt(1).IncrementsBy(1);
        modelBuilder.HasSequence<long>("SQ_Hilo_Comment").StartsAt(1).IncrementsBy(1);
        //modelBuilder.HasSequence<long>("SQ_Hilo_Comment").StartsAt(1).IncrementsBy(1);


        modelBuilder.Entity<User>().HasQueryFilter(c => !c.IsDeleted);
        modelBuilder.Entity<Comment>().HasQueryFilter(c => !c.IsDeleted);
        //modelBuilder.Entity<Station>().HasQueryFilter(c => !c.IsDeleted);
        //modelBuilder.Entity<WeatherReport>().HasQueryFilter(c => !c.IsDeleted);

    }
}
