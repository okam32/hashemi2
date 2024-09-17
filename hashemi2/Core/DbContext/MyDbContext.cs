using hashemi2.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace hashemi2.Core.DbContext
{
    public class MyDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<UserShift> UserShifts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }
    }
}
