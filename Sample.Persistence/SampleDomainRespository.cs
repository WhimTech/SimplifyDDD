using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.EntityFramework;

namespace Sample.Persistence
{
    public class SampleDomainRespository : DomainRepository, ISampleDomainRepository
    {
        public SampleDomainRespository(SampleDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
