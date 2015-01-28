using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Persistence
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext()
            : base("SampleDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SampleDbContext>());
        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>()
                .HasMany(ent => ent.Members)
                .WithMany(ent => ent.Activities)
                .Map(ent => ent.ToTable("ActivityMembers").MapLeftKey("ActivityId").MapRightKey("MemberId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
