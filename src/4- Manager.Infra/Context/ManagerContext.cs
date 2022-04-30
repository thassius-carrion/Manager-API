using Manager.Domain.Entities;
using Manager.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Context {

    public class ManagerContext : DbContext {

        public ManagerContext() {}

        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options) {}  

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=tcp:dbserverthass.database.windows.net,1433;Initial Catalog=bellafioridev;Persist Security Info=False;User ID=serverthass;Password=Tlove96!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }


    }
}