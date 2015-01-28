using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplifyDDD.Repository;
using SimplifyDDD.Service;

namespace Sample
{
    public class MemberService : BaseDomainService
    {
        public override IDomainRepository DomainRepository
        {
            get
            {
                return UnitOfWork.GetDomainRepository<ISampleDomainRepository>();
            }
        }

        public Member GetMember(string memberId)
        {
            return DomainRepository.GetByKey<Member>(memberId);
        }

        public void AddMember(Member member)
        {
            DomainRepository.Add(member);
            UnitOfWork.Commit();
        }
    }
}
