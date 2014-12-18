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
    }
}
