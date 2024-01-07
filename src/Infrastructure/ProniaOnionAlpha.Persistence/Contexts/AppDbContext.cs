using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProniaOnionAlpha.Domain;
using ProniaOnionAlpha.Domain.Entities;
using System.Reflection;

namespace ProniaOnionAlpha.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
      
        public DbSet<Position> Positions { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AccountRoles> AccountRoles { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Position>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Author>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.Entity<Tag>().HasQueryFilter(c => c.IsDeleted == false);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entites = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in entites)
            {
                switch (data.State)
                {
                    case EntityState.Modified:
                        data.Entity.ModifiedAt = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CreatedAt = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}